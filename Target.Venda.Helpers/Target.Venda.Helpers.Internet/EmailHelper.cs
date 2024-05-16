using System;
using System.Net;
using System.Net.Mail;
using Target.Venda.Helpers.Geral;

namespace Target.Venda.Helpers.Internet;

public class EmailHelper
{
	private static EmailConfiguration _configEmail;

	public static bool EnviarEmail(string destinatario, string mensagemEmail, string titulo)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			mailMessage.From = GetEmailAddressFrom();
			mailMessage.To.Add(destinatario.ToLower());
			mailMessage.Subject = titulo;
			mailMessage.IsBodyHtml = true;
			mailMessage.Body = mensagemEmail;
			SmtpClient smtpClient = GetSmtpClient();
			smtpClient.Send(mailMessage);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static EmailConfiguration getConfigEmail()
	{
		if (_configEmail == null)
		{
			_configEmail = ConfigHelper.getEmailConfiguration();
		}
		return _configEmail;
	}

	private static MailAddress GetEmailAddressFrom()
	{
		EmailConfiguration configEmail = getConfigEmail();
		return new MailAddress(configEmail.EMAIL_FROM, configEmail.EMAIL_FROM_DISPLAY);
	}

	private static SmtpClient GetSmtpClient()
	{
		EmailConfiguration configEmail = getConfigEmail();
		SmtpClient smtpClient = new SmtpClient();
		smtpClient.Port = configEmail.SMTP_CLIENT_PORT;
		smtpClient.Host = configEmail.SMTP_HOST;
		smtpClient.EnableSsl = configEmail.SMTP_ENABLE_SSL;
		if (configEmail.SMTP_NETWORK_CREDENCIAL != null)
		{
			smtpClient.Credentials = new NetworkCredential(configEmail.SMTP_NETWORK_CREDENCIAL["userName"], configEmail.SMTP_NETWORK_CREDENCIAL["password"]);
		}
		return smtpClient;
	}
}
