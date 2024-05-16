using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorTipoNotificacaoDAL
{
	private const string INSERT = "uspConfiguracaoVendedorTipoNotificacaoInsert";

	private const string SELECT = "uspConfiguracaoVendedorTipoNotificacaoSelect";

	private const string EXISTS = "uspConfiguracaoVendedorTipoNotificacaoExists";

	private const string DELETE = "uspConfiguracaoVendedorTipoNotificacaoDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorTipoNotificacaoInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorTipoNotificacaoTO> Select(SqlConnection connection, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorTipoNotificacaoSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		return sqlCommand.ExecuteReader();
	}

	private static List<ConfiguracaoVendedorTipoNotificacaoTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorTipoNotificacaoTO> list = new List<ConfiguracaoVendedorTipoNotificacaoTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorTipoNotificacaoTO configuracaoVendedorTipoNotificacaoTO = new ConfiguracaoVendedorTipoNotificacaoTO();
			configuracaoVendedorTipoNotificacaoTO.IDTipoNotificacao = GetDataReader.GetInt32(dr, "IDTipoNotificacao");
			configuracaoVendedorTipoNotificacaoTO.IDConfiguracaoVendedor = GetDataReader.GetInt32(dr, "IDConfiguracaoVendedor");
			list.Add(configuracaoVendedorTipoNotificacaoTO);
		}
		return list;
	}

	public static bool Delete(SqlTransaction transacao, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorTipoNotificacaoDelete", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		return Convert.ToBoolean(sqlCommand.ExecuteScalar());
	}

	public static bool Exists(SqlTransaction transacao, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorTipoNotificacaoExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}
}
