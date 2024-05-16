using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ImportacaoLogErroBLL
{
	public static ImportacaoLogErroTO[] Select(DbConnection connection, int Id)
	{
		ImportacaoLogErroTO[] array = ImportacaoLogErroDAL.Select(connection, Id);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, ImportacaoLogErroTO logErro)
	{
		ImportacaoLogErroDAL.Insert(connection, logErro);
	}
}
