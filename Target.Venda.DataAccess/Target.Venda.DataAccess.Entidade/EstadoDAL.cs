using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EstadoDAL : EntidadeBaseDAL<EstadoMO>
{
	protected override Expression<Func<EstadoMO, bool>> GetWhere(Expression<Func<EstadoMO, bool>> whereClause, EstadoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
