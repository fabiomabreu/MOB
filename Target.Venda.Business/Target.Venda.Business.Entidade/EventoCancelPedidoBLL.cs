using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EventoCancelPedidoBLL : EntidadeBaseBLL<EventoCancelPedidoMO>
{
	protected override EntidadeBaseDAL<EventoCancelPedidoMO> GetInstanceDAL()
	{
		return new EventoCancelPedidoDAL();
	}
}
