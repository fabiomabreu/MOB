using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class FabricBLL
{
	public static FabricTO[] Select(DbConnection connection, string CdFabric, string Descricao, bool? Ativo, bool? EnvioPalmTop, byte[] RowId)
	{
		FabricTO[] array = FabricDAL.Select(connection, CdFabric, Descricao, Ativo, EnvioPalmTop, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
