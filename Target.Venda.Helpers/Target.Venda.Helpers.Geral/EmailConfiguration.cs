using System.Collections.Generic;

namespace Target.Venda.Helpers.Geral;

public class EmailConfiguration
{
	public string EMAIL_FROM { get; set; }

	public string EMAIL_FROM_DISPLAY { get; set; }

	public int SMTP_CLIENT_PORT { get; set; }

	public string SMTP_HOST { get; set; }

	public bool SMTP_ENABLE_SSL { get; set; }

	public Dictionary<string, string> SMTP_NETWORK_CREDENCIAL { get; set; }
}
