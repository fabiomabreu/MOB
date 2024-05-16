using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TabelaPrecoDAL : EntidadeBaseDAL<TabelaPrecoMO>
{
	protected override Expression<Func<TabelaPrecoMO, bool>> GetWhere(Expression<Func<TabelaPrecoMO, bool>> whereClause, TabelaPrecoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
