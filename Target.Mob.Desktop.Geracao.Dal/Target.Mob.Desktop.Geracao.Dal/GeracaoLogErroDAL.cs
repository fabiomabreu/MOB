using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class GeracaoLogErroDAL
{
	public static List<GeracaoLogErroTO> Select(SqlConnection conexao, GeracaoLogErroTO geracaoLogErro)
	{
		using SqlDataReader dr = SelectDR(conexao, geracaoLogErro);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, GeracaoLogErroTO geracaoLogErro)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoLogErroSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracaoLogErro.Id);
		sqlCommand.Parameters.AddWithValue("@IdGeracaoItem", geracaoLogErro.IdGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@Classe", geracaoLogErro.Classe);
		sqlCommand.Parameters.AddWithValue("@Metodo", geracaoLogErro.Metodo);
		sqlCommand.Parameters.AddWithValue("@Erro", geracaoLogErro.Erro);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection conexao, GeracaoLogErroTO geracaoLogErro)
	{
		using SqlDataReader reader = SelectDR(conexao, geracaoLogErro);
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

	private static List<GeracaoLogErroTO> CreateInstance(SqlDataReader dr)
	{
		List<GeracaoLogErroTO> list = new List<GeracaoLogErroTO>();
		while (dr.Read())
		{
			GeracaoLogErroTO geracaoLogErroTO = new GeracaoLogErroTO();
			geracaoLogErroTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			geracaoLogErroTO.IdGeracaoItem = GetDataReader.GetNullableInt32(dr, "IdGeracaoItem");
			geracaoLogErroTO.Classe = GetDataReader.GetString(dr, "Classe");
			geracaoLogErroTO.Metodo = GetDataReader.GetString(dr, "Metodo");
			geracaoLogErroTO.Erro = GetDataReader.GetString(dr, "Erro");
			list.Add(geracaoLogErroTO);
		}
		return list;
	}

	public static void Insert(SqlConnection conexao, GeracaoLogErroTO geracaoLogErro)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoLogErroInsert", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdGeracaoItem", geracaoLogErro.IdGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@Classe", geracaoLogErro.Classe);
		sqlCommand.Parameters.AddWithValue("@Metodo", geracaoLogErro.Metodo);
		sqlCommand.Parameters.AddWithValue("@Erro", geracaoLogErro.Erro);
		object obj = sqlCommand.ExecuteScalar();
		geracaoLogErro.Id = int.Parse(obj.ToString());
	}

	public static void Update(SqlConnection conexao, GeracaoLogErroTO geracaoLogErro)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoLogErroUpdate", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracaoLogErro.Id);
		sqlCommand.Parameters.AddWithValue("@IdGeracaoItem", geracaoLogErro.IdGeracaoItem);
		sqlCommand.Parameters.AddWithValue("@Classe", geracaoLogErro.Classe);
		sqlCommand.Parameters.AddWithValue("@Metodo", geracaoLogErro.Metodo);
		sqlCommand.Parameters.AddWithValue("@Erro", geracaoLogErro.Erro);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlConnection conexao, GeracaoLogErroTO geracaoLogErro)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeracaoLogErroDelete", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", geracaoLogErro.Id);
		sqlCommand.Parameters.AddWithValue("@IdGeracaoItem", geracaoLogErro.IdGeracaoItem);
		sqlCommand.ExecuteNonQuery();
	}
}
