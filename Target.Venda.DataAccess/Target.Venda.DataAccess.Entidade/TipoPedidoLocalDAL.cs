using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TipoPedidoLocalDAL : EntidadeBaseDAL<TipoPedidoLocalMO>
{
	protected override Expression<Func<TipoPedidoLocalMO, bool>> GetWhere(Expression<Func<TipoPedidoLocalMO, bool>> whereClause, TipoPedidoLocalMO exemplo)
	{
		if (!string.IsNullOrEmpty(exemplo.TIPO_PEDIDO))
		{
			whereClause = whereClause.And((TipoPedidoLocalMO x) => x.TIPO_PEDIDO == exemplo.TIPO_PEDIDO);
		}
		if (exemplo.CODIGO_EMPRESA > 0)
		{
			whereClause = whereClause.And((TipoPedidoLocalMO x) => x.CODIGO_EMPRESA == exemplo.CODIGO_EMPRESA);
		}
		return whereClause;
	}
}
