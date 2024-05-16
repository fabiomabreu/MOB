using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorPaisBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorPaisTO instance)
	{
		ConfiguracaoVendedorPaisDAL.Insert(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorPaisTO instance)
	{
		ConfiguracaoVendedorPaisDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorPaisTO> Select(SqlConnection connection, ConfiguracaoVendedorPaisTO instance)
	{
		return ConfiguracaoVendedorPaisDAL.Select(connection, instance);
	}
}
