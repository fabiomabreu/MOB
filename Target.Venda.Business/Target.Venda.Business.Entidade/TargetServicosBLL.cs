using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class TargetServicosBLL : EntidadeBaseBLL<TargetServicosMO>
{
	protected override EntidadeBaseDAL<TargetServicosMO> GetInstanceDAL()
	{
		return new TargetServicosDAL();
	}

	public TargetServicosMO ObterTargetServicosPeloId(int TargetServicosID)
	{
		return BaseDAL.ObterUnicoPeloExemplo(new TargetServicosMO
		{
			TargetServicosID = TargetServicosID
		});
	}
}
