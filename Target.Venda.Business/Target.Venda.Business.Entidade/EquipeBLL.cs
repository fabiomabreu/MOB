using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EquipeBLL : EntidadeBaseBLL<EquipeMO>
{
	protected override EntidadeBaseDAL<EquipeMO> GetInstanceDAL()
	{
		return new EquipeDAL();
	}
}
