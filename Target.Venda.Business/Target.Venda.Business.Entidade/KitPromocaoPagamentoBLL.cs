using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class KitPromocaoPagamentoBLL : EntidadeBaseBLL<KitPromocaoPagamentoMO>
{
	protected override EntidadeBaseDAL<KitPromocaoPagamentoMO> GetInstanceDAL()
	{
		return new KitPromocaoPagamentoDAL();
	}
}
