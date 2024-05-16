using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class PedVdaEleDuplicBLL
{
	public static PedVdaEleDuplicTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		PedVdaEleDuplicTO[] array = PedVdaEleDuplicDAL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, PedVdaEleDuplicTO PedVdaEleDuplic)
	{
		PedVdaEleDuplicDAL.Insert(connection, PedVdaEleDuplic);
	}
}
