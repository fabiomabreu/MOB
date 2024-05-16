using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class VsControlBLL : EntidadeBaseBLL<VsControlMO>
{
	protected override EntidadeBaseDAL<VsControlMO> GetInstanceDAL()
	{
		return new VsControlDAL();
	}

	public bool ObterVsControl(int Ocorrencia, int Seq)
	{
		return (BaseDAL as VsControlDAL).BuscaVsControl(Ocorrencia, Seq);
	}
}
