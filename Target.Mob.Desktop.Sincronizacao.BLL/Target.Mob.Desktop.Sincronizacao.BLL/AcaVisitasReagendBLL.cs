using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AcaVisitasReagendBLL
{
	public static AcaVisitasReagendTO[] Select(DbConnection connection, int? SeqVisita)
	{
		AcaVisitasReagendTO[] array = AcaVisitasReagendDAL.Select(connection, SeqVisita);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, AcaVisitasReagendTO AcaVisitasReagend)
	{
		AcaVisitasReagendDAL.Insert(connection, AcaVisitasReagend);
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, DateTime DtVisita, string HrVisita, string CdTpFreqVisita, int QtdeDiasFreqVisita, int Reagendado)
	{
		return AcaVisitasReagendDAL.Count(connection, CdVend, CdClien, DtVisita, HrVisita, CdTpFreqVisita, QtdeDiasFreqVisita, Reagendado);
	}
}
