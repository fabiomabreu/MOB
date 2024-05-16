using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class VerbaFabricanteTipoLancamentoDAL : EntidadeBaseDAL<VerbaFabricanteTipoLancamentoMO>
{
	protected override Expression<Func<VerbaFabricanteTipoLancamentoMO, bool>> GetWhere(Expression<Func<VerbaFabricanteTipoLancamentoMO, bool>> whereClause, VerbaFabricanteTipoLancamentoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
