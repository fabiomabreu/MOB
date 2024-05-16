using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public static class WebServiceHelper
{
	public static EndpointAddress getEndPointConfig(string NameWebService)
	{
		foreach (ChannelEndpointElement endpoint in ServiceModelSectionGroup.GetSectionGroup(ConfigHelper.getConfig()).Client.Endpoints)
		{
			if (endpoint.Name == NameWebService)
			{
				return new EndpointAddress(endpoint.Address);
			}
		}
		return null;
	}

	public static EndpointAddress getEndPointConfigURL(string URL)
	{
		return new EndpointAddress(URL);
	}

	public static BasicHttpBinding getBasicBindingConfig(string NameWebService)
	{
		BindingsSection bindings = ServiceModelSectionGroup.GetSectionGroup(ConfigHelper.getConfig()).Bindings;
		BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
		foreach (BasicHttpBindingElement binding in bindings.BasicHttpBinding.Bindings)
		{
			if (binding.Name == NameWebService)
			{
				basicHttpBinding.Name = binding.Name;
				basicHttpBinding.CloseTimeout = binding.CloseTimeout;
				basicHttpBinding.ReceiveTimeout = binding.ReceiveTimeout;
				basicHttpBinding.SendTimeout = binding.SendTimeout;
				basicHttpBinding.AllowCookies = binding.AllowCookies;
				basicHttpBinding.BypassProxyOnLocal = binding.BypassProxyOnLocal;
				basicHttpBinding.HostNameComparisonMode = binding.HostNameComparisonMode;
				basicHttpBinding.MaxBufferPoolSize = binding.MaxBufferPoolSize;
				basicHttpBinding.MaxBufferSize = binding.MaxBufferSize;
				basicHttpBinding.MaxReceivedMessageSize = binding.MaxReceivedMessageSize;
				basicHttpBinding.MessageEncoding = binding.MessageEncoding;
				basicHttpBinding.ProxyAddress = binding.ProxyAddress;
				basicHttpBinding.TextEncoding = binding.TextEncoding;
				basicHttpBinding.TransferMode = binding.TransferMode;
				basicHttpBinding.UseDefaultWebProxy = binding.UseDefaultWebProxy;
				basicHttpBinding.ReaderQuotas.MaxStringContentLength = binding.ReaderQuotas.MaxStringContentLength;
				basicHttpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
				basicHttpBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
				basicHttpBinding.ReaderQuotas.MaxDepth = int.MaxValue;
				basicHttpBinding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
				basicHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
			}
		}
		return basicHttpBinding;
	}
}
