using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Modulo;

public class ModuloEstoqueBLL : ModuloBaseBLL, IModuloEstoqueBLL, IModuloBaseBLL
{
	public void GerarItensLocaisEstoquePedido(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoLocalBLL itemPedidoLocalBLL = new ItemPedidoLocalBLL();
		TipoPedidoLocalMO localMesmaEmpresa = itemPedidoLocalBLL.GerarItensLocais(pedidoVenda);
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		estoqueBLL.ValidarEnderecoWMS(localMesmaEmpresa);
	}

	public void TratarUnidadeProduto(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		UnidadeProdutoBLL unidadeProdutoBLL = new UnidadeProdutoBLL();
		unidadeProdutoBLL.UtilizaVendaMenorUnidade(itemPedido, pedidoVenda);
		unidadeProdutoBLL.CarregarMaiorUnidadeVendaItem(itemPedido);
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.TratarItemPromocionalSemEstoque(itemPedido, pedidoVenda);
	}

	public void TratarMaiorUnidadeVariavelProduto(PedidoVendaMO pedidoVenda)
	{
		UnidadeProdutoBLL unidadeProdutoBLL = new UnidadeProdutoBLL();
		unidadeProdutoBLL.CarregarMaiorUnidadeVariavelProdutoItensPedido(pedidoVenda);
	}

	public void ValidarUnidade(PedidoVendaMO pedidoVenda)
	{
		UnidadeProdutoBLL unidadeProdutoBLL = new UnidadeProdutoBLL();
		unidadeProdutoBLL.ValidarUnidadeItensPedido(pedidoVenda);
	}

	public void ValidarPapelCortado(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.ValidarPapelCortado(pedidoVenda);
	}

	public void TratarQuantidadeItemPedido(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			itemPedidoBLL.TratarQuantidadeItemPedido(iTEN);
		}
	}

	public void ValidarQuantidadeItensPedido(PedidoVendaMO pedidoVenda)
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			estoqueBLL.ValidarQuantidade(iTEN, pedidoVenda);
			estoqueBLL.ValidarQuantidadeMultipla(iTEN, pedidoVenda);
		}
	}

	public void ValidarQuantidadeLoteAutomatico(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			if (iTEN.DT_INI_VALIDADE_LOTE.HasValue)
			{
				estoqueBLL.ValidarQuantidadeLoteAutomatico(iTEN, pedidoEletronico);
			}
		}
	}

	public void GerarItPedvLogReservarLote(PedidoVendaMO pedidoVenda, bool VsControl746221)
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			estoqueBLL.GerarItPedvLogReservarLote(pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO, iTEN, pedidoVenda.TIPO_PEDIDO.ESCOLHA_LOTE_AUTOMATICO && VsControl746221);
		}
	}

	public void EfetivarReservaEstoque(PedidoVendaMO pedidoVenda)
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		string nOME_TABELA_TEMPORARIA = SessaoErpManager.CURRENT.SESSAO_DB_TEMP.NOME_TABELA_TEMPORARIA;
		estoqueBLL.AtualizarReservaEstoque(nOME_TABELA_TEMPORARIA, pedidoVenda.TIPO_PEDIDO.LOTE_MANUAL);
		estoqueBLL.EncerrarReservaEstoque(nOME_TABELA_TEMPORARIA);
	}

	public void RegistrarReservaEstoque(PedidoVendaMO pedidoVenda)
	{
		if (!ConfigHelper.getBoolAppConfig("ReservarEstoqueComCorte"))
		{
			EstoqueBLL estoqueBLL = new EstoqueBLL();
			string nOME_TABELA_TEMPORARIA = SessaoErpManager.CURRENT.SESSAO_DB_TEMP.NOME_TABELA_TEMPORARIA;
			estoqueBLL.ReservaEstoque(pedidoVenda, nOME_TABELA_TEMPORARIA);
		}
	}

	public void CarregarFaltasProdutos(PedidoVendaMO pedidoVenda)
	{
		TipoPedidoBLL tipoPedidoBLL = new TipoPedidoBLL();
		if (tipoPedidoBLL.VerificarTipoPedidoRegistraFaltaProdutos(pedidoVenda.TIPO_PEDIDO))
		{
			FaltaProdutoBLL faltaProdutoBLL = new FaltaProdutoBLL();
			pedidoVenda.FALTAS_PRODUTOS = faltaProdutoBLL.ObterFaltasPedidoEletronico(pedidoVenda);
		}
	}

	public void RegistrarFaltasEstoque(PedidoVendaMO pedidoVenda, List<ItemPedidoMO> itens)
	{
		FaltaProdutoBLL faltaProdutoBLL = new FaltaProdutoBLL();
		foreach (ItemPedidoMO iten in itens)
		{
			iten.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
			iten.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
			faltaProdutoBLL.RegistraFaltaEstoque(pedidoVenda, iten, LoginERP.USUARIO_LOGADO);
		}
	}

	public void AtualizarHorarioReservaEstoque()
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		string nOME_TABELA_TEMPORARIA = SessaoErpManager.CURRENT.SESSAO_DB_TEMP.NOME_TABELA_TEMPORARIA;
		estoqueBLL.AtualizarHorarioReservaEstoque(nOME_TABELA_TEMPORARIA);
	}
}
