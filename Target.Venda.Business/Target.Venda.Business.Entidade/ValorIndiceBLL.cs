using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ValorIndiceBLL : EntidadeBaseBLL<ValorIndiceMO>
{
	protected override EntidadeBaseDAL<ValorIndiceMO> GetInstanceDAL()
	{
		return new ValorIndiceDAL();
	}
}
