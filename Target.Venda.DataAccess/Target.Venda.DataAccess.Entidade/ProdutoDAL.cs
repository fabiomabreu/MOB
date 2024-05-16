using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class ProdutoDAL : EntidadeBaseDAL<ProdutoMO>
{
	protected override Expression<Func<ProdutoMO, bool>> GetWhere(Expression<Func<ProdutoMO, bool>> whereClause, ProdutoMO exemplo)
	{
		if (exemplo.CODIGO_PRODUTO > 0)
		{
			whereClause = whereClause.And((ProdutoMO x) => x.CODIGO_PRODUTO == exemplo.CODIGO_PRODUTO);
		}
		return whereClause;
	}

	public bool VerificaICMSDiferido(ItemPedidoMO item)
	{
		string select = " SELECT 1  \r\n                            FROM produto  \r\n                            WHERE cd_prod = {0}\r\n                              AND icms_diferido = 1  ";
		return ExecutarScalarSQL<bool>(select, new object[1] { item.CODIGO_PRODUTO });
	}

	public decimal BuscaCustoProdutoCalculo(int codigoProduto, int codigoEmpresa, TipoPedidoVO tipoPedido)
	{
		string text = "";
		if (tipoPedido.TIPO_VALOR_CUSTO_TRANSFERENCIA_AUTO == "SI")
		{
			text = "vl_custo_sem_imposto";
		}
		else
		{
			string text2 = (tipoPedido.UTILIZA_PRECO_CUSTO_SEM_ST ? "1" : "0");
			text = "vl_custo - ( ISNULL(vl_icm_subst, 0) * " + text2 + " ) ";
		}
		string select = " SELECT\r\n                            " + text + "\r\n                            FROM produto_custo \r\n                            WHERE cd_prod = {0}\r\n                              AND tp_custo = {1}\r\n                              AND cd_emp = {2} ";
		return ExecutarScalarSQL<decimal>(select, new object[3] { codigoProduto, tipoPedido.UTILIZA_PRECO_TP_CUSTO_BONIF, codigoEmpresa });
	}

	public int VerificaVendaProduto(ItemPedidoMO item, TipoPedidoLocalMO LocalMesmaEmpresa, bool utilizaWMS)
	{
		string empty = string.Empty;
		int? num = null;
		if (utilizaWMS)
		{
			empty = "\tSELECT TOP 1\r\n\t\t\t\t\t\t\t\tcd_emp\r\n\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\tvi_prod_wms_unid\r\n\t\t\t\t\t\t\tWHERE\r\n\t\t\t\t\t\t\t\tcd_prod = {0}\r\n\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\tcd_local = {1}\r\n\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\tISNULL(seq_prod_wms_unid,0) > 0\r\n\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\tcd_emp = {2}";
			num = ExecutarScalarSQL<int>(empty, new object[3] { item.CODIGO_PRODUTO, LocalMesmaEmpresa.CODIGO_LOCAL, LocalMesmaEmpresa.CODIGO_EMPRESA });
			if (num.HasValue)
			{
				return Convert.ToInt32(num);
			}
			empty = "\tSELECT TOP 1\r\n\t\t\t\t\t\t\t\t\tcd_emp\r\n\t\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\t\tvi_prod_wms_unid \r\n\t\t\t\t\t\t\t\tWHERE\r\n\t\t\t\t\t\t\t\t\tcd_prod = {0} \r\n\t\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\t\tcd_local = {1} \r\n\t\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\t\tISNULL(seq_prod_wms_unid,0) > 0\r\n\t\t\t\t\t\t\t\tORDER BY\r\n\t\t\t\t\t\t\t\t\tcd_emp\t";
		}
		else
		{
			empty = "\tSELECT \r\n\t\t\t\t\t\t\t\tDISTINCT 1 cd_emp\r\n\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\tprd_eest\r\n\t\t\t\t\t\t\tWHERE\r\n\t\t\t\t\t\t\t\tcd_prod = {0} \r\n\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\tcd_local = {1} \r\n\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\tcd_emp = {2}\r\n\t\t\t\t\t\t\tORDER BY\r\n\t\t\t\t\t\t\t\tcd_emp\t";
			num = ExecutarScalarSQL<int>(empty, new object[3] { item.CODIGO_PRODUTO, LocalMesmaEmpresa.CODIGO_LOCAL, LocalMesmaEmpresa.CODIGO_EMPRESA });
			if (num.HasValue)
			{
				return Convert.ToInt32(num);
			}
			empty = "\tSELECT TOP 1\r\n\t\t\t\t\t\t\t\t\t\tcd_emp\r\n\t\t\t\t\t\t\t\t\tFROM\r\n\t\t\t\t\t\t\t\t\t\tprd_eest\r\n\t\t\t\t\t\t\t\t\tWHERE\r\n\t\t\t\t\t\t\t\t\t\tcd_prod = {0} \r\n\t\t\t\t\t\t\t\t\tAND\r\n\t\t\t\t\t\t\t\t\t\tcd_local = {1} \r\n\t\t\t\t\t\t\t\t\tORDER BY\r\n\t\t\t\t\t\t\t\t\t\tcd_emp\t";
		}
		return ExecutarScalarSQL<int>(empty, new object[2] { item.CODIGO_PRODUTO, LocalMesmaEmpresa.CODIGO_LOCAL });
	}

	public bool VerificaDescGeralProd(ItemPedidoMO item)
	{
		string select = " SELECT CAST( 1   as BIT)\r\n                            FROM produto  \r\n                            WHERE cd_prod = {0}\r\n                              AND ISNULL(DescGeralProd,0) = 1  ";
		return ExecutarScalarSQL<bool>(select, new object[1] { item.CODIGO_PRODUTO });
	}
}
