using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorOrdenacaoGondolaDAL
{
	private const string INSERT = "uspConfiguracaoVendedorOrdenacaoGondolaInsert";

	private const string UPDATE = "uspConfiguracaoVendedorOrdenacaoGondolaUpdate";

	private const string SELECT = "uspConfiguracaoVendedorOrdenacaoGondolaSelect";

	private const string EXISTS = "uspConfiguracaoVendedorOrdenacaoGondolaExists";

	private const string DELETE = "uspConfiguracaoVendedorOrdenacaoGondolaDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorOrdenacaoGondolaInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Seq", instance.Seq);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@ColunaOrdenacao", instance.ColunaOrdenacao);
		sqlCommand.Parameters.AddWithValue("@TipoOrdenacao", instance.TipoOrdenacao);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedorOrdenacaoGondola", instance.IdConfiguracaoVendedorOrdenacaoGondola);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorOrdenacaoGondolaUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Seq", instance.Seq);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@ColunaOrdenacao", instance.ColunaOrdenacao);
		sqlCommand.Parameters.AddWithValue("@TipoOrdenacao", instance.TipoOrdenacao);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorOrdenacaoGondolaDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Seq", instance.Seq);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorOrdenacaoGondolaTO> Select(SqlConnection connection, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorOrdenacaoGondolaSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Seq", instance.Seq);
		sqlCommand.Parameters.AddWithValue("@IdConfiguracaoVendedor", instance.IdConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@ColunaOrdenacao", instance.ColunaOrdenacao);
		sqlCommand.Parameters.AddWithValue("@TipoOrdenacao", instance.TipoOrdenacao);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transacao, int? seq)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorOrdenacaoGondolaExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Seq", seq);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorOrdenacaoGondolaTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorOrdenacaoGondolaTO> list = new List<ConfiguracaoVendedorOrdenacaoGondolaTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorOrdenacaoGondolaTO configuracaoVendedorOrdenacaoGondolaTO = new ConfiguracaoVendedorOrdenacaoGondolaTO();
			configuracaoVendedorOrdenacaoGondolaTO.Seq = GetDataReader.GetInt32(dr, "Seq");
			configuracaoVendedorOrdenacaoGondolaTO.IdConfiguracaoVendedor = GetDataReader.GetNullableInt32(dr, "IdConfiguracaoVendedor");
			configuracaoVendedorOrdenacaoGondolaTO.ColunaOrdenacao = GetDataReader.GetString(dr, "ColunaOrdenacao");
			configuracaoVendedorOrdenacaoGondolaTO.TipoOrdenacao = GetDataReader.GetString(dr, "TipoOrdenacao");
			list.Add(configuracaoVendedorOrdenacaoGondolaTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
