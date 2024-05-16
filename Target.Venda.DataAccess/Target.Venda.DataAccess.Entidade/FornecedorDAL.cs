using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class FornecedorDAL : EntidadeBaseDAL<FornecedorMO>
{
	protected override Expression<Func<FornecedorMO, bool>> GetWhere(Expression<Func<FornecedorMO, bool>> whereClause, FornecedorMO exemplo)
	{
		if (exemplo.CODIGO_FORNECEDOR > 0)
		{
			whereClause = whereClause.And((FornecedorMO x) => x.CODIGO_FORNECEDOR == exemplo.CODIGO_FORNECEDOR);
		}
		return whereClause;
	}
}
