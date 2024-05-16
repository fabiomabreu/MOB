using System.Web.Http;
using System.Web.Http.SelfHost;
using Target.Venda.Helpers.Geral;

namespace Target.Venda.WebApiSelfHost;

public class Server
{
	public Server()
	{
		string appConfig = ConfigHelper.getAppConfig("PortaComunicacaoAPI");
		string baseAddress = $"http://localhost:{appConfig}";
		HttpSelfHostConfiguration httpSelfHostConfiguration = new HttpSelfHostConfiguration(baseAddress);
		httpSelfHostConfiguration.MapHttpAttributeRoutes();
		httpSelfHostConfiguration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new
		{
			id = RouteParameter.Optional
		});
		HttpSelfHostServer httpSelfHostServer = new HttpSelfHostServer(httpSelfHostConfiguration);
		httpSelfHostServer.OpenAsync().Wait();
	}
}
