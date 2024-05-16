using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AcaNaoVisitaBLL
{
	public static AcaNaoVisitaTO[] Select(DbConnection connection, int? Seq)
	{
		AcaNaoVisitaTO[] array = AcaNaoVisitaDAL.Select(connection, Seq);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, AcaNaoVisitaTO AcaNaoVisita)
	{
		AcaNaoVisitaDAL.Insert(connection, AcaNaoVisita);
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, string CdMotivo, DateTime Data)
	{
		return AcaNaoVisitaDAL.Count(connection, CdVend, CdClien, CdMotivo, Data);
	}
}
