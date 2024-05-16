using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class LinTxtLogDAL
{
	private const string INSERT = "uspLinTxtLogInsert";

	private const string UPDATE = "uspLinTxtLogUpdate";

	private const string DELETE = "uspLinTxtLogDelete";

	private const string SELECT = "uspLinTxtLogSelect";

	private const string EXISTS = "uspLinTxtLogExists";

	public static void Insert(DbConnection connection, LinTxtLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto_log", instance.CdTextoLog);
		connection.AddParameters("@num_lin", instance.NumLin);
		connection.AddParameters("@cd_texto_orig", instance.CdTextoOrig);
		connection.AddParameters("@texto", instance.Texto);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@cd_usuario", instance.CdUsuario);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspLinTxtLogInsert");
	}

	public static void Update(DbConnection connection, LinTxtLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto_log", instance.CdTextoLog);
		connection.AddParameters("@num_lin", instance.NumLin);
		connection.AddParameters("@cd_texto_orig", instance.CdTextoOrig);
		connection.AddParameters("@texto", instance.Texto);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@cd_usuario", instance.CdUsuario);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLinTxtLogUpdate");
	}

	public static void Delete(DbConnection connection, LinTxtLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto_log", instance.CdTextoLog);
		connection.AddParameters("@num_lin", instance.NumLin);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLinTxtLogDelete");
	}

	public static LinTxtLogTO[] Select(DbConnection connection, int? CdTextoOrig)
	{
		return Select(connection, null, null, CdTextoOrig, null, null, null);
	}

	public static LinTxtLogTO[] Select(DbConnection connection, int? CdTextoLog, int? NumLin)
	{
		return Select(connection, CdTextoLog, NumLin, null, null, null, null);
	}

	public static LinTxtLogTO[] Select(DbConnection connection, int? CdTextoLog, int? NumLin, int? CdTextoOrig, string Texto, DateTime? Data, string CdUsuario)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto_log", CdTextoLog);
		connection.AddParameters("@num_lin", NumLin);
		connection.AddParameters("@cd_texto_orig", CdTextoOrig);
		connection.AddParameters("@texto", Texto);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@cd_usuario", CdUsuario);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspLinTxtLogSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdTextoLog, int? NumLin, int? CdTextoOrig, string Texto, DateTime? Data, string CdUsuario)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto_log", CdTextoLog);
		connection.AddParameters("@num_lin", NumLin);
		connection.AddParameters("@cd_texto_orig", CdTextoOrig);
		connection.AddParameters("@texto", Texto);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@cd_usuario", CdUsuario);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspLinTxtLogExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static LinTxtLogTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				LinTxtLogTO linTxtLogTO = new LinTxtLogTO();
				linTxtLogTO.CdTextoLog = rs.GetInteger("cd_texto_log");
				linTxtLogTO.NumLin = rs.GetInteger("num_lin");
				linTxtLogTO.CdTextoOrig = rs.GetInteger("cd_texto_orig");
				linTxtLogTO.Texto = rs.GetString("texto");
				linTxtLogTO.Data = rs.GetDateTime("data");
				linTxtLogTO.CdUsuario = rs.GetString("cd_usuario");
				arrayList.Add(linTxtLogTO);
			}
		}
		return (LinTxtLogTO[])arrayList.ToArray(typeof(LinTxtLogTO));
	}
}
