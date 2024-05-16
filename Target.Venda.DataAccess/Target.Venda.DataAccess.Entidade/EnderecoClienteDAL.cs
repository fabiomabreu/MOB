using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class EnderecoClienteDAL : EntidadeBaseDAL<EnderecoClienteMO>
{
	protected override Expression<Func<EnderecoClienteMO, bool>> GetWhere(Expression<Func<EnderecoClienteMO, bool>> whereClause, EnderecoClienteMO exemplo)
	{
		throw new NotImplementedException();
	}
}
