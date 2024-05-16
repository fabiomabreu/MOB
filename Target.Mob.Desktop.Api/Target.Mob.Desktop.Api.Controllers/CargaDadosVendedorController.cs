using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Filters;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Api.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/cargadadosvendedor")]
public class CargaDadosVendedorController : ApiController
{
	private IConfiguration _configuration;

	public CargaDadosVendedorController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpGet]
	[Route("")]
	[GzipCompression]
	public IHttpActionResult Get()
	{
		HttpRequestHeaders headers = base.Request.Headers;
		string empty = string.Empty;
		long num = 0L;
		long cacheId = 0L;
		if (headers.Contains("codigovendedor") && headers.Contains("ultimoidcargaentidade"))
		{
			empty = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
			num = Convert.ToInt64(headers.GetValues("ultimoidcargaentidade").First());
			if (headers.Contains("cacheId"))
			{
				cacheId = Convert.ToInt64(headers.GetValues("cacheId").First());
			}
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != empty.Trim().ToUpper())
			{
				return Unauthorized();
			}
			string connectionString = _configuration.GetConnectionString();
			IEnumerable<DadosTO> enumerable = CargaDadosVendedorDAL.SelectDadosVendedor(connectionString, empty, num, cacheId);
			if (enumerable.Count() == 0)
			{
				VendedorSincronizacaoLogDAL.Update(connectionString, empty, num);
			}
			return Ok(enumerable);
		}
		return BadRequest("codigovendedor e/ou ultimoidcargaentidade não informados.");
	}

	[Authorize]
	[HttpGet]
	[Route("iscargacompleta")]
	public IHttpActionResult GetIsCargaCompleta()
	{
		HttpRequestHeaders headers = base.Request.Headers;
		string empty = string.Empty;
		if (headers.Contains("codigovendedor"))
		{
			empty = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != empty.Trim().ToUpper())
			{
				return Unauthorized();
			}
			bool content = CargaDadosVendedorDAL.IsCargaCompleta(_configuration.GetConnectionString(), empty);
			return Ok(content);
		}
		return BadRequest("codigovendedor não informado.");
	}
}
