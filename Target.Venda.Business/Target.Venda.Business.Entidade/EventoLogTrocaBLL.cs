using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EventoLogTrocaBLL : EntidadeBaseBLL<EventoLogTrocaMO>
{
	protected override EntidadeBaseDAL<EventoLogTrocaMO> GetInstanceDAL()
	{
		return new EventoLogTrocaDAL();
	}
}
