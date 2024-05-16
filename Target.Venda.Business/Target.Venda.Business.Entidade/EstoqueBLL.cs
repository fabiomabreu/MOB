using System.Linq;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class EstoqueBLL : EntidadeBaseBLL<EstoqueMO>
{
	protected override EntidadeBaseDAL<EstoqueMO> GetInstanceDAL()
	{
		return new EstoqueDAL();
	}

	public decimal ObterQuantidadeDisponivel(EstoqueMO exemploEstoque)
	{
		return (BaseDAL as EstoqueDAL).ObterQuantidadeDisponivel(exemploEstoque);
	}

	public decimal ObterQuantidadeDisponivelReservada(EstoqueMO exemploEstoque, string nomeTabelaTemporaria)
	{
		return (BaseDAL as EstoqueDAL).ObterQuantidadeDisponivelReservada(exemploEstoque, nomeTabelaTemporaria);
	}

	public void RemoverReservaEstoque(PedidoVendaMO pedidoVenda)
	{
		string nOME_TABELA_TEMPORARIA = SessaoErpManager.CURRENT.SESSAO_DB_TEMP.NOME_TABELA_TEMPORARIA;
		(BaseDAL as EstoqueDAL).RemoverReservaEstoque(nOME_TABELA_TEMPORARIA);
	}

	public void ForcarLockEstoque(string nomeTabelaTemporaria)
	{
		(BaseDAL as EstoqueDAL).ForcarLockEstoque(nomeTabelaTemporaria);
	}

	public void AtualizarReservaEstoque(string nomeTabelaTemporaria, bool loteManual)
	{
		EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
		estoqueDAL.AtualizarReservaEstoque(nomeTabelaTemporaria);
	}

	public void EncerrarReservaEstoque(string nomeTabelaTemporaria)
	{
		EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
		estoqueDAL.DroparTabelaTemporaria(nomeTabelaTemporaria);
		estoqueDAL.ExcluirQtdePendentes(nomeTabelaTemporaria);
	}

	public void ReservaEstoque(PedidoVendaMO pedidoVenda, string nomeTabelaTemporaria)
	{
		EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			foreach (ItemPedidoLocalMO iTENS_LOCAI in iTEN.ITENS_LOCAIS)
			{
				if (iTENS_LOCAI.CODIGO_EMPRESA_LOCAL_ESTOQUE > 0)
				{
					iTENS_LOCAI.CODIGO_EMPRESA = iTENS_LOCAI.CODIGO_EMPRESA_LOCAL_ESTOQUE;
				}
				else
				{
					iTENS_LOCAI.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
				}
				estoqueDAL.RegistraReservaEstoque(pedidoVenda, iTEN, iTENS_LOCAI, nomeTabelaTemporaria, LoginERP.PROGRAMA_ORIGEM, pedidoVenda.TIPO_PEDIDO);
			}
		}
	}

	public void ValidarQuantidadeMultipla(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		string text = null;
		decimal? qUANTIDADE_MULTIPLA = itemPedido.QUANTIDADE_MULTIPLA;
		decimal num = 1;
		if (!((qUANTIDADE_MULTIPLA.GetValueOrDefault() > num) & qUANTIDADE_MULTIPLA.HasValue))
		{
			return;
		}
		if (!pAR_CFG.UNID_PEDIDA)
		{
			decimal qUANTIDADE = itemPedido.QUANTIDADE;
			decimal? qUANTIDADE_MULTIPLA2 = itemPedido.QUANTIDADE_MULTIPLA;
			qUANTIDADE_MULTIPLA = (decimal?)qUANTIDADE % qUANTIDADE_MULTIPLA2;
			if ((qUANTIDADE_MULTIPLA.GetValueOrDefault() == default(decimal)) & qUANTIDADE_MULTIPLA.HasValue)
			{
				return;
			}
			text = string.Format("O produto {0}-{1} só pode ser vendido de {2} em {2} unidades", itemPedido.CODIGO_PRODUTO, itemPedido.DESCRICAO, itemPedido.QUANTIDADE_MULTIPLA);
			new MyException(text).ThrowException();
		}
		if (itemPedido.INDICE_RELACAO == "MAIOR")
		{
			qUANTIDADE_MULTIPLA = itemPedido.QUANTIDADE_UNIDADE_PEDIDA * (decimal?)itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal() % itemPedido.QUANTIDADE_MULTIPLA;
			if ((qUANTIDADE_MULTIPLA.GetValueOrDefault() == default(decimal)) & qUANTIDADE_MULTIPLA.HasValue)
			{
				return;
			}
		}
		else
		{
			qUANTIDADE_MULTIPLA = itemPedido.QUANTIDADE_UNIDADE_PEDIDA / (decimal?)itemPedido.FATOR_ESTOQUE_PEDIDA.ToDecimal() % itemPedido.QUANTIDADE_MULTIPLA;
			if ((qUANTIDADE_MULTIPLA.GetValueOrDefault() == default(decimal)) & qUANTIDADE_MULTIPLA.HasValue)
			{
				return;
			}
		}
		text = string.Format("O produto {0}-{1} só pode ser vendido de {2} em {2} unidades", itemPedido.CODIGO_PRODUTO, itemPedido.DESCRICAO, itemPedido.QUANTIDADE_MULTIPLA);
	}

	public void ValidarQuantidade(ItemPedidoMO itemPedido, PedidoVendaMO pedidoVenda)
	{
		ConfiguracaoVO pAR_CFG = ConfigERP.PAR_CFG;
		int num;
		if (itemPedido.QUANTIDADE_UNIDADE_PEDIDA.HasValue)
		{
			decimal? qUANTIDADE_UNIDADE_PEDIDA = itemPedido.QUANTIDADE_UNIDADE_PEDIDA;
			num = (((qUANTIDADE_UNIDADE_PEDIDA.GetValueOrDefault() == default(decimal)) & qUANTIDADE_UNIDADE_PEDIDA.HasValue) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool flag = (byte)num != 0;
		bool flag2 = itemPedido.QUANTIDADE == 0m;
		if (pAR_CFG.UNID_PEDIDA && flag)
		{
			new MyException("Quantidade invalida (zero)").ThrowException();
		}
		else if (flag2)
		{
			new MyException("Quantidade invalida (zero)").ThrowException();
		}
	}

	public void ValidarQuantidadeLoteAutomatico(ItemPedidoMO itemPedido, PedidoEletronicoMO pedidoEletronico)
	{
		EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
		ItemPedidoLocalMO itemPedidoLocalMO = itemPedido.ITENS_LOCAIS.FirstOrDefault();
		if (!estoqueDAL.ExisteQtdSuficienteLoteEscolhaAuto(itemPedidoLocalMO.CODIGO_EMPRESA_LOCAL_ESTOQUE, itemPedido.CODIGO_PRODUTO, itemPedido.QUANTIDADE, itemPedidoLocalMO.CODIGO_LOCAL, itemPedido.DT_INI_VALIDADE_LOTE, itemPedido.DT_FIM_VALIDADE_LOTE))
		{
			new MyException("O tipo de pedido possui o parâmetro de Escolha de Lote automática, mas não há quantidade suficiente.").ThrowException();
		}
	}

	public void GerarItPedvLogReservarLote(int cdEmp, int nuPed, ItemPedidoMO itemPedido, bool EscolhaLoteAuto)
	{
		EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
		ItemPedidoLocalMO itemPedidoLocalMO = itemPedido.ITENS_LOCAIS.FirstOrDefault();
		estoqueDAL.ReservaLotesManual(cdEmp, itemPedido.NUMERO_PEDIDO, itemPedido.SEQ, itemPedido.CODIGO_PRODUTO, itemPedidoLocalMO.CODIGO_LOCAL, 0m, itemPedido.QUANTIDADE, itemPedido.DT_INI_VALIDADE_LOTE, itemPedido.DT_FIM_VALIDADE_LOTE, EscolhaLoteAuto);
	}

	internal void AtualizarHorarioReservaEstoque(string nomeTabelaTemporaria)
	{
		EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
		estoqueDAL.AtualizarHorarioReservaEstoque(nomeTabelaTemporaria);
	}

	internal void ValidarEnderecoWMS(TipoPedidoLocalMO LocalMesmaEmpresa)
	{
		if (ConfigERP.PAR_CFG.UTILIZA_WMS)
		{
			EstoqueDAL estoqueDAL = BaseDAL as EstoqueDAL;
			if (!estoqueDAL.ExisteEnderecoFinalWMS(LocalMesmaEmpresa.CODIGO_LOCAL, LocalMesmaEmpresa.CODIGO_EMPRESA))
			{
				new MyException("Endereço final WMS não encontrado para esta empresa e este local de estoque.").ThrowException();
			}
		}
	}
}
