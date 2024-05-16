using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ServicoDAL
{
	private const string INSERT = "uspServicoInsert";

	private const string UPDATE = "uspServicoUpdate";

	private const string SELECT = "uspServicoSelect";

	private const string EXISTS = "uspServicoExists";

	private const string DELETE = "uspServicoDelete";

	public static void Insert(SqlTransaction transaction, ServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspServicoInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@CodigoServico", instance.CodigoServico);
		sqlCommand.Parameters.AddWithValue("@Status", instance.Status);
		sqlCommand.Parameters.AddWithValue("@Nome", instance.Nome);
		sqlCommand.Parameters.AddWithValue("@Principal", instance.Principal);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspServicoUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@CodigoServico", instance.CodigoServico);
		sqlCommand.Parameters.AddWithValue("@Status", instance.Status);
		sqlCommand.Parameters.AddWithValue("@Nome", instance.Nome);
		sqlCommand.Parameters.AddWithValue("@Principal", instance.Principal);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ServicoTO> Select(SqlConnection connection, ServicoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspServicoSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.Parameters.AddWithValue("@CodigoServico", instance.CodigoServico);
		sqlCommand.Parameters.AddWithValue("@Status", instance.Status);
		sqlCommand.Parameters.AddWithValue("@Nome", instance.Nome);
		sqlCommand.Parameters.AddWithValue("@Principal", instance.Principal);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspServicoExists", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	public static void Delete(SqlTransaction transaction, ServicoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspServicoDelete", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", instance.Id);
		sqlCommand.ExecuteNonQuery();
	}

	private static List<ServicoTO> CreateInstance(SqlDataReader dr)
	{
		List<ServicoTO> list = new List<ServicoTO>();
		while (dr.Read())
		{
			ServicoTO servicoTO = new ServicoTO();
			servicoTO.Id = GetDataReader.GetInt32(dr, "Id");
			servicoTO.CodigoServico = GetDataReader.GetNullableInt32(dr, "CodigoServico");
			servicoTO.Status = GetDataReader.GetNullableBoolean(dr, "Status");
			servicoTO.Nome = GetDataReader.GetString(dr, "Nome");
			servicoTO.Principal = GetDataReader.GetNullableBoolean(dr, "Principal");
			list.Add(servicoTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
