using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoVendedorClienteNovoFormPgtoBLL
{
	public static void Merge(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
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

	public static List<ConfiguracaoVendedorClienteNovoFormPgtoTO> Select(SqlConnection connection, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		return ConfiguracaoVendedorClienteNovoFormPgtoDAL.Select(connection, instance);
	}

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		ConfiguracaoVendedorClienteNovoFormPgtoDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		ConfiguracaoVendedorClienteNovoFormPgtoDAL.Update(transaction, instance);
	}

	public static bool Exists(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		return ConfiguracaoVendedorClienteNovoFormPgtoDAL.Exists(transaction, instance);
	}

	public static bool Delete(SqlTransaction transaction, ConfiguracaoVendedorClienteNovoFormPgtoTO instance)
	{
		return ConfiguracaoVendedorClienteNovoFormPgtoDAL.Delete(transaction, instance);
	}
}
