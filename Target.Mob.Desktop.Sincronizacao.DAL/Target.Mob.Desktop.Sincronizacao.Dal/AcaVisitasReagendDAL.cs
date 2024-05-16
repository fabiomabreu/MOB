using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AcaVisitasReagendDAL
{
	private const string INSERT = "uspAcaVisitasReagendInsert";

	private const string UPDATE = "uspAcaVisitasReagendUpdate";

	private const string DELETE = "uspAcaVisitasReagendDelete";

	private const string SELECT = "uspAcaVisitasReagendSelect";

	private const string EXISTS = "uspAcaVisitasReagendExists";

	private const string COUNT = "uspAcaVisitasReagendCount";

	public static void Insert(DbConnection connection, AcaVisitasReagendTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@dt_visita", instance.DtVisita);
		connection.AddParameters("@hr_visita", instance.HrVisita);
		connection.AddParameters("@cd_tp_freq_visita", instance.CdTpFreqVisita);
		connection.AddParameters("@qtde_dias_freq_visita", instance.QtdeDiasFreqVisita);
		connection.AddParameters("@reagendado", instance.Reagendado);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaVisitasReagendInsert");
		instance.SeqVisita = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, AcaVisitasReagendTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_visita", instance.SeqVisita);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@dt_visita", instance.DtVisita);
		connection.AddParameters("@hr_visita", instance.HrVisita);
		connection.AddParameters("@cd_tp_freq_visita", instance.CdTpFreqVisita);
		connection.AddParameters("@qtde_dias_freq_visita", instance.QtdeDiasFreqVisita);
		connection.AddParameters("@reagendado", instance.Reagendado);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaVisitasReagendUpdate");
	}

	public static void Delete(DbConnection connection, AcaVisitasReagendTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_visita", instance.SeqVisita);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaVisitasReagendDelete");
	}

	public static AcaVisitasReagendTO[] Select(DbConnection connection, int? SeqVisita)
	{
		return Select(connection, SeqVisita, null, null, null, null, null, null, null);
	}

	public static AcaVisitasReagendTO[] Select(DbConnection connection, int? SeqVisita, string CdVend, int? CdClien, DateTime? DtVisita, string HrVisita, string CdTpFreqVisita, int? QtdeDiasFreqVisita, int? Reagendado)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_visita", SeqVisita);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_visita", DtVisita);
		connection.AddParameters("@hr_visita", HrVisita);
		connection.AddParameters("@cd_tp_freq_visita", CdTpFreqVisita);
		connection.AddParameters("@qtde_dias_freq_visita", QtdeDiasFreqVisita);
		connection.AddParameters("@reagendado", Reagendado);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAcaVisitasReagendSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqVisita, string CdVend, int? CdClien, DateTime? DtVisita, string HrVisita, string CdTpFreqVisita, int? QtdeDiasFreqVisita, int? Reagendado)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_visita", SeqVisita);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_visita", DtVisita);
		connection.AddParameters("@hr_visita", HrVisita);
		connection.AddParameters("@cd_tp_freq_visita", CdTpFreqVisita);
		connection.AddParameters("@qtde_dias_freq_visita", QtdeDiasFreqVisita);
		connection.AddParameters("@reagendado", Reagendado);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaVisitasReagendExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, DateTime DtVisita, string HrVisita, string CdTpFreqVisita, int QtdeDiasFreqVisita, int Reagendado)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_visita", DtVisita);
		connection.AddParameters("@hr_visita", HrVisita);
		connection.AddParameters("@cd_tp_freq_visita", CdTpFreqVisita);
		connection.AddParameters("@qtde_dias_freq_visita", QtdeDiasFreqVisita);
		connection.AddParameters("@reagendado", Reagendado);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaVisitasReagendCount"));
	}

	private static AcaVisitasReagendTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AcaVisitasReagendTO acaVisitasReagendTO = new AcaVisitasReagendTO();
				acaVisitasReagendTO.SeqVisita = rs.GetInteger("seq_visita");
				acaVisitasReagendTO.CdVend = rs.GetString("cd_vend");
				acaVisitasReagendTO.CdClien = rs.GetInteger("cd_clien");
				acaVisitasReagendTO.DtVisita = rs.GetNullableDateTime("dt_visita");
				acaVisitasReagendTO.HrVisita = rs.GetString("hr_visita");
				acaVisitasReagendTO.CdTpFreqVisita = rs.GetString("cd_tp_freq_visita");
				acaVisitasReagendTO.QtdeDiasFreqVisita = rs.GetNullableInteger("qtde_dias_freq_visita");
				acaVisitasReagendTO.Reagendado = rs.GetNullableInteger("reagendado");
				arrayList.Add(acaVisitasReagendTO);
			}
		}
		return (AcaVisitasReagendTO[])arrayList.ToArray(typeof(AcaVisitasReagendTO));
	}
}
