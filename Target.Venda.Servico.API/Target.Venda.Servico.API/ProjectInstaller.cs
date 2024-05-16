using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Target.Venda.Servico.API;

[RunInstaller(true)]
public class ProjectInstaller : Installer
{
	private IContainer components = null;

	private ServiceProcessInstaller Instalador;

	private ServiceInstaller TargetVendaAPI;

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
		TargetVendaAPI = new ServiceInstaller();
		Instalador.Password = null;
		Instalador.Username = null;
		TargetVendaAPI.Description = "Target Venda - API";
		TargetVendaAPI.DisplayName = "Target Venda - API";
		TargetVendaAPI.ServiceName = "TargetVendaAPI";
		TargetVendaAPI.StartType = ServiceStartMode.Automatic;
		base.Installers.AddRange(new Installer[2] { Instalador, TargetVendaAPI });
	}
}
