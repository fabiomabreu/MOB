using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class TargetServicosBLL
{
	public static TargetServicosTO Select(DbConnection connTargetErp, int IdServico)
	{
		return TargetServicosDAL.Select(connTargetErp, IdServico);
	}
}
