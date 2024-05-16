using Owin;
using Target.Mob.Desktop.Api.Configuration;

namespace Target.Mob.Desktop.Api.Startup;

public class StartupFromView
{
	public void Configuration(IAppBuilder appBuilder)
	{
		Startup.Configuration(appBuilder, new ConfigurationFromView());
	}
}
