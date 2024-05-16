using System;
using System.Linq.Expressions;
using System.Text;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class IntPedidoLiberaProdutoDAL : EntidadeBaseDAL<IntPedidoLiberaProdutoMO>
{
	protected override Expression<Func<IntPedidoLiberaProdutoMO, bool>> GetWhere(Expression<Func<IntPedidoLiberaProdutoMO, bool>> whereClause, IntPedidoLiberaProdutoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public void GerarIntPedidoLiberaProduto(int codigoProduto, string tipoAlteracaoEvento, string codigoTabela)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(" INSERT INTO int_pdv_lib_prod ( \r\n                                                                           cd_emp,\r\n                                                                           cd_prod,\r\n                                                                           tp_inc,\r\n                                                                           tp_alt,\r\n                                                                           tp_pre,\r\n                                                                           etiqueta ) \r\n                                              SELECT\r\n                                              em.cd_emp,\r\n                                              {0},\r\n                                              0,\r\n                                              0,\r\n                                              0,\r\n                                              0\r\n                                              FROM\r\n                                              empresa em\r\n                                              WHERE\r\n                                              NOT EXISTS ( SELECT 1 FROM int_pdv_lib_prod\r\n                                                            WHERE cd_emp = em.cd_emp\r\n                                                              AND cd_prod = {0} )", codigoProduto);
			if (tipoAlteracaoEvento == "PRE" || tipoAlteracaoEvento == "CPR")
			{
				stringBuilder.AppendFormat(" AND EXISTS ( SELECT 1 FROM tab_pre_emp\r\n                                                           WHERE cd_emp = em.cd_emp\r\n                                                             AND cd_tabela = '{0}'\r\n                                                             AND utiliza = 1 ) ", codigoTabela);
			}
			ExecutarSqlCommand(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public void AlterarIntPedidoLiberaProduto(int codigoProduto, string tipoAlteracaoEvento, bool emiteEtiqueta)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE int_pdv_lib_prod SET ");
			switch (tipoAlteracaoEvento)
			{
			case "INC":
				stringBuilder.Append(" tp_inc = 1 ");
				break;
			case "ALT":
				stringBuilder.Append(" tp_alt = 1 ");
				break;
			default:
				if (!(tipoAlteracaoEvento == "CPR"))
				{
					break;
				}
				goto case "PRE";
			case "PRE":
				stringBuilder.Append(" tp_pre = 1 ");
				break;
			}
			if (emiteEtiqueta)
			{
				stringBuilder.Append(" , etiqueta = 1");
			}
			stringBuilder.AppendFormat(" WHERE cd_prod = {0}", codigoProduto);
			ExecutarSqlCommand(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
