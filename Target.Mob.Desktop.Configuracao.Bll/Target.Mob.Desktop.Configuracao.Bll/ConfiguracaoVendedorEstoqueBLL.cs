using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorEstoqueBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorEstoqueTO instance)
	{
		ConfiguracaoVendedorEstoqueDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorEstoqueTO instance)
	{
		ConfiguracaoVendedorEstoqueDAL.Update(transaction, instance);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoVendedorEstoqueTO instance)
	{
		ConfiguracaoVendedorEstoqueDAL.Delete(transaction, instance);
	}

	public static List<ConfiguracaoVendedorEstoqueTO> Select(SqlConnection connection, ConfiguracaoVendedorEstoqueTO instance)
	{
		return ConfiguracaoVendedorEstoqueDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoVendedorEstoqueDAL.Exists(transaction, id);
	}
}
