using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class LinTxtLogBLL
{
	public static LinTxtLogTO[] Select(DbConnection connection, int? CdTextoOrig)
	{
		LinTxtLogTO[] array = LinTxtLogDAL.Select(connection, CdTextoOrig);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, LinTxtLogTO LinTxtLog)
	{
		LinTxtLogDAL.Insert(connection, LinTxtLog);
	}
}
