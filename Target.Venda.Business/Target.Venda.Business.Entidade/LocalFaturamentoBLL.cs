using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class LocalFaturamentoBLL : EntidadeBaseBLL<LocalFaturamentoMO>
{
	protected override EntidadeBaseDAL<LocalFaturamentoMO> GetInstanceDAL()
	{
		return new LocalFaturamentoDAL();
	}
}
