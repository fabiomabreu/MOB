using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;

namespace Target.Venda.Helpers.Dao;

public static class DbConnectionManager
{
	private static Dictionary<string, SqlConnection> _dicConnection;

	private static void Add(string key, SqlConnection connection)
	{
		try
		{
			if (_dicConnection == null)
			{
				_dicConnection = new Dictionary<string, SqlConnection>();
			}
			if (!_dicConnection.ContainsKey(key))
			{
				_dicConnection.Add(key, connection);
			}
			else
			{
				_dicConnection[key] = connection;
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static void DisposeConnection(string key)
	{
		try
		{
			if (_dicConnection == null || !_dicConnection.ContainsKey(key))
			{
				throw new Exception($"A conexão '{key}' não foi iniciada.");
			}
			_dicConnection[key].Close();
			_dicConnection[key].Dispose();
			_dicConnection.Remove(key);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static SqlConnection GetOpenConnection(string key)
	{
		if (_dicConnection == null)
		{
			_dicConnection = new Dictionary<string, SqlConnection>();
		}
		if (_dicConnection.ContainsKey(key))
		{
			return _dicConnection[key];
		}
		SqlConnection sqlConnection = new SqlConnection(ConfigHelper.getStringConnection());
		sqlConnection.Open();
		Add(key, sqlConnection);
		return sqlConnection;
	}
}
