using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class RotaPrdfDAL : EntidadeBaseDAL<RotaPrdfMO>
{
	protected override Expression<Func<RotaPrdfMO, bool>> GetWhere(Expression<Func<RotaPrdfMO, bool>> whereClause, RotaPrdfMO exemplo)
	{
		throw new NotImplementedException();
	}
}
