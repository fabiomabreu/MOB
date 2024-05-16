using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TipoPedidoOutrosLocaisDAL : EntidadeBaseDAL<TipoPedidoOutrosLocaisMO>
{
	protected override Expression<Func<TipoPedidoOutrosLocaisMO, bool>> GetWhere(Expression<Func<TipoPedidoOutrosLocaisMO, bool>> whereClause, TipoPedidoOutrosLocaisMO exemplo)
	{
		if (!string.IsNullOrEmpty(exemplo.CODIGO_TIPO_PEDIDO))
		{
			whereClause = whereClause.And((TipoPedidoOutrosLocaisMO x) => x.CODIGO_TIPO_PEDIDO == exemplo.CODIGO_TIPO_PEDIDO);
		}
		if (exemplo.CODIGO_EMPRESA > 0)
		{
			whereClause = whereClause.And((TipoPedidoOutrosLocaisMO x) => x.CODIGO_EMPRESA == exemplo.CODIGO_EMPRESA);
		}
		return whereClause;
	}
}
