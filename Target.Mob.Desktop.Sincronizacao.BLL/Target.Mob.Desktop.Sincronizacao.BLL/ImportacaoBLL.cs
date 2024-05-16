using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ImportacaoBLL
{
	public static ImportacaoTO[] Select(DbConnection connection, int Id)
	{
		ImportacaoTO[] array = ImportacaoDAL.Select(connection, Id);
		if (array != null)
		{
			ImportacaoTO[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].oImportacaoItem = ImportacaoItemBLL.Select(connection, Id);
			}
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, ImportacaoTO imp)
	{
		ImportacaoDAL.Insert(connection, imp);
	}
}
