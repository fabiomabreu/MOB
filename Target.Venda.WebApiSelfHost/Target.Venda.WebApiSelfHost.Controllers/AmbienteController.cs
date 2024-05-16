using System.Web.Http;

namespace Target.Venda.WebApiSelfHost.Controllers;

public class AmbienteController : ApiController
{
	[HttpGet]
	public string Ambiente()
	{
		return "Server em execução";
	}
}
