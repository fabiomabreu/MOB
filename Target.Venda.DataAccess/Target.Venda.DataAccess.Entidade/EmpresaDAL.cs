using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EmpresaDAL : EntidadeBaseDAL<EmpresaMO>
{
	protected override Expression<Func<EmpresaMO, bool>> GetWhere(Expression<Func<EmpresaMO, bool>> whereClause, EmpresaMO exemplo)
	{
		return whereClause;
	}

	public bool ValidarCodigoEmpresa(int codigoEmpresa)
	{
		try
		{
			string select = " SELECT CAST(COUNT(1) AS BIT)\r\n                                   FROM Empresa\r\n                                   WHERE cd_emp = {0}";
			return ExecutarScalarSQL<bool>(select, new object[1] { codigoEmpresa });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
