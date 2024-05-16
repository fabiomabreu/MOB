using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ClientePromocaoDAL : EntidadeBaseDAL<ClientePromocaoMO>
{
	protected override Expression<Func<ClientePromocaoMO, bool>> GetWhere(Expression<Func<ClientePromocaoMO, bool>> whereClause, ClientePromocaoMO exemplo)
	{
		if (exemplo.SEQ_PROMOCAO > 0)
		{
			whereClause = whereClause.And((ClientePromocaoMO x) => x.SEQ_PROMOCAO == exemplo.SEQ_PROMOCAO);
		}
		if (exemplo.CODIGO_CLIENTE > 0)
		{
			whereClause = whereClause.And((ClientePromocaoMO x) => x.CODIGO_CLIENTE == exemplo.CODIGO_CLIENTE);
		}
		return whereClause;
	}
}
