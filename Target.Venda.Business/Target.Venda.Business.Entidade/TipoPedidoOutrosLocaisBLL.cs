using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class TipoPedidoOutrosLocaisBLL : EntidadeBaseBLL<TipoPedidoOutrosLocaisMO>
{
	protected override EntidadeBaseDAL<TipoPedidoOutrosLocaisMO> GetInstanceDAL()
	{
		return new TipoPedidoOutrosLocaisDAL();
	}
}
