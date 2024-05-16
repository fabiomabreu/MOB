using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Target.Mob.Desktop.Servico.ERP.Base;

namespace Target.Mob.Desktop.Servico.ERP.Servico;

internal class Servico : Principal
{
	private IContainer components;

	public Servico()
	{
		CodigoServico = 8;
		InitializeComponent();
	}

	protected override void OnStart(string[] args)
	{
		try
		{
			TimerCallback callback = oTimer_TimerCallback;
			base.Timer = new Timer(callback);
			base.Intervalo = 300000;
			base.Timer.Change(1000, base.Intervalo.Value);
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Servico", ex.Message, EventLogEntryType.Error);
			throw ex;
		}
	}

	protected override void OnStop()
	{
		base.Timer.Change(-1, -1);
	}

	public void Action()
	{
		try
		{
			ConfiguraSincroniza();
			Sincroniza.ImportaServico();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Servico", ex.Message, EventLogEntryType.Error);
		}
	}

	private void oTimer_TimerCallback(object state)
	{
		try
		{
			OnStop();
			base.Timer.Change(base.Intervalo.Value, base.Intervalo.Value);
			Action();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + "Servico", ex.Message, EventLogEntryType.Error);
			throw ex;
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
		base.ServiceName = "Servico";
	}
}
