using System;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ReplicacaoDAL
{
	private const string ReplicarTabela = "uspReplicarDadosTabela";

	private const string ReplicarTabelaLog = "uspReplicarDadosTabelaLog";

	private const string ReplicarTabelaRowId = "uspRowIdSel";

	public static DataTable EstruturaTabela(DbConnection connection, string tabela)
	{
		DataSet dataSet = new DataSet();
		string selectCommandText = "SELECT TOP 0 * FROM " + tabela;
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connection.GetConnection());
			try
			{
				sqlDataAdapter.ReturnProviderSpecificTypes = true;
				sqlDataAdapter.Fill(dataSet);
				dataSet.Tables[0].TableName = tabela;
			}
			finally
			{
				((IDisposable)(object)sqlDataAdapter)?.Dispose();
			}
		}
		catch (Exception)
		{
			dataSet = null;
		}
		return dataSet.Tables[0];
	}

	public static DataTable InfoTabela(DbConnection connection, string tabela)
	{
		DataTable dataTable = new DataTable();
		string commandText = "SELECT OBJECT_NAME(c.OBJECT_ID) AS Tabela ,c.name AS Coluna ,t.name AS TipoDado ,c.is_nullable AS ValorNulo ,c.max_length AS TamanhoMaximo, c.PRECISION AS Precisao, c.scale AS Escala FROM sys.columns AS c JOIN sys.types AS t ON c.user_type_id=t.user_type_id WHERE c.object_id = object_id('" + tabela + "')";
		try
		{
			using IDataReader reader = connection.ExecuteReader(CommandType.Text, commandText);
			dataTable.Load(reader);
			dataTable.TableName = tabela;
		}
		catch (Exception)
		{
			dataTable = null;
		}
		return dataTable;
	}

	public static DataTable Dados(DbConnection connection, string tabela)
	{
		DataSet dataSet = new DataSet();
		string selectCommandText = "SELECT * FROM " + tabela;
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connection.GetConnection());
			try
			{
				sqlDataAdapter.ReturnProviderSpecificTypes = true;
				sqlDataAdapter.Fill(dataSet);
				dataSet.Tables[0].TableName = tabela;
			}
			finally
			{
				((IDisposable)(object)sqlDataAdapter)?.Dispose();
			}
		}
		catch (Exception)
		{
			dataSet = null;
		}
		return dataSet.Tables[0];
	}

	public static DataTable DadosReplicar(DbConnection connection, string tabela, int totalRegistros)
	{
		DataSet dataSet = new DataSet();
		string selectCommandText = "SELECT TOP " + totalRegistros + " * FROM " + tabela + " WHERE Replicado = 0 order by IdControleTabelaLog";
		connection.ClearParameters();
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connection.GetConnection());
			try
			{
				sqlDataAdapter.ReturnProviderSpecificTypes = true;
				sqlDataAdapter.Fill(dataSet);
				dataSet.Tables[0].TableName = tabela;
			}
			finally
			{
				((IDisposable)(object)sqlDataAdapter)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			dataSet = null;
			throw ex;
		}
		return dataSet.Tables[0];
	}

	public static int TotalRegistros(DbConnection connection, string tabela)
	{
		int result = 0;
		string commandText = "SELECT COUNT(*) AS Total FROM " + tabela + " WHERE Replicado = 0";
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.Text, commandText);
		using (basicRS)
		{
			while (basicRS.MoveNext())
			{
				result = basicRS.GetInteger("Total");
			}
			return result;
		}
	}

	public static bool ExecutarScript(DbConnection connection, string script)
	{
		bool result = true;
		try
		{
			connection.ExecuteNonQuery(CommandType.Text, script);
			return result;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static bool SalvarTabela(DbConnection connection, DataTable dt)
	{
		bool result = true;
		string commandText = "DELETE FROM " + dt.TableName;
		connection.ExecuteNonQuery(CommandType.Text, commandText);
		SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection.GetConnection(), SqlBulkCopyOptions.KeepIdentity, null);
		sqlBulkCopy.DestinationTableName = dt.TableName;
		try
		{
			sqlBulkCopy.WriteToServer(dt);
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	public static void ReplicarDadosTabela(DbConnection connection, string tabela, int idControleTabelaLog)
	{
		connection.ClearParameters();
		connection.AddParameters("@Tabela", tabela);
		connection.AddParameters("@IdControleTabelaLog", idControleTabelaLog);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReplicarDadosTabela");
	}

	public static void ReplicarDadosTabelaLog(DbConnection connection, string servidorOrigem, string bancoOrigem, string tabelaOrigem, string tabelaDestino, string condicaoSelecao)
	{
		connection.SetCommandTimeout(300);
		connection.ClearParameters();
		connection.AddParameters("@ServidorOrigem", servidorOrigem);
		connection.AddParameters("@BancoOrigem", bancoOrigem);
		connection.AddParameters("@TabelaOrigem", tabelaOrigem);
		connection.AddParameters("@TabelaDestino", tabelaDestino);
		connection.AddParameters("@CondicaoSelecao", condicaoSelecao);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspReplicarDadosTabelaLog");
	}

	public static byte[] SelectRowId(DbConnection connection, string tabela)
	{
		byte[] result = null;
		connection.ClearParameters();
		connection.AddParameters("@modelo", tabela);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspRowIdSel");
		if (obj.ToString() != "")
		{
			result = (byte[])obj;
		}
		return result;
	}
}
