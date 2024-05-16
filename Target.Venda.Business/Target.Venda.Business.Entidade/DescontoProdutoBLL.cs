using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class DescontoProdutoBLL : EntidadeBaseBLL<DescontoProdutoMO>
{
	protected override EntidadeBaseDAL<DescontoProdutoMO> GetInstanceDAL()
	{
		return new DescontoProdutoDAL();
	}

	public DescontoProdutoMO ObterDescontoPorQuantidade(string codigoTabela, ItemPedidoMO itemPedido)
	{
		return (BaseDAL as DescontoProdutoDAL).ObterDescontoPorQuantidade(codigoTabela, itemPedido.CODIGO_PRODUTO, itemPedido.QUANTIDADE);
	}

	public decimal CalcularDescontoPermitidoItemPedido(ItemPedidoMO itemPedido)
	{
		return 1m - (1m - itemPedido.DESCONTO_POR_QUANTIDADE.ToDecimal()) * (1m - itemPedido.DESCONTO_PROMOCAO.ToDecimal());
	}

	public bool VerificaUtilizaDescontoPorQuantidade(ItemPedidoMO itemPedido)
	{
		bool dESC_QTDE_COMO_DESC_PERM_EM_BONIFICACOES = ConfigERP.PARAMETROS_TELA.VENDA.DESC_QTDE_COMO_DESC_PERM_EM_BONIFICACOES;
		if ((itemPedido.BONIFICADO.ToBool() && !dESC_QTDE_COMO_DESC_PERM_EM_BONIFICACOES) || !ConfigERP.PAR_CFG.DESCONTO_POR_QUANTIDADE)
		{
			return false;
		}
		return true;
	}
}
