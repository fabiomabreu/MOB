using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class ConfiguracaoReplicacaoDAL
{
	public static List<ConfiguracaoReplicacaoTO> Select(SqlConnection conexao, ConfiguracaoReplicacaoTO configuracaoReplicacao)
	{
		using SqlDataReader dr = SelectDR(conexao, configuracaoReplicacao);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoReplicacaoTO configuracaoReplicacao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoReplicacaoSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", configuracaoReplicacao.Id);
		sqlCommand.Parameters.AddWithValue("@Entidade", configuracaoReplicacao.Entidade);
		sqlCommand.Parameters.AddWithValue("@Prioridade", configuracaoReplicacao.Prioridade);
		sqlCommand.Parameters.AddWithValue("@CondicaoSelecao", configuracaoReplicacao.CondicaoSelecao);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoReplicacaoTO configuracaoReplicacao)
	{
		using SqlDataReader reader = SelectDR(conexao, configuracaoReplicacao);
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

	private static List<ConfiguracaoReplicacaoTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoReplicacaoTO> list = new List<ConfiguracaoReplicacaoTO>();
		while (dr.Read())
		{
			ConfiguracaoReplicacaoTO configuracaoReplicacaoTO = new ConfiguracaoReplicacaoTO();
			configuracaoReplicacaoTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			configuracaoReplicacaoTO.Entidade = GetDataReader.GetString(dr, "Entidade");
			configuracaoReplicacaoTO.Prioridade = GetDataReader.GetNullableInt32(dr, "Prioridade");
			configuracaoReplicacaoTO.CondicaoSelecao = GetDataReader.GetString(dr, "CondicaoSelecao");
			list.Add(configuracaoReplicacaoTO);
		}
		return list;
	}
}
