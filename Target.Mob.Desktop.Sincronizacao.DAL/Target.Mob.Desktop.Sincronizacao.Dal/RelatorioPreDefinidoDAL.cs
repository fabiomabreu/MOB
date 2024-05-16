using System;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class RelatorioPreDefinidoDAL
{
	public static DataTable Select(DbConnection connection, CadastroSPTO cadastroTO, string codigoVendedor)
	{
		string cmdText = cadastroTO.Descricao.Trim();
		SqlCommand sqlCommand = null;
		connection.Open();
		DataTable dataTable = new DataTable();
		try
		{
			using (sqlCommand = new SqlCommand(cmdText, connection.GetConnection()))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Clear();
				sqlCommand.Parameters.AddWithValue("@par_CodigoVendedor", codigoVendedor);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
				sqlDataAdapter.SelectCommand = sqlCommand;
				sqlDataAdapter.Fill(dataTable);
				return dataTable;
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static void Select_Carga(DbConnection connectionTargetERP, string nomeDb, string linkedServer, DbConnection connectionTargetMob)
	{
		string cmdText = "UspTargetMobIniciaCarga";
		string cmdText2 = "UspTargetMobVend";
		SqlCommand sqlCommand = null;
		connectionTargetERP.Open();
		connectionTargetMob.Open();
		DataTable dataTable = new DataTable();
		try
		{
			using (sqlCommand = new SqlCommand(cmdText2, connectionTargetMob.GetConnection()))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Clear();
				sqlCommand.Parameters.Add("@ServidorOrigem", (!string.IsNullOrEmpty(linkedServer)) ? linkedServer : null);
				sqlCommand.Parameters.Add("@BancoOrigem", nomeDb);
				sqlCommand.CommandTimeout = 600;
				sqlCommand.ExecuteScalar();
			}
			sqlCommand = null;
			using (sqlCommand = new SqlCommand(cmdText, connectionTargetERP.GetConnection()))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Clear();
				sqlCommand.CommandTimeout = 600;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
				sqlDataAdapter.SelectCommand = sqlCommand;
				sqlDataAdapter.Fill(dataTable);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
