using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using Target.Venda.Helpers.Seguranca;
using Target.Venda.Model.Enum;

namespace Target.Venda.Helpers.Geral;

public static class ConfigHelper
{
	private static string PATH_CONFIG_DLL = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Target.Venda.Configuracao.dll";

	private static string PATH_VERSAO_DLL = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Target.Venda.Configuracao.Versao.dll";

	private static string STRING_CONNECT;

	private static bool CONFIG_CONEXAO_ATUALIZADA = false;

	private static bool CONFIG_VERSAO_ATUALIZADA = false;

	public static string getAppConfig(string chaveConfig)
	{
		Configuration config = getConfig(verificaConfiguracao(chaveConfig));
		AppSettingsSection appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
		List<string> list = appSettingsSection.Settings.AllKeys.ToList();
		if (!list.Exists((string x) => x.Equals(chaveConfig)))
		{
			throw new Exception($"Não foi possivel carregar a configuração: '{chaveConfig}'");
		}
		return appSettingsSection.Settings[chaveConfig].Value;
	}

	public static void setAppConfig(string chaveConfig, string valor)
	{
		Configuration config = getConfig(verificaConfiguracao(chaveConfig));
		AppSettingsSection appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
		if (appSettingsSection.Settings.AllKeys.ToList().Exists((string x) => x.Equals(chaveConfig)))
		{
			appSettingsSection.Settings[chaveConfig].Value = valor;
			config.Save();
		}
	}

	public static bool getBoolAppConfig(string chaveConfig)
	{
		string appConfig = getAppConfig(chaveConfig);
		return appConfig == "true";
	}

