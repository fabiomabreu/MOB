using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class LocalBLL
{
	public static LocalTO[] Select(DbConnection connection, int? CdEmp, string CdLocal, bool? Ativo)
	{
		LocalTO[] array = LocalDAL.Select(connection, CdEmp, CdLocal, Ativo);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static LocalTO[] Select(DbConnection connection, int? CdEmp, string CdLocal, bool? Ativo, byte[] RowId)
	{
		LocalTO[] array = LocalDAL.Select(connection, CdEmp, CdLocal, Ativo, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
