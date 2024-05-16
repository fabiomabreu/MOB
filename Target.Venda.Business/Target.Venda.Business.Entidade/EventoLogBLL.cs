using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EventoLogBLL : EntidadeBaseBLL<EventoLogMO>
{
	protected override EntidadeBaseDAL<EventoLogMO> GetInstanceDAL()
	{
		return new EventoLogDAL();
	}
}
