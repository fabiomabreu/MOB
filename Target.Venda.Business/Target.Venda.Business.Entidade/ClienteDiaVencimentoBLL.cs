using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ClienteDiaVencimentoBLL : EntidadeBaseBLL<ClienteDiaVencimentoMO>
{
	protected override EntidadeBaseDAL<ClienteDiaVencimentoMO> GetInstanceDAL()
	{
		return new ClienteDiaVencimentoDAL();
	}
}
