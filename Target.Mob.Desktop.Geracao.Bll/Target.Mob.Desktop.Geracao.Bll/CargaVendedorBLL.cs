using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using Target.Mob.Common.IO;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaVendedorBLL
{
	private VendedorTO _Vendedor;

	private VersaoCargaTO _VersaoCarga;

	public VendedorTO Vendedor
	{
		get
		{
			return _Vendedor;
		}
		set
		{
			_Vendedor = value;
		}
	}

	public CargaVendedorBLL(VendedorTO vendedor)
	{
		Vendedor = vendedor;
	}

	public void Gera(object eventosAtivos)
	{
		GeracaoItemBLL geracaoItemBLL = null;
		GeracaoItemBLL geracaoItemBLL2 = null;
		GeracaoItemBLL geracaoItemBLL3 = null;
		GeracaoItemBLL geracaoItemBLL4 = null;
		GeracaoItemBLL geracaoItemBLL5 = null;
		GeracaoItemBLL geracaoItemBLL6 = null;
		try
		{
			geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor, null, Vendedor);
			geracaoItemBLL2 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_ObtemEntidades, null, Vendedor);
			geracaoItemBLL3 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_CriaBaseMobile, null, Vendedor);
			geracaoItemBLL4 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_CompactaBaseMobile, null, Vendedor);
			geracaoItemBLL5 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_InsereCargaMobileBancoDados, null, Vendedor);
			geracaoItemBLL6 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_AtualizaFlagCargaCompleta, null, Vendedor);
			geracaoItemBLL.Inicia();
			using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
			sqlConnection.Open();
			_VersaoCarga = VersaoCargaBLL.SelectMax(sqlConnection, Vendedor.Major, Vendedor.Minor);
			if (_VersaoCarga == null)
			{
				throw new Exception($"Não foi encontrada uma versão compatível da carga para o vendedor {Vendedor.CodigoVendedor}");
			}
			TipoCargaTR tipoCargaTR = DefineTipoCarga(sqlConnection, Vendedor, _VersaoCarga);
			geracaoItemBLL2.Inicia();
			ConfiguracaoControleTO configuracaoControleTO = new ConfiguracaoControleTO();
			configuracaoControleTO.IdVersaoCarga = _VersaoCarga.Id;
			List<ConfiguracaoControleTO> list = ConfiguracaoControleBLL.Select(sqlConnection, configuracaoControleTO);
			geracaoItemBLL2.Finaliza();
			geracaoItemBLL3.Inicia();
			string text = CriaDbSQLite(sqlConnection);
			string connectionString = $"Data Source={text};Version=3;New=False;Compress=True;";
			geracaoItemBLL3.Finaliza();
			using (SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString))
			{
				sQLiteConnection.Open();
				foreach (ConfiguracaoControleTO item in list)
				{
					using SQLiteTransaction sQLiteTransaction = sQLiteConnection.BeginTransaction();
					new CargaArquivoBLL(Vendedor, _VersaoCarga, item, tipoCargaTR, sQLiteTransaction).Gera();
					sQLiteTransaction.Commit();
				}
				if (tipoCargaTR == TipoCargaTR.Atualizacao)
				{
					SQLiteUtil.ExcluiTabelasVazias(sQLiteConnection);
				}
				sQLiteConnection.Close();
			}
			geracaoItemBLL4.Inicia();
			string text2 = Path.GetFullPath(text) + ".zip";
			ZipFile.Compacta(text, text2);
			geracaoItemBLL4.Finaliza();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			try
			{
				foreach (ConfiguracaoControleTO item2 in list)
				{
					new CargaArquivoBLL(Vendedor, _VersaoCarga, item2, tipoCargaTR, null).AtualizaControle(sqlConnection, sqlTransaction);
				}
				geracaoItemBLL5.Inicia();
				GravaCarga(sqlConnection, sqlTransaction, text2, tipoCargaTR);
				geracaoItemBLL5.Finaliza();
				if (tipoCargaTR == TipoCargaTR.Completa)
				{
					geracaoItemBLL6.Inicia();
					VendedorBLL.AtualizaFlagCargaCompleta(sqlConnection, sqlTransaction, Vendedor.Id.Value, valor: false);
					geracaoItemBLL6.Finaliza();
				}
				sqlTransaction.Commit();
			}
			catch (Exception ex)
			{
				sqlTransaction.Rollback();
				throw ex;
			}
			finally
			{
				sqlConnection.Close();
				geracaoItemBLL.Finaliza();
			}
		}
		catch (Exception ex2)
		{
			geracaoItemBLL.Erro("CargaVendedorBLL", "Gera", ex2.Message);
			geracaoItemBLL3.Erro("CargaVendedorBLL", "Gera", ex2.Message);
			geracaoItemBLL2.Erro("CargaVendedorBLL", "Gera", ex2.Message);
			geracaoItemBLL4.Erro("CargaVendedorBLL", "Gera", ex2.Message);
			geracaoItemBLL5.Erro("CargaVendedorBLL", "Gera", ex2.Message);
			geracaoItemBLL6.Erro("CargaVendedorBLL", "Gera", ex2.Message);
		}
		finally
		{
			((CountdownEvent)eventosAtivos).Signal();
		}
	}

	private TipoCargaTR DefineTipoCarga(SqlConnection conexaoSQL, VendedorTO vendedor, VersaoCargaTO versaoCarga)
	{
		TipoCargaTR result = TipoCargaTR.Atualizacao;
		if (vendedor.ForcaCargaCompleta == true)
		{
			result = TipoCargaTR.Completa;
		}
		else if (!CargaBLL.ExistsCompleta(conexaoSQL, vendedor.Id, versaoCarga.Major, versaoCarga.Minor, versaoCarga.Build, versaoCarga.Revision))
		{
			result = TipoCargaTR.Completa;
		}
		return result;
	}

	private string CriaDbSQLite(SqlConnection conexaoSQL)
	{
		ConfiguracaoTemplateSQLiteTO configuracaoTemplateSQLiteTO = new ConfiguracaoTemplateSQLiteTO();
		configuracaoTemplateSQLiteTO.IdVersaoCarga = _VersaoCarga.Id;
		List<ConfiguracaoTemplateSQLiteTO> list = ConfiguracaoTemplateSQLiteBLL.Select(conexaoSQL, configuracaoTemplateSQLiteTO);
		string text = Path.Combine(ConfigGeracao.TargetMobPath, "DatabasesTmp", Vendedor.CodigoVendedor.Trim() + ".db");
		if (!Directory.Exists(Path.GetDirectoryName(text)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(text));
		}
		if (list.Count > 0)
		{
			File.WriteAllBytes(text, list[0].Template);
			return text;
		}
		throw new Exception("Template do Banco Mobile Não Encontrado.");
	}

	private void GravaCarga(SqlConnection conexaoSQL, SqlTransaction transaction, string arquivoDbSQLite, TipoCargaTR tipoCarga)
	{
		CargaTO cargaTO = new CargaTO();
		cargaTO.DataGeracao = DateTime.Now;
		cargaTO.IdVendedor = Vendedor.Id;
		cargaTO.IdVersaoCarga = _VersaoCarga.Id;
		cargaTO.IdGeracao = GeracaoBLL.Geracao.Id;
		cargaTO.TipoCarga = tipoCarga;
		cargaTO.ArquivoCarga = File.ReadAllBytes(arquivoDbSQLite);
		cargaTO.Transmitido = false;
		CargaBLL.Insert(conexaoSQL, transaction, cargaTO);
	}
}
