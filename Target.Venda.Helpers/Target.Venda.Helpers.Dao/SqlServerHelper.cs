#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;

namespace Target.Venda.Helpers.Dao;

public static class SqlServerHelper
{
	public static CONTEXTO _CONTEXTO;

	private static SqlConnection _cnn;

	public static T executeScalar<T>(string cmdText)
	{
		SqlCommand command = getCommand(cmdText);
		return executeScalar<T>(command);
	}

	public static T executeScalar<T>(SqlCommand cmd)
	{
		if (cmd.Connection == null)
		{
			cmd.Connection = getOpenConnection();
		}
		else if (cmd.Connection.State == ConnectionState.Closed)
		{
			cmd.Connection.Open();
		}
		Debug.WriteLine(cmd.CommandText);
		cmd.Prepare();
		object obj = cmd.ExecuteScalar();
		if (obj == null || obj == DBNull.Value)
		{
			return default(T);
		}
		closeConnection();
		if (typeof(T) == typeof(long))
		{
			obj = Convert.ToInt64(obj);
		}
		else if (typeof(T) == typeof(double))
		{
			obj = Convert.ToDouble(obj);
		}
		else if (typeof(T) == typeof(string))
		{
			obj = Convert.ToString(obj);
		}
		else if (typeof(T) == typeof(bool))
		{
			obj = Convert.ToBoolean(obj);
		}
		return (T)obj;
	}

	public static int executeNonQuery(string cmdText)
	{
		SqlCommand command = getCommand(cmdText);
		int result = executeNonQuery(command);
		closeConnection();
		return result;
	}

	public static SqlDataReader executeReader(string cmdText)
	{
		SqlCommand command = getCommand(cmdText);
		return command.ExecuteReader(CommandBehavior.CloseConnection);
	}

	public static int executeNonQuery(SqlCommand cmd)
	{
		if (cmd.Connection == null)
		{
			cmd.Connection = getOpenConnection();
		}
		else if (cmd.Connection.State == ConnectionState.Closed)
		{
			cmd.Connection.Open();
		}
		Debug.WriteLine(cmd.CommandText);
		int result = cmd.ExecuteNonQuery();
		closeConnection();
		return result;
	}

	public static SqlCommand getCommand(string cmdText)
	{
		Debug.WriteLine(cmdText);
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.CommandText = cmdText;
		sqlCommand.Connection = getOpenConnection();
		return sqlCommand;
	}

	public static T ExecuteStoreProcedure<T>(string PROCEDURE, List<SqlParameter> PARAMETROS, int TimeOut = 0)
	{
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.Connection = getOpenConnection();
		sqlCommand.CommandText = PROCEDURE;
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.AddRange(PARAMETROS.ToArray());
		if (TimeOut > 0)
		{
			sqlCommand.CommandTimeout = TimeOut;
		}
		return executeScalar<T>(sqlCommand);
	}

	public static bool VerificaStringConexao(string str_con)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection();
			sqlConnection.ConnectionString = str_con;
			sqlConnection.Open();
			if (sqlConnection.State == ConnectionState.Open)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static SqlConnection getOpenConnection()
	{
		try
		{
			if (_cnn == null)
			{
				_cnn = new SqlConnection();
			}
			if (_cnn.State == ConnectionState.Open)
			{
				_cnn.Close();
			}
			if (_CONTEXTO == CONTEXTO.Target)
			{
				_cnn.ConnectionString = ConfigHelper.getStringConnection("TARGET");
			}
			else if (_CONTEXTO == CONTEXTO.DataCenter)
			{
				string stringConnection = ConfigHelper.getStringConnection("DATACENTER");
			}
			else if (_CONTEXTO == CONTEXTO.Retaguarda)
			{
				_cnn.ConnectionString = ConfigHelper.getStringConnection();
			}
			if (_cnn.State == ConnectionState.Closed)
			{
				_cnn.Open();
			}
			return _cnn;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static void closeConnection()
	{
		try
		{
			if (_cnn.State == ConnectionState.Open)
			{
				_cnn.Close();
			}
			if (_cnn != null)
			{
				_cnn.Dispose();
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static object createParameter(string name, object value)
	{
		return createParameter(name, SqlDbType.NVarChar, value, ParameterDirection.Input);
	}

	public static object createParameter(string name, SqlDbType type, object value)
	{
		return createParameter(name, type, value, ParameterDirection.Input);
	}

	public static object createParameter(string name, SqlDbType type, object value, ParameterDirection direction)
	{
		SqlParameter sqlParameter = new SqlParameter(name, value);
		sqlParameter.Direction = direction;
		sqlParameter.SqlDbType = type;
		return sqlParameter;
	}
}
