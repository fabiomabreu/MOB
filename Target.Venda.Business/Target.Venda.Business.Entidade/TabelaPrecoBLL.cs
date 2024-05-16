using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class TabelaPrecoBLL : EntidadeBaseBLL<TabelaPrecoMO>
{
	protected override EntidadeBaseDAL<TabelaPrecoMO> GetInstanceDAL()
	{
		return new TabelaPrecoDAL();
	}
}
