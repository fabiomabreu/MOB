using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class GeracaoDAL
{
	public static List<GeracaoTO> Select(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlDataReader dr = SelectDR(conexao, geracao);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracao.Id);
		sqlCommand.Parameters.AddWithValue("@DataInicio", geracao.DataInicio);
		sqlCommand.Parameters.AddWithValue("@DataFim", geracao.DataFim);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoTR", geracao.StatusGeracao);
		sqlCommand.Parameters.AddWithValue("@rowid", geracao.RowId);
		return sqlCommand.ExecuteReader();
	}

	public static SqlDataReader SelectDRQtdeVendedor(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoQtdeVendedor", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@rowid", geracao.RowId);
		return sqlCommand.ExecuteReader();
	}

	public static List<GeracaoTO> SelectQtdeVendedor(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlDataReader dr = SelectDRQtdeVendedor(conexao, geracao);
		return CreateInstance(dr);
	}

	public static DataTable SelectDT(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlDataReader reader = SelectDR(conexao, geracao);
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

	private static List<GeracaoTO> CreateInstance(SqlDataReader dr)
	{
		List<GeracaoTO> list = new List<GeracaoTO>();
		while (dr.Read())
		{
			GeracaoTO geracaoTO = new GeracaoTO();
			geracaoTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			geracaoTO.DataInicio = GetDataReader.GetNullableDateTime(dr, "DataInicio");
			geracaoTO.DataFim = GetDataReader.GetNullableDateTime(dr, "DataFim");
			geracaoTO.StatusGeracao = (StatusGeracaoTR?)GetDataReader.GetNullableInt32(dr, "IdStatusGeracaoTR");
			geracaoTO.RowId = GetDataReader.GetByteArray(dr, "Rowid");
			geracaoTO.QtdeVendedores = GetDataReader.GetNullableInt32(dr, "QtdeVendedores");
			list.Add(geracaoTO);
		}
		return list;
	}

	public static void Insert(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoInsert", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@DataInicio", geracao.DataInicio);
		sqlCommand.Parameters.AddWithValue("@DataFim", geracao.DataFim);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoTR", geracao.StatusGeracao);
		object obj = sqlCommand.ExecuteScalar();
		geracao.Id = int.Parse(obj.ToString());
	}

	public static void Update(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoUpdate", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracao.Id);
		sqlCommand.Parameters.AddWithValue("@DataInicio", geracao.DataInicio);
		sqlCommand.Parameters.AddWithValue("@DataFim", geracao.DataFim);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoTR", geracao.StatusGeracao);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlConnection conexao, GeracaoTO geracao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoDelete", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracao.Id);
		sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoTR", geracao.StatusGeracao);
		sqlCommand.ExecuteNonQuery();
	}
}
