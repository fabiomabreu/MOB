using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ItTrocaBLL
{
	public static ItTrocaTO[] Select(DbConnection connection, int? SeqTroca)
	{
		ItTrocaTO[] array = ItTrocaDAL.Select(connection, SeqTroca);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, ItTrocaTO ItTroca)
	{
		ItTrocaDAL.Insert(connection, ItTroca);
	}
}
