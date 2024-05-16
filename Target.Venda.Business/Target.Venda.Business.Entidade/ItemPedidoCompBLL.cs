using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ItemPedidoCompBLL : EntidadeBaseBLL<ItemPedidoCompMO>
{
	protected override EntidadeBaseDAL<ItemPedidoCompMO> GetInstanceDAL()
	{
		return new ItemPedidoCompDAL();
	}
}
