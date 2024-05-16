using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Api.Model;

namespace Target.Mob.Desktop.Api.DAL;

public class CargaEstatisticaDAL
{
	private const string SELECT_RESUMO_GERAL = "tgtmob_uspCargaEstatistica_ResumoGeral";

	private const string SELECT_RESUMO_SINCRONIZACAO_VENDEDORES = "tgtmob_uspCargaEstatistica_ResumoSincronizacaoVendedores";

	public static IEnumerable<EstatisticaResumoGeralTO> SelectResumoGeral(string stringConnTargetErp)
	{
		List<EstatisticaResumoGeralTO> result = new List<EstatisticaResumoGeralTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaEstatistica_ResumoGeral", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			using SqlDataReader dr = sqlCommand.ExecuteReader();
			result = CreateInstanceResumoGeral(dr);
		}
		sqlConnection.Close();
		return result;
	}

	private static List<EstatisticaResumoGeralTO> CreateInstanceResumoGeral(SqlDataReader dr)
	{
		List<EstatisticaResumoGeralTO> list = new List<EstatisticaResumoGeralTO>();
		while (dr.Read())
		{
			EstatisticaResumoGeralTO estatisticaResumoGeralTO = new EstatisticaResumoGeralTO();
			estatisticaResumoGeralTO.DataUltimaAtualizacao = GetDataReader.GetDateTime(dr, "dataUltimaAtualizacao");
			estatisticaResumoGeralTO.DuracaoUltimaAtualizacaoEmSegundos = GetDataReader.GetInt32(dr, "duracaoUltimaAtualizacaoEmSegundos");
			estatisticaResumoGeralTO.MaiorDuracaoDoDiaEmSegundos = GetDataReader.GetInt32(dr, "maiorDuracaoDoDiaEmSegundos");
			estatisticaResumoGeralTO.MenorDuracaoDoDiaEmSegundos = GetDataReader.GetInt32(dr, "menorDuracaoDoDiaEmSegundos");
			estatisticaResumoGeralTO.MediaDuracaoDoDiaEmSegundos = GetDataReader.GetInt32(dr, "mediaDuracaoDoDiaEmSegundos");
			estatisticaResumoGeralTO.QtdeDeAtualizacoesNoDia = GetDataReader.GetInt32(dr, "qtdeDeAtualizacoesNoDia");
			estatisticaResumoGeralTO.DataAtual = GetDataReader.GetDateTime(dr, "dataAtual");
			estatisticaResumoGeralTO.VersaoRetaguardaUltimaAtualizacao = GetDataReader.GetString(dr, "versaoRetaguardaUltimaAtualizacao");
			list.Add(estatisticaResumoGeralTO);
		}
		return list;
	}

	public static IEnumerable<EstatisticaResumoSincronizacaoVendedorTO> SelectResumoSincronizacaoVendedores(string stringConnTargetErp, string filtro)
	{
		List<EstatisticaResumoSincronizacaoVendedorTO> result = new List<EstatisticaResumoSincronizacaoVendedorTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaEstatistica_ResumoSincronizacaoVendedores", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.CommandTimeout = 300;
			sqlCommand.Parameters.AddWithValue("@filtro", filtro);
			using SqlDataReader dr = sqlCommand.ExecuteReader();
			result = CreateInstanceResumoSincronizacaoVendedor(dr);
		}
		sqlConnection.Close();
		return result;
	}

	private static List<EstatisticaResumoSincronizacaoVendedorTO> CreateInstanceResumoSincronizacaoVendedor(SqlDataReader dr)
	{
		List<EstatisticaResumoSincronizacaoVendedorTO> list = new List<EstatisticaResumoSincronizacaoVendedorTO>();
		while (dr.Read())
		{
			EstatisticaResumoSincronizacaoVendedorTO estatisticaResumoSincronizacaoVendedorTO = new EstatisticaResumoSincronizacaoVendedorTO();
			estatisticaResumoSincronizacaoVendedorTO.CodigoVendedor = GetDataReader.GetString(dr, "codigoVendedor");
			estatisticaResumoSincronizacaoVendedorTO.NomeVendedor = GetDataReader.GetString(dr, "nomeVendedor");
			estatisticaResumoSincronizacaoVendedorTO.NomeGuerra = GetDataReader.GetString(dr, "nomeGuerra");
			estatisticaResumoSincronizacaoVendedorTO.DataUltimaAtualizacao = GetDataReader.GetNullableDateTime(dr, "dataUltimaAtualizacao");
			list.Add(estatisticaResumoSincronizacaoVendedorTO);
		}
		return list;
	}
}
