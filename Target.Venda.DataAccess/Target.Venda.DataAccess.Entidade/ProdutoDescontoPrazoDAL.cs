using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ProdutoDescontoPrazoDAL : EntidadeBaseDAL<ProdutoDescontoPrazoMO>
{
	protected override Expression<Func<ProdutoDescontoPrazoMO, bool>> GetWhere(Expression<Func<ProdutoDescontoPrazoMO, bool>> whereClause, ProdutoDescontoPrazoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
