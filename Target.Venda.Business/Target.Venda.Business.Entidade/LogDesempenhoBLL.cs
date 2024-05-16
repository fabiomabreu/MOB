using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class LogDesempenhoBLL : EntidadeBaseBLL<LogDesempenhoMO>
{
	protected override EntidadeBaseDAL<LogDesempenhoMO> GetInstanceDAL()
	{
		return new LogDesempenhoDAL();
	}

	public int LogDesempenhoInicio(LogDesempenhoVO logDesempenho)
	{
		return (BaseDAL as LogDesempenhoDAL).LogDesempenhoInicio(logDesempenho);
	}

	public void LogDesempenhoFim(int pCodigoRetorno)
	{
		(BaseDAL as LogDesempenhoDAL).LogDesempenhoFim(pCodigoRetorno);
	}
}
