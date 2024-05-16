using System.Data;
using System.Data.SqlClient;

namespace Target.Venda.Helpers.Dao;

public static class DbTempHelper
{
	public static int ExecuteNonQuery(string cmdText, string nameTmpTable)
	{
		SqlCommand command = getCommand(cmdText, nameTmpTable);
		return executeNonQuery(command);
	}

	private static int executeNonQuery(SqlCommand cmd)
	{
		if (cmd.Connection.State == ConnectionState.Closed)
		{
			cmd.Connection.Open();
		}
		return cmd.ExecuteNonQuery();
	}

	private static SqlCommand getCommand(string cmdText, string keyConnection)
	{
		SqlConnection openConnection = DbConnectionManager.GetOpenConnection(keyConnection);
		if (openConnection.State == ConnectionState.Closed)
		{
			openConnection.Open();
		}
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.CommandText = cmdText;
		sqlCommand.Connection = openConnection;
		return sqlCommand;
	}
}
