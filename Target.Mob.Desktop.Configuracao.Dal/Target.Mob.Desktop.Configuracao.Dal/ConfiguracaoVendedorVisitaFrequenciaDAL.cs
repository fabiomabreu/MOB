using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorVisitaFrequenciaDAL
{
	private const string INSERT = "uspConfiguracaoVendedorVisitaFrequenciaInsert";

	private const string UPDATE = "uspConfiguracaoVendedorVisitaFrequenciaUpdate";

	private const string SELECT = "uspConfiguracaoVendedorVisitaFrequenciaSelect";

	private const string EXISTS = "uspConfiguracaoVendedorVisitaFrequenciaExists";

	private const string DELETE = "uspConfiguracaoVendedorVisitaFrequenciaDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaFrequenciaInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoTipoFrequenciaVisita", instance.CodigoTipoFrequenciaVisita);
		sqlCommand.Parameters.AddWithValue("@FrequenciaVisitaId", instance.FrequenciaVisitaId);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaFrequenciaUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoTipoFrequenciaVisita", instance.CodigoTipoFrequenciaVisita);
		sqlCommand.Parameters.AddWithValue("@FrequenciaVisitaId", instance.FrequenciaVisitaId);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaFrequenciaDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorVisitaFrequenciaTO> Select(SqlConnection connection, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaFrequenciaSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoTipoFrequenciaVisita", instance.CodigoTipoFrequenciaVisita);
		sqlCommand.Parameters.AddWithValue("@FrequenciaVisitaId", instance.FrequenciaVisitaId);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaFrequenciaExists", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorVisitaFrequenciaTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorVisitaFrequenciaTO> list = new List<ConfiguracaoVendedorVisitaFrequenciaTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorVisitaFrequenciaTO configuracaoVendedorVisitaFrequenciaTO = new ConfiguracaoVendedorVisitaFrequenciaTO();
			configuracaoVendedorVisitaFrequenciaTO.Id = GetDataReader.GetInt32(dr, "Id");
			configuracaoVendedorVisitaFrequenciaTO.IdConfiguracaoVendedor = GetDataReader.GetNullableInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorVisitaFrequenciaTO.CodigoTipoFrequenciaVisita = GetDataReader.GetString(dr, "CodigoTipoFrequenciaVisita");
			configuracaoVendedorVisitaFrequenciaTO.FrequenciaVisitaId = GetDataReader.GetNullableInt32(dr, "FrequenciaVisitaId");
			list.Add(configuracaoVendedorVisitaFrequenciaTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
