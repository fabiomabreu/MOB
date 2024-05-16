using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class LinhaBLL
{
	public static LinhaTO[] Select(DbConnection connection, string CdLinha, string Descricao, bool? Ativo, bool? EnvioPalmTop, string CdCategPrd, byte[] RowId)
	{
		LinhaTO[] array = LinhaDAL.Select(connection, CdLinha, Descricao, Ativo, EnvioPalmTop, CdCategPrd, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
