using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ClienteEmpresaFormaPagamentoDAL : EntidadeBaseDAL<ClienteEmpresaFormaPagamentoMO>
{
	protected override Expression<Func<ClienteEmpresaFormaPagamentoMO, bool>> GetWhere(Expression<Func<ClienteEmpresaFormaPagamentoMO, bool>> whereClause, ClienteEmpresaFormaPagamentoMO exemplo)
	{
		throw new NotImplementedException();
	}
}
