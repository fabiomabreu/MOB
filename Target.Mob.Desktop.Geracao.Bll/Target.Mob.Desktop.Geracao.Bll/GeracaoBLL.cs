using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public static class GeracaoBLL
{
	private static GeracaoTO _Geracao;

	private static GeracaoItemBLL _GeracaoItem;

	public static GeracaoTO Geracao
	{
		get
		{
			return _Geracao;
		}
		set
		{
			_Geracao = value;
		}
	}

	public static void Inicia()
	{
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		sqlConnection.Open();
		_Geracao = null;
		_Geracao = new GeracaoTO();
		_Geracao.StatusGeracao = StatusGeracaoTR.Processando;
		_Geracao.DataInicio = DateTime.Now;
		Insert(sqlConnection, _Geracao);
		_GeracaoItem = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao, null, new VendedorTO());
		_GeracaoItem.Inicia();
		sqlConnection.Close();
	}

	public static void Finaliza()
	{
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		sqlConnection.Open();
		_GeracaoItem.Finaliza();
		_Geracao.DataFim = DateTime.Now;
		if (CargaGeralBLL.Erro)
		{
			_Geracao.StatusGeracao = StatusGeracaoTR.Erro;
		}
		else
		{
			_Geracao.StatusGeracao = StatusGeracaoTR.Sucesso;
		}
		Update(sqlConnection, _Geracao);
		sqlConnection.Close();
	}

	public static void Erro(string classe, string metodo, string mensagem)
	{
		CargaGeralBLL.Erro = true;
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		sqlConnection.Open();
		_GeracaoItem.Erro(classe, metodo, mensagem);
		_Geracao.DataFim = DateTime.Now;
		_Geracao.StatusGeracao = StatusGeracaoTR.Erro;
		Update(sqlConnection, _Geracao);
		sqlConnection.Close();
	}

	public static List<GeracaoTO> Select(SqlConnection conexao, GeracaoTO geracao)
	{
		return GeracaoDAL.Select(conexao, geracao);
	}

	public static List<GeracaoTO> SelectQtdeVendedor(SqlConnection conexao, GeracaoTO geracao)
	{
		return GeracaoDAL.SelectQtdeVendedor(conexao, geracao);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, GeracaoTO geracao)
	{
		return GeracaoDAL.SelectDR(conexao, geracao);
	}

	public static DataTable SelectDT(SqlConnection conexao, GeracaoTO geracao)
	{
		return GeracaoDAL.SelectDT(conexao, geracao);
	}

	public static void Insert(SqlConnection conexao, GeracaoTO geracao)
	{
		string mensagemErro = string.Empty;
		if (Validate(geracao, out mensagemErro))
		{
			GeracaoDAL.Insert(conexao, geracao);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Update(SqlConnection conexao, GeracaoTO geracao)
	{
		string mensagemErro = string.Empty;
		if (Validate(geracao, out mensagemErro))
		{
			GeracaoDAL.Update(conexao, geracao);
			return;
		}
		throw new Exception(mensagemErro);
	}

	public static void Delete(SqlConnection conexao, GeracaoTO geracao)
	{
		GeracaoDAL.Delete(conexao, geracao);
	}

	private static bool Validate(GeracaoTO geracao, out string mensagemErro)
	{
		mensagemErro = string.Empty;
		if (!geracao.DataInicio.HasValue)
		{
			mensagemErro = "Data de Início Inválida!";
			return false;
		}
		return true;
	}
}
