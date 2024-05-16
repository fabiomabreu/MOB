using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class CdBarraUnprdBLL
{
	public static CdBarraUnprdTO[] Select(DbConnection connection, byte[] RowId)
	{
		CdBarraUnprdTO[] array = CdBarraUnprdDAL.Select(connection, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
