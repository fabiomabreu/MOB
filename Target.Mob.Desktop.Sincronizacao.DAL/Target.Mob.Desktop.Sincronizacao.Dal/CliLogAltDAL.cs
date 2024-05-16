using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class CliLogAltDAL
{
	private const string INSERT = "uspCliLogAltInsert";

	private const string UPDATE = "uspCliLogAltUpdate";

	private const string DELETE = "uspCliLogAltDelete";

	private const string SELECT = "uspCliLogAltSelect";

	private const string EXISTS = "uspCliLogAltExists";

	public static void Insert(DbConnection connection, CliLogAltTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_usuario", instance.CdUsuario);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@tp_log", instance.TpLog);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliLogAltInsert");
	}

	public static void Update(DbConnection connection, CliLogAltTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_log", instance.SeqLog);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_usuario", instance.CdUsuario);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@tp_log", instance.TpLog);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCliLogAltUpdate");
	}

	public static void Delete(DbConnection connection, CliLogAltTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_log", instance.SeqLog);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCliLogAltDelete");
	}

	public static CliLogAltTO[] Select(DbConnection connection, int? SeqLog, int? CdClien, int? CdEmp, string CdUsuario, DateTime? Data, string TpLog, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_log", SeqLog);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_usuario", CdUsuario);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@tp_log", TpLog);
		connection.AddParameters("@cd_texto", CdTexto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCliLogAltSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqLog, int? CdClien, int? CdEmp, string CdUsuario, DateTime? Data, string TpLog, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_log", SeqLog);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_usuario", CdUsuario);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@tp_log", TpLog);
		connection.AddParameters("@cd_texto", CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliLogAltExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static CliLogAltTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CliLogAltTO cliLogAltTO = new CliLogAltTO();
				cliLogAltTO.SeqLog = rs.GetInteger("seq_log");
				cliLogAltTO.CdClien = rs.GetInteger("cd_clien");
				cliLogAltTO.CdEmp = rs.GetInteger("cd_emp");
				cliLogAltTO.CdUsuario = rs.GetString("cd_usuario");
				cliLogAltTO.Data = rs.GetDateTime("data");
				cliLogAltTO.TpLog = rs.GetString("tp_log");
				cliLogAltTO.CdTexto = rs.GetInteger("cd_texto");
				arrayList.Add(cliLogAltTO);
			}
		}
		return (CliLogAltTO[])arrayList.ToArray(typeof(CliLogAltTO));
	}
}
