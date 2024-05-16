using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class TipoPedidoLocalBLL : EntidadeBaseBLL<TipoPedidoLocalMO>
{
	protected override EntidadeBaseDAL<TipoPedidoLocalMO> GetInstanceDAL()
	{
		return new TipoPedidoLocalDAL();
	}
}
