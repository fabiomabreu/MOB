using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Modulo;

public class ModuloSistemaBLL : ModuloBaseBLL, IModuloSistemaBLL, IModuloBaseBLL
{
	public void CriarSessaoUsuario(string codigoUsuario, int codigoEmpresa, string nomePrograma)
	{
		SessaoErpManager.Inicializar(codigoUsuario, codigoEmpresa, nomePrograma);
		EmpresaBLL empresaBLL = new EmpresaBLL();
		LoginERP.EMPRESA_LOGADA = empresaBLL.ObterPeloID(codigoEmpresa);
		UsuarioBLL usuarioBLL = new UsuarioBLL();
		LoginERP.USUARIO_LOGADO = usuarioBLL.ObterPeloID(codigoUsuario);
		CarregarConfiguracoes();
		ValidarConfiguracoes();
		CriarSessaoDbTemp();
	}

	public void EncerrarSessaoUsuario()
	{
		if (SessaoErpManager.INICIALIZADA)
		{
			RemoverSessaoDbTemp();
			SessaoErpManager.Encerrar();
		}
	}

	private void RemoverSessaoDbTemp()
	{
		try
		{
			if (SessaoErpManager.CURRENT != null && SessaoErpManager.CURRENT.SESSAO_DB_TEMP != null)
			{
				SessaoDbTempBLL sessaoDbTempBLL = new SessaoDbTempBLL();
				sessaoDbTempBLL.EncerrarSessaoDbTemp(SessaoErpManager.CURRENT.SESSAO_DB_TEMP);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void CriarSessaoDbTemp()
	{
		TransactionManager.ExecutarComTransacao(delegate
		{
			try
			{
				SessaoDbTempBLL sessaoDbTempBLL = new SessaoDbTempBLL();
				SessaoErpManager.CURRENT.SESSAO_DB_TEMP = sessaoDbTempBLL.GerarSessaoDbTemp(LoginERP.USUARIO_LOGADO);
			}
			catch (Exception)
			{
				throw;
			}
		});
	}

	private void CarregarConfiguracoes()
	{
		ParametroConfiguracaoBLL parametroConfiguracaoBLL = new ParametroConfiguracaoBLL();
		ConfigERP.PAR_CFG = parametroConfiguracaoBLL.ObterParametroConfiguracao(LoginERP.EMPRESA_LOGADA.CODIGO_EMPRESA);
		ParametroTelaDetalheBLL parametroTelaDetalheBLL = new ParametroTelaDetalheBLL();
		ConfigERP.PARAMETROS_TELA = new ConfiguracaoTelaVO();
		ConfigERP.PARAMETROS_TELA.VENDA = parametroTelaDetalheBLL.ObterParametroTelaVendas();
		ConfigERP.PARAMETROS_TELA.CLIENTE = parametroTelaDetalheBLL.ObterParametroTelaCliente();
		ConfigERP.PARAMETROS_TELA.EMISSAO_NOTA_FISCAL = parametroTelaDetalheBLL.ObterParametroTelaEmissaoNota();
		ConfigERP.PARAMETROS_TELA.TRANSFERENCIA_ESTOQUE = parametroTelaDetalheBLL.ObterParametroTelaTransferenciaEstoque();
	}

	public void ConfigurarStringConexao(string connectionString)
	{
		ConfigHelper.setStringConnection(connectionString);
	}

	private void ValidarConfiguracoes()
	{
		MyException ex = new MyException(base.RetornaMensagemAviso);
		if (ConfigERP.PAR_CFG.IND_PRODPAPEL)
		{
			ex.AddErro("O Parametro de Configuração: {0}, não é suportado pela interface.", "Ind. Produto Papel");
		}
		if (ConfigERP.PAR_CFG.UTILIZA_COMIS_RT)
		{
			ex.AddErro("O Parametro de Configuração: {0}, não é suportado pela interface.", "Comissão RT");
		}
		ex.ThrowException();
	}
}
