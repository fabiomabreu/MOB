using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers.Log;
using Target.Venda.Helpers.Seguranca;

namespace Target.Venda.Installer.View.Common;

public static class CommonInstaller
{
	public delegate void RetornoMensagens(string message);

	private static Dictionary<string, string> PATH_SERVICOS;

	public static Dictionary<string, string> CONFIGURACOES_SERVICO;

	public static Dictionary<string, SqlConnectionStringBuilder> CONEXOES;

	public static Dictionary<string, string> USUARIOS_SERVICO;

	private static bool _INSTALACAO_SILENCIOSA;

	private static int TENTATIVAS_INSTALACAO = 0;

	private static string _ServiceConfigRootDir = "C:\\TargetVenda";

	private static string _ServiceConfigApplicationDir = "Application";

	private static string _ServiceConfigApplicationFile = "Target.Venda.Configuracao.dll";

	private static string _FullPathInstallUtilFile = "C:\\Windows\\Microsoft.Net\\Framework\\v4.0.30319\\installutil";

	private static string _ApplicationName = "TARGET_VENDA";

	public static string _FullPathApplicationDir;

	private static string _FullPathApplicationFile;

	private static string _FullPathInstallApplicationFile;

	private static string _FullPathInstallApplicationDir;

	private static string _FullPathBackupDir;

	private static BasicHttpBindingCollectionElement _BasicHttp;

	private static ChannelEndpointElementCollection _EndPoint;

	public static event RetornoMensagens MENSAGENS;

	public static void Load(bool INSTALACAO_SILENCIOSA)
	{
		_INSTALACAO_SILENCIOSA = INSTALACAO_SILENCIOSA;
		LoadPath();
		SetarConfiguracaoPadrao();
		preencherListaServicos();
		AppConfigLoad();
		CarregarUsuariosServicos();
	}

