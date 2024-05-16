using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Api.Interface;

namespace Target.Mob.Desktop.Api.Configuration;

internal class Configuration : IConfiguration
{
	private string _stringConnTargetErp;

	public Configuration(string fileConfig)
	{
		ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + fileConfig).GetSection("connectionStrings");
		_stringConnTargetErp = connectionStringsSection.ConnectionStrings["ConexaoTargetErp"].ConnectionString;
		_stringConnTargetErp = EncrypterHelper.Descriptografia_ConnectionString(_stringConnTargetErp);
	}

	public string GetConnectionString()
	{
		return _stringConnTargetErp;
	}

	public string GetSecretKey()
	{
		return Convert.ToBase64String(Encoding.ASCII.GetBytes(_stringConnTargetErp));
	}

	public double GetExpiresMinutes()
	{
		return 30.0;
	}

	public string GetIssuer()
	{
		return "https://localhost/";
	}

	public string GetAudience()
	{
		return "https://localhost/";
	}
}
