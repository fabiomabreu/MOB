using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoAcaoComercialDAL : EntidadeBaseDAL<EventoAcaoComercialMO>
{
	protected override Expression<Func<EventoAcaoComercialMO, bool>> GetWhere(Expression<Func<EventoAcaoComercialMO, bool>> whereClause, EventoAcaoComercialMO exemplo)
	{
		throw new NotImplementedException();
	}
}
