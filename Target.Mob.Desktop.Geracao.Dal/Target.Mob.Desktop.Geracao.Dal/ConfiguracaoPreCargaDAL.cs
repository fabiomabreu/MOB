using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class ConfiguracaoPreCargaDAL
{
	public static List<ConfiguracaoPreCargaTO> Select(SqlConnection conexao, ConfiguracaoPreCargaTO configuracaoPreCarga)
	{
		using SqlDataReader dr = SelectDR(conexao, configuracaoPreCarga);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoPreCargaTO configuracaoPreCarga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoPreCargaSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", configuracaoPreCarga.Id);
		sqlCommand.Parameters.AddWithValue("@NomeProcedure", configuracaoPreCarga.NomeProcedure);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoPreCargaTO configuracaoPreCarga)
	{
		using SqlDataReader reader = SelectDR(conexao, configuracaoPreCarga);
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

	private static List<ConfiguracaoPreCargaTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoPreCargaTO> list = new List<ConfiguracaoPreCargaTO>();
		while (dr.Read())
		{
			ConfiguracaoPreCargaTO configuracaoPreCargaTO = new ConfiguracaoPreCargaTO();
			configuracaoPreCargaTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			configuracaoPreCargaTO.NomeProcedure = GetDataReader.GetString(dr, "NomeProcedure");
			list.Add(configuracaoPreCargaTO);
		}
		return list;
	}
}
