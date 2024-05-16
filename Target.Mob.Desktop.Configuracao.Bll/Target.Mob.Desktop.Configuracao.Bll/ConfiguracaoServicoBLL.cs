using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ConfiguracaoServicoBLL
{
	public static void Insert(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		ConfiguracaoServicoDAL.Insert(transaction, instance);
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		ConfiguracaoServicoDAL.Update(transaction, instance);
	}

	public static List<ConfiguracaoServicoTO> Select(SqlConnection connection, ConfiguracaoServicoTO instance)
	{
		return ConfiguracaoServicoDAL.Select(connection, instance);
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ConfiguracaoServicoDAL.Exists(transaction, id);
	}

	public static void Delete(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		ConfiguracaoServicoDAL.Delete(transaction, instance);
	}

	public static bool Alterado(SqlTransaction transaction, ConfiguracaoServicoTO instance)
	{
		return ConfiguracaoServicoDAL.Alterado(transaction, instance);
	}
}
