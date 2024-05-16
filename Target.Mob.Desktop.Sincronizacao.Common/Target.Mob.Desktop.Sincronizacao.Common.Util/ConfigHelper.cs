using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using Target.Mob.Common.Seguranca;

namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public static class ConfigHelper
{
	private static string STRING_CONNECT_MOB;

	private static string STRING_CONNECT_ERP;

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

	public static string getStringConnectionERP()
	{
		if (!string.IsNullOrEmpty(STRING_CONNECT_ERP))
		{
			return STRING_CONNECT_ERP;
		}
		STRING_CONNECT_ERP = ObterStringConnection("ConexaoTargetErp");
		return STRING_CONNECT_ERP;
	}

	public static string getStringConnectionMOB()
	{
		if (!string.IsNullOrEmpty(STRING_CONNECT_MOB))
		{
			return STRING_CONNECT_MOB;
		}
		STRING_CONNECT_MOB = ObterStringConnection("ConexaoTargetMob");
		return STRING_CONNECT_MOB;
	}

	private static string ObterStringConnection(string CONFIG)
	{
		Configuration config = getConfig();
		if (config == null)
		{
			return null;
		}
		string text = ((ConnectionStringsSection)config.GetSection("connectionStrings")).ConnectionStrings[CONFIG].ConnectionString;
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
		return sqlConnectionStringBuilder.ToString().Replace("\"", "");
	}
}
