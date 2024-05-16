using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ItPedvEleBLL
{
	public static ItPedvEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		ItPedvEleTO[] array = ItPedvEleDAL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
