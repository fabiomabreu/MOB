using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using Target.Mob.Common.Seguranca;

namespace Target.Mob.Common.Helper;

public static class ConfigHelper
{
	private static string STRING_CONNECT;

	public static string getAppConfig(string NOME_CONFIG)
	{
		AppSettingsSection appSettingsSection = (AppSettingsSection)getConfig().GetSection("appSettings");
		if (appSettingsSection.Settings.AllKeys.ToList().Exists((string x) => x.Equals(NOME_CONFIG)))
		{
			return appSettingsSection.Settings[NOME_CONFIG].Value;
		}
		return "";
	}

	public static void setAppConfig(string NOME_CONFIG, string VALOR)
	{
		Configuration config = getConfig();
		AppSettingsSection appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
		if (appSettingsSection.Settings.AllKeys.ToList().Exists((string x) => x.Equals(NOME_CONFIG)))
		{
			appSettingsSection.Settings[NOME_CONFIG].Value = VALOR;
			config.Save();
		}
	}

	public static Configuration getConfig()
	{
		string text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Target.Mob.Desktop.Servico.ERP.Principal.exe";
		if (File.Exists(text))
		{
			return ConfigurationManager.OpenExeConfiguration(text);
		}
		return null;
	}

	public static string getStringConnection()
	{
		if (!string.IsNullOrEmpty(STRING_CONNECT))
		{
			return STRING_CONNECT;
		}
		Configuration config = getConfig();
		if (config == null)
		{
			return null;
		}
		string text = ((ConnectionStringsSection)config.GetSection("connectionStrings")).ConnectionStrings["ConexaoTargetErp"].ConnectionString;
		string text2 = EncrypterHelper.Descriptografia_RijndaelManaged(text);
		if (!string.IsNullOrEmpty(text2))
		{
			text = text2;
		}
		SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(text);
		text2 = EncrypterHelper.Descriptografia_RijndaelManaged(sqlConnectionStringBuilder.Password);
		if (!string.IsNullOrEmpty(text2))
		{
			sqlConnectionStringBuilder.Password = text2;
		}
		STRING_CONNECT = sqlConnectionStringBuilder.ToString().Replace("\"", "");
		return STRING_CONNECT;
	}
}
