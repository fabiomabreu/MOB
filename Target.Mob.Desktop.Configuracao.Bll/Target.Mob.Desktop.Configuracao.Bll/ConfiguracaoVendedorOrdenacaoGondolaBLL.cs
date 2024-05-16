using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorOrdenacaoGondolaBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		ConfiguracaoVendedorOrdenacaoGondolaDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		ConfiguracaoVendedorOrdenacaoGondolaDAL.Update(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		ConfiguracaoVendedorOrdenacaoGondolaDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorOrdenacaoGondolaTO> Select(SqlConnection connection, ConfiguracaoVendedorOrdenacaoGondolaTO instance)
	{
		return ConfiguracaoVendedorOrdenacaoGondolaDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoVendedorOrdenacaoGondolaDAL.Exists(transaction, id);
	}
}
