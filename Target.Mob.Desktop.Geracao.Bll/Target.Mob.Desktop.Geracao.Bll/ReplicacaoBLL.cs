using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ReplicacaoBLL
{
	public void Gera()
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Replicacao, null, new VendedorTO());
		GeracaoItemBLL geracaoItemBLL2 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Replicacao_ObtemEntidades, null, new VendedorTO());
		try
		{
			geracaoItemBLL.Inicia();
			geracaoItemBLL2.Inicia();
			List<ConfiguracaoReplicacaoTO> source;
			using (SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob))
			{
				sqlConnection.Open();
				source = ConfiguracaoReplicacaoBLL.Select(sqlConnection, new ConfiguracaoReplicacaoTO());
				sqlConnection.Close();
			}
			geracaoItemBLL2.Finaliza();
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				foreach (ConfiguracaoReplicacaoTO item in source.Where((ConfiguracaoReplicacaoTO l) => l.Prioridade == 1))
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(new ReplicacaoItemBLL(item).Gera, countdownEvent);
				}
				foreach (ConfiguracaoReplicacaoTO item2 in source.Where((ConfiguracaoReplicacaoTO l) => !l.Prioridade.HasValue || l.Prioridade == 0))
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(new ReplicacaoItemBLL(item2).Gera, countdownEvent);
				}
				countdownEvent.Signal();
				countdownEvent.Wait();
			}
			GeraCtzERPVer11();
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("ReplicacaoBLL", "Gera", ex.Message);
			geracaoItemBLL2.Erro("ReplicacaoBLL", "Gera", ex.Message);
		}
	}

	private void GeraCtzERPVer11()
	{
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		using SqlCommand sqlCommand = new SqlCommand("uspCtzReplicaTabela", sqlConnection);
		sqlConnection.Open();
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@ServidorOrigem", (!string.IsNullOrEmpty(ConfigGeracao.NomeServidorOrigemReplicacao)) ? ("[" + ConfigGeracao.NomeServidorOrigemReplicacao.Replace("[", "").Replace("]", "") + "]") : null);
		sqlCommand.Parameters.AddWithValue("@BancoOrigem", ConfigGeracao.NomeDbOrigemReplicacao);
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}
}
