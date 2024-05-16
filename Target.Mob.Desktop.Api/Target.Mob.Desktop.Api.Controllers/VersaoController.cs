using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Geracao.Bll;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/versao")]
public class VersaoController : ApiController
{
	private IConfiguration _configuration;

	public VersaoController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[Route("compatibilidade")]
	public IHttpActionResult Get()
	{
		HttpRequestHeaders headers = base.Request.Headers;
		if (headers.Contains("versaomajor") && headers.Contains("versaominor"))
		{
			int versaoMajor = Convert.ToInt16(headers.GetValues("versaomajor").First());
			int versaoMinor = Convert.ToInt16(headers.GetValues("versaominor").First());
			bool content = GeraDadosBLL.IsVersaoCompativel(_configuration.GetConnectionString(), versaoMajor, versaoMinor);
			return Ok(content);
		}
		return BadRequest("versaomajor e/ou versaominor não informados.");
	}
}
