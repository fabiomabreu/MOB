using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Modulo;

public class ModuloPrecoBLL : ModuloBaseBLL, IModuloPrecoBLL, IModuloBaseBLL
{
	public void CalcularTotaisPedido(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.CalcularTotaisPedidoVenda(pedidoVenda, pedidoEletronico);
	}

	public void CarregarDescontoCondicaoPagamento(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		PrecoBLL precoBLL = new PrecoBLL();
		PrecoMO preco = precoBLL.ObterPrecoItemPedido(pedidoVenda, itemPedido);
		precoBLL.CalcularPrecoItemPedidoPelaCondPagto(preco, itemPedido, pedidoVenda.TIPO_PEDIDO.UTILIZA_PRECO_CUSTO);
	}

	public void CarregarDescontoCampanha(ItemPedidoMO itemPedido, PedidoEletronicoMO pedidoEletronico, PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PAR_CFG.UTILIZA_CAMPANHA || (ConfigERP.PAR_CFG.UTILIZA_CAMPANHA && ConfigERP.PAR_CFG.CAMPANHA_UTILIZA_FILA_APUR))
		{
			return;
		}
		CampanhaBLL campanhaBLL = new CampanhaBLL();
		if (pedidoVenda.CAMPANHAID.HasValue && pedidoVenda.CAMPANHAID > 0)
		{
			DescontoCampanhaVO descontoCampanhaVO = campanhaBLL.VerificarDescontoCampanhaItem(itemPedido, pedidoEletronico);
			if (descontoCampanhaVO != null)
			{
				itemPedido.PERCDESCCAMPANHA = descontoCampanhaVO.PERC_DESC_CAMPANHA;
				itemPedido.PERC_DESC_CAMPANHA_COMBO = descontoCampanhaVO.PERC_DESC_CAMPANHA_COMBO;
				itemPedido.CAMPANHA_CALCULAR_VERBA_FABRICANTE = descontoCampanhaVO.CALCULAR_VERBA_FABRICANTE;
				itemPedido.CAMPANHA_CONSIDERA_PRODUTOS_PROMOCAO = descontoCampanhaVO.CONSIDERA_PRODUTOS_PROMOCAO;
				itemPedido.CAMPANHA_CONSIDERA_PRODUTOS_BONIFICADOS = descontoCampanhaVO.CONSIDERA_PRODUTOS_BONIFICADOS;
				itemPedido.CAMPANHA_VERBA_FABR_DEBITA_PIS_COFINS = descontoCampanhaVO.VERBA_FABR_DEBITA_PIS_COFINS;
			}
		}
	}

	public void CarregarDescontoPorQuantidade(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		DescontoProdutoBLL descontoProdutoBLL = new DescontoProdutoBLL();
		if (descontoProdutoBLL.VerificaUtilizaDescontoPorQuantidade(itemPedido))
		{
			DescontoProdutoMO descontoProdutoMO = descontoProdutoBLL.ObterDescontoPorQuantidade(pedidoVenda.CODIGO_TABELA, itemPedido);
			if (descontoProdutoMO != null)
			{
				itemPedido.DESCONTO_POR_QUANTIDADE = descontoProdutoMO.DESCONTO;
			}
			else
			{
				itemPedido.DESCONTO_POR_QUANTIDADE = null;
			}
		}
	}

	public void CalcularDescontoPermitido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		if (!ConfigERP.PAR_CFG.UTILIZA_GRADE_DESC)
		{
			DescontoProdutoBLL descontoProdutoBLL = new DescontoProdutoBLL();
			itemPedido.DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE = descontoProdutoBLL.CalcularDescontoPermitidoItemPedido(itemPedido);
		}
	}

	public void CalcularPrecoVenda(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		bool flag = ConfigERP.PARAMETROS_TELA.VENDA.MANTER_DESCONTO_APLICADO_1_E_2_NOS_PEDIDOS_ELETRONICOS;
		if (itemPedido.CONSIDERA_PRECO_PROMOCAO)
		{
			flag = false;
		}
		if (pedidoVenda.TIPO_PEDIDO.INVENTARIO)
		{
			itemPedido.PRECO_BASICO = itemPedido.PRECO_UNITARIO;
			itemPedido.PRECO_NOTA_FISCAL = itemPedido.PRECO_UNITARIO;
		}
		else if (!flag && !pedidoVenda.TIPO_PEDIDO.UTILIZA_PRECO_CUSTO)
		{
			PromocaoBLL promocaoBLL = new PromocaoBLL();
			promocaoBLL.TratarPrecoItemPedidoPeloCondicaoPagamento(itemPedido, pedidoVenda.CODIGO_TABELA, pedidoVenda.SEQ_PROMOCAO.Value, pedidoVenda.CLIENTE.PRECO_VENDA_4_DEC, pedidoVenda.CODIGO_CLIENTE);
		}
		PrecoBLL precoBLL = new PrecoBLL();
		precoBLL.CalcularPrecoItemPedido(itemPedido, pedidoVenda);
	}

	public void CalcularTotalItemPedido(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		bool flag = ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC && (!ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE || (ConfigERP.PAR_CFG.PRECO_VENDA_4_DEC_CLIENTE && pedidoVenda.CLIENTE.PRECO_VENDA_4_DEC));
		itemPedidoBLL.CalcularValorComDesconto(itemPedido, pedidoVenda.TIPO_PEDIDO);
		if (flag)
		{
			itemPedido.PRECO_TABELA = itemPedido.PRECO_NOTA_FISCAL.ToDecimal();
		}
		else
		{
			itemPedido.PRECO_TABELA = Math.Round(itemPedido.PRECO_NOTA_FISCAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		}
		itemPedidoBLL.CalcularValorComImpostos(itemPedido, pedidoVenda.TIPO_PEDIDO);
	}

	public void RatearDescontoGeral(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		decimal num = pedidoVenda.ITENS.Sum(delegate(ItemPedidoMO x)
		{
			x.VALOR_DESCONTO_GERAL = Math.Round(x.VALOR_DESCONTO_GERAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			return x.VALOR_DESCONTO_GERAL.ToDecimal();
		});
		decimal num2 = Math.Round(pedidoVenda.VALOR_DESCONTO_GERAL.ToDecimal(), 2, MidpointRounding.AwayFromZero);
		if (num == 0m)
		{
			num2 = default(decimal);
		}
		decimal num3 = num2 - num;
		if (!(num == num2))
		{
			List<ItemPedidoMO> itensPedidoRateio = itemPedidoBLL.ObterItensNaoBonificados(pedidoVenda);
			itemPedidoBLL.RatearDiferencaValorDescontoNoItens(itensPedidoRateio, num2, num);
		}
	}

	public void CalcularCustoVenda(PedidoVendaMO pedidoVenda)
	{
		PrecoBLL precoBLL = new PrecoBLL();
		precoBLL.CalcularCustoVenda(pedidoVenda);
	}

	public void ValidarDescontoGeral(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.ValidarDescontoGeral(pedidoVenda);
	}

	public void ValidarDescontoMaximoPermitidoItens(PedidoVendaMO pedidoVenda)
	{
	}

	public void ValidarLimiteDescontoItens(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			itemPedidoBLL.ValidarLimiteDescontoItemPedido(iTEN);
		}
	}

	public void ValidarDesconto(PedidoVendaMO pedidoVenda)
	{
		if (ConfigERP.PAR_CFG.UTILIZA_GRADE_DESC)
		{
			throw new MyException("Grade de desconto não suportada pela interface");
		}
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			itemPedidoBLL.ValidarDescontoItemPedido(iTEN, pedidoVenda);
		}
	}

	public void ValidarPreco(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			if (!itemPedidoBLL.ValidarValorZeroItemPedido(iTEN))
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendFormat("{0} - {1}", iTEN.CODIGO_PRODUTO, iTEN.DESCRICAO);
			}
		}
		if (stringBuilder.Length > 0)
		{
			string menssage = $"Os produtos a seguir estão sem preço de venda e não são produtos bonificados: {stringBuilder.ToString()}";
			throw new MyException(menssage);
		}
	}

	public void ValidarKitPromocao(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO itemPedido in pedidoVenda.ITENS)
		{
			bool flag = pedidoVenda.PROMOCAO.KIT_PROMOCAO_PAGAMENTO.Exists((KitPromocaoPagamentoMO x) => x.SEQ_KIT == itemPedido.SEQ_KIT_PROMOCAO);
			if (itemPedido.SEQ_KIT_PROMOCAO > 0 && !flag)
			{
				string mensagem = $"Promoção do Produto: {itemPedido.CODIGO_PRODUTO}, não está associada a Condição de Pagamento.";
				MyException ex = new MyException(base.RetornaMensagemAviso);
				ex.AddAviso(mensagem);
				ex.ThrowException();
			}
		}
	}

	public void TratarItensBonificados(PedidoVendaMO pedidoVenda)
	{
		PrecoBLL precoBLL = new PrecoBLL();
		if (pedidoVenda.TIPO_PEDIDO.UTILIZA_PRECO_CUSTO)
		{
			precoBLL.CalcularValorVendaTpPedBonificado(pedidoVenda);
		}
		precoBLL.CalcularValorVendaItemBonificado(pedidoVenda);
		precoBLL.ObterValorVendaItemBonificadoPeloItemNaoBonificado(pedidoVenda);
	}

	public void TratarArredondamentoPrecoBasico(PedidoVendaMO pedidoVenda)
	{
		PrecoBLL precoBLL = new PrecoBLL();
		precoBLL.TratarArredondamentoPreco(pedidoVenda);
	}

	public void CalcularJurosRateioCartaoCredito(PedidoVendaMO pedidoVenda)
	{
		PrecoBLL precoBLL = new PrecoBLL();
		precoBLL.CalcularJurosRateioCartaoCredito(pedidoVenda);
	}
}
