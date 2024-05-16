using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class ConfiguracaoTemplateSQLiteDAL
{
	public static List<ConfiguracaoTemplateSQLiteTO> Select(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLite)
	{
		using SqlDataReader dr = SelectDR(conexao, configuracaoTemplateSQLite);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLite)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoTemplateSQLiteSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", configuracaoTemplateSQLite.Id);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", configuracaoTemplateSQLite.IdVersaoCarga);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLite)
	{
		using SqlDataReader reader = SelectDR(conexao, configuracaoTemplateSQLite);
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

	private static List<ConfiguracaoTemplateSQLiteTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoTemplateSQLiteTO> list = new List<ConfiguracaoTemplateSQLiteTO>();
		while (dr.Read())
		{
			ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLiteTO = new ConfiguracaoTemplateSQLiteTO();
			configuracaoTemplateSQLiteTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			configuracaoTemplateSQLiteTO.IdVersaoCarga = GetDataReader.GetNullableInt32(dr, "IdVersaoCarga");
			configuracaoTemplateSQLiteTO.Template = GetDataReader.GetByteArray(dr, "Template");
			list.Add(configuracaoTemplateSQLiteTO);
		}
		return list;
	}

	public static void Insert(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLite)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoTemplateSQLiteInsert", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", configuracaoTemplateSQLite.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@Template", configuracaoTemplateSQLite.Template);
		object obj = sqlCommand.ExecuteScalar();
		configuracaoTemplateSQLite.Id = int.Parse(obj.ToString());
	}

	public static void Update(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLite)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoTemplateSQLiteUpdate", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", configuracaoTemplateSQLite.Id);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", configuracaoTemplateSQLite.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@Template", configuracaoTemplateSQLite.Template);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLite)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoTemplateSQLiteDelete", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", configuracaoTemplateSQLite.Id);
		sqlCommand.ExecuteNonQuery();
	}
}
