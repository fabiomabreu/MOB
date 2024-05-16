using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class TrocaBLL : EntidadeBaseBLL<TrocaMO>
{
	protected override EntidadeBaseDAL<TrocaMO> GetInstanceDAL()
	{
		return new TrocaDAL();
	}

	public TrocaMO ObterMenorTrocaAberta(ObterTrocaParamVO filtro)
	{
		return (BaseDAL as TrocaDAL).ObterMenorTrocaAberta(filtro);
	}

	public void AssociarTrocaPedido(PedidoVendaMO pedidoVenda, TrocaMO troca)
	{
		(BaseDAL as TrocaDAL).AssociarTrocaPedido(pedidoVenda, troca);
	}

	public TrocaMO ObterTrocaPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		try
		{
			if (!pedidoVenda.TIPO_PEDIDO.GERA_TITULO_RECEBER.ToBool())
			{
				return null;
			}
			int? sEQ_TROCA = pedidoVenda.PEDIDO_ELETRONICO.SEQ_TROCA;
			if (sEQ_TROCA > 0)
			{
				return ObterPeloID(sEQ_TROCA);
			}
			ObterTrocaParamVO obterTrocaParamVO = new ObterTrocaParamVO();
			obterTrocaParamVO.CODIGO_CLIENTE = pedidoVenda.CLIENTE.CODIGO_CLIENTE;
			obterTrocaParamVO.CODIGO_EMPRESA = LoginERP.EMPRESA_LOGADA.CODIGO_EMPRESA;
			obterTrocaParamVO.CODIGO_VENDEDOR = pedidoVenda.VENDEDOR.CODIGO_VENDEDOR;
			obterTrocaParamVO.ASSOCIA_TROCA_SOMENTE_AO_MESMO_VENDEDOR_E_CLIENTE = ConfigERP.PARAMETROS_TELA.VENDA.ASSOCIA_TROCA_SOMENTE_AO_MESMO_VENDEDOR_E_CLIENTE;
			return ObterMenorTrocaAberta(obterTrocaParamVO);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public bool ExisteTrocaNoPedido(PedidoVendaMO pedidoVenda)
	{
		TrocaMO tROCA = pedidoVenda.TROCA;
		bool flag = false;
		return (tROCA != null && tROCA.SEQ_TROCA > 0) ? true : false;
	}

	public void ValidarTrocaPedido(PedidoVendaMO pedidoVenda)
	{
		TrocaMO tROCA = pedidoVenda.TROCA;
		decimal vALOR_TOTAL = tROCA.VALOR_TOTAL;
		decimal? vALOR_TOTAL2 = pedidoVenda.VALOR_TOTAL;
		bool flag = ((vALOR_TOTAL > vALOR_TOTAL2.GetValueOrDefault()) & vALOR_TOTAL2.HasValue) && (tROCA.TIPO_ABATIMENTO == "PN" || tROCA.TIPO_ABATIMENTO == "PT");
		decimal vALOR_TOTAL3 = tROCA.VALOR_TOTAL;
		vALOR_TOTAL2 = pedidoVenda.VALOR_TOTAL;
		bool flag2 = ((vALOR_TOTAL3 == vALOR_TOTAL2.GetValueOrDefault()) & vALOR_TOTAL2.HasValue) && tROCA.TIPO_ABATIMENTO == "PN" && pedidoVenda.TIPO_PEDIDO.IMPRIME_NOTA_FISCAL;
		if (flag2 || flag)
		{
			pedidoVenda.TROCA = null;
		}
	}
}
