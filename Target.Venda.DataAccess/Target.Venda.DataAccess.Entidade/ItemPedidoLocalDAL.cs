using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ItemPedidoLocalDAL : EntidadeBaseDAL<ItemPedidoLocalMO>
{
	protected override Expression<Func<ItemPedidoLocalMO, bool>> GetWhere(Expression<Func<ItemPedidoLocalMO, bool>> whereClause, ItemPedidoLocalMO exemplo)
	{
		throw new NotImplementedException();
	}
}
