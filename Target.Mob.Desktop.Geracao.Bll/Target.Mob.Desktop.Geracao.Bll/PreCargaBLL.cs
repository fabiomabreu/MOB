using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class PreCargaBLL
{
	public void Gera()
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_PreCarga, null, new VendedorTO());
		GeracaoItemBLL geracaoItemBLL2 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_PreCarga_ObtemEntidades, null, new VendedorTO());
		try
		{
			geracaoItemBLL.Inicia();
			geracaoItemBLL2.Inicia();
			List<ConfiguracaoPreCargaTO> list;
			using (SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob))
			{
				sqlConnection.Open();
				list = ConfiguracaoPreCargaBLL.Select(sqlConnection, new ConfiguracaoPreCargaTO());
				sqlConnection.Close();
			}
			geracaoItemBLL2.Finaliza();
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				foreach (ConfiguracaoPreCargaTO item in list)
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(new PreCargaItemBLL(item.NomeProcedure).Gera, countdownEvent);
				}
				countdownEvent.Signal();
				countdownEvent.Wait();
			}
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("PreCargaBLL", "Gera", ex.Message);
			geracaoItemBLL2.Erro("PreCargaBLL", "Gera", ex.Message);
		}
	}
}
