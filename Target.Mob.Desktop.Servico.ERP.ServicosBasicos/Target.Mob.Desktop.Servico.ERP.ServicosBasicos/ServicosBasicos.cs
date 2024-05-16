using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Target.Mob.Desktop.Servico.ERP.Base;

namespace Target.Mob.Desktop.Servico.ERP.ServicosBasicos;

internal class ServicosBasicos : Principal
{
	private IContainer components;

	public ServicosBasicos()
	{
		CodigoServico = 12;
		InitializeComponent();
	}

	protected override void OnStart(string[] args)
	{
		try
		{
			TimerCallback callback = oTimer_TimerCallback;
			base.Timer = new Timer(callback);
			if (args.Count() > 0)
			{
				base.Intervalo = Convert.ToInt32(args[1].ToString()) * 1000;
				base.Timer.Change(1000, base.Intervalo.Value);
				return;
			}
			base.Intervalo = BuscarIntervaloServico(CodigoServico);
			if (base.Intervalo.HasValue)
			{
				base.Timer.Change(1000, base.Intervalo.Value);
			}
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " ServicosBasicos", ex.Message, EventLogEntryType.Error);
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
			Sincroniza.ExportaCadastroBasico();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " ServicosBasicos", ex.Message, EventLogEntryType.Error);
			throw ex;
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
		base.ServiceName = "ServicosBasicos";
	}
}
