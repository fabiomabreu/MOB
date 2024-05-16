using System;
using System.Diagnostics;
using System.Reflection;
using System.Web.Http;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Api.Controllers;

[RoutePrefix("api/teste")]
public class TesteController : ApiController
{
	private IConfiguration _configuration;

	public TesteController(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	[AllowAnonymous]
	[Route("")]
	public IHttpActionResult Get()
	{
		return Ok("API OK!");
	}

	[AllowAnonymous]
	[Route("distribuidora")]
	public IHttpActionResult GetEmpresa()
	{
		string text = "";
		DbConnection dbConnection = new DbConnection(_configuration.GetConnectionString());
		try
		{
			dbConnection.Open();
			EmpresaTO[] array = EmpresaBLL.Select(dbConnection, null, null, null, null, true);
			foreach (EmpresaTO empresaTO in array)
			{
				if (!"".Equals(text))
				{
					text += "; ";
				}
				text += empresaTO.NomeFant;
			}
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
		}
		return Ok(text);
	}
}
