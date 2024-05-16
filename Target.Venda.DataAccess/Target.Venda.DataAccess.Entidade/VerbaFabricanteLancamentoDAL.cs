using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class VerbaFabricanteLancamentoDAL : EntidadeBaseDAL<VerbaFabricanteLancamentoMO>
{
	protected override Expression<Func<VerbaFabricanteLancamentoMO, bool>> GetWhere(Expression<Func<VerbaFabricanteLancamentoMO, bool>> whereClause, VerbaFabricanteLancamentoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
