using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ObservacaoPedidoDAL : EntidadeBaseDAL<ObservacaoPedidoMO>
{
	protected override Expression<Func<ObservacaoPedidoMO, bool>> GetWhere(Expression<Func<ObservacaoPedidoMO, bool>> whereClause, ObservacaoPedidoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
