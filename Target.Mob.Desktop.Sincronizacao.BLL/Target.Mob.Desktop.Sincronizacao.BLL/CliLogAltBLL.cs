using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class CliLogAltBLL
{
	public static CliLogAltTO[] Select(DbConnection connection, int? CdClien)
	{
		CliLogAltTO[] array = CliLogAltDAL.Select(connection, null, CdClien, null, null, null, null, null);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, CliLogAltTO CliLogAlt)
	{
		CliLogAltDAL.Insert(connection, CliLogAlt);
	}
}
