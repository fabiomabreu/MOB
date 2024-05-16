using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EnderecoPedidoEletronicoDAL : EntidadeBaseDAL<EnderecoPedidoEletronicoMO>
{
	protected override Expression<Func<EnderecoPedidoEletronicoMO, bool>> GetWhere(Expression<Func<EnderecoPedidoEletronicoMO, bool>> whereClause, EnderecoPedidoEletronicoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
