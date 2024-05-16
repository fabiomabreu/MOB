using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AcaVisitasDAL
{
	private const string SELECT = "uspAcaVisitasSelect";

	private const string SELECTEXPORT = "uspAcaVisitasSelectExport";

	private const string EXISTSVISITA = "uspAcaVisitasExistsVisita";

	private const string USPACAVISITASINCLUIR = "UspAcaVisitasIncluir";

	private const string USPACAVISITASEXCLUIR = "UspAcaVisitasExcluir";

	public static AcaVisitasTO[] SelectExport(DbConnection connection, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAcaVisitasSelectExport"));
	}

	public static AcaVisitasTO[] Select(DbConnection connection, int? SeqVisita)
	{
		return Select(connection, SeqVisita, null, null, null, null, null, null, null, null, null, null);
	}

	public static AcaVisitasTO[] Select(DbConnection connection, int? SeqVisita, string CdVend, int? CdClien, DateTime? DtVisita, string HrVisita, string CdTpFreqVisita, DateTime? DtUltVisita, byte[] RowId, bool? VisitaExcluida, int? FrequenciaVisitaID, bool? VisitaTelefonica)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_visita", SeqVisita);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_visita", DtVisita);
		connection.AddParameters("@hr_visita", HrVisita);
		connection.AddParameters("@dt_ult_visita", DtUltVisita);
		connection.AddParameters("@rowid", RowId);
		connection.AddParameters("@VisitaExcluida", VisitaExcluida);
		connection.AddParameters("@FrequenciaVisitaID", FrequenciaVisitaID);
		connection.AddParameters("@CdTpFreqVisita", CdTpFreqVisita);
		connection.AddParameters("@VisitaTelefonica", VisitaTelefonica);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAcaVisitasSelect"));
	}

	public static bool ExistsVisita(DbConnection connection, string CdVend, int? CdClien, DateTime? DtVisita)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_visita", DtVisita);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaVisitasExistsVisita");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static AcaVisitasTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AcaVisitasTO acaVisitasTO = new AcaVisitasTO();
				acaVisitasTO.SeqVisita = rs.GetInteger("seq_visita");
				acaVisitasTO.CdVend = rs.GetString("cd_vend");
				acaVisitasTO.CdClien = rs.GetInteger("cd_clien");
				acaVisitasTO.DtVisita = rs.GetDateTime("dt_visita");
				acaVisitasTO.HrVisita = rs.GetString("hr_visita");
				acaVisitasTO.VisitaExcluida = rs.GetNullableBoolean("VisitaExcluida");
				acaVisitasTO.DtUltVisita = rs.GetNullableDateTime("dt_ult_visita");
				acaVisitasTO.RowId = rs.GetArrayByte("rowid");
				acaVisitasTO.FrequenciaVisitaID = rs.GetNullableInteger("FrequenciaVisitaID");
				acaVisitasTO.OpcoesRota = rs.GetString("OpcoesRota");
				acaVisitasTO.VisitaTelefonica = rs.GetNullableBoolean("VisitaTelefonica");
				arrayList.Add(acaVisitasTO);
			}
		}
		return (AcaVisitasTO[])arrayList.ToArray(typeof(AcaVisitasTO));
	}

	public static void InsertVisita(DbConnection connection, string CdVend, int CdClien, DateTime DtVisita, int SeqVisitaAlterada, string Hora, int? FrequenciaVisitaID, string CdTpFreqVisita)
	{
		connection.ClearParameters();
		connection.AddParameters("@pCdVend", CdVend);
		connection.AddParameters("@pCdClien", CdClien);
		connection.AddParameters("@pDtVisita", DtVisita);
		connection.AddParameters("@pSeqVisitaAlterada", SeqVisitaAlterada);
		connection.AddParameters("@pHora", Hora);
		connection.AddParameters("@pFrequenciaVisitaID", FrequenciaVisitaID);
		connection.AddParameters("@pCdTpFreqVisita", CdTpFreqVisita);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "UspAcaVisitasIncluir");
	}

	public static void ExcluirVisita(DbConnection connection, DateTime DtExclusao, int SeqVisita)
	{
		connection.ClearParameters();
		connection.AddParameters("@pDtExclusao", DtExclusao);
		connection.AddParameters("@pSeqVisita", SeqVisita);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "UspAcaVisitasExcluir");
	}
}
