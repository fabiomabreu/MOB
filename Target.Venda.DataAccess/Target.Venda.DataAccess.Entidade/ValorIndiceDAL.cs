using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ValorIndiceDAL : EntidadeBaseDAL<ValorIndiceMO>
{
	protected override Expression<Func<ValorIndiceMO, bool>> GetWhere(Expression<Func<ValorIndiceMO, bool>> whereClause, ValorIndiceMO exemplo)
	{
		throw new NotImplementedException();
	}
}
