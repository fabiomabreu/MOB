using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorVisitaDiasSemanaBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		ConfiguracaoVendedorVisitaDiasSemanaDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		ConfiguracaoVendedorVisitaDiasSemanaDAL.Update(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		ConfiguracaoVendedorVisitaDiasSemanaDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorVisitaDiasSemanaTO> Select(SqlConnection connection, ConfiguracaoVendedorVisitaDiasSemanaTO instance)
	{
		return ConfiguracaoVendedorVisitaDiasSemanaDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoVendedorVisitaDiasSemanaDAL.Exists(transaction, id);
	}
}
