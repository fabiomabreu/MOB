using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/pedido")]
public class PedidoController : ApiController
{
	private IConfiguration _configuration;

	public PedidoController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpPost]
	[Route("liberar")]
	public IHttpActionResult liberarSupervisor()
	{
		try
		{
			HttpRequestHeaders headers = base.Request.Headers;
			if (!headers.Contains("codigosupervisor") || !headers.Contains("codigoempresa") || !headers.Contains("numeropedido"))
			{
				return BadRequest("Parametros inválidos.");
			}
			string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigosupervisor");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
			{
				return Unauthorized();
			}
			int cdEmp = Convert.ToInt32(headers.GetValues("codigoempresa").First());
			int nuPed = Convert.ToInt32(headers.GetValues("numeropedido").First());
			int content = PedidoDAL.LiberarPedidoSupervisor(_configuration.GetConnectionString(), paramFromHeader, cdEmp, nuPed);
			return Ok(content);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
