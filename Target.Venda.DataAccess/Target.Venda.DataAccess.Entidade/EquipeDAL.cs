using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EquipeDAL : EntidadeBaseDAL<EquipeMO>
{
	protected override Expression<Func<EquipeMO, bool>> GetWhere(Expression<Func<EquipeMO, bool>> whereClause, EquipeMO exemplo)
	{
		throw new NotImplementedException();
	}
}
