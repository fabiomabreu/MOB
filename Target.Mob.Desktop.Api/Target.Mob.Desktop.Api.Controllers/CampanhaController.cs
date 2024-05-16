using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/campanha")]
public class CampanhaController : ApiController
{
	private IConfiguration _configuration;

	public CampanhaController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpGet]
	[Route("exists")]
	public IHttpActionResult Exists()
	{
		_ = base.Request;
		HttpRequestHeaders headers = base.Request.Headers;
		if (headers.Contains("codigovendedor") && headers.Contains("codigoempresa") && headers.Contains("tpped") && headers.Contains("codigocliente"))
		{
			try
			{
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				int codigoEmpresa = Convert.ToInt32(headers.GetValues("codigoempresa").First());
				string tpPed = headers.GetValues("tpped").First();
				int codigoCliente = Convert.ToInt32(headers.GetValues("codigoCliente").First());
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
				{
					return Unauthorized();
				}
				bool content = CampanhaDAL.Exists(_configuration.GetConnectionString(), paramFromHeader, codigoCliente, codigoEmpresa, tpPed);
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
