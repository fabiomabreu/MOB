using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class TelCliDAL
{
	private const string INSERT = "uspTelCliInsert";

	private const string UPDATE = "uspTelCliUpdate";

	private const string DELETE = "uspTelCliDelete";

	private const string DELETE_CLIENTE = "uspTelCliDeleteCliente";

	private const string SELECT = "uspTelCliSelect";

	private const string EXISTS = "uspTelCliExists";

	public static void Insert(DbConnection connection, TelCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@tp_tel", instance.TpTel);
		connection.AddParameters("@ddd", instance.Ddd);
		connection.AddParameters("@numero", instance.Numero);
		connection.AddParameters("@compl", instance.Compl);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspTelCliInsert");
		instance.Seq = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, TelCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@tp_tel", instance.TpTel);
		connection.AddParameters("@ddd", instance.Ddd);
		connection.AddParameters("@numero", instance.Numero);
		connection.AddParameters("@compl", instance.Compl);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTelCliUpdate");
	}

	public static void Delete(DbConnection connection, TelCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTelCliDelete");
	}

	public static void Delete(DbConnection connection, int cdClien)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", cdClien);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspTelCliDeleteCliente");
	}

	public static TelCliTO[] Select(DbConnection connection, int? CdClien)
	{
		return Select(connection, CdClien, null, null, null, null, null);
	}

	public static TelCliTO[] Select(DbConnection connection, int? CdClien, int? Seq)
	{
		return Select(connection, CdClien, Seq, null, null, null, null);
	}

	public static TelCliTO[] Select(DbConnection connection, int? CdClien, int? Seq, string TpTel, string Ddd, int? Numero, int? Compl)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@tp_tel", TpTel);
		connection.AddParameters("@ddd", Ddd);
		connection.AddParameters("@numero", Numero);
		connection.AddParameters("@compl", Compl);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTelCliSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdClien, int? Seq, string TpTel, string Ddd, int? Numero, int? Compl)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@tp_tel", TpTel);
		connection.AddParameters("@ddd", Ddd);
		connection.AddParameters("@numero", Numero);
		connection.AddParameters("@compl", Compl);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspTelCliExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static TelCliTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TelCliTO telCliTO = new TelCliTO();
				telCliTO.CdClien = rs.GetInteger("cd_clien");
				telCliTO.Seq = rs.GetInteger("seq");
				telCliTO.TpTel = rs.GetString("tp_tel");
				telCliTO.Ddd = rs.GetString("ddd");
				telCliTO.Numero = rs.GetLong("numero");
				telCliTO.Compl = rs.GetNullableInteger("compl");
				arrayList.Add(telCliTO);
			}
		}
		return (TelCliTO[])arrayList.ToArray(typeof(TelCliTO));
	}
}
