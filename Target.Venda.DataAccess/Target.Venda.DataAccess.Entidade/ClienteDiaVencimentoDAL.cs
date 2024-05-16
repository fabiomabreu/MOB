using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ClienteDiaVencimentoDAL : EntidadeBaseDAL<ClienteDiaVencimentoMO>
{
	protected override Expression<Func<ClienteDiaVencimentoMO, bool>> GetWhere(Expression<Func<ClienteDiaVencimentoMO, bool>> whereClause, ClienteDiaVencimentoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
