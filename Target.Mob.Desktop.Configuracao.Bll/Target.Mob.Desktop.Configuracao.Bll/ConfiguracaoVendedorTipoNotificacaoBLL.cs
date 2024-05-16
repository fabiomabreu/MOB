using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorTipoNotificacaoBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		ConfiguracaoVendedorTipoNotificacaoDAL.Insert(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		ConfiguracaoVendedorTipoNotificacaoDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorTipoNotificacaoTO> Select(SqlConnection connection, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		return ConfiguracaoVendedorTipoNotificacaoDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, ConfiguracaoVendedorTipoNotificacaoTO instance)
	{
		return ConfiguracaoVendedorTipoNotificacaoDAL.Exists(transaction, instance);
	}
}
