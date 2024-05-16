using System;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Api.Model;

namespace Target.Mob.Desktop.Api.DAL;

public class IndicacaoFaltaEstoqueDAL
{
	private const string INSERT = "tgtmob_uspIndicacaoFaltaEstoqueInsert";

	private const string SELECT_BY_ID = "tgtmob_uspIndicacaoFaltaEstoqueSelect";

	public static int Insert(string stringConnTargetErp, IndicacaoFaltaEstoqueTO model)
	{
		int num = 0;
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndicacaoFaltaEstoqueInsert", sqlConnection, sqlTransaction);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.Add("@IDIndicacaoFaltaEstoque", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
			setParametros(model, sqlCommand);
			sqlCommand.ExecuteNonQuery();
			num = (int)sqlCommand.Parameters["@IDIndicacaoFaltaEstoque"].Value;
			sqlTransaction.Commit();
			return num;
		}
		catch (Exception ex)
		{
			sqlTransaction.Rollback();
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public static IndicacaoFaltaEstoqueTO SelectByID(string stringConnTargetErp, int id)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("tgtmob_uspIndicacaoFaltaEstoqueSelect", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@IDIndicacaoFaltaEstoque", id);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			IndicacaoFaltaEstoqueTO result = null;
			if (sqlDataReader.Read())
			{
				result = CreateInstance(sqlDataReader);
			}
			return result;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	private static IndicacaoFaltaEstoqueTO CreateInstance(SqlDataReader dr)
	{
		return new IndicacaoFaltaEstoqueTO
		{
			IDIndicacaoFaltaEstoque = GetDataReader.GetInt32(dr, "IDIndicacaoFaltaEstoque"),
			DataReporte = GetDataReader.GetDateTime(dr, "DataReporte"),
			CdClien = GetDataReader.GetInt32(dr, "CdClien"),
			CdPromotor = GetDataReader.GetString(dr, "CdPromotor"),
			CdProd = GetDataReader.GetInt32(dr, "CdProd")
		};
	}

	private static void setParametros(IndicacaoFaltaEstoqueTO model, SqlCommand cmd)
	{
		cmd.Parameters.AddWithValue("@DataReporte", model.DataReporte);
		cmd.Parameters.AddWithValue("@CdClien", model.CdClien);
		cmd.Parameters.AddWithValue("@CdPromotor", model.CdPromotor);
		cmd.Parameters.AddWithValue("@CdProd", model.CdProd);
	}
}
