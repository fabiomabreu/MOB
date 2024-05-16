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

public class GeracaoItemBLL
{
	private GeracaoItemTO _GeracaoItem;

	public GeracaoItemBLL(EtapaGeracaoItemTR etapaGeracaoItem, string tabelaBancoDados, VendedorTO Vendedor)
	{
		_GeracaoItem = new GeracaoItemTO();
		_GeracaoItem.EtapaGeracaoItem = etapaGeracaoItem;
		_GeracaoItem.TabelaBancoDados = tabelaBancoDados;
		_GeracaoItem.IdVendedor = Vendedor.Id;
		_GeracaoItem.StatusGeracaoItem = StatusGeracaoItemTR.Processando;
	}

	public void Inicia()
	{
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		sqlConnection.Open();
		_GeracaoItem.IdGeracao = GeracaoBLL.Geracao.Id;
		_GeracaoItem.DataInicio = DateTime.Now;
		if (ConfigGeracao.GeracaoLogaEtapa)
		{
			Insert(sqlConnection, _GeracaoItem);
		}
		sqlConnection.Close();
	}

	public void Finaliza()
	{
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		sqlConnection.Open();
		_GeracaoItem.DataFim = DateTime.Now;
		_GeracaoItem.StatusGeracaoItem = StatusGeracaoItemTR.Sucesso;
		if (ConfigGeracao.GeracaoLogaEtapa)
		{
			Update(sqlConnection, _GeracaoItem);
		}
		sqlConnection.Close();
	}

	public void Erro(string classe, string metodo, string mensagem)
	{
		CargaGeralBLL.Erro = true;
		if (!_GeracaoItem.DataInicio.HasValue || _GeracaoItem.DataFim.HasValue)
		{
			return;
		}
		if (!CargaGeralBLL.Erro)
		{
			GeracaoBLL.Erro(classe, metodo, mensagem);
		}
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		sqlConnection.Open();
		_GeracaoItem.DataFim = DateTime.Now;
		_GeracaoItem.StatusGeracaoItem = StatusGeracaoItemTR.Erro;
		if (ConfigGeracao.GeracaoLogaEtapa)
		{
			Update(sqlConnection, _GeracaoItem);
		}
		else
		{
			Insert(sqlConnection, _GeracaoItem);
		}
		GeracaoLogErroTO geracaoLogErroTO = new GeracaoLogErroTO();
		geracaoLogErroTO.IdGeracaoItem = _GeracaoItem.Id;
		geracaoLogErroTO.Classe = classe;
		geracaoLogErroTO.Metodo = metodo;
		geracaoLogErroTO.Erro = mensagem;
		GeracaoLogErroBLL.Insert(sqlConnection, geracaoLogErroTO);
		sqlConnection.Close();
	}

	private static List<GeracaoItemTO> Select(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		return GeracaoItemDAL.Select(conexao, geracaoItem);
	}

	private static SqlDataReader SelectDR(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		return GeracaoItemDAL.SelectDR(conexao, geracaoItem);
	}

	private static DataTable SelectDT(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		return GeracaoItemDAL.SelectDT(conexao, geracaoItem);
	}

	private static bool Existe(SqlConnection conexao, int? id)
	{
		bool result = false;
		if (id.HasValue)
		{
			GeracaoItemTO geracaoItemTO = new GeracaoItemTO();
			geracaoItemTO.Id = id;
			using SqlDataReader sqlDataReader = GeracaoItemDAL.SelectDR(conexao, geracaoItemTO);
			if (sqlDataReader.Read())
			{
				result = true;
			}
		}
		return result;
	}

	private static void Insert(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		string mensagemErro = string.Empty;
		if (Validate(geracaoItem, out mensagemErro))
		{
			GeracaoItemDAL.Insert(conexao, geracaoItem);
			return;
		}
		throw new Exception(mensagemErro);
	}

	private static void Update(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		string mensagemErro = string.Empty;
		if (Validate(geracaoItem, out mensagemErro))
		{
			GeracaoItemDAL.Update(conexao, geracaoItem);
			return;
		}
		throw new Exception(mensagemErro);
	}

	private static void Delete(SqlConnection conexao, GeracaoItemTO geracaoItem)
	{
		GeracaoItemDAL.Delete(conexao, geracaoItem);
	}

	private static bool Validate(GeracaoItemTO geracaoItem, out string mensagemErro)
	{
		mensagemErro = string.Empty;
		if (!geracaoItem.IdGeracao.HasValue)
		{
			mensagemErro = "Id da geração inválido para o item da geração!";
			return false;
		}
		if (!geracaoItem.EtapaGeracaoItem.HasValue)
		{
			mensagemErro = "Etapa do item da geração inválida!";
			return false;
		}
		return true;
	}
}
