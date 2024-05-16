using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Geracao.Common;

namespace Target.Mob.Desktop.Api.DAL;

public class CargaDadosPromotorDAL
{
	private const string SELECT_DADOS_PROMOTOR = "tgtmob_uspCargaDadosPromotor";

	private const string SELECT_IS_CARGA_COMPLETA = "tgtmob_uspCargaDadosPromotor_IsCargaCompleta";

	public static IEnumerable<DadosTO> SelectDadosPromotor(string stringConnTargetErp, string codigoPromotor, long ultimoIdCargaEntidade, long cacheId)
	{
		int num = 20000;
		List<DadosTO> result = new List<DadosTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaDadosPromotor", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.CommandTimeout = 300;
			sqlCommand.Parameters.AddWithValue("@codigoPromotor", codigoPromotor);
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

	internal static bool IsCargaCompleta(string conn, string codigoPromotor, int major, int minor, int build, int revision)
	{
		bool result = false;
		using SqlConnection sqlConnection = new SqlConnection(conn);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaDadosPromotor_IsCargaCompleta", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@CodigoPromotor", codigoPromotor);
			sqlCommand.Parameters.AddWithValue("@major", major);
			sqlCommand.Parameters.AddWithValue("@minor", minor);
			sqlCommand.Parameters.AddWithValue("@build", build);
			sqlCommand.Parameters.AddWithValue("@revision", revision);
			result = Convert.ToBoolean(int.Parse(sqlCommand.ExecuteScalar().ToString()));
		}
		sqlConnection.Close();
		return result;
	}
}
