using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class EventoPdelBLL
{
	public static EventoPdelTO Select(DbConnection connection, int? SeqEvento)
	{
		return EventoPdelDAL.Select(connection, SeqEvento)[0];
	}

	internal static void Insert(DbConnection connection, EventoPdelTO EventoPdel)
	{
		EventoPdelDAL.Insert(connection, EventoPdel);
	}
}
