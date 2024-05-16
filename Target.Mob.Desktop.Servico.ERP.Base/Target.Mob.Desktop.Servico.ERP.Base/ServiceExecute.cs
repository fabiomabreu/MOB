using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Servico.ERP.Base;

public class ServiceExecute : ServicoBase
{
	public ServicoTO Servico { get; set; }

	public ServiceExecute(ServicoTO servico)
	{
		Servico = servico;
	}

	public void IniciarCarregamentoServicos()
	{
		ConfiguracaoServicoTO configuracaoServico = GetConfiguracaoServico(Servico);
		if ((configuracaoServico != null || Servico.Principal == true) && Servico.Status == true)
		{
			if (configuracaoServico != null && configuracaoServico.Alterado == true)
			{
				ParaServico(Servico);
			}
			IniciaServico(Servico);
			if (configuracaoServico != null)
			{
				configuracaoServico.Alterado = false;
				AtualizaConfiguracao(configuracaoServico);
			}
		}
		else
		{
			ParaServico(Servico);
		}
	}

	private bool AtualizaConfiguracao(ConfiguracaoServicoTO config)
	{
		SqlConnection sqlConnection = new SqlConnection(EncrypterHelper.Descriptografia_ConnectionString(((ConnectionStringsSection)ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Target.Mob.Desktop.Servico.ERP.Principal.exe").GetSection("connectionStrings")).ConnectionStrings["ConexaoTargetMob"].ConnectionString));
		sqlConnection.Open();
		SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
		try
		{
			ConfiguracaoServicoBLL.Update(sqlTransaction, config);
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
		}
		return true;
	}
}
