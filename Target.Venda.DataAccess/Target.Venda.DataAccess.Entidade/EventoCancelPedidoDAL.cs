using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoCancelPedidoDAL : EntidadeBaseDAL<EventoCancelPedidoMO>
{
	protected override Expression<Func<EventoCancelPedidoMO, bool>> GetWhere(Expression<Func<EventoCancelPedidoMO, bool>> whereClause, EventoCancelPedidoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
