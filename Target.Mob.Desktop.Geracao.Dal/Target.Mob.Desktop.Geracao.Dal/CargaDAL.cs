using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class CargaDAL
{
	public static List<CargaTO> Select(SqlConnection conexao, CargaTO carga)
	{
		using SqlDataReader dr = SelectDR(conexao, carga);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, CargaTO carga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", carga.Id);
		sqlCommand.Parameters.AddWithValue("@DataGeracao", carga.DataGeracao);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
		sqlCommand.Parameters.AddWithValue("@Transmitido", carga.Transmitido);
		sqlCommand.Parameters.AddWithValue("@DataTransmitido", carga.DataTransmitido);
		return sqlCommand.ExecuteReader();
	}

	public static SqlDataReader SelectDRSemArquivo(SqlConnection conexao, CargaTO carga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaSelectSemArquivo", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", carga.Id);
		sqlCommand.Parameters.AddWithValue("@DataGeracao", carga.DataGeracao);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
		sqlCommand.Parameters.AddWithValue("@Transmitido", carga.Transmitido);
		sqlCommand.Parameters.AddWithValue("@DataTransmitido", carga.DataTransmitido);
		return sqlCommand.ExecuteReader();
	}

	public static List<CargaTO> SelectSemArquivo(SqlConnection conexao, CargaTO carga)
	{
		using SqlDataReader dr = SelectDRSemArquivo(conexao, carga);
		return CreateInstance(dr, arquivo: false);
	}

	public static DataTable SelectDT(SqlConnection conexao, CargaTO carga)
	{
		using SqlDataReader reader = SelectDR(conexao, carga);
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

	private static List<CargaTO> CreateInstance(SqlDataReader dr)
	{
		return CreateInstance(dr, arquivo: true);
	}

	private static List<CargaTO> CreateInstance(SqlDataReader dr, bool arquivo)
	{
		List<CargaTO> list = new List<CargaTO>();
		while (dr.Read())
		{
			CargaTO cargaTO = new CargaTO();
			cargaTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			cargaTO.DataGeracao = GetDataReader.GetNullableDateTime(dr, "DataGeracao");
			cargaTO.IdVendedor = GetDataReader.GetNullableInt32(dr, "IdVendedor");
			cargaTO.IdVersaoCarga = GetDataReader.GetNullableInt32(dr, "IdVersaoCarga");
			cargaTO.IdGeracao = GetDataReader.GetNullableInt32(dr, "IdGeracao");
			cargaTO.TipoCarga = (TipoCargaTR?)GetDataReader.GetNullableInt32(dr, "IdTipoCargaTR");
			if (arquivo)
			{
				cargaTO.ArquivoCarga = GetDataReader.GetByteArray(dr, "ArquivoCarga");
			}
			cargaTO.Transmitido = GetDataReader.GetNullableBoolean(dr, "Transmitido");
			cargaTO.DataTransmitido = GetDataReader.GetNullableDateTime(dr, "DataTransmitido");
			list.Add(cargaTO);
		}
		return list;
	}

	public static void Insert(SqlConnection conexao, CargaTO carga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaInsert", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 3600;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@DataGeracao", carga.DataGeracao);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
		sqlCommand.Parameters.AddWithValue("@ArquivoCarga", carga.ArquivoCarga);
		sqlCommand.Parameters.AddWithValue("@Transmitido", carga.Transmitido);
		sqlCommand.Parameters.AddWithValue("@DataTransmitido", carga.DataTransmitido);
		object obj = sqlCommand.ExecuteScalar();
		carga.Id = int.Parse(obj.ToString());
	}

	public static void Insert(SqlConnection conexao, SqlTransaction transaction, CargaTO carga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaInsert", conexao, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 3600;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@DataGeracao", carga.DataGeracao);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
		sqlCommand.Parameters.AddWithValue("@ArquivoCarga", carga.ArquivoCarga);
		sqlCommand.Parameters.AddWithValue("@Transmitido", carga.Transmitido);
		sqlCommand.Parameters.AddWithValue("@DataTransmitido", carga.DataTransmitido);
		object obj = sqlCommand.ExecuteScalar();
		carga.Id = int.Parse(obj.ToString());
	}

	public static void Update(SqlConnection conexao, CargaTO carga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaUpdate", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", carga.Id);
		sqlCommand.Parameters.AddWithValue("@DataGeracao", carga.DataGeracao);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
		sqlCommand.Parameters.AddWithValue("@ArquivoCarga", carga.ArquivoCarga);
		sqlCommand.Parameters.AddWithValue("@Transmitido", carga.Transmitido);
		sqlCommand.Parameters.AddWithValue("@DataTransmitido", carga.DataTransmitido);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Delete(SqlConnection conexao, CargaTO carga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaDelete", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", carga.Id);
		sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
		sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
		sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
		sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
		sqlCommand.ExecuteNonQuery();
	}

	public static bool Exists(SqlConnection conexao, CargaTO carga)
	{
		int num = 0;
		using (SqlCommand sqlCommand = new SqlCommand("uspCargaExists", conexao))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@DataGeracao", carga.DataGeracao);
			sqlCommand.Parameters.AddWithValue("@IdVendedor", carga.IdVendedor);
			sqlCommand.Parameters.AddWithValue("@IdVersaoCarga", carga.IdVersaoCarga);
			sqlCommand.Parameters.AddWithValue("@IdGeracao", carga.IdGeracao);
			sqlCommand.Parameters.AddWithValue("@IdTipoCargaTR", carga.TipoCarga);
			sqlCommand.Parameters.AddWithValue("@Transmitido", carga.Transmitido);
			sqlCommand.Parameters.AddWithValue("@DataTransmitido", carga.DataTransmitido);
			num = (int)sqlCommand.ExecuteScalar();
		}
		return num != 0;
	}

	public static bool ExistsCompleta(SqlConnection conexao, int? idVendedor, int? major, int? minor, int? build, int? revision)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaExistsCompleta", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdVendedor", idVendedor);
		sqlCommand.Parameters.AddWithValue("@Major", major);
		sqlCommand.Parameters.AddWithValue("@Minor", minor);
		sqlCommand.Parameters.AddWithValue("@Build", build);
		sqlCommand.Parameters.AddWithValue("@Revision", revision);
		return (bool)sqlCommand.ExecuteScalar();
	}

	public static void SetTransmitido(SqlConnection conexao, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaSetTransmitido", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<CargaTO> SelectEnvio(SqlConnection sqlConnection, int? IdVendedor)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaSelectEnvio", sqlConnection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdVendedor", IdVendedor);
		return CreateInstance(sqlCommand.ExecuteReader());
	}

	public static void SelectMonitoramento(SqlConnection sqlConnection, ref int? CargaPendEnvioQtde, ref DateTime? CargaPendEnvioMaisAntigo)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCargaSelectMonitoramento", sqlConnection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows && sqlDataReader.Read())
		{
			CargaPendEnvioQtde = Convert.ToInt32(sqlDataReader["CargaPendEnvioQtde"]);
			if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("CargaPendEnvioMaisAntigo")))
			{
				CargaPendEnvioMaisAntigo = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("CargaPendEnvioMaisAntigo"));
			}
		}
		sqlDataReader.Close();
	}
}
