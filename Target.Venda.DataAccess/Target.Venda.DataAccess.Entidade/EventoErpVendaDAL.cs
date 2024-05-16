using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoErpVendaDAL : EntidadeBaseDAL<EventoErpVendaMO>
{
	protected override Expression<Func<EventoErpVendaMO, bool>> GetWhere(Expression<Func<EventoErpVendaMO, bool>> whereClause, EventoErpVendaMO exemplo)
	{
		throw new NotImplementedException();
	}
}
