using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EventoAlteracaoPrecoBLL : EntidadeBaseBLL<EventoAlteracaoPrecoMO>
{
	protected override EntidadeBaseDAL<EventoAlteracaoPrecoMO> GetInstanceDAL()
	{
		return new EventoAlteracaoPrecoDAL();
	}
}
