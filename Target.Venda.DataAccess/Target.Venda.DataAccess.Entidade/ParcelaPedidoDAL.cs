using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ParcelaPedidoDAL : EntidadeBaseDAL<ParcelaPedidoMO>
{
	protected override Expression<Func<ParcelaPedidoMO, bool>> GetWhere(Expression<Func<ParcelaPedidoMO, bool>> whereClause, ParcelaPedidoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
