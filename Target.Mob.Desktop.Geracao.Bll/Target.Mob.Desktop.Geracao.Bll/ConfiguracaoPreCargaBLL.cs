using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ConfiguracaoPreCargaBLL
{
	public static List<ConfiguracaoPreCargaTO> Select(SqlConnection conexao, ConfiguracaoPreCargaTO configuracaoPreCarga)
	{
		return ConfiguracaoPreCargaDAL.Select(conexao, configuracaoPreCarga);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoPreCargaTO configuracaoPreCarga)
	{
		return ConfiguracaoPreCargaDAL.SelectDR(conexao, configuracaoPreCarga);
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoPreCargaTO configuracaoPreCarga)
	{
		return ConfiguracaoPreCargaDAL.SelectDT(conexao, configuracaoPreCarga);
	}
}
