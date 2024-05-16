using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorClienteNovoFormPgtoDAL
{
	private const string INSERT = "uspConfiguracaoVendedorClienteNovoFormPgtoInsert";

	private const string UPDATE = "uspConfiguracaoVendedorClienteNovoFormPgtoUpdate";

	private const string SELECT = "uspConfiguracaoVendedorClienteNovoFormPgtoSelect";

	private const string EXISTS = "uspConfiguracaoVendedorClienteNovoFormPgtoExists";

	private const string DELETE = "uspConfiguracaoVendedorClienteNovoFormPgtoDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorClienteNovoFormPgtoInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		sqlCommand.Parameters.AddWithValue("@Padrao", instance.Padrao);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorClienteNovoFormPgtoUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		sqlCommand.Parameters.AddWithValue("@Padrao", instance.Padrao);
		foreach (SqlParameter parameter in sqlCommand.Parameters)
		{
			if (parameter.Value == null)
			{
				parameter.Value = DBNull.Value;
			}
		}
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorClienteNovoFormPgtoTO> Select(SqlConnection connection, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorClienteNovoFormPgtoSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		sqlCommand.Parameters.AddWithValue("@Padrao", instance.Padrao);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transacao, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorClienteNovoFormPgtoExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorClienteNovoFormPgtoTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorClienteNovoFormPgtoTO> list = new List<ConfiguracaoVendedorClienteNovoFormPgtoTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorClienteNovoFormPgtoTO configuracaoVendedorClienteNovoFormPgtoTO = new ConfiguracaoVendedorClienteNovoFormPgtoTO();
			configuracaoVendedorClienteNovoFormPgtoTO.IdConfiguracaoVendedor = GetDataReader.GetInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorClienteNovoFormPgtoTO.CodigoFormPgto = GetDataReader.GetString(dr, "CodigoFormPgto");
			configuracaoVendedorClienteNovoFormPgtoTO.Padrao = GetDataReader.GetBoolean(dr, "@Padrao");
			list.Add(configuracaoVendedorClienteNovoFormPgtoTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	public static bool Delete(SqlTransaction transacao, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorClienteNovoFormPgtoDelete", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		return Convert.ToBoolean(sqlCommand.ExecuteScalar());
	}
}
