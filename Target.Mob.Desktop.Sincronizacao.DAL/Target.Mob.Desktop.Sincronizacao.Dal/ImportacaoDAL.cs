using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ImportacaoDAL
{
	private const string INSERT = "uspImportacaoInsert";

	private const string UPDATE = "uspImportacaoUpdate";

	private const string DELETE = "uspImportacaoDelete";

	private const string SELECT = "uspImportacaoSelect";

	public static void Insert(DbConnection connection, ImportacaoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@DataInicio", instance.DataInicio);
		connection.AddParameters("@DataFim", instance.DataFim);
		connection.AddParameters("@IdStatusImportacaoTR", instance.IdStatusImportacaoTR);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspImportacaoInsert");
		instance.Id = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, ImportacaoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", instance.Id);
		connection.AddParameters("@DataInicio", instance.DataInicio);
		connection.AddParameters("@DataFim", instance.DataFim);
		connection.AddParameters("@IdStatusImportacaoTR", instance.IdStatusImportacaoTR);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImportacaoUpdate");
	}

	public static void Delete(DbConnection connection, ImportacaoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", instance.Id);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImportacaoDelete");
	}

	public static ImportacaoTO[] Select(DbConnection connection, int? Id)
	{
		return Select(connection, Id, null, null, null);
	}

	public static ImportacaoTO[] Select(DbConnection connection, int? Id, DateTime? DataInicio, DateTime? DataFim, int? IdStatusImportacaoTR)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", Id);
		connection.AddParameters("@DataInicio", DataInicio);
		connection.AddParameters("@DataFim", DataFim);
		connection.AddParameters("@IdStatusImportacaoTR", IdStatusImportacaoTR);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspImportacaoSelect"));
	}

	private static ImportacaoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ImportacaoTO importacaoTO = new ImportacaoTO();
				importacaoTO.Id = rs.GetInteger("Id");
				importacaoTO.DataInicio = rs.GetDateTime("DataInicio");
				importacaoTO.DataFim = rs.GetNullableDateTime("DataFim");
				importacaoTO.IdStatusImportacaoTR = (StatusImportacaoTR)rs.GetInteger("IdStatusImportacaoTR");
				arrayList.Add(importacaoTO);
			}
		}
		return (ImportacaoTO[])arrayList.ToArray(typeof(ImportacaoTO));
	}
}
