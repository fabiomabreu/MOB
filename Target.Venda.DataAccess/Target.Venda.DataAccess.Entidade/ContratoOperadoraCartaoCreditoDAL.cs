using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ContratoOperadoraCartaoCreditoDAL : EntidadeBaseDAL<ContratoOperadoraCartaoCreditoMO>
{
	protected override Expression<Func<ContratoOperadoraCartaoCreditoMO, bool>> GetWhere(Expression<Func<ContratoOperadoraCartaoCreditoMO, bool>> whereClause, ContratoOperadoraCartaoCreditoMO exemplo)
	{
		if (exemplo.CONTRATO_ID > 0)
		{
			whereClause = whereClause.And((ContratoOperadoraCartaoCreditoMO x) => x.CONTRATO_ID == exemplo.CONTRATO_ID);
		}
		return whereClause;
	}
}
