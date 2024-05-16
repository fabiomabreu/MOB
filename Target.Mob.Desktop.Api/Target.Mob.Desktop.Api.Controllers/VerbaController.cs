using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Api.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/verba")]
public class VerbaController : ApiController
{
	private IConfiguration _configuration;

	public VerbaController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpPost]
	[Route("transferir")]
	public IHttpActionResult verbaTransferir()
	{
		try
		{
			HttpRequestHeaders headers = base.Request.Headers;
			if (!headers.Contains("codigosupervisor") || !headers.Contains("valorverbasupervisor") || !headers.Contains("codigovendedor") || !headers.Contains("valorverbavendedor") || !headers.Contains("tipooperacao") || !headers.Contains("valortransferencia"))
			{
				return BadRequest("Parametros inválidos.");
			}
			string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigosupervisor");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
			{
				return Unauthorized();
			}
			CultureInfo provider = new CultureInfo("en-US");
			decimal valorVerbaSupervisor = Convert.ToDecimal(headers.GetValues("valorverbasupervisor").First(), provider);
			string paramFromHeader2 = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
			decimal valorVerbaVendedor = Convert.ToDecimal(headers.GetValues("valorverbavendedor").First(), provider);
			string paramFromHeader3 = ControllerUtil.getParamFromHeader(headers, "tipooperacao");
			decimal valorTransferencia = Convert.ToDecimal(headers.GetValues("valortransferencia").First(), provider);
			int content = VerbaDAL.TransferirVerba(_configuration.GetConnectionString(), paramFromHeader, valorVerbaSupervisor, paramFromHeader2, valorVerbaVendedor, paramFromHeader3, valorTransferencia);
			return Ok(content);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpGet]
	[Route("saldo")]
	public IHttpActionResult getSaldo()
	{
		try
		{
			HttpRequestHeaders headers = base.Request.Headers;
			if (!headers.Contains("codigosupervisor"))
			{
				return BadRequest("Parametros inválidos.");
			}
			string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigosupervisor");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
			{
				return Unauthorized();
			}
			IEnumerable<VerbaSaldoTO> saldo = VerbaDAL.GetSaldo(_configuration.GetConnectionString(), paramFromHeader);
			return Ok(saldo);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
