using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Target.Mob.Desktop.Sincronizacao.BLL.Util;

public static class EmailHelper
{
	public static bool Validate(string inputEmail)
	{
		if (!string.IsNullOrEmpty(inputEmail.Trim()) && new Regex("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$").IsMatch(inputEmail.Trim()))
		{
			return true;
		}
		return false;
	}

	public static bool ValidateExists(string inputEmail, out string message)
	{
		try
		{
			message = string.Empty;
			if (Validate(inputEmail))
			{
				IPEndPoint iPEndPoint = new IPEndPoint(Dns.GetHostEntry(inputEmail.Trim().Split('@')[1]).AddressList[0], 25);
				new System.Net.Sockets.Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp).Connect(iPEndPoint);
				return true;
			}
		}
		catch (Exception ex)
		{
			message = ex.Message;
		}
		return false;
	}

	public static bool ValidateExists(string inputEmail)
	{
		string message;
		return ValidateExists(inputEmail.Trim(), out message);
	}

	public static bool SendMail(string smtpServer, int port, string user, string password, MailAddress from, MailAddress[] to, MailAddress[] cc, MailAddress[] bcc, string subject, string body, Attachment[] attachmentCollection, bool useSSL, bool useDefaultCredentials, bool isHTMLBody, out string message)
	{
		using MailMessage mailMessage = new MailMessage();
		try
		{
			message = string.Empty;
			mailMessage.From = from;
			if (to != null)
			{
				MailAddress[] array = to;
				foreach (MailAddress item in array)
				{
					mailMessage.To.Add(item);
				}
			}
			if (cc != null)
			{
				MailAddress[] array = cc;
				foreach (MailAddress item2 in array)
				{
					mailMessage.CC.Add(item2);
				}
			}
			if (bcc != null)
			{
				MailAddress[] array = bcc;
				foreach (MailAddress item3 in array)
				{
					mailMessage.Bcc.Add(item3);
				}
			}
			mailMessage.Subject = subject;
			mailMessage.Body = body;
			mailMessage.IsBodyHtml = isHTMLBody;
			if (attachmentCollection != null && attachmentCollection.Length != 0)
			{
				foreach (Attachment item4 in attachmentCollection)
				{
					mailMessage.Attachments.Add(item4);
				}
			}
			SmtpClient smtpClient = new SmtpClient(smtpServer, port);
			NetworkCredential credentials = new NetworkCredential(user, password);
			smtpClient.Port = port;
			smtpClient.Host = smtpServer;
			smtpClient.EnableSsl = useSSL;
			smtpClient.UseDefaultCredentials = useDefaultCredentials;
			smtpClient.Credentials = credentials;
			smtpClient.Send(mailMessage);
			return true;
		}
		catch (Exception ex)
		{
			message = ex.Message;
			return false;
		}
	}
}
