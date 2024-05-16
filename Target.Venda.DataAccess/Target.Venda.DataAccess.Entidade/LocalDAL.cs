using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class LocalDAL : EntidadeBaseDAL<LocalMO>
{
	protected override Expression<Func<LocalMO, bool>> GetWhere(Expression<Func<LocalMO, bool>> whereClause, LocalMO exemplo)
	{
		throw new NotImplementedException();
	}
}
