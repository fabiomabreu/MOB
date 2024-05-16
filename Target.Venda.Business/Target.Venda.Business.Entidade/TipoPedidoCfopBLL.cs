using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class TipoPedidoCfopBLL : EntidadeBaseBLL<TipoPedidoCfopMO>
{
	protected override EntidadeBaseDAL<TipoPedidoCfopMO> GetInstanceDAL()
	{
		return new TipoPedidoCfopDAL();
	}
}