	public static Configuration getConfig(TipoConfiguracao versao)
	{
		string text;
		if (versao == TipoConfiguracao.CONEXAO)
		{
			text = PATH_CONFIG_DLL;
			if (!CONFIG_CONEXAO_ATUALIZADA)
			{
				atualizaConfiguracoes(versao);
				CONFIG_CONEXAO_ATUALIZADA = true;
			}
		}
		else
		{
			text = PATH_VERSAO_DLL;
			if (!CONFIG_VERSAO_ATUALIZADA)
			{
				atualizaConfiguracoes(versao);
				CONFIG_VERSAO_ATUALIZADA = true;
			}
		}
		if (File.Exists(text))
		{
			return ConfigurationManager.OpenExeConfiguration(text);
		}
		Configuration configuration = null;
		return (HttpContext.Current == null || HttpContext.Current.Request.PhysicalPath.Equals(string.Empty)) ? ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) : WebConfigurationManager.OpenWebConfiguration("~");
	}

	public static Configuration getConfig()
	{
		if (File.Exists(PATH_CONFIG_DLL))
		{
			if (!CONFIG_CONEXAO_ATUALIZADA)
			{
				atualizaConfiguracoes(TipoConfiguracao.CONEXAO);
				CONFIG_CONEXAO_ATUALIZADA = true;
			}
			return ConfigurationManager.OpenExeConfiguration(PATH_CONFIG_DLL);
		}
		Configuration configuration = null;
		return (HttpContext.Current == null || HttpContext.Current.Request.PhysicalPath.Equals(string.Empty)) ? ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) : WebConfigurationManager.OpenWebConfiguration("~");
	}

	public static TipoConfiguracao verificaConfiguracao(string config)
	{
		TipoConfiguracao result = (TipoConfiguracao)0;
		switch (config)
		{
		case "BancoDB":
		case "SenhaDB":
		case "EmailFrom":
		case "UsuarioDB":
		case "SmtpEnableSSL":
		case "TimePrincipal":
		case "PathSendMailERP":
		case "portaImpostoApi":
		case "ServidorDB":
		case "QuantidadeThreadSimultaneo":
		case "ReservarEstoqueComCorte":
		case "ImpostosApi":
		case "PathExtracao":
		case "EmailFromDisplay":
		case "SmtpHost":
		case "SmtpClientPort":
		case "SmtpNetworkCredencial":
		case "PortaComunicacaoAPI":
			result = TipoConfiguracao.CONEXAO;
			break;
		case "VersaoMinimaERP":
			result = TipoConfiguracao.VERSAO;
			break;
		}
		return result;
	}

	public static string getStringConnection(string nomeAppConfig = null)
	{
		if (!string.IsNullOrEmpty(STRING_CONNECT))
		{
			return STRING_CONNECT;
		}
		Configuration config = getConfig(TipoConfiguracao.CONEXAO);
		if (config == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(nomeAppConfig))
		{
			nomeAppConfig = "ERP";
		}
		STRING_CONNECT = getStringConnection(config, nomeAppConfig);
		return STRING_CONNECT;
	}

	private static string getStringConnection(Configuration config, string chaveConfig)
	{
		ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
		string text = "";
		for (int i = 0; i < connectionStringsSection.ConnectionStrings.Count; i++)
		{
			if (connectionStringsSection.ConnectionStrings[i].Name == chaveConfig)
			{
				text = connectionStringsSection.ConnectionStrings[chaveConfig].ConnectionString;
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		string appConfig = getAppConfig("ServidorDB");
		string appConfig2 = getAppConfig("BancoDB");
		string appConfig3 = getAppConfig("UsuarioDB");
		string appConfig4 = getAppConfig("SenhaDB");
		criptografaSenha(appConfig4);
		appConfig4 = getAppConfig("SenhaDB");
		text = string.Format(text, appConfig, appConfig2, appConfig3, appConfig4);
		return CriptografiaHelper.Descriptografar_ConnectionString(text);
	}

	public static void criptografaSenha(string senhaAtual)
	{
		string value = CriptografiaHelper.Descriptografar_RijndaelManaged(senhaAtual);
		if (string.IsNullOrEmpty(value))
		{
			string valor = CriptografiaHelper.Criptografar_RijndaelManaged(senhaAtual);
			setAppConfig("SenhaDB", valor);
		}
	}

	public static EmailConfiguration getEmailConfiguration()
	{
		EmailConfiguration emailConfiguration = new EmailConfiguration();
		emailConfiguration.EMAIL_FROM = getAppConfig("EmailFrom");
		emailConfiguration.EMAIL_FROM_DISPLAY = getAppConfig("EmailFromDisplay");
		emailConfiguration.SMTP_CLIENT_PORT = ConvertHelper.ToInt(getAppConfig("SmtpClientPort"));
		emailConfiguration.SMTP_HOST = getAppConfig("SmtpHost");
		emailConfiguration.SMTP_ENABLE_SSL = ConvertHelper.ToBool(getAppConfig("SmtpEnableSSL"));
		string appConfig = getAppConfig("SmtpNetworkCredencial");
		if (!string.IsNullOrEmpty(appConfig))
		{
			List<string> source = appConfig.Split(';').ToList();
			emailConfiguration.SMTP_NETWORK_CREDENCIAL = new Dictionary<string, string>();
			emailConfiguration.SMTP_NETWORK_CREDENCIAL.Add("userName", source.First());
			emailConfiguration.SMTP_NETWORK_CREDENCIAL.Add("password", source.Last());
		}
		return emailConfiguration;
	}

	public static string getNomeBancoDados()
	{
		SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(getStringConnection());
		return sqlConnectionStringBuilder.InitialCatalog;
	}

	public static string getServidorBancoDados()
	{
		SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(getStringConnection());
		return sqlConnectionStringBuilder.DataSource;
	}

	public static string getUserBancoDados()
	{
		SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(getStringConnection());
		return sqlConnectionStringBuilder.UserID;
	}

	public static string getPswBancoDados()
	{
		SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(getStringConnection());
		return sqlConnectionStringBuilder.Password;
	}

	public static string getVersaoSistema()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
		return versionInfo.FileVersion;
	}

	public static void setStringConnection(string connectionString)
	{
		Configuration config = getConfig(TipoConfiguracao.CONEXAO);
		connectionString = CriptografiaHelper.Criptografar_ConnectionString(connectionString);
		SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
		setAppConfig("ServidorDB", sqlConnectionStringBuilder.DataSource);
		setAppConfig("BancoDB", sqlConnectionStringBuilder.InitialCatalog);
		setAppConfig("UsuarioDB", sqlConnectionStringBuilder.UserID);
		setAppConfig("SenhaDB", sqlConnectionStringBuilder.Password);
		sqlConnectionStringBuilder.DataSource = "{0}";
		sqlConnectionStringBuilder.InitialCatalog = "{1}";
		sqlConnectionStringBuilder.UserID = "{2}";
		sqlConnectionStringBuilder.Password = "{3}";
		ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
		for (int i = 0; i < connectionStringsSection.ConnectionStrings.Count; i++)
		{
			if (connectionStringsSection.ConnectionStrings[i].Name == "ERP")
			{
				connectionStringsSection.ConnectionStrings["ERP"].ConnectionString = connectionString;
			}
		}
	}

	private static void atualizaConfiguracoes(TipoConfiguracao tipoConfiguracao)
	{
		Configuration configuration = ConfigurationManager.OpenExeConfiguration((tipoConfiguracao == TipoConfiguracao.CONEXAO) ? PATH_CONFIG_DLL : PATH_VERSAO_DLL);
		if (tipoConfiguracao == TipoConfiguracao.CONEXAO)
		{
			AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
			List<string> list = appSettingsSection.Settings.AllKeys.ToList();
			if (!list.Exists((string x) => x.Equals("ReservarEstoqueComCorte")))
			{
				appSettingsSection.Settings.Add("ReservarEstoqueComCorte", "false");
			}
			if (!list.Exists((string x) => x.Equals("ImpostosApi")))
			{
				appSettingsSection.Settings.Add("ImpostosApi", "false");
				appSettingsSection.Settings.Add("portaImpostoApi", "5500");
			}
			configuration.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
}
