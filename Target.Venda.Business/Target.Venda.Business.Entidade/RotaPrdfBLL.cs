using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class RotaPrdfBLL : EntidadeBaseBLL<RotaPrdfMO>
{
	protected override EntidadeBaseDAL<RotaPrdfMO> GetInstanceDAL()
	{
		return new RotaPrdfDAL();
	}
}