	private static void LoadPath()
	{
		string path = "Installer";
		string path2 = "Backup";
		FileInfo fileInfo = new FileInfo(typeof(CommonInstaller).Assembly.Location);
		_ServiceConfigRootDir = fileInfo.Directory.Parent.Parent.FullName;
		if (Debugger.IsAttached)
		{
			_ServiceConfigRootDir = "C:\\TargetVenda";
		}
		_FullPathBackupDir = Path.Combine(_ServiceConfigRootDir, path2);
		_FullPathApplicationDir = Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir);
		_FullPathApplicationFile = Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, _ServiceConfigApplicationFile);
		_FullPathInstallApplicationDir = Path.Combine(_ServiceConfigRootDir, path, _ServiceConfigApplicationDir);
		_FullPathInstallApplicationFile = Path.Combine(_ServiceConfigRootDir, path, _ServiceConfigApplicationDir, _ServiceConfigApplicationFile);
	}

	private static void preencherListaServicos()
	{
		PATH_SERVICOS = new Dictionary<string, string>();
		string value = Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Venda.Servico.API.exe");
		PATH_SERVICOS.Add("TargetVendaAPI", value);
	}

	private static void SetarConfiguracaoPadrao()
	{
		CONFIGURACOES_SERVICO = new Dictionary<string, string>();
		CONFIGURACOES_SERVICO.Add("ServidorDB", ".");
		CONFIGURACOES_SERVICO.Add("BancoDB", "MOINHO");
		CONFIGURACOES_SERVICO.Add("UsuarioDB", "");
		CONFIGURACOES_SERVICO.Add("SenhaDB", "");
		CONFIGURACOES_SERVICO.Add("TimePrincipal", "");
		CONFIGURACOES_SERVICO.Add("QuantidadeThreadSimultaneo", "50");
		CONFIGURACOES_SERVICO.Add("PathExtracao", "C:\\Target\\Temp\\Extracao");
		CONFIGURACOES_SERVICO.Add("PathSendMailERP", "C:\\TARGET\\EXE\\NET\\SendMailERP\\SendMailERP.exe");
		CONFIGURACOES_SERVICO.Add("EmailFrom", "");
		CONFIGURACOES_SERVICO.Add("EmailFromDisplay", "");
		CONFIGURACOES_SERVICO.Add("SmtpHost", "");
		CONFIGURACOES_SERVICO.Add("SmtpClientPort", "");
		CONFIGURACOES_SERVICO.Add("SmtpEnableSSL", "");
		CONFIGURACOES_SERVICO.Add("SmtpNetworkCredencial", "");
		CONFIGURACOES_SERVICO.Add("PortaComunicacaoAPI", "30212");
	}

	public static List<string> ValidarUsuarioCadastrado()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, string> item in USUARIOS_SERVICO)
		{
			if (!string.IsNullOrEmpty(item.Value) && item.Value.ToLower().Replace(" ", "") != "localsystem" && CONFIGURACOES_SERVICO["UsuarioServico"].ToLower() != item.Value.ToLower())
			{
				if (_INSTALACAO_SILENCIOSA)
				{
					string menssage = string.Format("O serviço: {0}, está instalado com o usuário: {1} e está diferente da configuração \"{2}\".", item.Key, item.Value, CONFIGURACOES_SERVICO["UsuarioServico"]);
					throw new MyException(menssage);
				}
				list.Add(item.Value);
			}
		}
		return list;
	}

	private static void CarregarUsuariosServicos()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("select name, startname\r\n                       from Win32_Service\r\n                       where ");
		foreach (KeyValuePair<string, string> pATH_SERVICO in PATH_SERVICOS)
		{
			stringBuilder.AppendFormat(" name = '{0}' or ", pATH_SERVICO.Key);
		}
		stringBuilder.Remove(stringBuilder.Length - 3, 3);
		USUARIOS_SERVICO = new Dictionary<string, string>();
		SelectQuery query = new SelectQuery(stringBuilder.ToString());
		using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
		foreach (ManagementObject item in managementObjectSearcher.Get())
		{
			USUARIOS_SERVICO.Add(item["Name"].ToString(), item["startname"].ToString());
		}
	}

	private static void AppConfigLoad()
	{
		try
		{
			Configuration configuration = null;
			CONEXOES = new Dictionary<string, SqlConnectionStringBuilder>();
			if (File.Exists(_FullPathApplicationFile))
			{
				configuration = ConfigurationManager.OpenExeConfiguration(_FullPathApplicationFile);
			}
			else
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(_FullPathBackupDir);
				if (directoryInfo.Exists)
				{
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int num = directories.Length - 1; num > 0; num--)
					{
						string text = Path.Combine(directories[num].FullName, _ServiceConfigApplicationFile);
						if (File.Exists(text))
						{
							configuration = ConfigurationManager.OpenExeConfiguration(text);
							break;
						}
					}
				}
			}
			if ((configuration == null || configuration.AppSettings.Settings.AllKeys.Length == 0) && File.Exists(Path.Combine(_FullPathInstallApplicationDir, _ServiceConfigApplicationFile)))
			{
				configuration = ConfigurationManager.OpenExeConfiguration(Path.Combine(_FullPathInstallApplicationDir, _ServiceConfigApplicationFile));
			}
			if (configuration == null)
			{
				return;
			}
			AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
			ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
			_BasicHttp = ServiceModelSectionGroup.GetSectionGroup(configuration).Bindings.BasicHttpBinding;
			_EndPoint = ServiceModelSectionGroup.GetSectionGroup(configuration).Client.Endpoints;
			for (int i = 1; i < connectionStringsSection.ConnectionStrings.Count; i++)
			{
				string value = appSettingsSection.Settings["ServidorDB"].Value;
				string value2 = appSettingsSection.Settings["BancoDB"].Value;
				string value3 = appSettingsSection.Settings["UsuarioDB"].Value;
				string value4 = appSettingsSection.Settings["SenhaDB"].Value;
				string connectionString = string.Format(connectionStringsSection.ConnectionStrings[i].ConnectionString, value, value2, value3, value4);
				SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
				string text2 = CriptografiaHelper.Descriptografar_ConnectionString(sqlConnectionStringBuilder.Password);
				if (!string.IsNullOrEmpty(text2))
				{
					sqlConnectionStringBuilder.Password = text2;
				}
				sqlConnectionStringBuilder.ConnectTimeout = 300;
				CONEXOES.Add(connectionStringsSection.ConnectionStrings[i].Name, sqlConnectionStringBuilder);
			}
			string[] allKeys = appSettingsSection.Settings.AllKeys;
			foreach (string key in allKeys)
			{
				if (CONFIGURACOES_SERVICO.ContainsKey(key))
				{
					CONFIGURACOES_SERVICO[key] = appSettingsSection.Settings[key].Value;
				}
			}
			Configuration configuration2 = ConfigurationManager.OpenExeConfiguration(_FullPathInstallApplicationFile);
			AppSettingsSection appSettingsSection2 = (AppSettingsSection)configuration2.GetSection("appSettings");
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static void ExibirMensagem(string mensagem, string titulo, MessageBoxIcon tipoMensagem, Exception ex = null)
	{
		if (ex == null)
		{
			MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, tipoMensagem);
		}
		else
		{
			MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, tipoMensagem);
		}
	}

	public static void GravarLog(Exception ex, StringBuilder MomentoInstalacao)
	{
		LogHelper.ErroLog(ex);
		try
		{
			string path = Path.Combine(_FullPathApplicationDir, "LOG_INSTALACAO.txt");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			using StreamWriter streamWriter = new StreamWriter(path);
			streamWriter.Write(MomentoInstalacao);
			streamWriter.Close();
		}
		catch (Exception ex2)
		{
			LogHelper.ErroLog(ex2);
		}
		try
		{
		}
		catch (Exception ex3)
		{
			LogHelper.ErroLog(ex3);
		}
	}

	private static void RetornaMensagem(string MENSAGEM)
	{
		CommonInstaller.MENSAGENS(MENSAGEM);
	}

	private static void UninstallService(object PARAMETRO)
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)PARAMETRO;
		string nomeServico = keyValuePair.Key;
		string value = keyValuePair.Value;
		ServiceController serviceController = (from x in ServiceController.GetServices()
			where x.ServiceName == nomeServico
			select x).FirstOrDefault();
		if (serviceController != null)
		{
			StopServiceUninstall(serviceController, Path.GetFileName(value).Replace(".exe", ""));
			string arguments = $"/u {value}";
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(_FullPathInstallUtilFile, arguments);
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}
	}

	private static void StopServiceUninstall(ServiceController Service, string NomeExecutavel)
	{
		if (Service.Status == ServiceControllerStatus.Running)
		{
			Service.Stop();
		}
		Service.Refresh();
		if (Service.Status != ServiceControllerStatus.Stopped)
		{
			Thread.Sleep(3000);
		}
		Service.Refresh();
		if (Service.Status != ServiceControllerStatus.Stopped)
		{
			string text = NomeExecutavel;
			if (text.Length > 50)
			{
				text = text.Substring(0, 50);
			}
			Process[] processesByName = Process.GetProcessesByName(text);
			foreach (Process process in processesByName)
			{
				process.Kill();
			}
		}
	}

	private static void InstallService(string nomeServico, string pathAplicacao, string usuario, string senha)
	{
		if (File.Exists(pathAplicacao))
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrWhiteSpace(usuario))
			{
				stringBuilder.AppendFormat("/user=\"{0}\" /password=\"{1}\" ", usuario, senha);
			}
			stringBuilder.AppendFormat("  {0}", pathAplicacao);
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(_FullPathInstallUtilFile, stringBuilder.ToString());
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.UseShellExecute = false;
			process.EnableRaisingEvents = true;
			process.Start();
			process.WaitForExit();
			if (process.ExitCode != 0)
			{
				throw new Exception("Erro instalação serviço " + nomeServico);
			}
		}
	}

	private static void DesinstalarServico(string nomeServico, string pathAplicacao)
	{
		string processo = Path.GetFileName(pathAplicacao).Replace(".exe", "");
		if (!File.Exists(pathAplicacao))
		{
			return;
		}
		ServiceController serviceController = (from x in ServiceController.GetServices()
			where x.ServiceName == nomeServico
			select x).FirstOrDefault();
		if (serviceController != null)
		{
			PararServico(serviceController, processo);
			string arguments = $"/u {pathAplicacao}";
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(_FullPathInstallUtilFile, arguments);
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
			if (process.ExitCode != 0)
			{
				throw new Exception("Erro na desinstalação do serviço: " + nomeServico);
			}
			RetornaMensagem("Serviço: " + nomeServico + " desinstalado com sucesso...");
		}
		else
		{
			RetornaMensagem("Serviço: " + nomeServico + " não encontrado...");
		}
	}

	private static void PararServico(ServiceController servico, string processo)
	{
		RetornaMensagem("Serviço " + servico.ServiceName + ": parando...");
		servico.Refresh();
		if (servico.Status == ServiceControllerStatus.Running)
		{
			servico.Stop();
		}
		servico.Refresh();
		if (servico.Status != ServiceControllerStatus.Stopped)
		{
			Thread.Sleep(3000);
		}
		servico.Refresh();
		if (servico.Status != ServiceControllerStatus.Stopped)
		{
			string text = processo;
			if (text.Length > 50)
			{
				text = text.Substring(0, 50);
			}
			RetornaMensagem("Serviço " + servico.ServiceName + ": forçar parada...");
			matarServico(servico.ServiceName, text);
		}
		RetornaMensagem("Serviço " + servico.ServiceName + ": parado com sucesso.");
	}

	private static void matarServico(string ServiceName, string ProcessName)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName(ProcessName);
			foreach (Process process in processesByName)
			{
				process.Kill();
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Erro no Kill " + ex.Message + " ...");
		}
	}

	public static void Install()
	{
		try
		{
			RetornaMensagem("Desinstalando serviços...");
			DesinstalarServicosPrograma();
			RetornaMensagem("Serviços desinstalados com sucesso...");
			RetornaMensagem(string.Empty);
			RetornaMensagem("Executando Backup da aplicação atual...");
			RealizaBackupApp();
			RetornaMensagem("Backup da aplicação atual executado com sucesso...");
			RetornaMensagem(string.Empty);
			RetornaMensagem("Copiando a Aplicação para a pasta de Instalação...");
			RetornaMensagem(string.Empty);
			Util.CopyDirectory(_FullPathInstallApplicationDir, _FullPathApplicationDir);
			RetornaMensagem("Atualizando arquivo de configurações...");
			RetornaMensagem(string.Empty);
			AppConfigUpdate();
			RetornaMensagem("Instalando os Serviços do Windows...");
			RetornaMensagem(string.Empty);
			InstalarServicos();
			RetornaMensagem("Instalação concluída com sucesso!!!");
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private static void AtualizarStringConnectionModuloTargetVenda()
	{
		try
		{
			string path = Path.Combine(_FullPathApplicationDir, "TargetVenda");
			if (Directory.Exists(path))
			{
				Directory.Delete(path, recursive: true);
			}
		}
		catch
		{
		}
		Assembly assembly = Assembly.LoadFrom(Path.Combine(_FullPathApplicationDir, "VendasERP", "Target.Venda.IBusiness.dll"));
		Type type = assembly.GetType("Target.Venda.IBusiness.Factory.BusinessFactory");
		MethodInfo method = type.GetMethod("GetSistemaBLL");
		object obj2 = method.Invoke(null, null);
		SqlConnectionStringBuilder sqlConnectionStringBuilder = CONEXOES["DATABASE"];
		MethodInfo method2 = obj2.GetType().GetMethod("ConfigurarStringConexao");
		method2.Invoke(obj2, new object[1] { sqlConnectionStringBuilder.ToString() });
	}

	private static void DesinstalarServicosPrograma()
	{
		try
		{
			Parallel.ForEach(PATH_SERVICOS, delegate(KeyValuePair<string, string> x)
			{
				DesinstalarServico(x.Key, x.Value);
			});
		}
		catch (Exception innerException)
		{
			string text = "Não é possível desinstalar os serviços.";
			RetornaMensagem(text);
			throw new Exception(text, innerException);
		}
	}

	private static void RealizaBackupApp()
	{
		if (!Directory.Exists(_FullPathApplicationDir))
		{
			return;
		}
		if (!Directory.Exists(_FullPathBackupDir))
		{
			Directory.CreateDirectory(_FullPathBackupDir);
		}
		string text = Path.Combine(_FullPathBackupDir, DateTime.Now.ToString("yyyyMMddhhmmss"));
		Directory.CreateDirectory(text);
		string[] files = Directory.GetFiles(_FullPathApplicationDir, "*.*");
		foreach (string text2 in files)
		{
			string destFileName = Path.Combine(text, Path.GetFileName(text2));
			File.Move(text2, destFileName);
		}
		string[] files2 = Directory.GetFiles(_FullPathApplicationDir, "*.*", SearchOption.AllDirectories);
		foreach (string text3 in files2)
		{
			try
			{
				string destFileName2 = Path.Combine(text, Path.GetFileName(text3));
				File.Move(text3, destFileName2);
			}
			catch
			{
				File.Delete(text3);
			}
		}
		string text4 = Path.Combine(_FullPathApplicationDir, "AppLogs");
		string path = Path.Combine(text4, "LogsApp.xml");
		if (Directory.Exists(text4) && File.Exists(path))
		{
			File.Delete(path);
		}
	}

	private static void InstalarServicos()
	{
		try
		{
			string usuario = "";
			string senha = "";
			TENTATIVAS_INSTALACAO++;
			if (CONFIGURACOES_SERVICO.ContainsKey("UsuarioServico") && !string.IsNullOrEmpty(CONFIGURACOES_SERVICO["UsuarioServico"]))
			{
				usuario = CONFIGURACOES_SERVICO["UsuarioServico"];
			}
			if (CONFIGURACOES_SERVICO.ContainsKey("UsuarioServico") && !string.IsNullOrEmpty(CONFIGURACOES_SERVICO["UsuarioServico"]))
			{
				senha = CONFIGURACOES_SERVICO["PassServico"];
			}
			foreach (KeyValuePair<string, string> pATH_SERVICO in PATH_SERVICOS)
			{
				if (pATH_SERVICO.Key != "EDIEnvioPreco")
				{
					InstallService(pATH_SERVICO.Key, pATH_SERVICO.Value, usuario, senha);
					RetornaMensagem($"Serviço {pATH_SERVICO.Key}, instalado com Sucesso...");
					RetornaMensagem(string.Empty);
				}
			}
		}
		catch (Exception innerException)
		{
			string text = "Não é possível instalar os serviços.";
			RetornaMensagem(text);
			RetornaMensagem(string.Empty);
			if (TENTATIVAS_INSTALACAO < 3)
			{
				RetornaMensagem("Realizando nova tentativa de instalação...");
				RetornaMensagem(string.Empty);
				Thread.Sleep(2000);
				Install();
				return;
			}
			throw new Exception(text, innerException);
		}
	}

	private static void AppConfigUpdate()
	{
		Configuration configuration = ConfigurationManager.OpenExeConfiguration(_FullPathApplicationFile);
		AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
		foreach (KeyValuePair<string, string> item in CONFIGURACOES_SERVICO)
		{
			if (appSettingsSection.Settings[item.Key] == null)
			{
				appSettingsSection.Settings.Add(item.Key, item.Value);
			}
			else
			{
				appSettingsSection.Settings[item.Key].Value = item.Value;
			}
		}
		if (_BasicHttp != null)
		{
			ServiceModelSectionGroup serviceModelSectionGroup = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
			foreach (BasicHttpBindingElement binding in _BasicHttp.Bindings)
			{
				serviceModelSectionGroup.Bindings.BasicHttpBinding.Bindings[binding.Name] = binding;
			}
			foreach (ChannelEndpointElement item2 in _EndPoint)
			{
				for (int i = 0; i < serviceModelSectionGroup.Client.Endpoints.Count; i++)
				{
					if (serviceModelSectionGroup.Client.Endpoints[i].Name == item2.Name)
					{
						serviceModelSectionGroup.Client.Endpoints[i] = item2;
						if (item2.Name == "TargetERPSoap")
						{
							serviceModelSectionGroup.Client.Endpoints[i].Address = new Uri("http://reterp.paineltarget.net.br:8088/TargetERPWebService/TargetERP.asmx");
						}
					}
				}
			}
		}
		configuration.Save();
	}

	public static bool ValidarAlterarStringConexao(string NAME_CONNECTION, string DATASOURCE, string DATABASE, string USER, string PASSWORD, bool AUTENTICACAO_WINDOWS)
	{
		try
		{
			CONFIGURACOES_SERVICO["ServidorDB"] = DATASOURCE;
			CONFIGURACOES_SERVICO["BancoDB"] = DATABASE;
			CONFIGURACOES_SERVICO["UsuarioDB"] = USER;
			CONFIGURACOES_SERVICO["SenhaDB"] = PASSWORD;
			if (!CONEXOES.ContainsKey(NAME_CONNECTION))
			{
				CONEXOES.Add(NAME_CONNECTION, new SqlConnectionStringBuilder());
			}
			string text = Util.BuildStringConnection(DATASOURCE, DATABASE, USER, PASSWORD, CONEXOES[NAME_CONNECTION].MaxPoolSize, AUTENTICACAO_WINDOWS, _ApplicationName);
			CONEXOES[NAME_CONNECTION] = new SqlConnectionStringBuilder(text);
			if (!Util.StringConnectionTest(text))
			{
				return false;
			}
		}
		catch
		{
			return false;
		}
		return true;
	}

	public static void IniciarServicos()
	{
		try
		{
			foreach (KeyValuePair<string, string> servico in PATH_SERVICOS)
			{
				if (servico.Value.ToUpper().Contains("TARGET.VENDA.SERVICO.API"))
				{
					ServiceController serviceController = (from x in ServiceController.GetServices()
						where x.ServiceName == servico.Key
						select x).FirstOrDefault();
					serviceController.Start();
					break;
				}
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public static void DesinstalarAplicacao()
	{
		try
		{
			LoadPath();
			preencherListaServicos();
			foreach (KeyValuePair<string, string> pATH_SERVICO in PATH_SERVICOS)
			{
				UninstallService(pATH_SERVICO);
			}
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
		}
	}
}
