using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EnderecoPedidoEletronicoBLL : EntidadeBaseBLL<EnderecoPedidoEletronicoMO>
{
	protected override EntidadeBaseDAL<EnderecoPedidoEletronicoMO> GetInstanceDAL()
	{
		return new EnderecoPedidoEletronicoDAL();
	}
}
