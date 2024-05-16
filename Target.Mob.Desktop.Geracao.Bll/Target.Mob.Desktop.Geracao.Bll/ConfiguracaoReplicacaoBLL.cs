using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ConfiguracaoReplicacaoBLL
{
	public static List<ConfiguracaoReplicacaoTO> Select(SqlConnection conexao, ConfiguracaoReplicacaoTO configuracaoReplicacao)
	{
		return ConfiguracaoReplicacaoDAL.Select(conexao, configuracaoReplicacao);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoReplicacaoTO configuracaoReplicacao)
	{
		return ConfiguracaoReplicacaoDAL.SelectDR(conexao, configuracaoReplicacao);
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoReplicacaoTO configuracaoReplicacao)
	{
		return ConfiguracaoReplicacaoDAL.SelectDT(conexao, configuracaoReplicacao);
	}
}
