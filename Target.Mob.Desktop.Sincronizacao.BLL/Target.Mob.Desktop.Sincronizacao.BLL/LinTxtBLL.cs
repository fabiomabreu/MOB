using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class LinTxtBLL
{
	public static LinTxtTO[] Select(DbConnection connection, int? CdTexto)
	{
		LinTxtTO[] array = LinTxtDAL.Select(connection, CdTexto);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, LinTxtTO LinTxt)
	{
		LinTxtDAL.Insert(connection, LinTxt);
	}
}
