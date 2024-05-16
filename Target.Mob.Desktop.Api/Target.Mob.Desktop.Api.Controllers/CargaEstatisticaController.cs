using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Api.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/cargaestatistica")]
public class CargaEstatisticaController : ApiController
{
	private IConfiguration _configuration;

	public CargaEstatisticaController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpGet]
	[Route("ResumoGeral")]
	public IHttpActionResult GetResumoGeral()
	{
		if (!requestPainelIsValid(base.Request))
		{
			return Unauthorized();
		}
		IEnumerable<EstatisticaResumoGeralTO> content = CargaEstatisticaDAL.SelectResumoGeral(_configuration.GetConnectionString());
		return Ok(content);
	}

	[Authorize]
	[HttpGet]
	[Route("ResumoSincronizacaoVendedores")]
	public IHttpActionResult GetResumoSincronizacaoVendedores()
	{
		if (!requestPainelIsValid(base.Request))
		{
			return Unauthorized();
		}
		HttpRequestHeaders headers = base.Request.Headers;
		if (headers.Contains("filtro"))
		{
			string text = headers.GetValues("filtro").First();
			if ((text != "" && !Regex.IsMatch(text, "^[A-Za-z0-9-áàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ_. ]+$")) || text.Length > 255)
			{
				return BadRequest("filtro inválido.");
			}
			IEnumerable<EstatisticaResumoSincronizacaoVendedorTO> content = CargaEstatisticaDAL.SelectResumoSincronizacaoVendedores(_configuration.GetConnectionString(), text);
			return Ok(content);
		}
		return BadRequest("filtro não informado.");
	}

	private bool requestPainelIsValid(HttpRequestMessage request)
	{
		string role = HttpRequestMessageHelper.GetRole(base.Request);
		if (role == null || role.Trim().ToUpper() != "PAINELTARGET")
		{
			return false;
		}
		return true;
	}
}
