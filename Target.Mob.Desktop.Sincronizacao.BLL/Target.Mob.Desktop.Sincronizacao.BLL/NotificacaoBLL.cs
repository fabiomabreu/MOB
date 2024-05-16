using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Dal;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class NotificacaoBLL
{
	public static void Insert(DbConnection transaction, NotificacaoTO instance)
	{
		NotificacaoDAL.Insert(transaction, instance);
	}

	public static void Update(DbConnection transaction, NotificacaoTO instance)
	{
		NotificacaoDAL.Update(transaction, instance);
	}

	public static void Delete(DbConnection transaction, NotificacaoTO instance)
	{
		NotificacaoDAL.Delete(transaction, instance);
	}

	public static List<NotificacaoTO> Select(DbConnection connection, NotificacaoTO instance)
	{
		return NotificacaoDAL.Select(connection, instance);
	}

	public static List<NotificacaoTO> SelectNaoTransmitidas(DbConnection connection, NotificacaoTO instance)
	{
		return NotificacaoDAL.SelectNaoTransmitidas(connection, instance);
	}

	public static bool Exists(DbConnection transaction, NotificacaoTO instance)
	{
		return NotificacaoDAL.Exists(transaction, instance);
	}

	public static void VerificarNotificacoes(DbConnection transaction, string nomeServidorOrigem, string nomeDbOrigem)
	{
		NotificacaoDAL.VerificarNotificacoes(transaction, nomeServidorOrigem, nomeDbOrigem);
	}

	public static void AtualizarTransmitidos(DbConnection transaction, int idNotificacao)
	{
		NotificacaoDAL.AtualizarTransmitidos(transaction, idNotificacao);
	}
}
