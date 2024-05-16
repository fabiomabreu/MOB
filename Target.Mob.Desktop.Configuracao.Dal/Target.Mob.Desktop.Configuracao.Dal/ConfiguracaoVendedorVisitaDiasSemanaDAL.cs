using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorVisitaDiasSemanaDAL
{
	private const string INSERT = "uspConfiguracaoVendedorVisitaDiasSemanaInsert";

	private const string UPDATE = "uspConfiguracaoVendedorVisitaDiasSemanaUpdate";

	private const string SELECT = "uspConfiguracaoVendedorVisitaDiasSemanaSelect";

	private const string EXISTS = "uspConfiguracaoVendedorVisitaDiasSemanaExists";

	private const string DELETE = "uspConfiguracaoVendedorVisitaDiasSemanaDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaDiasSemanaInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoDiaSemanaVisita", instance.CodigoDiaSemanaVisita);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaDiasSemanaUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoDiaSemanaVisita", instance.CodigoDiaSemanaVisita);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaDiasSemanaDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorVisitaDiasSemanaTO> Select(SqlConnection connection, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaDiasSemanaSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoDiaSemanaVisita", instance.CodigoDiaSemanaVisita);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transacao, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorVisitaDiasSemanaExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorVisitaDiasSemanaTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorVisitaDiasSemanaTO> list = new List<ConfiguracaoVendedorVisitaDiasSemanaTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorVisitaDiasSemanaTO configuracaoVendedorVisitaDiasSemanaTO = new ConfiguracaoVendedorVisitaDiasSemanaTO();
			configuracaoVendedorVisitaDiasSemanaTO.Id = GetDataReader.GetInt32(dr, "Id");
			configuracaoVendedorVisitaDiasSemanaTO.IdConfiguracaoVendedor = GetDataReader.GetNullableInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorVisitaDiasSemanaTO.CodigoDiaSemanaVisita = GetDataReader.GetString(dr, "CodigoDiaSemanaVisita");
			list.Add(configuracaoVendedorVisitaDiasSemanaTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
