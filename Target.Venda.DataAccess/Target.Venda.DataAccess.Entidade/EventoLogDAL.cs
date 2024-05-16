using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoLogDAL : EntidadeBaseDAL<EventoLogMO>
{
	protected override Expression<Func<EventoLogMO, bool>> GetWhere(Expression<Func<EventoLogMO, bool>> whereClause, EventoLogMO exemplo)
	{
		throw new NotImplementedException();
	}
}
