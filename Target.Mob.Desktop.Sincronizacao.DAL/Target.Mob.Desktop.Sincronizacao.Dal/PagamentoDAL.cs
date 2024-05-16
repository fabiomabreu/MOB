using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class PagamentoDAL
{
	private const string INSERT = "uspPagamentoInsert";

	private const string UPDATE = "uspPagamentoUpdate";

	private const string DELETE = "uspPagamentoDelete";

	private const string SELECT = "uspPagamentoSelect";

	private const string EXISTS = "uspPagamentoExists";

	public static void Insert(DbConnection connection, PagamentoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@CodigoCliente", instance.CdClien);
		connection.AddParameters("@DataPgto", instance.DataPgto);
		connection.AddParameters("@FormaPgto", instance.TpPgto);
		connection.AddParameters("@ValorPgto", instance.ValorPgto);
		connection.AddParameters("@CodigoVendedor", instance.CdVend);
		connection.AddParameters("@DataImportacao", instance.DataImportacao);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspPagamentoInsert");
	}

	public static void Update(DbConnection connection, PagamentoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo", instance.TgtMobPagamentoID);
		connection.AddParameters("@CodigoCliente", instance.CdClien);
		connection.AddParameters("@DataPgto", instance.DataPgto);
		connection.AddParameters("@ValorPgto", instance.ValorPgto);
		connection.AddParameters("@FormaPgto", instance.TpPgto);
		connection.AddParameters("@CodigoVendedor", instance.CdVend);
		connection.AddParameters("@DataImportacao", instance.DataImportacao);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPagamentoUpdate");
	}

	public static void Delete(DbConnection connection, PagamentoTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo", instance.TgtMobPagamentoID);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPagamentoDelete");
	}

	public static PagamentoTO[] Select(DbConnection connection, int? Codigo, int? CodigoCliente, DateTime? DataAtualizacao, DateTime? DataPgto, string Situacao, double? ValorPgto, string FormaPgto, string CodigoVendedor)
	{
		connection.ClearParameters();
		connection.AddParameters("@CodigoCliente", CodigoCliente);
		connection.AddParameters("@DataAtualizacao", DataAtualizacao);
		connection.AddParameters("@DataPgto", DataPgto);
		connection.AddParameters("@ValorPgto", ValorPgto);
		connection.AddParameters("@FormaPgto", FormaPgto);
		connection.AddParameters("@CodigoVendedor", CodigoVendedor);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPagamentoSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdClien, DateTime? DataPgto, string FormaPgto, double? ValorPgto, string CdVendedor)
	{
		connection.ClearParameters();
		connection.AddParameters("@CodigoCliente", CdClien);
		connection.AddParameters("@DataPgto", DataPgto);
		connection.AddParameters("@FormaPgto", FormaPgto);
		connection.AddParameters("@ValorPgto", ValorPgto);
		connection.AddParameters("@CodigoVendedor", CdVendedor);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspPagamentoExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static PagamentoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PagamentoTO pagamentoTO = new PagamentoTO();
				pagamentoTO.TgtMobPagamentoID = rs.GetInteger("TgtMobPagamentoID");
				pagamentoTO.CdClien = rs.GetInteger("CdClien");
				pagamentoTO.DataPgto = rs.GetDateTime("DataPgto");
				pagamentoTO.TpPgto = rs.GetString("TpPgto");
				pagamentoTO.ValorPgto = rs.GetDouble("ValorPgto");
				pagamentoTO.CdVend = rs.GetString("CdVend");
				pagamentoTO.DataImportacao = rs.GetDateTime("DataImportacao");
				arrayList.Add(pagamentoTO);
			}
		}
		return (PagamentoTO[])arrayList.ToArray(typeof(PagamentoTO));
	}
}
