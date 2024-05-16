using System.Net.Http;
using System.Web;
using Microsoft.Owin;

namespace Target.Mob.Desktop.Api.Util;

public class HttpRequestMessageHelper
{
	private static string httpContext = "MS_HttpContext";

	private static string owinContext = "MS_OwinContext";

	public static string GetUsuario(HttpRequestMessage request)
	{
		if (request.Headers.Authorization != null)
		{
			if (request.Properties.ContainsKey(httpContext))
			{
				HttpContextWrapper httpContextWrapper = (HttpContextWrapper)request.Properties[httpContext];
				if (httpContextWrapper != null)
				{
					return httpContextWrapper.User?.Identity?.Name;
				}
			}
			if (request.Properties.ContainsKey(HttpRequestMessageHelper.owinContext))
			{
				OwinContext owinContext = (OwinContext)request.Properties[HttpRequestMessageHelper.owinContext];
				if (owinContext != null)
				{
					return owinContext.Authentication.User?.Identity?.Name;
				}
			}
		}
		return "";
	}

	public static string GetRole(HttpRequestMessage request)
	{
		if (request.Headers.Authorization != null && request.Properties.ContainsKey(HttpRequestMessageHelper.owinContext))
		{
			OwinContext owinContext = (OwinContext)request.Properties[HttpRequestMessageHelper.owinContext];
			if (owinContext != null)
			{
				return owinContext.Authentication.User?.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
			}
		}
		return "";
	}

	public static string GetClientIp(HttpRequestMessage request)
	{
		if (request.Properties.ContainsKey(httpContext))
		{
			HttpContextWrapper httpContextWrapper = (HttpContextWrapper)request.Properties[httpContext];
			if (httpContextWrapper != null)
			{
				return httpContextWrapper.Request.UserHostAddress;
			}
		}
		if (request.Properties.ContainsKey(HttpRequestMessageHelper.owinContext))
		{
			OwinContext owinContext = (OwinContext)request.Properties[HttpRequestMessageHelper.owinContext];
			if (owinContext != null)
			{
				return owinContext.Request.RemoteIpAddress;
			}
		}
		return null;
	}
}
