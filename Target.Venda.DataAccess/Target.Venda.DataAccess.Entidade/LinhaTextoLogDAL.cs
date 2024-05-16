using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class LinhaTextoLogDAL : EntidadeBaseDAL<LinhaTextoLogMO>
{
	protected override Expression<Func<LinhaTextoLogMO, bool>> GetWhere(Expression<Func<LinhaTextoLogMO, bool>> whereClause, LinhaTextoLogMO exemplo)
	{
		throw new NotImplementedException();
	}
}
