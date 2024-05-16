using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class TelCliBLL
{
	public static TelCliTO[] Select(DbConnection connection, int? CdClien)
	{
		TelCliTO[] array = TelCliDAL.Select(connection, CdClien);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, TelCliTO TelCli)
	{
		TelCliDAL.Insert(connection, TelCli);
	}

	public static void Update(DbConnection connection, TelCliTO TelCli)
	{
		TelCliDAL.Update(connection, TelCli);
	}

	public static void Delete(DbConnection connTargetErp, int cdClien)
	{
		TelCliDAL.Delete(connTargetErp, cdClien);
	}
}
