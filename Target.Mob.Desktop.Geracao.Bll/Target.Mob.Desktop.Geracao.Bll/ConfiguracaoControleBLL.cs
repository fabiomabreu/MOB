using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ConfiguracaoControleBLL
{
	public static List<ConfiguracaoControleTO> Select(SqlConnection conexao, ConfiguracaoControleTO entidade)
	{
		return ConfiguracaoControleDAL.Select(conexao, entidade);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoControleTO entidade)
	{
		return ConfiguracaoControleDAL.SelectDR(conexao, entidade);
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoControleTO entidade)
	{
		return ConfiguracaoControleDAL.SelectDT(conexao, entidade);
	}
}
