using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class GeracaoLogErroBLL
{
	public static List<GeracaoLogErroTO> Select(SqlConnection conexao, GeracaoLogErroTO logErro)
	{
		return GeracaoLogErroDAL.Select(conexao, logErro);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, GeracaoLogErroTO logErro)
	{
		return GeracaoLogErroDAL.SelectDR(conexao, logErro);
	}

	public static DataTable SelectDT(SqlConnection conexao, GeracaoLogErroTO logErro)
	{
		return GeracaoLogErroDAL.SelectDT(conexao, logErro);
	}

	public static void Insert(SqlConnection conexao, GeracaoLogErroTO logErro)
	{
		string mensagemErro = string.Empty;
		if (Validate(logErro, out mensagemErro))
		{
			GeracaoLogErroDAL.Insert(conexao, logErro);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Update(SqlConnection conexao, GeracaoLogErroTO logErro)
	{
		string mensagemErro = string.Empty;
		if (Validate(logErro, out mensagemErro))
		{
			GeracaoLogErroDAL.Update(conexao, logErro);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Delete(SqlConnection conexao, GeracaoLogErroTO logErro)
	{
		GeracaoLogErroDAL.Delete(conexao, logErro);
	}

	private static bool Validate(GeracaoLogErroTO logErro, out string mensagemErro)
	{
		mensagemErro = string.Empty;
		if (logErro.Classe == null)
		{
			mensagemErro = "Classe Inválida!";
			return false;
		}
		return true;
	}
}
