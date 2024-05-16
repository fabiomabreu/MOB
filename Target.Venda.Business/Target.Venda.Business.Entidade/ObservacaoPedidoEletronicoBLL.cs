using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ObservacaoPedidoEletronicoBLL : EntidadeBaseBLL<ObservacaoPedidoEletronicoMO>
{
	protected override EntidadeBaseDAL<ObservacaoPedidoEletronicoMO> GetInstanceDAL()
	{
		return new ObservacaoPedidoEletronicoDAL();
	}
}
