using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class RegiaoDAL : EntidadeBaseDAL<RegiaoMO>
{
	protected override Expression<Func<RegiaoMO, bool>> GetWhere(Expression<Func<RegiaoMO, bool>> whereClause, RegiaoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
