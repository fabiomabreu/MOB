using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class TributacaoClienteBLL : EntidadeBaseBLL<TributacaoClienteMO>
{
	protected override EntidadeBaseDAL<TributacaoClienteMO> GetInstanceDAL()
	{
		return new TributacaoClienteDAL();
	}
}
