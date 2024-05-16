using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaGeralBLL
{
	private static bool _Erro;

	public static bool Erro
	{
		get
		{
			return _Erro;
		}
		set
		{
			_Erro = value;
		}
	}

	public CargaGeralBLL(string connStringTargetMob, string nomeServidorOrigemReplicacao, string nomeDbOrigemReplicacao, string targetMobPath, bool geracaoLogaEtapa)
	{
		if (string.IsNullOrEmpty(connStringTargetMob))
		{
			throw new Exception("String de conexão com o banco TargetMob inválida!");
		}
		if (string.IsNullOrEmpty(nomeDbOrigemReplicacao))
		{
			throw new Exception("Nome do banco origem da replicação inválido!");
		}
		ConfigGeracao.ConnStringTargetMob = connStringTargetMob;
		ConfigGeracao.NomeServidorOrigemReplicacao = nomeServidorOrigemReplicacao;
		ConfigGeracao.NomeDbOrigemReplicacao = nomeDbOrigemReplicacao;
		ConfigGeracao.TargetMobPath = targetMobPath;
		ConfigGeracao.GeracaoLogaEtapa = geracaoLogaEtapa;
	}

	public void Gera()
	{
		_Erro = false;
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_ObtemVendedores, null, new VendedorTO());
		try
		{
			GeracaoBLL.Inicia();
			using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
			sqlConnection.Open();
			new ReplicacaoBLL().Gera();
			if (_Erro)
			{
				GeracaoBLL.Erro("CargaGeralBLL", "Gera", "Erro na replicação");
				return;
			}
			new PreCargaBLL().Gera();
			if (_Erro)
			{
				GeracaoBLL.Erro("CargaGeralBLL", "Gera", "Erro na précarga");
				return;
			}
			geracaoItemBLL.Inicia();
			new VendedorTO().Ativo = true;
			List<VendedorTO> list = VendedorBLL.SelectCarga(sqlConnection);
			geracaoItemBLL.Finaliza();
			if (_Erro)
			{
				return;
			}
			using (CountdownEvent countdownEvent = new CountdownEvent(1))
			{
				foreach (VendedorTO item in list)
				{
					if (VendedorUtilizaPocketPc(sqlConnection, item))
					{
						countdownEvent.AddCount();
						ThreadPool.QueueUserWorkItem(new CargaVendedorBLL(item).Gera, countdownEvent);
					}
				}
				countdownEvent.Signal();
				countdownEvent.Wait();
			}
			GeracaoBLL.Finaliza();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("CargaGeralBLL", "Gera", ex.Message);
			GeracaoBLL.Erro("CargaGeralBLL", "Gera", ex.Message);
		}
	}

	private void GeraControleGeracaoSimultanea(SqlConnection conexaoSQL)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspGeraControleGeracaoSimultanea", conexaoSQL);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
		sqlCommand.Parameters.AddWithValue("IdGeracao", GeracaoBLL.Geracao.Id);
		sqlCommand.ExecuteNonQuery();
	}

	private void LiberaControleGeracaoSimultanea()
	{
		using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
		using SqlCommand sqlCommand = new SqlCommand("uspLiberaControleGeracaoSimultanea", sqlConnection);
		sqlConnection.Open();
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private bool VendedorUtilizaPocketPc(SqlConnection conexaoSQL, VendedorTO vendedor)
	{
		int num = 0;
		using (SqlCommand sqlCommand = new SqlCommand("uspVendedorUtilizaPocketPc", conexaoSQL))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@CodigoVendedor", vendedor.CodigoVendedor);
			num = (int)sqlCommand.ExecuteScalar();
		}
		return num != 0;
	}
}
