using System;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class GeraDadosDAL
{
	public static int LogInsert(string connStringTargetERP, GeracaoLogTO geracao)
	{
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspGeracaoLog_INSERT", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@DataInicio", geracao.DataInicio);
			sqlCommand.Parameters.AddWithValue("@DataFim", geracao.DataFim);
			sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoTR", geracao.IdStatusGeracaoTR);
			sqlCommand.Parameters.AddWithValue("@Erro", geracao.Erro);
			sqlCommand.Parameters.AddWithValue("@MultiThread", geracao.MultiThread);
			sqlCommand.Parameters.AddWithValue("@Versao", geracao.Versao);
			sqlCommand.Parameters.AddWithValue("@VersaoMajor", geracao.VersaoMajor);
			sqlCommand.Parameters.AddWithValue("@VersaoMinor", geracao.VersaoMinor);
			sqlCommand.Parameters.AddWithValue("@Etapa", geracao.Etapa);
			object obj = sqlCommand.ExecuteScalar();
			geracao.Id = int.Parse(obj.ToString());
		}
		sqlConnection.Close();
		return geracao.Id;
	}

	public static void LimpaCargaEntidadeExclusaoAntigas(string connStringTargetERP)
	{
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspLimpaCargaEntidadeExclusaoAntigas", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	public static void LimpaLogAlteracaoTabela(string connStringTargetERP)
	{
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaLimpaLogAlteracaoTabela", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	public static void LogUpdate(string connStringTargetERP, GeracaoLogTO geracao)
	{
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspGeracaoLog_UPDATE", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@Id", geracao.Id);
			sqlCommand.Parameters.AddWithValue("@DataInicio", geracao.DataInicio);
			sqlCommand.Parameters.AddWithValue("@DataFim", geracao.DataFim);
			sqlCommand.Parameters.AddWithValue("@IdStatusGeracaoTR", geracao.IdStatusGeracaoTR);
			sqlCommand.Parameters.AddWithValue("@Erro", geracao.Erro);
			sqlCommand.Parameters.AddWithValue("@MultiThread", geracao.MultiThread);
			sqlCommand.Parameters.AddWithValue("@Etapa", geracao.Etapa);
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	public static bool IsVersaoCompativel(string connStringTargetERP, int versaoMajor, int versaoMinor)
	{
		bool result = false;
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspGeracaoLog_IsVersaoCompativel", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@VersaoMajor", versaoMajor);
			sqlCommand.Parameters.AddWithValue("@VersaoMinor", versaoMinor);
			result = Convert.ToBoolean(int.Parse(sqlCommand.ExecuteScalar().ToString()));
		}
		sqlConnection.Close();
		return result;
	}
}
