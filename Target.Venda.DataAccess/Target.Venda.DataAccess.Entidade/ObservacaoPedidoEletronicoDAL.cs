using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ObservacaoPedidoEletronicoDAL : EntidadeBaseDAL<ObservacaoPedidoEletronicoMO>
{
	protected override Expression<Func<ObservacaoPedidoEletronicoMO, bool>> GetWhere(Expression<Func<ObservacaoPedidoEletronicoMO, bool>> whereClause, ObservacaoPedidoEletronicoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
