using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class PendEleLogBLL
{
	public static PendEleLogTO Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, int? SeqPed)
	{
		PendEleLogTO[] array = PendEleLogDAL.Select(connection, CdEmpEle, NuPedEle, SeqPed);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array[0];
	}

	public static PendEleLogTO Select(DbConnection connection, int? idProc)
	{
		PendEleLogTO[] array = PendEleLogDAL.Select(connection, null, null, null, null, null, null, idProc, null);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array[0];
	}

	public static PendEleLogTO[] Select(DbConnection connection, bool processando, bool falha)
	{
		PendEleLogTO[] array = PendEleLogDAL.Select(connection, processando, falha);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, PendEleLogTO PendEleLog)
	{
		PendEleLogDAL.Insert(connection, PendEleLog);
	}
}
