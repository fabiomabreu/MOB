using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class KitPromocaoPagamentoDAL : EntidadeBaseDAL<KitPromocaoPagamentoMO>
{
	protected override Expression<Func<KitPromocaoPagamentoMO, bool>> GetWhere(Expression<Func<KitPromocaoPagamentoMO, bool>> whereClause, KitPromocaoPagamentoMO exemplo)
	{
		if (exemplo.SEQ_PROMOCAO > 0)
		{
			whereClause = whereClause.And((KitPromocaoPagamentoMO x) => x.SEQ_PROMOCAO == exemplo.SEQ_PROMOCAO);
		}
		return whereClause;
	}
}
