using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Util;
using Target.Mob.Desktop.Sincronizacao.BLL;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/cliente")]
public class ClienteController : ApiController
{
	private IConfiguration _configuration;

	public ClienteController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpGet]
	[Route("exists")]
	public IHttpActionResult Exists()
	{
		HttpRequestHeaders headers = base.Request.Headers;
		if (headers.Contains("codigovendedor") && headers.Contains("cnpjcpf"))
		{
			try
			{
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				string cnpj = headers.GetValues("cnpjcpf").First();
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
				{
					return Unauthorized();
				}
				bool content = ClienteBLL.Exists(_configuration.GetConnectionString(), cnpj);
				return Ok(content);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		return BadRequest("Parametros inválidos.");
	}
}
