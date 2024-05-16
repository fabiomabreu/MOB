using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorInadimplenciaFormPgtoBLL
{
	public static void Merge(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		if (Exists(transaction, instance))
		{
			Update(transaction, instance);
		}
		else
		{
			Insert(transaction, instance);
		}
	}

	public static List<ConfiguracaoVendedorInadimplenciaFormPgtoTO> Select(SqlConnection connection, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		return ConfiguracaoVendedorInadimplenciaFormPgtoDAL.Select(connection, instance);
	}

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		ConfiguracaoVendedorInadimplenciaFormPgtoDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		ConfiguracaoVendedorInadimplenciaFormPgtoDAL.Update(transaction, instance);
	}

	public static bool Exists(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		return ConfiguracaoVendedorInadimplenciaFormPgtoDAL.Exists(transaction, instance);
	}

	public static bool Delete(SqlTransaction transaction, ConfiguracaoVendedorInadimplenciaFormPgtoTO instance)
	{
		return ConfiguracaoVendedorInadimplenciaFormPgtoDAL.Delete(transaction, instance);
	}
}
