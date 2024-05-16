using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class TipoNotificacaoDAL
{
	private const string INSERT = "uspTipoNotificacaoInsert";

	private const string UPDATE = "uspTipoNotificacaoUpdate";

	private const string SELECT = "uspTipoNotificacaoSelect";

	private const string EXISTS = "uspTipoNotificacaoExists";

	private const string DELETE = "uspTipoNotificacaoDelete";

	public static void Insert(SqlTransaction transaction, TipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspTipoNotificacaoInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@Descricao", instance.Descricao);
		sqlCommand.Parameters.AddWithValue("@Ativo", instance.Ativo);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, TipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspTipoNotificacaoUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@Descricao", instance.Descricao);
		sqlCommand.Parameters.AddWithValue("@Ativo", instance.Ativo);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<TipoNotificacaoTO> Select(SqlConnection connection, TipoNotificacaoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection connection, TipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspTipoNotificacaoSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@Descricao", instance.Descricao);
		sqlCommand.Parameters.AddWithValue("@Ativo", instance.Ativo);
		return sqlCommand.ExecuteReader();
	}

	private static List<TipoNotificacaoTO> CreateInstance(SqlDataReader dr)
	{
		List<TipoNotificacaoTO> list = new List<TipoNotificacaoTO>();
		while (dr.Read())
		{
			TipoNotificacaoTO tipoNotificacaoTO = new TipoNotificacaoTO();
			tipoNotificacaoTO.IDTipoNotificacao = GetDataReader.GetDrInt(dr["IDTipoNotificacao"]);
			tipoNotificacaoTO.Descricao = GetDataReader.GetDrString(dr["Descricao"]);
			tipoNotificacaoTO.Ativo = GetDataReader.GetDrNullableBool(dr["Ativo"]);
			list.Add(tipoNotificacaoTO);
		}
		return list;
	}

	public static bool Delete(SqlTransaction transacao, TipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspTipoNotificacaoDelete", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		return Convert.ToBoolean(sqlCommand.ExecuteScalar());
	}

	public static bool Exists(SqlTransaction transacao, TipoNotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspTipoNotificacaoExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}
}
