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

[RoutePrefix("api/promotor")]
public class PromotorController : ApiController
{
	private IConfiguration _configuration;

	public PromotorController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpPost]
	[Route("indicacaoFaltaEstoque")]
	[GzipCompression]
	public IHttpActionResult Set([FromBody] IndicacaoFaltaEstoqueTO indicacaoFaltaEstoque)
	{
		string text = null;
		HttpRequestHeaders headers = base.Request.Headers;
		try
		{
			if (headers.Contains("codigoPromotor"))
			{
				text = ControllerUtil.getParamFromHeader(headers, "codigoPromotor");
			}
			if (text == null && headers.Contains("codigopromotor"))
			{
				text = ControllerUtil.getParamFromHeader(headers, "codigopromotor");
			}
			if (text != null)
			{
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != text.Trim().ToUpper())
				{
					return Unauthorized();
				}
				if (indicacaoFaltaEstoque == null || !indicacaoFaltaEstoque.CdClien.HasValue || !indicacaoFaltaEstoque.CdProd.HasValue || indicacaoFaltaEstoque.CdPromotor == null)
				{
					return BadRequest("Indicacao de falta estoque inválida.");
				}
				string connectionString = _configuration.GetConnectionString();
				int id = IndicacaoFaltaEstoqueDAL.Insert(connectionString, indicacaoFaltaEstoque);
				IndicacaoFaltaEstoqueTO content = IndicacaoFaltaEstoqueDAL.SelectByID(connectionString, id);
				return Ok(content);
			}
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		return BadRequest("codigopromotor não informado.");
	}

	[Authorize]
	[HttpGet]
	[Route("pedidoEntrega")]
	[GzipCompression]
	public IHttpActionResult GetPedidoEntrega([FromBody] DateTime DtEntrega)
	{
		string text = null;
		HttpRequestHeaders headers = base.Request.Headers;
		try
		{
			if (headers.Contains("codigoPromotor"))
			{
				text = ControllerUtil.getParamFromHeader(headers, "codigoPromotor");
			}
			if (text == null && headers.Contains("codigopromotor"))
			{
				text = ControllerUtil.getParamFromHeader(headers, "codigopromotor");
			}
			if (text == null)
			{
				return BadRequest("codigopromotor não informado.");
			}
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != text.Trim().ToUpper())
			{
				return Unauthorized();
			}
			int? codigo = null;
			if (headers.Contains("codigo"))
			{
				string text2 = headers.GetValues("codigo").First();
				if (!string.IsNullOrEmpty(text2))
				{
					codigo = int.Parse(text2);
				}
			}
			List<PedidoEntregaTO> pedidoEntrega = PedidoEntregaDAL.GetPedidoEntrega(_configuration.GetConnectionString(), text, codigo);
			return Ok(pedidoEntrega);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
