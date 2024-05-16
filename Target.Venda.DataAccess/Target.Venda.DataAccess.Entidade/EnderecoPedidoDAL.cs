using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EnderecoPedidoDAL : EntidadeBaseDAL<EnderecoPedidoMO>
{
	protected override Expression<Func<EnderecoPedidoMO, bool>> GetWhere(Expression<Func<EnderecoPedidoMO, bool>> whereClause, EnderecoPedidoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
