using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

internal static class SeqTxtLogBLL
{
	public static SeqTxtLogTO Select(DbConnection connection)
	{
		return SeqTxtLogDAL.Select(connection)[0];
	}
}
