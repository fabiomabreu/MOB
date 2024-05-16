using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class LocalFaturamentoDAL : EntidadeBaseDAL<LocalFaturamentoMO>
{
	protected override Expression<Func<LocalFaturamentoMO, bool>> GetWhere(Expression<Func<LocalFaturamentoMO, bool>> whereClause, LocalFaturamentoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
