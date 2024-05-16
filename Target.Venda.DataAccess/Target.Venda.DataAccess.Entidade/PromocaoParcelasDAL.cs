using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class PromocaoParcelasDAL : EntidadeBaseDAL<PromocaoParcelasMO>
{
	protected override Expression<Func<PromocaoParcelasMO, bool>> GetWhere(Expression<Func<PromocaoParcelasMO, bool>> whereClause, PromocaoParcelasMO exemplo)
	{
		if (exemplo.SEQ_PROMOCAO > 0)
		{
			whereClause = whereClause.And((PromocaoParcelasMO x) => x.SEQ_PROMOCAO == exemplo.SEQ_PROMOCAO);
		}
		return whereClause;
	}
}
