using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AcaVisitasBLL
{
	public static AcaVisitasTO[] Select(DbConnection connection, int? SeqVisita)
	{
		AcaVisitasTO[] array = AcaVisitasDAL.Select(connection, SeqVisita);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static bool ExistsVisita(DbConnection connection, string CdVend, int CdClien, DateTime DtVisita)
	{
		return AcaVisitasDAL.ExistsVisita(connection, CdVend, CdClien, DtVisita);
	}

	public static void InsertVisita(DbConnection connection, string pCdVend, int pCdClien, DateTime pDtVisita, int pSeqVisitaAlterada, string pHora, int? FrequenciaVisitaID, string CdTpFreqVisita)
	{
		AcaVisitasDAL.InsertVisita(connection, pCdVend, pCdClien, pDtVisita, pSeqVisitaAlterada, pHora, FrequenciaVisitaID, CdTpFreqVisita);
	}

	public static void ExcluirVisita(DbConnection connection, DateTime DtExclusao, int SeqVisita)
	{
		AcaVisitasDAL.ExcluirVisita(connection, DtExclusao, SeqVisita);
	}

	public static AcaVisitasTO[] SelectExport(DbConnection connTargetErp, byte[] RowId)
	{
		return AcaVisitasDAL.SelectExport(connTargetErp, RowId);
	}
}
