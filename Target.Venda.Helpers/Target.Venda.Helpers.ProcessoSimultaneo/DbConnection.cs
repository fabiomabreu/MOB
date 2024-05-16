using System;
using System.Data;
using System.Data.SqlClient;

namespace Target.Venda.Helpers.ProcessoSimultaneo;

public class DbConnection : IDisposable
{
	private SqlCommand command;

	private SqlConnection connection;

	private SqlTransaction transaction;

	private bool disposed = false;

	public ConnectionState State => connection.State;

	public DbConnection(string connectionString)
	{
		connection = new SqlConnection(connectionString);
		command = new SqlCommand();
		command.Connection = connection;
	}

	public SqlParameter AddParameters(string parameterName, object value)
	{
		return command.Parameters.AddWithValue(parameterName, value);
	}

	public void ClearParameters()
	{
		command.Parameters.Clear();
	}

	public void SetCommandTimeout(int commandTimeout)
	{
		command.CommandTimeout = commandTimeout;
	}

	public int ExecuteNonQuery(CommandType commandType, string commandText)
	{
		command.CommandType = commandType;
		command.CommandText = commandText;
		command.Transaction = transaction;
		return command.ExecuteNonQuery();
	}

	public object ExecuteScalar(CommandType commandType, string commandText)
	{
		command.CommandType = commandType;
		command.CommandText = commandText;
		command.Transaction = transaction;
		return command.ExecuteScalar();
	}

	public void Open()
	{
		if (State == ConnectionState.Closed)
		{
			connection.Open();
		}
	}

	public void BeginTransaction()
	{
		if (transaction == null)
		{
			transaction = connection.BeginTransaction();
		}
	}

	public void CommitTransaction()
	{
		transaction.Commit();
		transaction.Dispose();
		transaction = null;
	}

	public void Close()
	{
		if (State != 0)
		{
			connection.Close();
		}
	}

	public void RollbackTransaction()
	{
		if (transaction != null)
		{
			transaction.Rollback();
			transaction.Dispose();
			transaction = null;
		}
	}

	public SqlConnection GetConnection()
	{
		return connection;
	}

	public SqlTransaction GetTransaction()
	{
		return transaction;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Dispose(bool disposing)
	{
		if (disposed)
		{
			return;
		}
		if (disposing)
		{
			if (command != null)
			{
				command.Dispose();
			}
			if (transaction != null)
			{
				transaction.Dispose();
			}
			if (connection != null)
			{
				connection.Dispose();
			}
		}
		disposed = true;
	}

	~DbConnection()
	{
		Dispose(disposing: false);
	}
}
