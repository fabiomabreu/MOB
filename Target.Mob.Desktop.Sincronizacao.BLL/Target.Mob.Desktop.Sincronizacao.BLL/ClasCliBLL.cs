using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ClasCliBLL
{
	public static ClasCliTO[] Select(DbConnection connection, int? CdClien)
	{
		ClasCliTO[] array = ClasCliDAL.Select(connection, CdClien);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static ClasCliTO[] SelectNewCustomer(DbConnection connection)
	{
		ClasCliTO[] array = ClasCliDAL.SelectNewCustomer(connection);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, ClasCliTO ClasCli)
	{
		ClasCliDAL.Insert(connection, ClasCli);
	}
}
