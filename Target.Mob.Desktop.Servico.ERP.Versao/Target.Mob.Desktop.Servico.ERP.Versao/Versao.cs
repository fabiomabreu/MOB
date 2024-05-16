using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Target.Mob.Desktop.Servico.ERP.Base;

namespace Target.Mob.Desktop.Servico.ERP.Versao;

public class Versao : Principal
{
	private IContainer components;

	public Versao()
	{
		CodigoServico = 21;
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
			EventLog.WriteEntry(ex.Source + " Versão", ex.Message, EventLogEntryType.Error);
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
			Sincroniza.ImportaVersaoRetaguarda();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Versão", ex.Message, EventLogEntryType.Error);
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
			EventLog.WriteEntry(ex.Source + "Versão", ex.Message, EventLogEntryType.Error);
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
		base.ServiceName = "Versao";
	}
}
