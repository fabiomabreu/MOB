using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class GeracaoItemDAL
{
	public static List<GeracaoItemTO> Select(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		using SqlDataReader dr = SelectDR(conexao, geracaoItem);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoItemSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracaoItem.Id);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", geracaoItem.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@DataInicio", geracaoItem.DataInicio);
		sqlCommand.Parameters.AddWithValue("@IdEtapaGeracaoItemTR", geracaoItem.EtapaGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@TabelaBancoDados", geracaoItem.TabelaBancoDados);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", geracaoItem.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@DataFim", geracaoItem.DataFim);
		sqlCommand.Parameters.AddWithValue("@QtdeRegistros", geracaoItem.QtdeRegistros);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoItemTR", geracaoItem.StatusGeracaoItem);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		using SqlDataReader reader = SelectDR(conexao, geracaoItem);
		DataTable dataTable = new DataTable();
		try
		{
			dataTable.Load(reader);
			return dataTable;
		}
		finally
		{
			((IDisposable)dataTable)?.Dispose();
		}
	}

	private static List<GeracaoItemTO> CreateInstance(SqlDataReader dr)
	{
		List<GeracaoItemTO> list = new List<GeracaoItemTO>();
		while (dr.Read())
		{
			GeracaoItemTO geracaoItemTO = new GeracaoItemTO();
			geracaoItemTO.Id = GetDataReader.GetNullableInt32(dr, "@Id");
			geracaoItemTO.IdGeracao = GetDataReader.GetNullableInt32(dr, "@IdGeracao");
			geracaoItemTO.DataInicio = GetDataReader.GetNullableDateTime(dr, "@DataInicio");
			geracaoItemTO.EtapaGeracaoItem = (EtapaGeracaoItemTR?)GetDataReader.GetNullableInt32(dr, "@IdEtapaGeracaoItemTR");
			geracaoItemTO.TabelaBancoDados = GetDataReader.GetString(dr, "@TabelaBancoDados");
			geracaoItemTO.IdVendedor = GetDataReader.GetNullableInt32(dr, "@IdVendedor");
			geracaoItemTO.DataFim = GetDataReader.GetNullableDateTime(dr, "@DataFim");
			geracaoItemTO.QtdeRegistros = GetDataReader.GetNullableInt32(dr, "@QtdeRegistros");
			geracaoItemTO.StatusGeracaoItem = (StatusGeracaoItemTR?)GetDataReader.GetNullableInt32(dr, "@IdStatusGeracaoItemTR");
			list.Add(geracaoItemTO);
		}
		return list;
	}

	public static void Insert(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoItemInsert", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdGeracao", geracaoItem.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@DataInicio", geracaoItem.DataInicio);
		sqlCommand.Parameters.AddWithValue("@IdEtapaGeracaoItemTR", geracaoItem.EtapaGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@TabelaBancoDados", geracaoItem.TabelaBancoDados);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", geracaoItem.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@DataFim", geracaoItem.DataFim);
		sqlCommand.Parameters.AddWithValue("@QtdeRegistros", geracaoItem.QtdeRegistros);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoItemTR", geracaoItem.StatusGeracaoItem);
		object obj = sqlCommand.ExecuteScalar();
		geracaoItem.Id = int.Parse(obj.ToString());
	}

	public static void Update(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoItemUpdate", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracaoItem.Id);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", geracaoItem.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@DataInicio", geracaoItem.DataInicio);
		sqlCommand.Parameters.AddWithValue("@IdEtapaGeracaoItemTR", geracaoItem.EtapaGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@TabelaBancoDados", geracaoItem.TabelaBancoDados);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", geracaoItem.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@DataFim", geracaoItem.DataFim);
		sqlCommand.Parameters.AddWithValue("@QtdeRegistros", geracaoItem.QtdeRegistros);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoItemTR", geracaoItem.StatusGeracaoItem);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoItemDelete", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracaoItem.Id);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", geracaoItem.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdEtapaGeracaoItemTR", geracaoItem.EtapaGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", geracaoItem.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoItemTR", geracaoItem.StatusGeracaoItem);
		sqlCommand.ExecuteNonQuery();
	}
}
