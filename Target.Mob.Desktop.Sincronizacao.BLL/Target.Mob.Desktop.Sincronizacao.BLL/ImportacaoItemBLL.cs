using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ImportacaoItemBLL
{
	public static ImportacaoItemTO[] Select(DbConnection connection, int Id)
	{
		ImportacaoItemTO[] array = ImportacaoItemDAL.Select(connection, Id);
		if (array != null)
		{
			ImportacaoItemTO[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].oImportacaoLogErro = ImportacaoLogErroBLL.Select(connection, Id);
			}
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, ImportacaoItemTO item)
	{
		ImportacaoItemDAL.Insert(connection, item);
	}
}
