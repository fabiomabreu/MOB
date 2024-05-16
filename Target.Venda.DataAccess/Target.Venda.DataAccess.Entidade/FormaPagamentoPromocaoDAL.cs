using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class FormaPagamentoPromocaoDAL : EntidadeBaseDAL<FormaPagamentoPromocaoMO>
{
	protected override Expression<Func<FormaPagamentoPromocaoMO, bool>> GetWhere(Expression<Func<FormaPagamentoPromocaoMO, bool>> whereClause, FormaPagamentoPromocaoMO exemplo)
	{
		if (exemplo.SEQ_PROMOCAO > 0)
		{
			whereClause = whereClause.And((FormaPagamentoPromocaoMO x) => x.SEQ_PROMOCAO == exemplo.SEQ_PROMOCAO);
		}
		return whereClause;
	}
}
