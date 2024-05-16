using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorVisitaFrequenciaBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		ConfiguracaoVendedorVisitaFrequenciaDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		ConfiguracaoVendedorVisitaFrequenciaDAL.Update(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		ConfiguracaoVendedorVisitaFrequenciaDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorVisitaFrequenciaTO> Select(SqlConnection connection, ConfiguracaoVendedorVisitaFrequenciaTO instance)
	{
		return ConfiguracaoVendedorVisitaFrequenciaDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoVendedorVisitaFrequenciaDAL.Exists(transaction, id);
	}
}
