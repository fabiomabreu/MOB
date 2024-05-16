using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorCoordenadaDiasSemanaDAL
{
	private const string INSERT = "uspConfiguracaoVendedorCoordenadaDiasSemanaInsert";

	private const string UPDATE = "uspConfiguracaoVendedorCoordenadaDiasSemanaUpdate";

	private const string SELECT = "uspConfiguracaoVendedorCoordenadaDiasSemanaSelect";

	private const string EXISTS = "uspConfiguracaoVendedorCoordenadaDiasSemanaExists";

	private const string DELETE = "uspConfiguracaoVendedorCoordenadaDiasSemanaDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorCoordenadaDiasSemanaInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoCoordenadaDiaSemana", instance.CodigoCoordenadaDiaSemana);
		sqlCommand.Parameters.AddWithValue("@HorarioInicioCoordenada", instance.HorarioInicioCoordenada);
		sqlCommand.Parameters.AddWithValue("@HorarioFimCoordenada", instance.HorarioFimCoordenada);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorCoordenadaDiasSemanaUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoCoordenadaDiaSemana", instance.CodigoCoordenadaDiaSemana);
		sqlCommand.Parameters.AddWithValue("@HorarioInicioCoordenada", instance.HorarioInicioCoordenada);
		sqlCommand.Parameters.AddWithValue("@HorarioFimCoordenada", instance.HorarioFimCoordenada);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorCoordenadaDiasSemanaDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorCoordenadaDiasSemanaTO> Select(SqlConnection connection, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorCoordenadaDiasSemanaSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoCoordenadaDiaSemana", instance.CodigoCoordenadaDiaSemana);
		sqlCommand.Parameters.AddWithValue("@HorarioInicioCoordenada", instance.HorarioInicioCoordenada);
		sqlCommand.Parameters.AddWithValue("@HorarioFimCoordenada", instance.HorarioFimCoordenada);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transacao, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorCoordenadaDiasSemanaExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorCoordenadaDiasSemanaTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorCoordenadaDiasSemanaTO> list = new List<ConfiguracaoVendedorCoordenadaDiasSemanaTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorCoordenadaDiasSemanaTO configuracaoVendedorCoordenadaDiasSemanaTO = new ConfiguracaoVendedorCoordenadaDiasSemanaTO();
			configuracaoVendedorCoordenadaDiasSemanaTO.Id = GetDataReader.GetInt32(dr, "Id");
			configuracaoVendedorCoordenadaDiasSemanaTO.IdConfiguracaoVendedor = GetDataReader.GetNullableInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorCoordenadaDiasSemanaTO.CodigoCoordenadaDiaSemana = GetDataReader.GetString(dr, "CodigoCoordenadaDiaSemana");
			configuracaoVendedorCoordenadaDiasSemanaTO.HorarioInicioCoordenada = GetDataReader.GetNullableDateTime(dr, "HorarioInicioCoordenada");
			configuracaoVendedorCoordenadaDiasSemanaTO.HorarioFimCoordenada = GetDataReader.GetNullableDateTime(dr, "HorarioFimCoordenada");
			list.Add(configuracaoVendedorCoordenadaDiasSemanaTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
