using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class UsuarioDAL : EntidadeBaseDAL<UsuarioMO>
{
	protected override Expression<Func<UsuarioMO, bool>> GetWhere(Expression<Func<UsuarioMO, bool>> whereClause, UsuarioMO exemplo)
	{
		throw new NotImplementedException();
	}

	public bool ValidarCodigoUsuario(string codigoUsuario)
	{
		try
		{
			string select = " SELECT CAST(COUNT(1) AS BIT)\r\n                                     FROM Usuario\r\n                                    WHERE cd_usuario = {0} ";
			return ExecutarScalarSQL<bool>(select, new object[1] { codigoUsuario });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
