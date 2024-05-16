using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

internal static class SeqTxtBLL
{
	internal static SeqTxtTO Select(DbConnection connection)
	{
		return SeqTxtDAL.Select(connection)[0];
	}
}
