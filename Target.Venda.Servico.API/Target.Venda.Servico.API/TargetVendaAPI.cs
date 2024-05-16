using System.ComponentModel;
using System.ServiceProcess;
using Target.Venda.WebApiSelfHost;

namespace Target.Venda.Servico.API;

public class TargetVendaAPI : ServiceBase
{
	private Server server;

	private IContainer components = null;

	public TargetVendaAPI()
	{
		InitializeComponent();
	}

	protected override void OnStart(string[] args)
	{
		server = new Server();
	}

	protected override void OnStop()
	{
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
		components = new Container();
		base.ServiceName = "Service1";
	}
}
