using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class PedVdaTransferAtacadistaLogTO
{
	public int IdPedVdaTransferAtacadistaLog { get; set; }

	public DateTime Data { get; set; }

	public int CdEmp { get; set; }

	public int NuPed { get; set; }

	public string EmailSmtpServidor { get; set; }

	public int EmailSmtpPort { get; set; }

	public string EmailUser { get; set; }

	public string EmailPassword { get; set; }

	public bool EmailUseSSL { get; set; }

	public string EmailFrom { get; set; }

	public string EmailTo { get; set; }

	public string EmailCc { get; set; }

	public string EmailSubject { get; set; }

	public string EmailBody { get; set; }

	public bool EmailBodyIsHtml { get; set; }

	public int EmailEnvioSituacao { get; set; }

	public string EmailEnvioMsg { get; set; }
}
