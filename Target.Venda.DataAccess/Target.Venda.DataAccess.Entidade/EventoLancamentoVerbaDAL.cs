using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EventoLancamentoVerbaDAL : EntidadeBaseDAL<EventoLancamentoVerbaMO>
{
	protected override Expression<Func<EventoLancamentoVerbaMO, bool>> GetWhere(Expression<Func<EventoLancamentoVerbaMO, bool>> whereClause, EventoLancamentoVerbaMO exemplo)
	{
		throw new NotImplementedException();
	}
}
