using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class CliEmpFormPgtoBLL
{
	public static int IsPrincipal(DbConnection connection, int? CdEmpEle, int? CdClien, string Formpgto)
	{
		if (CliEmpFormPgtoDAL.Exists(connection, CdEmpEle, CdClien, Formpgto))
		{
			return 1;
		}
		return 0;
	}
}
