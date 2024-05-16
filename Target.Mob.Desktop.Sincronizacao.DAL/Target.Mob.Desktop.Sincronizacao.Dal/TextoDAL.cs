using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class TextoDAL
{
	private const string INSERT = "uspTextoInsert";

	private const string UPDATE = "uspTextoUpdate";

	private const string DELETE = "uspTextoDelete";

	private const string SELECT = "uspTextoSelect";

	private const string EXISTS = "uspTextoExists";

	public static void Insert(DbConnection connection, TextoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspTextoInsert");
	}

	public static int GeraSeq(DbConnection connection)
	{
		return DbUtils.GeraSeq(connection, "seq_txt");
	}

	public static void Update(DbConnection connection, TextoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTextoUpdate");
	}

	public static void Delete(DbConnection connection, TextoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTextoDelete");
	}

	public static TextoTO[] Select(DbConnection connection, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", CdTexto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTextoSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_texto", CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspTextoExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static TextoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TextoTO textoTO = new TextoTO();
				textoTO.CdTexto = rs.GetInteger("cd_texto");
				arrayList.Add(textoTO);
			}
		}
		return (TextoTO[])arrayList.ToArray(typeof(TextoTO));
	}
}
