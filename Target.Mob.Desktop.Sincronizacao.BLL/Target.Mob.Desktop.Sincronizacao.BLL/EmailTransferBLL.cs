using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Target.Mob.Desktop.Sincronizacao.BLL.Util;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class EmailTransferBLL
{
	public static void Enviar(DbConnection connTargetErp, string emailSmtpServidor, int emailSmtpPort, string emailUser, string emailPassword, bool emailUseSSL, string emailFrom)
	{
		PedVdaTransferAtacadistaLogBLL.Limpa(connTargetErp);
		PedVdaTransferAtacadistaLogTO[] array = PedVdaTransferAtacadistaLogBLL.Gera(connTargetErp, emailSmtpServidor, emailSmtpPort, emailUser, emailPassword, emailUseSSL, emailFrom);
		foreach (PedVdaTransferAtacadistaLogTO pedVdaTransferAtacadistaLogTO in array)
		{
			List<MailAddress> mails = GetMails(pedVdaTransferAtacadistaLogTO.EmailTo);
			List<MailAddress> mails2 = GetMails(pedVdaTransferAtacadistaLogTO.EmailCc);
			string message = "";
			bool envioOk = false;
			if (!mails.Count().Equals(0) || !mails2.Count().Equals(0))
			{
				envioOk = EmailHelper.SendMail(pedVdaTransferAtacadistaLogTO.EmailSmtpServidor, pedVdaTransferAtacadistaLogTO.EmailSmtpPort, pedVdaTransferAtacadistaLogTO.EmailUser, pedVdaTransferAtacadistaLogTO.EmailPassword, new MailAddress(pedVdaTransferAtacadistaLogTO.EmailFrom), mails.ToArray(), mails2.ToArray(), null, pedVdaTransferAtacadistaLogTO.EmailSubject, pedVdaTransferAtacadistaLogTO.EmailBody, null, pedVdaTransferAtacadistaLogTO.EmailUseSSL, useDefaultCredentials: false, pedVdaTransferAtacadistaLogTO.EmailBodyIsHtml, out message);
			}
			PedVdaTransferAtacadistaLogBLL.AtualizaStatus(connTargetErp, pedVdaTransferAtacadistaLogTO.IdPedVdaTransferAtacadistaLog, envioOk, message);
		}
	}

	private static List<MailAddress> GetMails(string emails)
	{
		string[] array = emails.Split(';');
		List<MailAddress> list = new List<MailAddress>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains("@"))
			{
				list.Add(new MailAddress(text.Trim()));
			}
		}
		return list;
	}

	public static void EnviarTeste(string emailSmtpServidor, int emailSmtpPort, string emailUser, string emailPassword, bool emailUseSSL, string emailFrom)
	{
		List<MailAddress> mails = GetMails("daniel.piqueras@targetsistemas.com.br");
		List<MailAddress> mails2 = GetMails("gustavo.silva@targetsistemas.com.br");
		string message = "";
		if (!EmailHelper.SendMail(emailSmtpServidor, emailSmtpPort, emailUser, emailPassword, new MailAddress(emailFrom), mails.ToArray(), mails2.ToArray(), null, "*** E-MAIL TESTE ***", "*** E-MAIL TESTE ***", null, emailUseSSL, useDefaultCredentials: false, isHTMLBody: false, out message))
		{
			new Exception("Falha ao enviar o e-mail: " + message);
		}
	}
}
