using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoLogTrocaDAL : EntidadeBaseDAL<EventoLogTrocaMO>
{
	protected override Expression<Func<EventoLogTrocaMO, bool>> GetWhere(Expression<Func<EventoLogTrocaMO, bool>> whereClause, EventoLogTrocaMO exemplo)
	{
		throw new NotImplementedException();
	}
}
