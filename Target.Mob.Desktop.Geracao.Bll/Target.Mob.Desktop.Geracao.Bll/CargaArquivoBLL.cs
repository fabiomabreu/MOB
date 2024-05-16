using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class CargaArquivoBLL
{
	private VendedorTO _Vendedor;

	private ConfiguracaoControleTO _ConfiguracaoControle;

	private TipoCargaTR _TipoCarga;

	private SQLiteTransaction _TransacaoSQLite;

	private string _NomeTemplate;

	private string _NomeLayout;

	private string _NomeControle;

	private string _NomeSPTransforma;

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

	public ConfiguracaoControleTO ConfiguracaoControle
	{
		get
		{
			return _ConfiguracaoControle;
		}
		set
		{
			_ConfiguracaoControle = value;
		}
	}

	public TipoCargaTR TipoCarga
	{
		get
		{
			return _TipoCarga;
		}
		set
		{
			_TipoCarga = value;
		}
	}

	public SQLiteTransaction TransacaoSQLite
	{
		get
		{
			return _TransacaoSQLite;
		}
		set
		{
			_TransacaoSQLite = value;
		}
	}

	public CargaArquivoBLL(VendedorTO vendedor, VersaoCargaTO versaoCarga, ConfiguracaoControleTO configuracaoControle, TipoCargaTR tipoCarga, SQLiteTransaction transacaoSQLite)
	{
		Vendedor = vendedor;
		ConfiguracaoControle = configuracaoControle;
		TipoCarga = tipoCarga;
		TransacaoSQLite = transacaoSQLite;
		_NomeTemplate = GetNomeTemplate(configuracaoControle);
		_NomeLayout = GetNomeLayout(configuracaoControle, vendedor);
		_NomeControle = GetNomeControle(configuracaoControle, vendedor, versaoCarga);
		_NomeSPTransforma = GetNomeSPTransforma(configuracaoControle);
	}

	public void Gera()
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_Entidade, ConfiguracaoControle.Entidade, Vendedor);
		try
		{
			geracaoItemBLL.Inicia();
			CriaEstrutura();
			TransformaDados();
			ExportaDados();
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("CargaArquivoBLL", "Gera", ex.Message);
			throw ex;
		}
	}

	private void CriaEstrutura()
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_Entidade_PreparaTabelaLayout, ConfiguracaoControle.Entidade, Vendedor);
		GeracaoItemBLL geracaoItemBLL2 = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_Entidade_PreparaTabelaControle, ConfiguracaoControle.Entidade, Vendedor);
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob);
			sqlConnection.Open();
			geracaoItemBLL.Inicia();
			TabelaSQL.CopiaTabela(sqlConnection, _NomeTemplate, _NomeLayout, sobreescreve: false);
			TabelaSQL.LimpaTabela(sqlConnection, _NomeLayout);
			geracaoItemBLL.Finaliza();
			geracaoItemBLL2.Inicia();
			if (ConfiguracaoControle.TipoControle == TipoControleTR.RowVersion)
			{
				TabelaSQL.CriaTabelaRowVersion(sqlConnection, _NomeTemplate, _NomeControle, sobreescreve: false);
			}
			else
			{
				TabelaSQL.CopiaTabela(sqlConnection, _NomeTemplate, _NomeControle, sobreescreve: false);
			}
			geracaoItemBLL2.Finaliza();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			geracaoItemBLL2.Erro("CargaArquivoBLL", "CriaEstrutura", ex.Message);
			geracaoItemBLL.Erro("CargaArquivoBLL", "CriaEstrutura", ex.Message);
			throw ex;
		}
	}

	private void TransformaDados()
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_Entidade_TransformaDados, ConfiguracaoControle.Entidade, Vendedor);
		try
		{
			geracaoItemBLL.Inicia();
			using (SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob))
			{
				using SqlCommand sqlCommand = new SqlCommand(_NomeSPTransforma, sqlConnection);
				sqlConnection.Open();
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 3600;
				sqlCommand.Parameters.Clear();
				sqlCommand.Parameters.AddWithValue("@CodigoVendedor", Vendedor.CodigoVendedor);
				sqlCommand.Parameters.AddWithValue("@TabelaLayout", _NomeLayout);
				sqlCommand.Parameters.AddWithValue("@TabelaControle", _NomeControle);
				sqlCommand.Parameters.AddWithValue("@TipoCarga", (int)TipoCarga);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("CargaArquivoBLL", "TransformaDados", ex.Message);
			throw ex;
		}
	}

	public void AtualizaControle(SqlConnection conexaoSQL, SqlTransaction transaction)
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_AtualizaTabelaControle, ConfiguracaoControle.Entidade, Vendedor);
		try
		{
			geracaoItemBLL.Inicia();
			using (SqlCommand sqlCommand = new SqlCommand("uspAtualizaControle", conexaoSQL, transaction))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 0;
				sqlCommand.Parameters.Clear();
				sqlCommand.Parameters.AddWithValue("@TabelaLayout", _NomeLayout);
				sqlCommand.Parameters.AddWithValue("@TabelaControle", _NomeControle);
				sqlCommand.Parameters.AddWithValue("@TipoCarga", (int)TipoCarga);
				sqlCommand.ExecuteNonQuery();
			}
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("CargaArquivoBLL", "AtualizaControle", ex.Message);
			throw ex;
		}
	}

	private void ExportaDados()
	{
		GeracaoItemBLL geracaoItemBLL = new GeracaoItemBLL(EtapaGeracaoItemTR.Geracao_Vendedor_Entidade_ExportaDadosBaseMobile, ConfiguracaoControle.Entidade, Vendedor);
		try
		{
			geracaoItemBLL.Inicia();
			using (SqlConnection sqlConnection = new SqlConnection(ConfigGeracao.ConnStringTargetMob))
			{
				sqlConnection.Open();
				new ExportaSQLite(sqlConnection, TransacaoSQLite, _NomeLayout, ConfiguracaoControle.Entidade).Exporta();
				sqlConnection.Close();
			}
			geracaoItemBLL.Finaliza();
		}
		catch (Exception ex)
		{
			geracaoItemBLL.Erro("CargaArquivoBLL", "ExportaDados", ex.Message);
			throw ex;
		}
	}

	private string GetNomeTemplate(ConfiguracaoControleTO entidade)
	{
		return $"Template_Ver{entidade.IdVersaoCarga}_{entidade.Entidade}";
	}

	private string GetNomeLayout(ConfiguracaoControleTO entidade, VendedorTO vendedor)
	{
		return $"Layout_Vend{vendedor.Id}_Ver{entidade.IdVersaoCarga}_{entidade.Entidade}";
	}

	private string GetNomeControle(ConfiguracaoControleTO entidade, VendedorTO vendedor, VersaoCargaTO versaoCarga)
	{
		if (entidade.TipoControle == TipoControleTR.RowVersion)
		{
			return $"ControleRV_Vend{vendedor.Id}_Ver{versaoCarga.Id}_{entidade.Entidade}";
		}
		return $"ControleES_Vend{vendedor.Id}_Ver{versaoCarga.Id}_{entidade.Entidade}";
	}

	private string GetNomeSPTransforma(ConfiguracaoControleTO entidade)
	{
		return $"uspTransforma_Ver{entidade.IdVersaoCarga}_{entidade.Entidade}";
	}
}
