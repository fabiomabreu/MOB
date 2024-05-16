using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorInadimplenciaFormPgtoDAL
{
	private const string INSERT = "uspConfiguracaoVendedorInadimplenciaFormPgtoInsert";

	private const string UPDATE = "uspConfiguracaoVendedorInadimplenciaFormPgtoUpdate";

	private const string SELECT = "uspConfiguracaoVendedorInadimplenciaFormPgtoSelect";

	private const string EXISTS = "uspConfiguracaoVendedorInadimplenciaFormPgtoExists";

	private const string DELETE = "uspConfiguracaoVendedorInadimplenciaFormPgtoDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorInadimplenciaFormPgtoInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		sqlCommand.Parameters.AddWithValue("@Padrao", instance.Padrao);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorInadimplenciaFormPgtoUpdate", transaction.Connection, transaction);
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

	public static List<ConfiguracaoVendedorInadimplenciaFormPgtoTO> Select(SqlConnection connection, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorInadimplenciaFormPgtoSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		sqlCommand.Parameters.AddWithValue("@Padrao", instance.Padrao);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transacao, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorInadimplenciaFormPgtoExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorInadimplenciaFormPgtoTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorInadimplenciaFormPgtoTO> list = new List<ConfiguracaoVendedorInadimplenciaFormPgtoTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorInadimplenciaFormPgtoTO configuracaoVendedorInadimplenciaFormPgtoTO = new ConfiguracaoVendedorInadimplenciaFormPgtoTO();
			configuracaoVendedorInadimplenciaFormPgtoTO.IdConfiguracaoVendedor = GetDataReader.GetInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorInadimplenciaFormPgtoTO.CodigoFormPgto = GetDataReader.GetString(dr, "CodigoFormPgto");
			configuracaoVendedorInadimplenciaFormPgtoTO.Padrao = GetDataReader.GetBoolean(dr, "@Padrao");
			list.Add(configuracaoVendedorInadimplenciaFormPgtoTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	public static bool Delete(SqlTransaction transacao, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorInadimplenciaFormPgtoDelete", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoFormPgto", instance.CodigoFormPgto);
		return Convert.ToBoolean(sqlCommand.ExecuteScalar());
	}
}
