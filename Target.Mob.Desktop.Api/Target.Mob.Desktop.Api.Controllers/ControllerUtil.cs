using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Target.Mob.Desktop.Api.Controllers;

public static class ControllerUtil
{
	public static string getParamFromHeader(HttpRequestHeaders headers, string param)
	{
		if (headers == null)
		{
			throw new Exception("Header Nulo: " + param);
		}
		if (!headers.Contains(param))
		{
			throw new Exception("Header Param Nulo: " + param);
		}
		return HttpUtility.UrlDecode(headers.GetValues(param).First(), Encoding.UTF8);
	}
}
