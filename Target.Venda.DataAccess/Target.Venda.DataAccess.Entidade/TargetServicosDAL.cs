using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TargetServicosDAL : EntidadeBaseDAL<TargetServicosMO>
{
	protected override Expression<Func<TargetServicosMO, bool>> GetWhere(Expression<Func<TargetServicosMO, bool>> whereClause, TargetServicosMO exemplo)
	{
		if (exemplo.TargetServicosID > 0)
		{
			whereClause = whereClause.And((TargetServicosMO x) => x.TargetServicosID == exemplo.TargetServicosID);
		}
		return whereClause;
	}
}
