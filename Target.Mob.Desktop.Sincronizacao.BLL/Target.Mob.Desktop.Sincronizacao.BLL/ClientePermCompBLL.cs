using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ClientePermCompBLL
{
	public static ClientePermCompTO[] Select(DbConnection connection, int? CdClien)
	{
		ClientePermCompTO[] array = ClientePermCompDAL.Select(connection, CdClien);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, ClientePermCompTO ClientePermComp)
	{
		ClientePermCompDAL.Insert(connection, ClientePermComp);
	}
}
