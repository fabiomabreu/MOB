using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorCoordenadaDiasSemanaBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		ConfiguracaoVendedorCoordenadaDiasSemanaDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		ConfiguracaoVendedorCoordenadaDiasSemanaDAL.Update(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		ConfiguracaoVendedorCoordenadaDiasSemanaDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorCoordenadaDiasSemanaTO> Select(SqlConnection connection, ConfiguracaoVendedorCoordenadaDiasSemanaTO instance)
	{
		return ConfiguracaoVendedorCoordenadaDiasSemanaDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoVendedorCoordenadaDiasSemanaDAL.Exists(transaction, id);
	}
}
