using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class VendedorDAL : EntidadeBaseDAL<VendedorMO>
{
	protected override Expression<Func<VendedorMO, bool>> GetWhere(Expression<Func<VendedorMO, bool>> whereClause, VendedorMO exemplo)
	{
		if (!string.IsNullOrEmpty(exemplo.CODIGO_VENDEDOR))
		{
			whereClause = whereClause.And((VendedorMO x) => x.CODIGO_VENDEDOR == exemplo.CODIGO_VENDEDOR);
		}
		return whereClause;
	}
}
