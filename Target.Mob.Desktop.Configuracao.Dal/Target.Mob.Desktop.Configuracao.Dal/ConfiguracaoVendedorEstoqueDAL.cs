using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorEstoqueDAL
{
	private const string INSERT = "uspConfiguracaoVendedorEstoqueInsert";

	private const string UPDATE = "uspConfiguracaoVendedorEstoqueUpdate";

	private const string SELECT = "uspConfiguracaoVendedorEstoqueSelect";

	private const string EXISTS = "uspConfiguracaoVendedorEstoqueExists";

	private const string DELETE = "uspConfiguracaoVendedorEstoqueDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorEstoqueTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorEstoqueInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresaOrigem", instance.CodigoEmpresaOrigem);
		sqlCommand.Parameters.AddWithValue("@CodigoLocalEstoqueOrigem", instance.CodigoLocalEstoqueOrigem);
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresaDestino", instance.CodigoEmpresaDestino);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorEstoqueTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorEstoqueUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresaOrigem", instance.CodigoEmpresaOrigem);
		sqlCommand.Parameters.AddWithValue("@CodigoLocalEstoqueOrigem", instance.CodigoLocalEstoqueOrigem);
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresaDestino", instance.CodigoEmpresaDestino);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorEstoqueTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorEstoqueDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorEstoqueTO> Select(SqlConnection connection, ConfiguracaoVendedorEstoqueTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorEstoqueTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorEstoqueSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresaOrigem", instance.CodigoEmpresaOrigem);
		sqlCommand.Parameters.AddWithValue("@CodigoLocalEstoqueOrigem", instance.CodigoLocalEstoqueOrigem);
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresaDestino", instance.CodigoEmpresaDestino);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorEstoqueExists", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorEstoqueTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorEstoqueTO> list = new List<ConfiguracaoVendedorEstoqueTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorEstoqueTO configuracaoVendedorEstoqueTO = new ConfiguracaoVendedorEstoqueTO();
			configuracaoVendedorEstoqueTO.Id = GetDataReader.GetInt32(dr, "Id");
			configuracaoVendedorEstoqueTO.IdConfiguracaoVendedor = GetDataReader.GetNullableInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorEstoqueTO.CodigoEmpresaOrigem = GetDataReader.GetNullableInt32(dr, "CodigoEmpresaOrigem");
			configuracaoVendedorEstoqueTO.CodigoLocalEstoqueOrigem = GetDataReader.GetString(dr, "CodigoLocalEstoqueOrigem");
			configuracaoVendedorEstoqueTO.CodigoEmpresaDestino = GetDataReader.GetNullableInt32(dr, "CodigoEmpresaDestino");
			list.Add(configuracaoVendedorEstoqueTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
