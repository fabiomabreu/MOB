using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TipoPedidoCfopDAL : EntidadeBaseDAL<TipoPedidoCfopMO>
{
	protected override Expression<Func<TipoPedidoCfopMO, bool>> GetWhere(Expression<Func<TipoPedidoCfopMO, bool>> whereClause, TipoPedidoCfopMO exemplo)
	{
		throw new NotImplementedException();
	}
}
