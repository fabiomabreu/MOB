using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorPaisDAL
{
	private const string INSERT = "uspConfiguracaoVendedorPaisInsert";

	private const string SELECT = "uspConfiguracaoVendedorPaisSelect";

	private const string DELETE = "uspConfiguracaoVendedorPaisDelete";

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorPaisTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorPaisInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoPais", instance.CodigoPais);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorPaisTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorPaisDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorPaisTO> Select(SqlConnection connection, ConfiguracaoVendedorPaisTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorPaisTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorPaisSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDConfiguracaoVendedor", instance.IDConfiguracaoVendedor);
		sqlCommand.Parameters.AddWithValue("@CodigoPais", instance.CodigoPais);
		return sqlCommand.ExecuteReader();
	}

	private static List<ConfiguracaoVendedorPaisTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorPaisTO> list = new List<ConfiguracaoVendedorPaisTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorPaisTO configuracaoVendedorPaisTO = new ConfiguracaoVendedorPaisTO();
			configuracaoVendedorPaisTO.IDConfiguracaoVendedor = GetDataReader.GetInt32(dr, "IDConfiguracaoVendedor");
			configuracaoVendedorPaisTO.CodigoPais = GetDataReader.GetString(dr, "CodigoPais");
			list.Add(configuracaoVendedorPaisTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
