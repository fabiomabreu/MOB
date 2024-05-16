using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class AcaoComercialProdutoBLL : EntidadeBaseBLL<AcaoComercialProdutoMO>
{
	protected override EntidadeBaseDAL<AcaoComercialProdutoMO> GetInstanceDAL()
	{
		return new AcaoComercialProdutoDAL();
	}

	public decimal ObterValorVerbaFabricanteProduto(ItemPedidoMO item)
	{
		return (BaseDAL as AcaoComercialProdutoDAL).ObterValorVerbaFabricanteProduto(item);
	}

	public List<AcaoComercialEncerradaVO> ObterAcaoComercialProdutoEncerradas(PedidoVendaMO pedidoVenda, ConfiguracaoVO parCfg)
	{
		AcaoComercialProdutoDAL acaoComercialProdutoDAL = BaseDAL as AcaoComercialProdutoDAL;
		List<AcaoComercialEncerradaVO> list = new List<AcaoComercialEncerradaVO>();
		if (parCfg.VERBA_FABR_ENC_ITEM_ESTOQUE)
		{
			List<AcaoComercialEncerradaVO> collection = acaoComercialProdutoDAL.ObterAcaoComercialProdutoEncerradasFaltaEstoque(pedidoVenda);
			list.AddRange(collection);
		}
		List<AcaoComercialEncerradaVO> collection2 = acaoComercialProdutoDAL.ObterAcaoComercialProdutoEncerradasLimite(pedidoVenda);
		list.AddRange(collection2);
		return list;
	}

	public void EncerrarAcaoComercialProduto(AcaoComercialEncerradaVO acaoComercialEncerrada, PedidoVendaMO pedidoVenda)
	{
		AcaoComercialProdutoDAL acaoComercialProdutoDAL = BaseDAL as AcaoComercialProdutoDAL;
		acaoComercialProdutoDAL.EncerrarAcaoComercialProduto(acaoComercialEncerrada);
		AtualizarPrecoProdutoAcaoComercial(acaoComercialEncerrada, "ENC", pedidoVenda);
		EventoAcaoComercialBLL eventoAcaoComercialBLL = new EventoAcaoComercialBLL();
		eventoAcaoComercialBLL.GerarEventoEnceramentoAcaoComercial(acaoComercialEncerrada, LoginERP.USUARIO_LOGADO);
		if (acaoComercialProdutoDAL.VerificarAcaoComercialProdutoEstaEncerrada(acaoComercialEncerrada))
		{
			AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
			acaoComercialBLL.EncerrarAcaoComercial(acaoComercialEncerrada, pedidoVenda);
		}
	}

	public void AtualizarPrecoProdutoAcaoComercial(AcaoComercialEncerradaVO acaoComercial, string tipoOperacao, PedidoVendaMO pedidoVenda)
	{
		AcaoComercialProdutoPrecoBLL acaoComercialProdutoPrecoBLL = new AcaoComercialProdutoPrecoBLL();
		AcaoComercialProdutoBLL acaoComercialProdutoBLL = new AcaoComercialProdutoBLL();
		PrecoBLL precoBLL = new PrecoBLL();
		EventoBLL eventoBLL = new EventoBLL();
		List<string> list = acaoComercialProdutoPrecoBLL.ObterTabelasAcaoComercialProduto(acaoComercial);
		foreach (string item in list)
		{
			AcaoComercialProdutoPrecoVO acaoComercialProdutoPrecoVO = acaoComercialProdutoPrecoBLL.ObterAcaoComercialProdutoPrecoPelaTabela(acaoComercial, item);
			if (acaoComercialProdutoPrecoVO != null)
			{
				acaoComercialProdutoPrecoVO.VALOR_PRECO_ATUALIZADO = acaoComercialProdutoPrecoVO.VALOR_PRECO_ACAO_COMERCIAL;
				if (tipoOperacao == "ENC")
				{
					acaoComercialProdutoPrecoVO.VALOR_PRECO_ATUALIZADO = acaoComercialProdutoPrecoVO.VALOR_PRECO_POS_ACAO_COMERCIAL;
				}
				precoBLL.AtualizarPrecoProdutoPelaTabela(acaoComercialProdutoPrecoVO.CODIGO_PRODUTO, acaoComercialProdutoPrecoVO.VALOR_PRECO_ATUALIZADO, item);
				eventoBLL.GerarEventoAlteracaoPreco(acaoComercialProdutoPrecoVO, pedidoVenda, "PRE");
			}
		}
	}

	public void EncerrarTodosProdutosAcaoComercial(int seqAcaoComercial)
	{
		(BaseDAL as AcaoComercialProdutoDAL).EncerrarTodosProdutosAcaoComercial(seqAcaoComercial);
	}
}
