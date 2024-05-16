using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class GrupoComissaoDAL : EntidadeBaseDAL<GrupoComissaoMO>
{
	protected override Expression<Func<GrupoComissaoMO, bool>> GetWhere(Expression<Func<GrupoComissaoMO, bool>> whereClause, GrupoComissaoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
