using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ItemPedidoCompDAL : EntidadeBaseDAL<ItemPedidoCompMO>
{
	protected override Expression<Func<ItemPedidoCompMO, bool>> GetWhere(Expression<Func<ItemPedidoCompMO, bool>> whereClause, ItemPedidoCompMO exemplo)
	{
		throw new NotImplementedException();
	}
}
