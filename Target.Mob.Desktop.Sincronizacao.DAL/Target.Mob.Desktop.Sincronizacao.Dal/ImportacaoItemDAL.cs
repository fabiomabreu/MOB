using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ImportacaoItemDAL
{
	private const string INSERT = "uspImportacaoItemInsert";

	private const string UPDATE = "uspImportacaoItemUpdate";

	private const string DELETE = "uspImportacaoItemDelete";

	private const string SELECT = "uspImportacaoItemSelect";

	public static void Insert(DbConnection connection, ImportacaoItemTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdImportacao", instance.IdImportacao);
		connection.AddParameters("@DataInicio", instance.DataInicio);
		connection.AddParameters("@IdEtapaImportacaoItemTR", instance.IdEtapaImportacaoItemTR);
		connection.AddParameters("@TabelaBancoDados", instance.TabelaBancoDados);
		connection.AddParameters("@DataFim", instance.DataFim);
		connection.AddParameters("@IdStatusImportacaoItemTR", instance.IdStatusImportacaoItemTR);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspImportacaoItemInsert");
		instance.Id = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, ImportacaoItemTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", instance.Id);
		connection.AddParameters("@IdImportacao", instance.IdImportacao);
		connection.AddParameters("@DataInicio", instance.DataInicio);
		connection.AddParameters("@IdEtapaImportacaoItemTR", instance.IdEtapaImportacaoItemTR);
		connection.AddParameters("@TabelaBancoDados", instance.TabelaBancoDados);
		connection.AddParameters("@DataFim", instance.DataFim);
		connection.AddParameters("@IdStatusImportacaoItemTR", instance.IdStatusImportacaoItemTR);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImportacaoItemUpdate");
	}

	public static void Delete(DbConnection connection, ImportacaoItemTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", instance.Id);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspImportacaoItemDelete");
	}

	public static ImportacaoItemTO[] Select(DbConnection connection, int? Id)
	{
		return Select(connection, Id, null, null, null, null, null, null);
	}

	public static ImportacaoItemTO[] Select(DbConnection connection, int? Id, int? IdImportacao, DateTime? DataInicio, int? IdEtapaImportacaoItemTR, string TabelaBancoDados, DateTime? DataFim, int? IdStatusImportacaoItemTR)
	{
		connection.ClearParameters();
		connection.AddParameters("@Id", Id);
		connection.AddParameters("@IdImportacao", IdImportacao);
		connection.AddParameters("@DataInicio", DataInicio);
		connection.AddParameters("@IdEtapaImportacaoItemTR", IdEtapaImportacaoItemTR);
		connection.AddParameters("@TabelaBancoDados", TabelaBancoDados);
		connection.AddParameters("@DataFim", DataFim);
		connection.AddParameters("@IdStatusImportacaoItemTR", IdStatusImportacaoItemTR);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspImportacaoItemSelect"));
	}

	private static ImportacaoItemTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ImportacaoItemTO importacaoItemTO = new ImportacaoItemTO();
				importacaoItemTO.Id = rs.GetInteger("Id");
				importacaoItemTO.IdImportacao = rs.GetInteger("IdImportacao");
				importacaoItemTO.DataInicio = rs.GetDateTime("DataInicio");
				importacaoItemTO.IdEtapaImportacaoItemTR = (EtapaImportacaoItemTR)rs.GetInteger("IdEtapaImportacaoItemTR");
				importacaoItemTO.TabelaBancoDados = rs.GetString("TabelaBancoDados");
				importacaoItemTO.DataFim = rs.GetNullableDateTime("DataFim");
				importacaoItemTO.IdStatusImportacaoItemTR = (StatusImportacaoItemTR)rs.GetInteger("IdStatusImportacaoItemTR");
				arrayList.Add(importacaoItemTO);
			}
		}
		return (ImportacaoItemTO[])arrayList.ToArray(typeof(ImportacaoItemTO));
	}
}
