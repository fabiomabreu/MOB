using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ObsPedEleBLL
{
	public static ObsPedEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		ObsPedEleTO[] array = ObsPedEleDAL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, ObsPedEleTO ObsPedEle)
	{
		ObsPedEleDAL.Insert(connection, ObsPedEle);
	}
}
