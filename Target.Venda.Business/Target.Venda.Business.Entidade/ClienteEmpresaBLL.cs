using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ClienteEmpresaBLL : EntidadeBaseBLL<ClienteEmpresaMO>
{
	protected override EntidadeBaseDAL<ClienteEmpresaMO> GetInstanceDAL()
	{
		return new ClienteEmpresaDAL();
	}
}
