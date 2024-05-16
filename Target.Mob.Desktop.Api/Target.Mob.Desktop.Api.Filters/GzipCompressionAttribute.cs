using System.Net.Http;
using System.Web.Http.Filters;

namespace Target.Mob.Desktop.Api.Filters;

public class GzipCompressionAttribute : ActionFilterAttribute
{
	public override void OnActionExecuted(HttpActionExecutedContext actionContext)
	{
		byte[] array = actionContext.Response.Content?.ReadAsByteArrayAsync().Result;
		byte[] content = ((array == null) ? new byte[0] : CompressionHelper.GzipByte(array));
		actionContext.Response.Content = new ByteArrayContent(content);
		actionContext.Response.Content.Headers.Remove("Content-Type");
		actionContext.Response.Content.Headers.Add("Content-encoding", "gzip");
		actionContext.Response.Content.Headers.Add("Content-Type", "application/json");
		base.OnActionExecuted(actionContext);
	}
}
