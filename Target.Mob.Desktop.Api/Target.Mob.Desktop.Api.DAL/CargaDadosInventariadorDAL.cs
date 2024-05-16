using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Geracao.Common;

namespace Target.Mob.Desktop.Api.DAL;

public class CargaDadosInventariadorDAL
{
	private const string SELECT_DADOS_INVENTARIADOR = "tgtmob_uspCargaDadosInventariador";

	private const string SELECT_IS_CARGA_COMPLETA = "tgtmob_uspCargaDadosInventariador_IsCargaCompleta";

	public static IEnumerable<DadosTO> SelectDadosInventariador(string stringConnTargetErp, string codigoUsuario, long ultimoIdCargaEntidade, long cacheId)
	{
		int num = 20000;
		List<DadosTO> result = new List<DadosTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaDadosInventariador", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.CommandTimeout = 300;
			sqlCommand.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);
			sqlCommand.Parameters.AddWithValue("@qtdeRegistrosTop", num);
			sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", ultimoIdCargaEntidade);
			sqlCommand.Parameters.AddWithValue("@cacheId", cacheId);
			using SqlDataReader dr = sqlCommand.ExecuteReader();
			result = CreateInstance(dr);
		}
		sqlConnection.Close();
		return result;
	}

	private static List<DadosTO> CreateInstance(SqlDataReader dr)
	{
		List<DadosTO> list = new List<DadosTO>();
		while (dr.Read())
		{
			DadosTO dadosTO = new DadosTO();
			dadosTO.IdCargaEntidade = GetDataReader.GetInt64(dr, "idCargaEntidade");
			dadosTO.EntidadeNome = GetDataReader.GetString(dr, "entidadeNome");
			dadosTO.Chave = GetDataReader.GetString(dr, "chave");
			dadosTO.Dados = GetDataReader.GetString(dr, "dados");
			dadosTO.Exclusao = GetDataReader.GetBoolean(dr, "exclusao");
			list.Add(dadosTO);
		}
		return list;
	}

	internal static bool IsCargaCompleta(string conn, string codigoUsuario)
	{
		bool result = false;
		using SqlConnection sqlConnection = new SqlConnection(conn);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaDadosInventariador_IsCargaCompleta", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);
			result = Convert.ToBoolean(int.Parse(sqlCommand.ExecuteScalar().ToString()));
		}
		sqlConnection.Close();
		return result;
	}
}
