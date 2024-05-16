using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ClientePermCompDAL
{
	private const string INSERT = "uspClientePermCompInsert";

	private const string UPDATE = "uspClientePermCompUpdate";

	private const string DELETE = "uspClientePermCompDelete";

	private const string SELECT = "uspClientePermCompSelect";

	private const string EXISTS = "uspClientePermCompExists";

	public static void Insert(DbConnection connection, ClientePermCompTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdClien", instance.CdClien);
		connection.AddParameters("@CdDoc", instance.CdDoc);
		connection.AddParameters("@NumeroDoc", instance.NumeroDoc);
		connection.AddParameters("@DtVencimento", instance.DtVencimento);
		connection.AddParameters("@SitRegular", instance.SitRegular);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspClientePermCompInsert");
	}

	public static void Update(DbConnection connection, ClientePermCompTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@ClientePermCompID)", instance.ClientePermCompID);
		connection.AddParameters("@CdClien", instance.CdClien);
		connection.AddParameters("@CdDoc", instance.CdDoc);
		connection.AddParameters("@NumeroDoc", instance.NumeroDoc);
		connection.AddParameters("@DtVencimento", instance.DtVencimento);
		connection.AddParameters("@SitRegular", instance.SitRegular);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspClientePermCompUpdate");
	}

	public static void Delete(DbConnection connection, ClientePermCompTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@ClientePermCompID)", instance.ClientePermCompID);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspClientePermCompDelete");
	}

	public static ClientePermCompTO[] Select(DbConnection connection, int? CdClien)
	{
		return Select(connection, null, CdClien, null, null, null, null);
	}

	public static ClientePermCompTO[] Select(DbConnection connection, int? CdClien, int? CdDoc)
	{
		return Select(connection, null, CdClien, CdDoc, null, null, null);
	}

	public static ClientePermCompTO[] Select(DbConnection connection, int? ClientePermCompID, int? CdClien, int? CdDoc, DateTime? DtVencimento, string NumeroDoc, string SitRegular)
	{
		connection.ClearParameters();
		connection.AddParameters("@ClientePermCompID)", ClientePermCompID);
		connection.AddParameters("@CdClien", CdClien);
		connection.AddParameters("@CdDoc", CdDoc);
		connection.AddParameters("@NumeroDoc", NumeroDoc);
		connection.AddParameters("@DtVencimento", DtVencimento);
		connection.AddParameters("@SitRegular", SitRegular);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspClientePermCompSelect"));
	}

	public static bool Exists(DbConnection connection, int? ClientePermCompID, int? CdClien, int? CdDoc)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo)", ClientePermCompID);
		connection.AddParameters("@CodigoCliente", CdClien);
		connection.AddParameters("@CodigoDocumento", CdDoc);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspClientePermCompExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static ClientePermCompTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ClientePermCompTO clientePermCompTO = new ClientePermCompTO();
				clientePermCompTO.ClientePermCompID = rs.GetInteger("ClientePermCompID");
				clientePermCompTO.CdClien = rs.GetInteger("CdClien");
				clientePermCompTO.CdDoc = rs.GetInteger("CdDoc");
				clientePermCompTO.NumeroDoc = rs.GetString("NumeroDoc");
				clientePermCompTO.DtVencimento = rs.GetNullableDateTime("DtVencimento");
				clientePermCompTO.SitRegular = rs.GetString("SitRegular");
				arrayList.Add(clientePermCompTO);
			}
		}
		return (ClientePermCompTO[])arrayList.ToArray(typeof(ClientePermCompTO));
	}
}
