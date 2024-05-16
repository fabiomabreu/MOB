using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ClienteEmpresaDAL : EntidadeBaseDAL<ClienteEmpresaMO>
{
	protected override Expression<Func<ClienteEmpresaMO, bool>> GetWhere(Expression<Func<ClienteEmpresaMO, bool>> whereClause, ClienteEmpresaMO exemplo)
	{
		throw new NotImplementedException();
	}
}
