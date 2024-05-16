using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ReplicacaoItemBLL
{
	private ConfiguracaoReplicacaoTO _ConfiguracaoReplicacao;

	public ConfiguracaoReplicacaoTO ConfiguracaoReplicacao
	{
		get
		{
			return _ConfiguracaoReplicacao;
		}
		set
		{
			_ConfiguracaoReplicacao = value;
		}
	}

	public ReplicacaoItemBLL(ConfiguracaoReplicacaoTO ConfiguracaoReplicacao)
	{
		this.ConfiguracaoReplicacao = ConfiguracaoReplicacao;
	}

	public void Gera(object eventosAtivos)
	{
		GeracaoItemBLL geracaoItemBLL = null;
		try
		{
			geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Replicacao_TransfereDados, ConfiguracaoReplicacao.Entidade, new VendedorTO());
			geracaoItemBLL.Inicia();
			string entidade = ConfiguracaoReplicacao.Entidade;
			string value = $"Replicacao_{ConfiguracaoReplicacao.Entidade}";
			using (SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob))
			{
				using SqlCommand sqlCommand = new SqlCommand("uspReplicaTabela", sqlConnection);
				sqlConnection.Open();
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 0;
				sqlCommand.Parameters.Clear();
				sqlCommand.Parameters.AddWithValue("@ServidorOrigem", (!string.IsNullOrEmpty(ConfigGeracao.NomeServidorOrigemReplicacao)) ? ("[" + ConfigGeracao.NomeServidorOrigemReplicacao.Replace("[", "").Replace("]", "") + "]") : null);
				sqlCommand.Parameters.AddWithValue("@BancoOrigem", ConfigGeracao.NomeDbOrigemReplicacao);
				sqlCommand.Parameters.AddWithValue("@TabelaOrigem", entidade);
				sqlCommand.Parameters.AddWithValue("@TabelaDestino", value);
				sqlCommand.Parameters.AddWithValue("@CondicaoSelecao", ConfiguracaoReplicacao.CondicaoSelecao);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("ReplicacaoItemBLL", "Gera", ex.Message);
		}
		finally
		{
			((CountdownEvent)eventosAtivos).Signal();
		}
	}
}
