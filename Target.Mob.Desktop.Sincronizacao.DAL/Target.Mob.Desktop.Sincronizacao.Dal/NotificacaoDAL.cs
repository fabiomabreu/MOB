using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.Dal;

public class NotificacaoDAL
{
	private const string INSERT = "uspNotificacaoInsert";

	private const string UPDATE = "uspNotificacaoUpdate";

	private const string SELECT = "uspNotificacaoSelect";

	private const string EXISTS = "uspNotificacaoExists";

	private const string DELETE = "uspNotificacaoDelete";

	private const string VERIFICAR = "uspNotificacaoGetNews";

	private const string ATUALIZARTRANSMITIDOS = "uspNotificacaoAtualizarTransmitidos";

	private const string SELECTNAOTRANSMITIDOS = "uspNotificacaoSelNaoTransmitidos";

	public static void Insert(DbConnection transaction, NotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoInsert", transaction.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@DataPublicacao", instance.DataPublicacao);
		sqlCommand.Parameters.AddWithValue("@Titulo", instance.Titulo);
		sqlCommand.Parameters.AddWithValue("@Descricao", instance.Descricao);
		sqlCommand.Parameters.AddWithValue("@DtTransmitido", instance.DtTransmitido);
		sqlCommand.Parameters.AddWithValue("@CodigoVendedor", instance.CodigoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(DbConnection transaction, NotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoUpdate", transaction.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDNotificacao", instance.IDNotificacao);
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@DataPublicacao", instance.DataPublicacao);
		sqlCommand.Parameters.AddWithValue("@Titulo", instance.Titulo);
		sqlCommand.Parameters.AddWithValue("@Descricao", instance.Descricao);
		sqlCommand.Parameters.AddWithValue("@DtTransmitido", instance.DtTransmitido);
		sqlCommand.Parameters.AddWithValue("@CodigoVendedor", instance.CodigoVendedor);
		sqlCommand.ExecuteNonQuery();
	}

	public static List<NotificacaoTO> Select(DbConnection connection, NotificacaoTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(DbConnection connection, NotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoSelect", connection.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDNotificacao", instance.IDNotificacao);
		sqlCommand.Parameters.AddWithValue("@IDTipoNotificacao", instance.IDTipoNotificacao);
		sqlCommand.Parameters.AddWithValue("@DataPublicacao", instance.DataPublicacao);
		sqlCommand.Parameters.AddWithValue("@Titulo", instance.Titulo);
		sqlCommand.Parameters.AddWithValue("@Descricao", instance.Descricao);
		sqlCommand.Parameters.AddWithValue("@DtTransmitido", instance.DtTransmitido);
		sqlCommand.Parameters.AddWithValue("@CodigoVendedor", instance.CodigoVendedor);
		return sqlCommand.ExecuteReader();
	}

	public static List<NotificacaoTO> SelectNaoTransmitidas(DbConnection connection, NotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoSelNaoTransmitidos", connection.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDNotificacao", instance.IDNotificacao);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		List<NotificacaoTO> result = CreateInstance(sqlDataReader);
		sqlDataReader.Close();
		return result;
	}

	private static List<NotificacaoTO> CreateInstance(SqlDataReader dr)
	{
		List<NotificacaoTO> list = new List<NotificacaoTO>();
		while (dr.Read())
		{
			NotificacaoTO notificacaoTO = new NotificacaoTO();
			notificacaoTO.IDNotificacao = GetDataReader.GetDrInt(dr["IDNotificacao"]);
			notificacaoTO.IDTipoNotificacao = GetDataReader.GetDrInt(dr["IDTipoNotificacao"]);
			notificacaoTO.DataPublicacao = GetDataReader.GetDrDateTime(dr["DataPublicacao"]);
			notificacaoTO.Titulo = GetDataReader.GetDrString(dr["Titulo"]);
			notificacaoTO.DtTransmitido = GetDataReader.GetDrNullableDateTime(dr["DtTransmitido"]);
			notificacaoTO.Descricao = GetDataReader.GetDrString(dr["Descricao"]);
			notificacaoTO.CodigoVendedor = GetDataReader.GetDrString(dr["CodigoVendedor"]);
			notificacaoTO.IDVendedor = GetDataReader.GetDrNullableInt(dr["IDVendedor"]);
			list.Add(notificacaoTO);
		}
		return list;
	}

	public static bool Delete(DbConnection transacao, NotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoDelete", transacao.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDNotificacao", instance.IDTipoNotificacao);
		return Convert.ToBoolean(sqlCommand.ExecuteScalar());
	}

	public static bool Exists(DbConnection transacao, NotificacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoExists", transacao.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IDNotificacao", instance.IDNotificacao);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	public static void VerificarNotificacoes(DbConnection transacao, string nomeServidorOrigem, string nomeDbOrigem)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoGetNews", transacao.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 150;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@ServidorOrigem", nomeServidorOrigem);
		sqlCommand.Parameters.AddWithValue("@BancoOrigem", nomeDbOrigem);
		sqlCommand.ExecuteNonQuery();
	}

	public static void AtualizarTransmitidos(DbConnection transacao, int idNotificacao)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspNotificacaoAtualizarTransmitidos", transacao.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@IdNotificacao", idNotificacao);
		sqlCommand.ExecuteNonQuery();
	}
}
