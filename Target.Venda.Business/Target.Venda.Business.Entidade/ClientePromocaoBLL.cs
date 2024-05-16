using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ClientePromocaoBLL : EntidadeBaseBLL<ClientePromocaoMO>
{
	protected override EntidadeBaseDAL<ClientePromocaoMO> GetInstanceDAL()
	{
		return new ClientePromocaoDAL();
	}
}
