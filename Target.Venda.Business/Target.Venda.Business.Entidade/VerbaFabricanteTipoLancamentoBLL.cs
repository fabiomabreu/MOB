using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class VerbaFabricanteTipoLancamentoBLL : EntidadeBaseBLL<VerbaFabricanteTipoLancamentoMO>
{
	protected override EntidadeBaseDAL<VerbaFabricanteTipoLancamentoMO> GetInstanceDAL()
	{
		return new VerbaFabricanteTipoLancamentoDAL();
	}
}
