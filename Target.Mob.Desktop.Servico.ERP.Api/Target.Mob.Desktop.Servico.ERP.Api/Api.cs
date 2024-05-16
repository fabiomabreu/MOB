using System;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Owin.Hosting;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Api.Startup;
using Target.Mob.Desktop.Servico.ERP.Base;

namespace Target.Mob.Desktop.Servico.ERP.Api;

internal class Api : Principal
{
	private IDisposable _server;

	private IContainer components;

	public Api()
	{
		CodigoServico = 31;
		InitializeComponent();
	}

	protected override void OnStart(string[] args)
	{
		try
		{
			ConfiguraSincroniza();
			if (Sincroniza.SistemaAutenticado())
			{
				_server = WebApp.Start<StartupFromService>(Sincroniza.GetApiBaseAddress());
			}
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry(ex.Source + " TargetApi ", ex.Message, EventLogEntryType.Error);
			throw ex;
		}
	}

	protected override void OnStop()
	{
		if (_server != null)
		{
			_server.Dispose();
			_server = null;
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
		components = new Container();
		base.ServiceName = "Api";
	}
}
