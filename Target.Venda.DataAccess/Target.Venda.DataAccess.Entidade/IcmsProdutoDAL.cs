using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class IcmsProdutoDAL : EntidadeBaseDAL<IcmsProdutoMO>
{
	protected override Expression<Func<IcmsProdutoMO, bool>> GetWhere(Expression<Func<IcmsProdutoMO, bool>> whereClause, IcmsProdutoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
