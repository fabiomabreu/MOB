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

[RoutePrefix("api/cargadadosinventariador")]
public class CargaDadosInventariadorController : ApiController
{
	private IConfiguration _configuration;

	public CargaDadosInventariadorController(IConfiguration configuration)
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
		if (headers.Contains("codigousuario") && headers.Contains("ultimoidcargaentidade"))
		{
			string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigousuario");
			long ultimoIdCargaEntidade = Convert.ToInt64(headers.GetValues("ultimoidcargaentidade").First());
			long cacheId = 0L;
			if (headers.Contains("cacheId"))
			{
				cacheId = Convert.ToInt64(headers.GetValues("cacheId").First());
			}
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
			{
				return Unauthorized();
			}
			string connectionString = _configuration.GetConnectionString();
			IEnumerable<DadosTO> enumerable = CargaDadosInventariadorDAL.SelectDadosInventariador(connectionString, paramFromHeader, ultimoIdCargaEntidade, cacheId);
			if (enumerable.Count() == 0)
			{
				InventariadorSincronizacaoLogDAL.Update(connectionString, paramFromHeader, ultimoIdCargaEntidade);
			}
			return Ok(enumerable);
		}
		return BadRequest("codigousuario e/ou ultimoidcargaentidade não informados.");
	}

	[Authorize]
	[HttpGet]
	[Route("iscargacompleta")]
	public IHttpActionResult GetIsCargaCompleta()
	{
		HttpRequestHeaders headers = base.Request.Headers;
		string empty = string.Empty;
		if (headers.Contains("codigousuario"))
		{
			empty = ControllerUtil.getParamFromHeader(headers, "codigousuario");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != empty.Trim().ToUpper())
			{
				return Unauthorized();
			}
			bool content = CargaDadosInventariadorDAL.IsCargaCompleta(_configuration.GetConnectionString(), empty);
			return Ok(content);
		}
		return BadRequest("codigoUsuario não informado.");
	}
}
