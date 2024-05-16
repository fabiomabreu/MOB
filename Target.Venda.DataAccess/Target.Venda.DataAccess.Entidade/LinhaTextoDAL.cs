using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class LinhaTextoDAL : EntidadeBaseDAL<LinhaTextoMO>
{
	protected override Expression<Func<LinhaTextoMO, bool>> GetWhere(Expression<Func<LinhaTextoMO, bool>> whereClause, LinhaTextoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
