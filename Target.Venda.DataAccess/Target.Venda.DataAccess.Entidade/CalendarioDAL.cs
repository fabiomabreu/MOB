using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class CalendarioDAL : EntidadeBaseDAL<CalendarioMO>
{
	protected override Expression<Func<CalendarioMO, bool>> GetWhere(Expression<Func<CalendarioMO, bool>> whereClause, CalendarioMO exemplo)
	{
		throw new NotImplementedException();
	}

	public int CalculaQuantidadeDias(DateTime dataInicial, DateTime dataFinal, bool somenteDiasUteis, int cdEmpresa)
	{
		string text = " data >= {0}  AND  data <= {1} ";
		if (dataInicial > dataFinal)
		{
			text = "data <= {0} AND  data >= {1} ";
		}
		string select = " SELECT\r\n                                COUNT( * )\r\n                            FROM calend\r\n                            WHERE " + text + "\r\n                              AND util = {2}\r\n                              AND cd_emp = {3}";
		return ExecutarScalarSQL<int>(select, new object[4] { dataInicial, dataFinal, somenteDiasUteis, cdEmpresa });
	}

	public DateTime ObterProximoDiaUltil(int cdEmpresa, DateTime dataPrimeiroVencimento)
	{
		string select = " SELECT \r\n                                MIN( data )\r\n                            FROM  calend\r\n                            WHERE data >= {0}\r\n                              AND cd_emp = {1}\r\n                              AND  util = 1 ";
		return ExecutarScalarSQL<DateTime>(select, new object[2] { dataPrimeiroVencimento, cdEmpresa });
	}
}
