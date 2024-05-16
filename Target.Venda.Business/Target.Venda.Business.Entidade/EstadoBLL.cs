using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EstadoBLL : EntidadeBaseBLL<EstadoMO>
{
	protected override EntidadeBaseDAL<EstadoMO> GetInstanceDAL()
	{
		return new EstadoDAL();
	}
}
