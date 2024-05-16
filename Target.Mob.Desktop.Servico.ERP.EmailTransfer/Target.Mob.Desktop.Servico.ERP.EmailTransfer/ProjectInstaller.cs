using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Target.Mob.Desktop.Servico.ERP.EmailTransfer;

[RunInstaller(true)]
public class ProjectInstaller : Installer
{
	private IContainer components;

	private ServiceProcessInstaller Instalador;

	private ServiceInstaller EmailTransfer;

	public ProjectInstaller()
	{
		InitializeComponent();
	}

	public string GetContextParameter(string key)
	{
		string text = "";
		try
		{
			return base.Context.Parameters[key].ToString();
		}
		catch
		{
			return "";
		}
	}

	protected override void OnBeforeInstall(IDictionary savedState)
	{
		SetServiceName();
		base.OnBeforeInstall(savedState);
		string text = GetContextParameter("user").Trim();
		string text2 = GetContextParameter("password").Trim();
		if (text != "" && text2 != "")
		{
			Instalador.Account = ServiceAccount.User;
			Instalador.Username = text;
			Instalador.Password = text2;
		}
		else
		{
			Instalador.Account = ServiceAccount.LocalSystem;
		}
	}

	protected override void OnBeforeUninstall(IDictionary savedState)
	{
		SetServiceName();
		base.OnBeforeUninstall(savedState);
	}

	private void SetServiceName()
	{
		if (base.Context.Parameters.ContainsKey("ServiceName"))
		{
			EmailTransfer.ServiceName = base.Context.Parameters["ServiceName"];
		}
		if (base.Context.Parameters.ContainsKey("DisplayName"))
		{
			EmailTransfer.DisplayName = base.Context.Parameters["DisplayName"];
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		Instalador = new ServiceProcessInstaller();
		EmailTransfer = new ServiceInstaller();
		Instalador.Password = null;
		Instalador.Username = null;
		EmailTransfer.Description = "Target Mob ERP - Envio de Email Transfer Atacadista";
		EmailTransfer.DisplayName = "Target Mob ERP - Envio de Email Transfer Atacadista";
		EmailTransfer.ServiceName = "EmailTransfer";
		base.Installers.AddRange(new Installer[2] { Instalador, EmailTransfer });
	}
}
