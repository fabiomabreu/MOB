using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;
using Target.Mob.Desktop.Api.Interface;
using Target.Mob.Desktop.Api.Log;
using Target.Mob.Desktop.Api.Resolver;
using Target.Mob.Desktop.Api.Security;

namespace Target.Mob.Desktop.Api.Startup;

public class Startup
{
	public static void Configuration(IAppBuilder appBuilder, IConfiguration configuration)
	{
		HttpConfiguration httpConfiguration = new HttpConfiguration();
		httpConfiguration.MapHttpAttributeRoutes();
		httpConfiguration.MessageHandlers.Add(new LogRequestAndResponseHandler(configuration));
		httpConfiguration.DependencyResolver = new NinjectResolver(configuration.GetType());
		appBuilder.UseJwtBearerAuthentication(ConfigureAuth.GetOptionsAuth(configuration));
		appBuilder.UseCors(CorsOptions.AllowAll);
		appBuilder.UseWebApi(httpConfiguration);
	}
}
