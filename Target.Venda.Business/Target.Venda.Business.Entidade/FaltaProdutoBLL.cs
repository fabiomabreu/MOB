using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class FaltaProdutoBLL : EntidadeBaseBLL<FaltaProdutoMO>
{
	protected override EntidadeBaseDAL<FaltaProdutoMO> GetInstanceDAL()
	{
		return new FaltaProdutoDAL();
	}

	public List<FaltaProdutoMO> ObterFaltasPedidoEletronico(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		List<FaltaProdutoMO> list = (BaseDAL as FaltaProdutoDAL).ObterFaltasPedidoEletronico(pEDIDO_ELETRONICO);
		foreach (FaltaProdutoMO item in list)
		{
			AcaoComercialVO acaoComercialVO = pedidoVenda.ACOES_COMERCIAIS.Find(delegate(AcaoComercialVO x)
			{
				decimal? sEQ_ITEM = x.SEQ_ITEM;
				decimal sEQ_ITEM_PEDIDO = item.SEQ_ITEM_PEDIDO;
				return (sEQ_ITEM.GetValueOrDefault() == sEQ_ITEM_PEDIDO) & sEQ_ITEM.HasValue;
			});
			if (acaoComercialVO != null)
			{
				item.SEQ_ACAO_COMERCIAL = acaoComercialVO.SEQ_ACAO_COMERCIAL;
			}
			item.CODIGO_VENDEDOR = pEDIDO_ELETRONICO.CODIGO_VENDEDOR;
			item.CODIGO_USUARIO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
			item.CODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE;
			item.PRECO_BASICO = Math.Round(item.PRECO_BASICO, 2, MidpointRounding.AwayFromZero);
			if (item.PRECO_UNITARIO.HasValue)
			{
				item.PRECO_UNITARIO = Math.Round(item.PRECO_UNITARIO.ToDecimal(), 2, MidpointRounding.AwayFromZero);
			}
		}
		return list;
	}

	public void RegistraFaltaEstoque(PedidoVendaMO pedidoVenda, ItemPedidoMO item, UsuarioMO usuario)
	{
		FaltaProdutoMO faltaProdutoMO = pedidoVenda.FALTAS_PRODUTOS.Find((FaltaProdutoMO x) => x.CODIGO_PRODUTO == item.CODIGO_PRODUTO && x.SEQ_ITEM_PEDIDO == (decimal)item.SEQ);
		if (faltaProdutoMO == null || faltaProdutoMO.QUANTIDADE_FALTA == 0m)
		{
			return;
		}
		int? num = pedidoVenda.NUMERO_PEDIDO;
		if (pedidoVenda.NUMERO_PEDIDO == 0)
		{
			num = null;
		}
		if (item.SEQ_ACAO_COMERCIAL == 0)
		{
			item.SEQ_ACAO_COMERCIAL = null;
		}
		if (item.ITENS_LOCAIS != null)
		{
			foreach (ItemPedidoLocalMO iTENS_LOCAI in item.ITENS_LOCAIS)
			{
				if (iTENS_LOCAI.CODIGO_EMPRESA_LOCAL_ESTOQUE > 0)
				{
					faltaProdutoMO.CODIGO_EMPRESA_LOCAL_ESTOQUE = iTENS_LOCAI.CODIGO_EMPRESA_LOCAL_ESTOQUE;
					faltaProdutoMO.CODIGO_LOCAL = iTENS_LOCAI.CODIGO_LOCAL;
				}
				else
				{
					iTENS_LOCAI.CODIGO_EMPRESA_LOCAL_ESTOQUE = pedidoVenda.CODIGO_EMPRESA;
					iTENS_LOCAI.CODIGO_LOCAL = null;
				}
			}
		}
		faltaProdutoMO.DATA_FALTA = DateTimeHelper.ObterDataHoraAtualBancoDados();
		faltaProdutoMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		faltaProdutoMO.CODIGO_TIPO_FALTA_PRODUTO = "CELE";
		faltaProdutoMO.UNIDADE_VENDA = item.UNIDADE_VENDA;
		faltaProdutoMO.SEQ_ACAO_COMERCIAL = item.SEQ_ACAO_COMERCIAL;
		faltaProdutoMO.UNIDADE_ESTOQUE = item.UNIDADE;
		FaltaProdutoDAL faltaProdutoDAL = (FaltaProdutoDAL)BaseDAL;
		faltaProdutoDAL.Insert(faltaProdutoMO);
	}
}
