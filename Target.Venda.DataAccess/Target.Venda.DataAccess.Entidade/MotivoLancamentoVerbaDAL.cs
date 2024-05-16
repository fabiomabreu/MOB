using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class MotivoLancamentoVerbaDAL : EntidadeBaseDAL<MotivoLancamentoVerbaMO>
{
	protected override Expression<Func<MotivoLancamentoVerbaMO, bool>> GetWhere(Expression<Func<MotivoLancamentoVerbaMO, bool>> whereClause, MotivoLancamentoVerbaMO exemplo)
	{
		throw new NotImplementedException();
	}
}
