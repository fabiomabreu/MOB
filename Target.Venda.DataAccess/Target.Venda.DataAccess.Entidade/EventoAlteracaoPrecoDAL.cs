using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoAlteracaoPrecoDAL : EntidadeBaseDAL<EventoAlteracaoPrecoMO>
{
	protected override Expression<Func<EventoAlteracaoPrecoMO, bool>> GetWhere(Expression<Func<EventoAlteracaoPrecoMO, bool>> whereClause, EventoAlteracaoPrecoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
