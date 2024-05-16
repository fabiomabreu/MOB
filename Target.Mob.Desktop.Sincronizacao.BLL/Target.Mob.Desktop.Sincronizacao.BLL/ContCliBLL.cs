using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ContCliBLL
{
	public static ContCliTO[] Select(DbConnection connection, int? CdClien)
	{
		ContCliTO[] array = ContCliDAL.Select(connection, CdClien);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, ContCliTO ContCli)
	{
		ContCliDAL.Insert(connection, ContCli);
	}

	public static void Update(DbConnection connection, ContCliTO ContCli)
	{
		ContCliDAL.Update(connection, ContCli);
	}

	public static void Delete(DbConnection connection, ContCliTO ContCli)
	{
		ContCliDAL.Delete(connection, ContCli);
	}

	public static void Delete(DbConnection connTargetErp, int cdClien)
	{
		ContCliDAL.Delete(connTargetErp, cdClien);
	}
}
