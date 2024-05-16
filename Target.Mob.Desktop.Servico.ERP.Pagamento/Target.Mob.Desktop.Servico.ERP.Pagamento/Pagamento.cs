using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Target.Mob.Desktop.Servico.ERP.Base;

namespace Target.Mob.Desktop.Servico.ERP.Pagamento;

internal class Pagamento : Principal
{
	private IContainer components;

	public Pagamento()
	{
		CodigoServico = 26;
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
			EventLog.WriteEntry(ex.Source + " Pagamento", ex.Message, EventLogEntryType.Error);
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
			Sincroniza.ImportaPagamento();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Pagamento", ex.Message, EventLogEntryType.Error);
			throw ex;
		}
	}

	public override void OnTimerEvent(object source, EventArgs e)
	{
		Action();
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
		base.ServiceName = "Pagamento";
	}
}
