using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class MotivoLancamentoVerbaBLL : EntidadeBaseBLL<MotivoLancamentoVerbaMO>
{
	protected override EntidadeBaseDAL<MotivoLancamentoVerbaMO> GetInstanceDAL()
	{
		return new MotivoLancamentoVerbaDAL();
	}
}
