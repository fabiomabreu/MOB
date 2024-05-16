using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocketIOClient;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Geracao.Bll;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL.Socket;

public class SocketManager
{
	private string _StringConnTargetErp;

	private string _Uri;

	private string _Cnpj;

	private List<string> _Documentos;

	private SocketIO socket;

	public SocketManager(string stringConnTargetErp, string uri)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_Uri = uri;
		_Documentos = EmpresaBLL.getCnpjs(_StringConnTargetErp, null, null, null, null, true, null);
		_Cnpj = _Documentos[0];
		socket = new SocketIO(_Uri, new SocketIOOptions
		{
			Query = new Dictionary<string, string> { 
			{
				"token",
				GetToken()
			} },
			ConnectionTimeout = TimeSpan.FromSeconds(10.0)
		});
		socket.OnConnected += Socket_OnConnected;
		socket.OnDisconnected += Socket_OnDisconnected;
		socket.OnPing += Socket_OnPing;
		socket.OnPong += Socket_OnPong;
		socket.OnReconnecting += Socket_OnReconnecting;
		socket.On("carga", delegate(SocketIOResponse data)
		{
			SocketTO socketTO = DataToModel(data);
			if (socketTO != null && !(socketTO.AcaoRetag != "gerarCarga"))
			{
				string[] dados = CargaEntidadeBLL.SelectDadosVendedor(_StringConnTargetErp, socketTO.CodigoVendedor, socketTO.IdCargaEntidade);
				socket.EmitAsync("mobMensagemRetaguarda", GetObjectEmit(socketTO, dados));
			}
		});
	}

	private void Socket_OnConnected(object sender, EventArgs e)
	{
		MethodBase currentMethod = MethodBase.GetCurrentMethod();
		LogEventoSocket.WriteEntry(GetType().Name + "." + currentMethod.Name, "Socket Conectado.", EventLogEntryType.Information);
	}

	private void Socket_OnDisconnected(object sender, string e)
	{
		MethodBase currentMethod = MethodBase.GetCurrentMethod();
		LogEventoSocket.WriteEntry(GetType().Name + "." + currentMethod.Name, "Socket Desconectado.", EventLogEntryType.Information);
	}

	private static void Socket_OnPing(object sender, EventArgs e)
	{
		Console.WriteLine("Ping");
	}

	private static void Socket_OnPong(object sender, TimeSpan e)
	{
		Console.WriteLine("Pong: " + e.TotalMilliseconds);
	}

	private static void Socket_OnReconnecting(object sender, int e)
	{
		MethodBase currentMethod = MethodBase.GetCurrentMethod();
		LogEventoSocket.WriteEntry("SocketManager." + currentMethod.Name, "Socket Reconectando.", EventLogEntryType.Information);
	}

	public async Task Conectar()
	{
		await socket.ConnectAsync();
	}

	public async Task Desconectar()
	{
		await socket.DisconnectAsync();
	}

	private SocketTO DataToModel(SocketIOResponse data)
	{
		try
		{
			byte[] array = Convert.FromBase64String(data.GetValue<string>());
			return JsonConvert.DeserializeObject<SocketTO>(Encoding.UTF8.GetString(array, 0, array.Length));
		}
		catch (Exception)
		{
			return null;
		}
	}

	private string ModelToData(SocketTO model)
	{
		string s = JsonConvert.SerializeObject(model);
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
	}

	private string GetToken()
	{
		SocketTO socketTO = new SocketTO();
		socketTO.CNPJ = _Cnpj;
		socketTO.CodigoVendedor = "-1";
		socketTO.IdVendedor = "-1";
		socketTO.Token = socketTO.CNPJ + socketTO.CodigoVendedor;
		socketTO.TipoCliente = "1";
		socketTO.Sistema = "20";
		socketTO.Documentos = _Documentos;
		return ModelToData(socketTO);
	}

	private string GetObjectEmit(SocketTO modelReceived, string[] dados)
	{
		SocketTO socketTO = new SocketTO();
		socketTO.Token = _Cnpj + modelReceived.CodigoVendedor;
		socketTO.CodigoVendedor = modelReceived.CodigoVendedor;
		socketTO.IdVendedor = modelReceived.IdVendedor;
		socketTO.ChaveDispositivo = "";
		socketTO.CNPJ = _Cnpj;
		socketTO.Sistema = "20";
		socketTO.TipoCliente = "2";
		socketTO.Acao = "dadosRetagRetorno";
		socketTO.AcaoRetag = modelReceived.AcaoRetag;
		socketTO.Parametros = "";
		socketTO.MensagemRetorno = dados;
		socketTO.IdCargaEntidade = modelReceived.IdCargaEntidade;
		socketTO.Documentos = _Documentos;
		return ModelToData(socketTO);
	}
}
