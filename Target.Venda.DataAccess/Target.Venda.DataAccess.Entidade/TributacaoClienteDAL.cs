using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class TributacaoClienteDAL : EntidadeBaseDAL<TributacaoClienteMO>
{
	protected override Expression<Func<TributacaoClienteMO, bool>> GetWhere(Expression<Func<TributacaoClienteMO, bool>> whereClause, TributacaoClienteMO exemplo)
	{
		throw new NotImplementedException();
	}
}
