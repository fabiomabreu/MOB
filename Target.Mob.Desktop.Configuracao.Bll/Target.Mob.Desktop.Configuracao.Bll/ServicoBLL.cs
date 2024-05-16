using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Dal;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Configuracao.Bll;

public class ServicoBLL
{
	public static void Insert(SqlTransaction transaction, ServicoTO instance)
	{
		ServicoDAL.Insert(transaction, instance);
		if (instance.ConfiguracaoServico == null)
		{
			return;
		}
		foreach (ConfiguracaoServicoTO item in instance.ConfiguracaoServico)
		{
			ConfiguracaoServicoBLL.Insert(transaction, item);
		}
	}

	public static List<ServicoTO> Select(SqlConnection connection, ServicoTO instance)
	{
		List<ServicoTO> list = ServicoDAL.Select(connection, instance);
		if (list != null)
		{
			foreach (ServicoTO item in list)
			{
				ConfiguracaoServicoTO configuracaoServicoTO = new ConfiguracaoServicoTO();
				configuracaoServicoTO.IdServico = item.Id;
				item.ConfiguracaoServico = ConfiguracaoServicoBLL.Select(connection, configuracaoServicoTO);
			}
		}
		return list;
	}

	public static bool Exists(SqlTransaction transaction, int? id)
	{
		return ServicoDAL.Exists(transaction, id);
	}

	public static void Delete(SqlTransaction transaction, ServicoTO instance)
	{
		ConfiguracaoServicoTO configuracaoServicoTO = new ConfiguracaoServicoTO();
		configuracaoServicoTO.IdServico = instance.Id;
		ConfiguracaoServicoBLL.Delete(transaction, configuracaoServicoTO);
		ServicoDAL.Delete(transaction, instance);
	}
}
