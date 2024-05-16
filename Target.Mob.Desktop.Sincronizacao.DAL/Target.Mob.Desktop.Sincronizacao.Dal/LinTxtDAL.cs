using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class LinTxtDAL
{
	private const string INSERT = "uspLinTxtInsert";

	private const string UPDATE = "uspLinTxtUpdate";

	private const string DELETE = "uspLinTxtDelete";

	private const string SELECT = "uspLinTxtSelect";

	private const string EXISTS = "uspLinTxtExists";

	public static void Insert(DbConnection connection, LinTxtTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.AddParameters("@num_lin", instance.NumLin);
		connection.AddParameters("@texto", instance.Texto);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspLinTxtInsert");
	}

	public static void Update(DbConnection connection, LinTxtTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.AddParameters("@num_lin", instance.NumLin);
		connection.AddParameters("@texto", instance.Texto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLinTxtUpdate");
	}

	public static void Delete(DbConnection connection, LinTxtTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.AddParameters("@num_lin", instance.NumLin);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLinTxtDelete");
	}

	public static LinTxtTO[] Select(DbConnection connection, int? CdTexto)
	{
		return Select(connection, CdTexto, null, null);
	}

	public static LinTxtTO[] Select(DbConnection connection, int? CdTexto, int? NumLin)
	{
		return Select(connection, CdTexto, NumLin, null);
	}

	public static LinTxtTO[] Select(DbConnection connection, int? CdTexto, int? NumLin, string Texto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", CdTexto);
		connection.AddParameters("@num_lin", NumLin);
		connection.AddParameters("@texto", Texto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspLinTxtSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdTexto, int? NumLin, string Texto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", CdTexto);
		connection.AddParameters("@num_lin", NumLin);
		connection.AddParameters("@texto", Texto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspLinTxtExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static LinTxtTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				LinTxtTO linTxtTO = new LinTxtTO();
				linTxtTO.CdTexto = rs.GetInteger("cd_texto");
				linTxtTO.NumLin = rs.GetInteger("num_lin");
				linTxtTO.Texto = rs.GetString("texto");
				arrayList.Add(linTxtTO);
			}
		}
		return (LinTxtTO[])arrayList.ToArray(typeof(LinTxtTO));
	}
}
