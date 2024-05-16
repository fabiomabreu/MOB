using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class VendedorClienteDAL : EntidadeBaseDAL<VendedorClienteMO>
{
	protected override Expression<Func<VendedorClienteMO, bool>> GetWhere(Expression<Func<VendedorClienteMO, bool>> whereClause, VendedorClienteMO exemplo)
	{
		throw new NotImplementedException();
	}
}
