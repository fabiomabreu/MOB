using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ClienteEmpresaFormaPagamentoBLL : EntidadeBaseBLL<ClienteEmpresaFormaPagamentoMO>
{
	protected override EntidadeBaseDAL<ClienteEmpresaFormaPagamentoMO> GetInstanceDAL()
	{
		return new ClienteEmpresaFormaPagamentoDAL();
	}
}
