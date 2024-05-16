using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class EventoPdelDAL
{
	private const string INSERT = "uspEventoPdelInsert";

	private const string UPDATE = "uspEventoPdelUpdate";

	private const string DELETE = "uspEventoPdelDelete";

	private const string SELECT = "uspEventoPdelSelect";

	private const string EXISTS = "uspEventoPdelExists";

	public static void Insert(DbConnection connection, EventoPdelTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@cd_usr_ger", instance.CdUsrGer);
		connection.AddParameters("@cd_usr_enc", instance.CdUsrEnc);
		connection.AddParameters("@dt_encer", instance.DtEncer);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspEventoPdelInsert");
		instance.SeqEvento = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, EventoPdelTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", instance.SeqEvento);
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@cd_usr_ger", instance.CdUsrGer);
		connection.AddParameters("@dt_criacao", instance.DtCriacao);
		connection.AddParameters("@cd_usr_enc", instance.CdUsrEnc);
		connection.AddParameters("@dt_encer", instance.DtEncer);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoPdelUpdate");
	}

	public static void Delete(DbConnection connection, EventoPdelTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", instance.SeqEvento);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoPdelDelete");
	}

	public static EventoPdelTO[] Select(DbConnection connection, int? SeqEvento)
	{
		return Select(connection, SeqEvento, null, null, null, null, null, null, null, null);
	}

	public static EventoPdelTO[] Select(DbConnection connection, int? SeqEvento, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, string CdUsrGer, DateTime? DtCriacao, string CdUsrEnc, DateTime? DtEncer, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", SeqEvento);
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@cd_usr_ger", CdUsrGer);
		connection.AddParameters("@dt_criacao", DtCriacao);
		connection.AddParameters("@cd_usr_enc", CdUsrEnc);
		connection.AddParameters("@dt_encer", DtEncer);
		connection.AddParameters("@cd_texto", CdTexto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEventoPdelSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqEvento, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, string CdUsrGer, DateTime? DtCriacao, string CdUsrEnc, DateTime? DtEncer, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", SeqEvento);
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@cd_usr_ger", CdUsrGer);
		connection.AddParameters("@dt_criacao", DtCriacao);
		connection.AddParameters("@cd_usr_enc", CdUsrEnc);
		connection.AddParameters("@dt_encer", DtEncer);
		connection.AddParameters("@cd_texto", CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspEventoPdelExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static EventoPdelTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				EventoPdelTO eventoPdelTO = new EventoPdelTO();
				eventoPdelTO.SeqEvento = rs.GetInteger("seq_evento");
				eventoPdelTO.CdEmpEle = rs.GetInteger("cd_emp_ele");
				eventoPdelTO.NuPedEle = rs.GetInteger("nu_ped_ele");
				eventoPdelTO.SeqPed = rs.GetDecimal("seq_ped");
				eventoPdelTO.CdUsrGer = rs.GetString("cd_usr_ger");
				eventoPdelTO.DtCriacao = rs.GetDateTime("dt_criacao");
				eventoPdelTO.CdUsrEnc = rs.GetString("cd_usr_enc");
				eventoPdelTO.DtEncer = rs.GetNullableDateTime("dt_encer");
				eventoPdelTO.CdTexto = rs.GetNullableInteger("cd_texto");
				arrayList.Add(eventoPdelTO);
			}
		}
		return (EventoPdelTO[])arrayList.ToArray(typeof(EventoPdelTO));
	}
}
