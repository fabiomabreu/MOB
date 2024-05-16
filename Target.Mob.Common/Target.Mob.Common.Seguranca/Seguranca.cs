using System;
using System.Net;
using System.Net.Sockets;
using Target.Mob.Common.Properties;

namespace Target.Mob.Common.Seguranca;

public class Seguranca
{
	public static string MensagemErro => Resources.Mensagem;

	public static string GeraTokenERP(string cnpj, DateTime data)
	{
		return cnpj + data.ToString("ddMMyyyy");
	}

	public static string getHostName()
	{
		if ("RMATEUS".Equals(Environment.MachineName))
		{
			return "SRV-TESTE";
		}
		return Environment.MachineName;
	}

	public static string GetIpLanPrefered()
	{
		using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
		socket.Connect("8.8.8.8", 65530);
		return (socket.LocalEndPoint as IPEndPoint).Address.ToString();
	}

	public static string GetLocalIPAddress()
	{
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				return iPAddress.ToString();
			}
		}
		throw new Exception("No network adapters with an IPv4 address in the system!");
	}
}
