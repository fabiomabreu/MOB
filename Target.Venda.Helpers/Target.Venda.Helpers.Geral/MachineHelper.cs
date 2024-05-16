using System;
using System.Net;
using System.Net.NetworkInformation;
using FrameworkTarget.Seguranca;

namespace Target.Venda.Helpers.Geral;

public static class MachineHelper
{
	public static string GetHostName()
	{
		return (!string.IsNullOrEmpty(Dns.GetHostName())) ? Dns.GetHostName() : Environment.MachineName;
	}

	public static string GetMACAddress()
	{
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			string text = string.Empty;
			NetworkInterface[] array = allNetworkInterfaces;
			foreach (NetworkInterface networkInterface in array)
			{
				if (text == string.Empty)
				{
					IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
					text = networkInterface.GetPhysicalAddress().ToString();
				}
			}
			return text;
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	public static string GetMachineID()
	{
		return MaquinaID.ObterMaquinaID();
	}
}
