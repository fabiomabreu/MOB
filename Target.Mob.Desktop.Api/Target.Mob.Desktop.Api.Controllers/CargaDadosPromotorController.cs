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

[RoutePrefix("api/cargadadospromotor")]
public class CargaDadosPromotorController : ApiController
{
	private IConfiguration _configuration;

	public CargaDadosPromotorController(IConfiguration configuration)
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
		if (headers.Contains("codigopromotor") && headers.Contains("ultimoidcargaentidade"))
		{
			empty = ControllerUtil.getParamFromHeader(headers, "codigopromotor");
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
			IEnumerable<DadosTO> enumerable = CargaDadosPromotorDAL.SelectDadosPromotor(connectionString, empty, num, cacheId);
			if (enumerable.Count() == 0)
			{
				PromotorSincronizacaoLogDAL.Update(connectionString, empty, num);
			}
			return Ok(enumerable);
		}
		return BadRequest("codigopromotor e/ou ultimoidcargaentidade não informados.");
	}

	[Authorize]
	[HttpGet]
	[Route("iscargacompleta")]
	public IHttpActionResult GetIsCargaCompleta()
	{
		HttpRequestHeaders headers = base.Request.Headers;
		string empty = string.Empty;
		if (headers.Contains("codigopromotor"))
		{
			empty = ControllerUtil.getParamFromHeader(headers, "codigopromotor");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != empty.Trim().ToUpper())
			{
				return Unauthorized();
			}
			int result = 0;
			int result2 = 0;
			int result3 = 0;
			int result4 = 0;
			if (headers.Contains("major"))
			{
				int.TryParse(ControllerUtil.getParamFromHeader(headers, "major"), out result);
			}
			if (headers.Contains("minor"))
			{
				int.TryParse(ControllerUtil.getParamFromHeader(headers, "minor"), out result2);
			}
			if (headers.Contains("build"))
			{
				int.TryParse(ControllerUtil.getParamFromHeader(headers, "build"), out result3);
			}
			if (headers.Contains("revision"))
			{
				int.TryParse(ControllerUtil.getParamFromHeader(headers, "revision"), out result4);
			}
			bool content = CargaDadosPromotorDAL.IsCargaCompleta(_configuration.GetConnectionString(), empty, result, result2, result3, result4);
			return Ok(content);
		}
		return BadRequest("codigopromotor não informado.");
	}
}
