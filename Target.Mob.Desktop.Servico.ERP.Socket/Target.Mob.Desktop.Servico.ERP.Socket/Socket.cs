using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Servico.ERP.Base;
using Target.Mob.Desktop.Sincronizacao.BLL.Socket;

namespace Target.Mob.Desktop.Servico.ERP.Socket;

internal class Socket : Principal
{
	private SocketManager _socket;

	private IContainer components;

	public Socket()
	{
		CodigoServico = 30;
		InitializeComponent();
	}

	protected override async void OnStart(string[] args)
	{
		try
		{
			ConfiguraSincroniza();
			_socket = Sincroniza.SocketManagerFactory();
			await _socket.Conectar();
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			Type type = GetType();
			LogEvento.WriteEntry(type.Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
			LogEventoSocket.WriteEntry(type.Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
			throw ex;
		}
	}

	protected override async void OnStop()
	{
		if (_socket != null)
		{
			await _socket.Desconectar();
			_socket = null;
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
		base.ServiceName = "Socket";
	}
}
