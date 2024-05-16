using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TabPreBLL
{
	public static TabPreTO[] Select(DbConnection connection, string CdTabela, string Descricao, bool? Ativo)
	{
		TabPreTO[] array = TabPreDAL.Select(connection, CdTabela, Descricao, Ativo);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static TabPreTO[] Select(DbConnection connection, string CdTabela, string Descricao, bool? Ativo, byte[] RowId)
	{
		TabPreTO[] array = TabPreDAL.Select(connection, CdTabela, Descricao, Ativo, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
