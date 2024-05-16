using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TpCustoBLL
{
	public static TpCustoTO[] Select(DbConnection connection, string TpCusto, string Descricao, bool? Contabil)
	{
		TpCustoTO[] array = TpCustoDAL.Select(connection, TpCusto, Descricao, Contabil);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static TpCustoTO[] Select(DbConnection connection, string TpCusto, string Descricao, bool? Contabil, byte[] RowId)
	{
		TpCustoTO[] array = TpCustoDAL.Select(connection, TpCusto, Descricao, Contabil, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
