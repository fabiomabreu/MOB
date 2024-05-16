using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TpPedBLL
{
	public static TpPedTO[] Select(DbConnection connection, TpPedTO tpPed)
	{
		TpPedTO[] array = TpPedDAL.Select(connection, tpPed);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
