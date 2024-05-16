using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/titulo")]
public class TituloController : ApiController
{
	private IConfiguration _configuration;

	public TituloController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpGet]
	[Route("linhadigitavel")]
	public IHttpActionResult BoletoTitulo()
	{
		_ = base.Request;
		HttpRequestHeaders headers = base.Request.Headers;
		if (headers.Contains("codigovendedor"))
		{
			try
			{
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
				{
					return Unauthorized();
				}
				int numeroTitulo = Convert.ToInt32(headers.GetValues("numerotitulo").First());
				string value = headers.GetValues("serietitulo").First();
				char serieTitulo = ((!"".Equals(value)) ? Convert.ToChar(value) : ' ');
				string boletoTitulo = TituloDAL.GetBoletoTitulo(_configuration.GetConnectionString(), numeroTitulo, serieTitulo);
				return Ok(boletoTitulo);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		return BadRequest("Parametros inválidos.");
	}
}
