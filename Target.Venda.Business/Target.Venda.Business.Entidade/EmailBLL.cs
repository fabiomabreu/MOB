using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class EmailBLL : EntidadeBaseBLL<EmailMO>
{
	protected override EntidadeBaseDAL<EmailMO> GetInstanceDAL()
	{
		return new EmailDAL();
	}

	public void GerarEnvioEmailERP(List<EmailVO> emails)
	{
		foreach (EmailVO email in emails)
		{
			GerarEnvioEmailERP(email);
		}
	}

	public void GerarEnvioEmailERP(EmailVO email)
	{
		EmailDAL emailDAL = (EmailDAL)BaseDAL;
		int num = emailDAL.IncluirRegistroEmail(email);
	}

	private bool EnviarEmailPeloSendMailERP(int seqEmail)
	{
		try
		{
			List<string> list = new List<string>();
			list.Add($"-U {LoginERP.USUARIO_LOGADO.CODIGO_USUARIO}");
			list.Add($"-S {ConfigHelper.getServidorBancoDados()}");
			list.Add($"-D {ConfigHelper.getNomeBancoDados()}");
			list.Add($"-E {seqEmail}");
			list.Add($"-V {ConfigERP.VERSAO_ERP}");
			string appConfig = ConfigHelper.getAppConfig("PathSendMailERP");
			int timeOutSegundos = 10;
			object obj = new object();
			lock (obj)
			{
				ProcessStartHelper.InvocarExecutavel(appConfig, list, timeOutSegundos);
			}
			return true;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			return false;
		}
	}
}
