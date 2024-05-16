using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

internal static class SeqCliBLL
{
	internal static SeqCliTO Select(DbConnection connection)
	{
		return SeqCliDAL.Select(connection)[0];
	}
}
