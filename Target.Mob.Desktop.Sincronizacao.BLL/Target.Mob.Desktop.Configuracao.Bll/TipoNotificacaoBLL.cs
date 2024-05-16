using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class TipoNotificacaoBLL
{
	public static void Insert(SqlTransaction transaction, TipoNotificacaoTO instance)
	{
		TipoNotificacaoDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, TipoNotificacaoTO instance)
	{
		TipoNotificacaoDAL.Update(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, TipoNotificacaoTO instance)
	{
		TipoNotificacaoDAL.Delete(transaction, instance);
	}

	public static List<TipoNotificacaoTO> Select(SqlConnection connection, TipoNotificacaoTO instance)
	{
		return TipoNotificacaoDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, TipoNotificacaoTO instance)
	{
		return TipoNotificacaoDAL.Exists(transaction, instance);
	}
}
