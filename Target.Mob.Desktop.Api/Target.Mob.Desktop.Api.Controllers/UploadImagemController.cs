using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Api.BLL;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/uploadimagem")]
public class UploadImagemController : ApiController
{
	private IConfiguration _configuration;

	public UploadImagemController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[Authorize]
	[HttpPost]
	[Route("")]
	public async Task<IHttpActionResult> ReceiveImgAsync()
	{
		HttpRequestMessage request = base.Request;
		HttpRequestHeaders headers = base.Request.Headers;
		string stringConnTargetERP = _configuration.GetConnectionString();
		DbConnection connTargetErp = new DbConnection(stringConnTargetERP);
		_ = string.Empty;
		_ = string.Empty;
		if (headers.Contains("codigovendedor") && headers.Contains("codigocliente") && headers.Contains("clientebdmovimento") && headers.Contains("cnpjcpf"))
		{
			if (!request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}
			try
			{
				string text = headers.GetValues("clientebdmovimento").First();
				string value = headers.GetValues("codigocliente").First();
				string paramFromHeader = ControllerUtil.getParamFromHeader(headers, "codigovendedor");
				int codigoCliente = Convert.ToInt32(value);
				bool clienteBdMovimento = Convert.ToBoolean(text.ToLower());
				string cnpjCpf = headers.GetValues("cnpjcpf").First();
				ImagemClienteTO model = new ImagemClienteTO
				{
					CodigoVendedor = paramFromHeader,
					CodigoCliente = codigoCliente,
					ClienteBdMovimento = clienteBdMovimento,
					CnpjCpf = cnpjCpf,
					Arquivos = new List<ArquivoImagemClienteTO>()
				};
				MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
				await base.Request.Content.ReadAsMultipartAsync(provider);
				new List<ArquivoImagemClienteTO>();
				foreach (HttpContent content in provider.Contents)
				{
					string filename = content.Headers.ContentDisposition.FileName.Trim('"');
					ArquivoImagemClienteTO item = new ArquivoImagemClienteTO(filename, await content.ReadAsByteArrayAsync());
					model.Arquivos.Add(item);
				}
				connTargetErp.Open();
				if (model.ClienteBdMovimento)
				{
					model.CodigoCliente = -1;
					try
					{
						model.CodigoCliente = ClienteBLL.getCodigoClienteByCnpj(cnpjCpf, 0, "", null, stringConnTargetERP).Value;
					}
					catch (Exception)
					{
					}
					if (model.CodigoCliente == -1)
					{
						model.Erro = "Cliente não existe - CliNovo=true; CdClien=" + codigoCliente + "; CnpjCpf=" + cnpjCpf;
						ImagemClienteBLL.Insert(stringConnTargetERP, model);
						return Ok("ok");
					}
					model.ClienteBdMovimento = false;
				}
				else if (!ClienteBLL.Exists(stringConnTargetERP, codigoCliente))
				{
					model.Erro = "Cliente não existe - CliNovo=false; CdClien=" + codigoCliente + "; CnpjCpf=" + cnpjCpf;
					ImagemClienteBLL.Insert(stringConnTargetERP, model);
					return Ok("ok");
				}
				string diretorioRaizDeDocumentosClientes;
				try
				{
					diretorioRaizDeDocumentosClientes = getDiretorioRaizDeDocumentosClientes(connTargetErp);
					if (diretorioRaizDeDocumentosClientes == null)
					{
						model.Erro = "Diretório Raiz - Nulo";
						ImagemClienteBLL.Insert(stringConnTargetERP, model);
						return Ok("ok");
					}
					Directory.CreateDirectory(diretorioRaizDeDocumentosClientes);
				}
				catch (Exception ex2)
				{
					model.Erro = "Diretório Raiz - Exception: " + ex2.Message;
					ImagemClienteBLL.Insert(stringConnTargetERP, model);
					return Ok("ok");
				}
				string text2;
				try
				{
					text2 = Path.Combine(diretorioRaizDeDocumentosClientes, codigoCliente.ToString());
					Directory.CreateDirectory(text2);
				}
				catch (Exception ex3)
				{
					model.Erro = "Diretório Cliente - Exception: " + ex3.Message;
					ImagemClienteBLL.Insert(stringConnTargetERP, model);
					return Ok("ok");
				}
				try
				{
					foreach (ArquivoImagemClienteTO arquivo in model.Arquivos)
					{
						File.WriteAllBytes(Path.Combine(text2, arquivo.FileName), arquivo.Conteudo);
					}
					ImagemClienteBLL.Insert(stringConnTargetERP, model);
				}
				catch (Exception ex4)
				{
					model.Erro = "Erro ao gravar arquivo. Erro: " + ex4.Message;
					ImagemClienteBLL.Insert(stringConnTargetERP, model);
				}
				return Ok("ok");
			}
			catch (Exception ex5)
			{
				return BadRequest(ex5.Message);
			}
			finally
			{
				connTargetErp?.Close();
			}
		}
		return BadRequest("Parametros inválidos.");
	}

	private string getDiretorioRaizDeDocumentosClientes(DbConnection connTargetErp)
	{
		try
		{
			new PcfgTelaMultiTO();
			connTargetErp.Open();
			return PcfgTelaMultiBLL.getDiretorioRaizDeArquivoDeCliente(connTargetErp);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		return null;
	}
}
