using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class ConfiguracaoTemplateSQLiteBLL
{
	public static List<ConfiguracaoTemplateSQLiteTO> Select(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO databaseTemplate)
	{
		return ConfiguracaoTemplateSQLiteDAL.Select(conexao, databaseTemplate);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO databaseTemplate)
	{
		return ConfiguracaoTemplateSQLiteDAL.SelectDR(conexao, databaseTemplate);
	}

	public static DataTable SelectDT(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO databaseTemplate)
	{
		return ConfiguracaoTemplateSQLiteDAL.SelectDT(conexao, databaseTemplate);
	}

	public static void Insert(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO databaseTemplate)
	{
		string mensagemErro = string.Empty;
		if (Validate(databaseTemplate, out mensagemErro))
		{
			ConfiguracaoTemplateSQLiteDAL.Insert(conexao, databaseTemplate);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Update(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO databaseTemplate)
	{
		string mensagemErro = string.Empty;
		if (Validate(databaseTemplate, out mensagemErro))
		{
			ConfiguracaoTemplateSQLiteDAL.Update(conexao, databaseTemplate);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Delete(SqlConnection conexao, ConfiguracaoTemplateSQLiteTO databaseTemplate)
	{
		ConfiguracaoTemplateSQLiteDAL.Delete(conexao, databaseTemplate);
	}

	private static bool Validate(ConfiguracaoTemplateSQLiteTO databaseTemplate, out string mensagemErro)
	{
		mensagemErro = string.Empty;
		if (!databaseTemplate.IdVersaoCarga.HasValue)
		{
			mensagemErro = "Versa da Carga Inválida!";
			return false;
		}
		return true;
	}
}
