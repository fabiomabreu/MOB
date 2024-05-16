using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class VendedorClienteBLL : EntidadeBaseBLL<VendedorClienteMO>
{
	protected override EntidadeBaseDAL<VendedorClienteMO> GetInstanceDAL()
	{
		return new VendedorClienteDAL();
	}
}
