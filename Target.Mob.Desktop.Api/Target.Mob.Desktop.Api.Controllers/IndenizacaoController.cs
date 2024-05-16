using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Filters;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Api.Util;
using Target.Mob.Desktop.GCS;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/indenizacao")]
public class IndenizacaoController : ApiController
{
	private IConfiguration _configuration;

	public IndenizacaoController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpPost]
	[Route("")]
	[GzipCompression]
	public IHttpActionResult Set([FromBody] IndenizacaoTO indenizacao)
	{
		HttpRequestHeaders headers = base.Request.Headers;
		try
		{
			if (headers.Contains("codigovendedor"))
			{
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
				{
					return Unauthorized();
				}
				if (indenizacao == null || string.IsNullOrEmpty(indenizacao.UUID) || indenizacao.IndenizacaoHistorico == null || indenizacao.IndenizacaoHistorico.Length == 0 || indenizacao.IndenizacaoItem == null || indenizacao.IndenizacaoItem.Length == 0)
				{
					return BadRequest("Indenizacao inválida. Item = 0 ou Historico = 0 ou UUID não informado.");
				}
				string connectionString = _configuration.GetConnectionString();
				IndenizacaoTO indenizacaoTO = IndenizacaoDAL.SelectByUUID(connectionString, indenizacao.UUID);
				if (indenizacaoTO != null)
				{
					indenizacao = IndenizacaoDAL.SelectByID(connectionString, indenizacaoTO.IndenizacaoID.Value);
					return Ok(indenizacao);
				}
				int indenizacaoID = IndenizacaoDAL.Insert(connectionString, indenizacao);
				indenizacao = IndenizacaoDAL.SelectByID(connectionString, indenizacaoID);
				return Ok(indenizacao);
			}
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
		return BadRequest("codigovendedor não informado.");
	}

	[Authorize]
	[HttpPost]
	[Route("imagem")]
	[GzipCompression]
	public async Task<IHttpActionResult> SetImagem()
	{
		_ = 1;
		try
		{
			HttpRequestHeaders headers = base.Request.Headers;
			if (headers.Contains("codigovendedor") && headers.Contains("IndenizacaoID"))
			{
				string stringConnTargetERP = _configuration.GetConnectionString();
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				int IndenizacaoID = Convert.ToInt32(headers.GetValues("IndenizacaoID").First());
				IndenizacaoTO indenizacao = IndenizacaoDAL.SelectByID(stringConnTargetERP, IndenizacaoID);
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
				{
					return Unauthorized();
				}
				MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
				await base.Request.Content.ReadAsMultipartAsync(provider);
				List<IndenizacaoImagemTO> indImgs = new List<IndenizacaoImagemTO>();
				foreach (HttpContent content in provider.Contents)
				{
					string filename = content.Headers.ContentDisposition.FileName.Trim('"');
					byte[] arquivo = await content.ReadAsByteArrayAsync();
					IndenizacaoImagemTO item = new IndenizacaoImagemTO(IndenizacaoID, filename, arquivo);
					indImgs.Add(item);
				}
				EmpresaTO empresaTO = null;
				using (DbConnection dbConnection = new DbConnection(stringConnTargetERP))
				{
					dbConnection.Open();
					EmpresaTO[] array = EmpresaBLL.Select(dbConnection, indenizacao.CdEmp, null, null, null, true);
					if (array != null && array.Length == 1)
					{
						empresaTO = array[0];
					}
					dbConnection.Close();
				}
				foreach (IndenizacaoImagemTO item2 in indImgs)
				{
					IndenizacaoDAL.InsertImagens(stringConnTargetERP, item2);
					try
					{
						new GCSController(empresaTO.Cgc).EnviarIndenizacao(item2.IndenizacaoID.Value, item2.Arquivo, item2.Nome);
					}
					catch (Exception ex)
					{
						MethodBase currentMethod = MethodBase.GetCurrentMethod();
						LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, "Erro ao enviar Google Storage Cloud. IndenizacaoID: " + indenizacao.IndenizacaoID + ". " + ex.Message, EventLogEntryType.Error);
					}
				}
				return Ok("ok");
			}
			return BadRequest("Codigovendedor ou IndenizacaoID não informado.");
		}
		catch (Exception ex2)
		{
			return BadRequest(ex2.Message);
		}
	}

	[Authorize]
	[HttpGet]
	[Route("saldo")]
	[GzipCompression]
	public IHttpActionResult GetSaldo()
	{
		try
		{
			HttpRequestHeaders headers = base.Request.Headers;
			if (headers.Contains("codigoVendedor") && headers.Contains("codigoCliente"))
			{
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
				if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
				{
					return Unauthorized();
				}
				string value = headers.GetValues("codigoCliente").First();
				if (string.IsNullOrEmpty(value))
				{
					return BadRequest("Codigo Cliente Invalido.");
				}
				int codigoCliente = Convert.ToInt32(value);
				decimal saldo = IndenizacaoDAL.getSaldo(_configuration.GetConnectionString(), codigoCliente);
				return Ok(saldo);
			}
			return BadRequest("CodigoVendedor ou CodigoCliente não infomado. ");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpGet]
	[Route("notafiscal")]
	public IHttpActionResult Get()
	{
		try
		{
			_ = base.Request;
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
				string connectionString = _configuration.GetConnectionString();
				int? numeroNotaFiscal = null;
				DateTime? dataValidade = null;
				DateTime? dataNotaInicial = null;
				DateTime? dataNotaFinal = null;
				if (headers.Contains("codigovendedor") && headers.Contains("codigocliente") && headers.Contains("codigoproduto") && headers.Contains("codigoempresa"))
				{
					try
					{
						empty = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
						int codigoCliente = Convert.ToInt32(headers.GetValues("codigocliente").First());
						int codigoProduto = Convert.ToInt32(headers.GetValues("codigoproduto").First());
						int codigoEmpresa = Convert.ToInt32(headers.GetValues("codigoEmpresa").First());
						if (headers.Contains("numeronotafiscal"))
						{
							numeroNotaFiscal = Convert.ToInt32(headers.GetValues("numeronotafiscal").First());
						}
						if (headers.Contains("datavalidade"))
						{
							dataValidade = Convert.ToDateTime(headers.GetValues("datavalidade").First());
						}
						if (headers.Contains("datanotainicial"))
						{
							dataNotaInicial = Convert.ToDateTime(headers.GetValues("datanotainicial").First());
						}
						if (headers.Contains("datanotafinal"))
						{
							dataNotaFinal = Convert.ToDateTime(headers.GetValues("datanotafinal").First());
						}
						List<NotaFiscalTO> content = NotaFiscalDAL.Select(connectionString, empty, codigoCliente, codigoProduto, codigoEmpresa, numeroNotaFiscal, dataValidade, dataNotaInicial, dataNotaFinal);
						return Ok(content);
					}
					catch (Exception ex)
					{
						return BadRequest(ex.Message);
					}
				}
				string text = string.Empty;
				if (!headers.Contains("codigovendedor"))
				{
					text += "Código Vendedor";
				}
				if (!headers.Contains("codigocliente"))
				{
					if (text.Length > 0)
					{
						text += ", ";
					}
					text += "Código Cliente";
				}
				if (!headers.Contains("codigoproduto"))
				{
					if (text.Length > 0)
					{
						text += ", ";
					}
					text += "Código Produto ";
				}
				if (!headers.Contains("codigoempresa"))
				{
					if (text.Length > 0)
					{
						text += ", ";
					}
					text += "Código Empresa ";
				}
				return BadRequest("Parametros a seguir precisam possuir valores: " + text);
			}
			return BadRequest("codigovendedor não informado.");
		}
		catch (Exception ex2)
		{
			return BadRequest(ex2.Message);
		}
	}

	[Authorize]
	[HttpPost]
	[Route("liberar")]
	[GzipCompression]
	public IHttpActionResult LiberarSupervisor()
	{
		try
		{
			if (!base.Request.Headers.Contains("codigosupervisor") || !base.Request.Headers.Contains("codigoempresa") || !base.Request.Headers.Contains("numeroindenizacao") || !base.Request.Headers.Contains("status") || !base.Request.Headers.Contains("motivodevolucao"))
			{
				return BadRequest("Parametros inválidos.");
			}
			string paramFromHeader = ControllerUtil.getParamFromHeader(base.Request.Headers, "codigosupervisor");
			string usuario = HttpRequestMessageHelper.GetUsuario(base.Request);
			if (usuario == null || usuario.Trim().ToUpper() != paramFromHeader.Trim().ToUpper())
			{
				return Unauthorized();
			}
			int cdEmp = Convert.ToInt32(base.Request.Headers.GetValues("codigoempresa").First());
			int nuIndenizacao = Convert.ToInt32(base.Request.Headers.GetValues("numeroindenizacao").First());
			int status = Convert.ToInt32(base.Request.Headers.GetValues("status").First());
			string value = base.Request.Headers.GetValues("motivodevolucao").First();
			int? motivoDevolucao = null;
			if (!string.IsNullOrEmpty(value))
			{
				motivoDevolucao = Convert.ToInt32(value);
			}
			int content = IndenizacaoDAL.LiberarSupervisor(_configuration.GetConnectionString(), paramFromHeader, cdEmp, nuIndenizacao, status, motivoDevolucao);
			return Ok(content);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
