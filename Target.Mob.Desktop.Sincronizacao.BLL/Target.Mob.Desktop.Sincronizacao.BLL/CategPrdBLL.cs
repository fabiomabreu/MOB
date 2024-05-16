using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class CategPrdBLL
{
	public static CategPrdTO[] Select(DbConnection connection, string CdCategPrd, string Descricao, bool? Ativo, bool? EnvioPalmTop, byte[] RowId)
	{
		CategPrdTO[] array = CategPrdDAL.Select(connection, CdCategPrd, Descricao, Ativo, EnvioPalmTop, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
