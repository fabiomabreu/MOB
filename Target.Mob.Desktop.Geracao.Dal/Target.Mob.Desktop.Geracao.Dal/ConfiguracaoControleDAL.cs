using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class ConfiguracaoControleDAL
{
	public static List<ConfiguracaoControleTO> Select(SqlConnection conexao, ConfiguracaoControleTO configuracaoControle)
	{
		using SqlDataReader dr = SelectDR(conexao, configuracaoControle);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoControleTO configuracaoControle)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoControleSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", configuracaoControle.Id);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", configuracaoControle.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@Entidade", configuracaoControle.Entidade);
		sqlCommand.Parameters.AddWithValue("@IdTipoControleTR", configuracaoControle.TipoControle);
		return sqlCommand.ExecuteReader();
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoControleTO configuracaoControle)
	{
		using SqlDataReader reader = SelectDR(conexao, configuracaoControle);
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

	private static List<ConfiguracaoControleTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoControleTO> list = new List<ConfiguracaoControleTO>();
		while (dr.Read())
		{
			ConfiguracaoControleTO configuracaoControleTO = new ConfiguracaoControleTO();
			configuracaoControleTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			configuracaoControleTO.IdVersaoCarga = GetDataReader.GetNullableInt32(dr, "IdVersaoCarga");
			configuracaoControleTO.Entidade = GetDataReader.GetString(dr, "Entidade");
			configuracaoControleTO.TipoControle = (TipoControleTR)GetDataReader.GetNullableInt32(dr, "IdTipoControleTR").Value;
			list.Add(configuracaoControleTO);
		}
		return list;
	}
}
