using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Database.Script.Executor;
using Target.Mob.Desktop.Sincronizacao.WsERP.Import;

namespace Target.Mob.Desktop.Installer.ERP.View.Common;

public static class CommonInstaller
{
	public delegate void RetornoMensagens(string message);

	private static Dictionary<string, string> PATH_SCRIPTS;

	private static Dictionary<string, string> PATH_SERVICOS;

	public static Dictionary<string, string> CONFIGURACOES_SERVICO;

	public static Dictionary<string, SqlConnectionStringBuilder> CONEXOES;

	private static string _ServiceConfigRootDir = "C:\\TargetMob\\ServicoERP\\";

	private static string _ServiceConfigApplicationDir = "Application";

	private static string _ServiceConfigApplicationFile = "Target.Mob.Desktop.Servico.ERP.Principal.exe";

	private static string _FullPathInstallUtilFile = "C:\\Windows\\Microsoft.Net\\Framework\\v4.0.30319\\installutil";

	private static string _ApplicationName = "TARGET_MOB_RETAGUARDA";

	public static string _FullPathApplicationDir;

	private static string _FullPathApplicationFile;

	private static string _FullPathInstallApplicationFile;

	private static string _FullPathInstallApplicationDir;

	private static string _FullPathBackupDir;

	private static string _ServiceConfigTemplateSQLiteNamePrefix = "TargetMobBaseCarga_Ver";

	private static string _ServiceConfigTemplateSQLiteDir = "TemplateSQLite";

	private static BasicHttpBindingCollectionElement _BasicHttp;

	private static ChannelEndpointElementCollection _EndPoint;

	public static event RetornoMensagens MENSAGENS;

	public static void Load()
	{
		LoadPath();
		SetarConfiguracaoPadrao();
		preencherListaServicos();
		AppConfigLoad();
	}

	private static void LoadPath()
	{
		string path = "Installer";
		string path2 = "Backup";
		_ServiceConfigRootDir = new FileInfo(typeof(CommonInstaller).Assembly.Location).Directory.Parent.Parent.FullName;
		_FullPathBackupDir = Path.Combine(_ServiceConfigRootDir, path2);
		_FullPathApplicationDir = Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir);
		_FullPathApplicationFile = Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, _ServiceConfigApplicationFile);
		_FullPathInstallApplicationDir = Path.Combine(_ServiceConfigRootDir, path, _ServiceConfigApplicationDir);
		_FullPathInstallApplicationFile = Path.Combine(_ServiceConfigRootDir, path, _ServiceConfigApplicationDir, _ServiceConfigApplicationFile);
		_ServiceConfigTemplateSQLiteDir = Path.Combine(_ServiceConfigRootDir, path, _ServiceConfigTemplateSQLiteDir);
		PATH_SCRIPTS = new Dictionary<string, string>();
		string value = Path.Combine(_ServiceConfigRootDir, path, "ScriptTargetERP");
		PATH_SCRIPTS.Add("ConexaoTargetErp", value);
		string value2 = Path.Combine(_ServiceConfigRootDir, path, "ScriptTargetMob");
		PATH_SCRIPTS.Add("ConexaoTargetMob", value2);
	}

	private static void preencherListaServicos()
	{
		PATH_SERVICOS = new Dictionary<string, string>();
		PATH_SERVICOS.Add("Principal", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Principal.exe"));
		PATH_SERVICOS.Add("GerarCarga", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.GerarCarga.exe"));
		PATH_SERVICOS.Add("Pedido", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Pedido.exe"));
		PATH_SERVICOS.Add("Troca", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Troca.exe"));
		PATH_SERVICOS.Add("Cliente", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Cliente.exe"));
		PATH_SERVICOS.Add("Carga", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Carga.exe"));
		PATH_SERVICOS.Add("Configuracao", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Configuracao.exe"));
		PATH_SERVICOS.Add("LogErro", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.LogErro.exe"));
		PATH_SERVICOS.Add("Servico", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Servico.exe"));
		PATH_SERVICOS.Add("Visita", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Visita.exe"));
		PATH_SERVICOS.Add("PedidoAtendimento", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.PedidoAtendimento.exe"));
		PATH_SERVICOS.Add("MotivoNaoVenda", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.MotivoNaoVenda.exe"));
		PATH_SERVICOS.Add("LiberacaoPedido", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.LiberacaoPedido.exe"));
		PATH_SERVICOS.Add("ServicosBasicos", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.ServicosBasicos.exe"));
		PATH_SERVICOS.Add("LimpaDados", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.LimpaDados.exe"));
		PATH_SERVICOS.Add("RelatorioPrepara", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.RelatorioPrepara.exe"));
		PATH_SERVICOS.Add("Relatorio_Export", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Relatorio_Export.exe"));
		PATH_SERVICOS.Add("RelatorioConfig_Import", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.RelatorioConfig_Imp.exe"));
		PATH_SERVICOS.Add("RelatorioGera", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.RelatorioGera.exe"));
		PATH_SERVICOS.Add("Versao", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Versao.exe"));
		PATH_SERVICOS.Add("Monitoramento", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Monitoramento.exe"));
		PATH_SERVICOS.Add("Notificacao", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Notificacao.exe"));
		PATH_SERVICOS.Add("Localizacao", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Localizacao.exe"));
		PATH_SERVICOS.Add("Pagamento", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Pagamento.exe"));
		PATH_SERVICOS.Add("TrabalhoVendedor", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.TrabalhoVendedor.exe"));
		PATH_SERVICOS.Add("EmailTransfer", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.EmailTransfer.exe"));
		PATH_SERVICOS.Add("GerarDados", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.GerarDados.exe"));
		PATH_SERVICOS.Add("Socket", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Socket.exe"));
		PATH_SERVICOS.Add("TargetMobApi", Path.Combine(_ServiceConfigRootDir, _ServiceConfigApplicationDir, "Target.Mob.Desktop.Servico.ERP.Api.exe"));
	}

	private static void SetarConfiguracaoPadrao()
	{
		CONFIGURACOES_SERVICO = new Dictionary<string, string>();
		CONFIGURACOES_SERVICO.Add("TargetMobPath", "C:\\TargetMob\\");
		CONFIGURACOES_SERVICO.Add("TargetMobPathDownload", "C:\\TargetMob\\Download");
		CONFIGURACOES_SERVICO.Add("TargetRelatorioPathDestino", "C:\\TargetMob\\Relatorios_Processando");
		CONFIGURACOES_SERVICO.Add("TargetRelatorioPathOrigem", "C:\\TargetMob\\Relatorios");
		CONFIGURACOES_SERVICO.Add("TargetRelatorioTamanho", "500");
		CONFIGURACOES_SERVICO.Add("QtdeThreadSimultaneaGeral", "25");
		CONFIGURACOES_SERVICO.Add("QtdeThreadSimultaneaIO", "25");
		CONFIGURACOES_SERVICO.Add("NomeServidorOrigemReplicacao", "");
		CONFIGURACOES_SERVICO.Add("GeracaoLogaEtapa", "false");
		CONFIGURACOES_SERVICO.Add("LiberaAutoNomeProcesso", "libera_auto_target_mob");
		CONFIGURACOES_SERVICO.Add("LiberaAutoCaminhoExe", "C:\\Target\\libera_auto_target_mob.exe");
		CONFIGURACOES_SERVICO.Add("LiberaAutoConnOdbc", "TGTMOB_MOINHO");
		CONFIGURACOES_SERVICO.Add("LiberaAutoTimeout", "30");
		CONFIGURACOES_SERVICO.Add("LiberaAutoNumeroTentativas", "2");
		CONFIGURACOES_SERVICO.Add("LiberaAutoUsuarioLiberacao", "SUPER");
		CONFIGURACOES_SERVICO.Add("LiberaAutoQtdeLiberacaoSimultanea", "5");
		CONFIGURACOES_SERVICO.Add("ValidaVersaoERP", "9.04;9;28|10.01;2;1");
		CONFIGURACOES_SERVICO.Add("VersaoERPMinimaAbsoluta", "9.04");
		CONFIGURACOES_SERVICO.Add("UsuarioServico", "");
		CONFIGURACOES_SERVICO.Add("PassServico", "");
		CONFIGURACOES_SERVICO.Add("Autenticado", "true");
		CONFIGURACOES_SERVICO.Add("MultiThread", "false");
		CONFIGURACOES_SERVICO.Add("HabilitarNovaPedTmk", "true");
		CONFIGURACOES_SERVICO.Add("SiglaCliente", "");
		CONFIGURACOES_SERVICO.Add("EmailSmtpServidor", "");
		CONFIGURACOES_SERVICO.Add("EmailSmtpPort", "0");
		CONFIGURACOES_SERVICO.Add("EmailUser", "");
		CONFIGURACOES_SERVICO.Add("EmailPassword", "");
		CONFIGURACOES_SERVICO.Add("EmailUseSSL", "false");
		CONFIGURACOES_SERVICO.Add("EmailFrom", "");
		CONFIGURACOES_SERVICO.Add("RotaVendasPedidos", "/api/Pedido/Liberar");
		CONFIGURACOES_SERVICO.Add("HabilitarVendasApi", "false");
		CONFIGURACOES_SERVICO.Add("UriSocket", "http://socketmob.paineltarget.net.br:33667");
		CONFIGURACOES_SERVICO.Add("ApiBaseAddress", "http://+:37878/");
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
				SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionStringsSection.ConnectionStrings[i].ConnectionString);
				string text2 = EncrypterHelper.Descriptografia_RijndaelManaged(sqlConnectionStringBuilder.Password);
				if (!string.IsNullOrEmpty(text2))
				{
					sqlConnectionStringBuilder.Password = text2;
				}
				sqlConnectionStringBuilder.ConnectTimeout = 300;
				CONEXOES.Add(connectionStringsSection.ConnectionStrings[i].Name, sqlConnectionStringBuilder);
			}
			string[] allKeys = appSettingsSection.Settings.AllKeys;
			foreach (string text3 in allKeys)
			{
				if (CONFIGURACOES_SERVICO.ContainsKey(text3))
				{
					CONFIGURACOES_SERVICO[text3] = appSettingsSection.Settings[text3].Value;
					if ("RotaVendasPedidos".Equals(text3))
					{
						CONFIGURACOES_SERVICO[text3] = "/api/Pedido/Liberar";
					}
					if ("HabilitarVendasApi".Equals(text3))
					{
						CONFIGURACOES_SERVICO[text3] = "true";
					}
				}
			}
			_ = (AppSettingsSection)ConfigurationManager.OpenExeConfiguration(_FullPathInstallApplicationFile).GetSection("appSettings");
		}
		catch (Exception ex)
		{
			RegistrarLog(ex, "AppConfigLoad");
			throw;
		}
	}

	private static void RegistrarLog(Exception ex, string Metodo)
	{
		LogEvento.WriteEntry("CommonInstaller." + Metodo, ex.Message, EventLogEntryType.Error);
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
		RegistrarLog(ex, "GravarLog");
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
			streamWriter.Flush();
		}
		catch (Exception ex2)
		{
			RegistrarLog(ex2, "GravarLog");
		}
		try
		{
			new ImportVersao().SetAtualizacaoErroInstalacao();
		}
		catch (Exception ex3)
		{
			RegistrarLog(ex3, "GravarLog");
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
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}
	}

	private static void InstallService(string nomeServico, string pathAplicacao, string usuario, string senha)
	{
		if (File.Exists(pathAplicacao))
		{
			string arguments = $"/user=\"{usuario}\" /password=\"{senha}\"  {pathAplicacao}";
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(_FullPathInstallUtilFile, arguments);
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
			if (process.ExitCode != 0)
			{
				throw new Exception("Erro instalação serviço " + nomeServico);
			}
		}
	}

	private static void desinstalarServico(string nomeServico, string pathAplicacao)
	{
		string processo = Path.GetFileName(pathAplicacao).Replace(".exe", "");
		if (!File.Exists(pathAplicacao))
		{
			return;
		}
		RetornaMensagem("Desinstalando serviço " + nomeServico + "...");
		ServiceController serviceController = (from x in ServiceController.GetServices()
			where x.ServiceName == nomeServico
			select x).FirstOrDefault();
		if (serviceController != null)
		{
			pararServico(serviceController, processo);
			string arguments = $"/u {pathAplicacao}";
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(_FullPathInstallUtilFile, arguments);
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
			if (process.ExitCode != 0)
			{
				throw new Exception("Erro na desinstalação do serviço " + nomeServico);
			}
			RetornaMensagem("Serviço " + nomeServico + " desinstalado com sucesso...");
		}
		else
		{
			RetornaMensagem("Serviço " + nomeServico + " não encontrado...");
		}
	}

	private static void pararServico(ServiceController servico, string processo)
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
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Erro no Kill " + ex.Message + " ...");
		}
	}

	public static void Install()
	{
		Install(clienteCloud: false);
	}

	public static void Install(bool clienteCloud)
	{
		try
		{
			if (!clienteCloud)
			{
				RetornaMensagem("Desinstalando serviços...");
				DesinstalarServicosPrograma();
				RetornaMensagem("Serviços desinstalados com sucesso...");
				RetornaMensagem(string.Empty);
			}
			RetornaMensagem("Executando Backup da aplicação atual...");
			RealizaBackupApp();
			RetornaMensagem("Backup da aplicação atual executado com sucesso...");
			RetornaMensagem(string.Empty);
			foreach (KeyValuePair<string, SqlConnectionStringBuilder> cONEXO in CONEXOES)
			{
				string text = EncrypterHelper.Descriptografia_RijndaelManaged(cONEXO.Value.Password);
				if (!string.IsNullOrEmpty(text))
				{
					cONEXO.Value.Password = text;
				}
				string text2 = cONEXO.Value.ToString().Replace("\"", "");
				if (cONEXO.Key == "ConexaoTargetMob")
				{
					try
					{
						string stringConnection = text2.Replace(cONEXO.Value.InitialCatalog, "master").ToString().Replace("\"", "");
						if (!Util.DatabaseExists(stringConnection, cONEXO.Value.InitialCatalog))
						{
							Util.CreateDatabase(stringConnection, cONEXO.Value.InitialCatalog);
							RetornaMensagem($"Banco de Dados {cONEXO.Value.InitialCatalog.ToUpper()} criado com sucesso...");
							RetornaMensagem(string.Empty);
						}
					}
					catch (Exception ex)
					{
						RetornaMensagem($"Erro ao criar o banco de dados {cONEXO.Value.InitialCatalog.ToUpper()}");
						throw ex;
					}
				}
				RetornaMensagem($"Atualizando base de dados {cONEXO.Value.InitialCatalog.ToUpper()}...");
				RetornaMensagem(string.Empty);
				string text3 = "";
				if (PATH_SCRIPTS.ContainsKey(cONEXO.Key))
				{
					text3 = PATH_SCRIPTS[cONEXO.Key];
					ScriptExecutor scriptExecutor = new ScriptExecutor(text2, text3, versionScriptsUpdateControl: true);
					scriptExecutor.OnMessageOutput += RetornaMensagem;
					scriptExecutor.Execute();
				}
			}
			RetornaMensagem("Atualizando template do banco do pocket...");
			RetornaMensagem(string.Empty);
			foreach (string item in Directory.EnumerateFiles(_ServiceConfigTemplateSQLiteDir, _ServiceConfigTemplateSQLiteNamePrefix + "*.db").ToList())
			{
				string text4 = Path.GetFileName(item).Replace("TargetMobBaseCarga_Ver", string.Empty);
				text4 = text4.Replace(".db", string.Empty);
				Util.UpdateTemplateSQLite(CONEXOES["ConexaoTargetMob"].ToString(), item, int.Parse(text4));
			}
			RetornaMensagem("Copiando a Aplicação para a pasta de Instalação...");
			RetornaMensagem(string.Empty);
			Util.CopyDirectory(_FullPathInstallApplicationDir, _FullPathApplicationDir);
			RetornaMensagem("Atualizando arquivo de configurações...");
			RetornaMensagem(string.Empty);
			AppConfigUpdate();
			if (!clienteCloud)
			{
				RetornaMensagem("Instalando os Serviços do Windows...");
				RetornaMensagem(string.Empty);
				InstalarServicos();
			}
			RetornaMensagem("Permissão na Pasta instalada");
			RetornaMensagem(string.Empty);
			ExecutarPermissao();
			RetornaMensagem("Atualizando a String de Conexão do Modulo de Target Vendas...");
			RetornaMensagem(string.Empty);
			AtualizarStringConnectionModuloTargetVenda();
			RetornaMensagem("Instalação concluída com sucesso!!!");
		}
		catch (Exception ex2)
		{
			RegistrarLog(ex2, "Install");
			throw;
		}
	}

	private static void ExecutarPermissao()
	{
		string text = Path.Combine(_FullPathApplicationDir, "Permissao.bat");
		string[] array = File.ReadAllLines(text);
		DirectoryInfo directoryInfo = new DirectoryInfo(_ServiceConfigRootDir);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Replace("C:\\TargetMob", directoryInfo.Parent.FullName);
		}
		File.Delete(text);
		using (StreamWriter streamWriter = new StreamWriter(text))
		{
			string[] array2 = array;
			foreach (string value in array2)
			{
				streamWriter.WriteLine(value);
			}
			streamWriter.Close();
		}
		Process process = new Process();
		process.StartInfo.FileName = text;
		process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		process.Start();
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
		object obj2 = Assembly.LoadFrom(Path.Combine(_FullPathApplicationDir, "VendasERP", "Target.Venda.IBusiness.dll")).GetType("Target.Venda.IBusiness.Factory.BusinessFactory").GetMethod("GetSistemaBLL")
			.Invoke(null, null);
		SqlConnectionStringBuilder sqlConnectionStringBuilder = CONEXOES["ConexaoTargetErp"];
		string text = EncrypterHelper.Descriptografia_RijndaelManaged(sqlConnectionStringBuilder.Password);
		if (!string.IsNullOrEmpty(text))
		{
			sqlConnectionStringBuilder.Password = text;
		}
		obj2.GetType().GetMethod("ConfigurarStringConexao").Invoke(obj2, new object[1] { sqlConnectionStringBuilder.ToString() });
	}

	private static void DesinstalarServicosPrograma()
	{
		foreach (KeyValuePair<string, string> pATH_SERVICO in PATH_SERVICOS)
		{
			desinstalarServico(pATH_SERVICO.Key, pATH_SERVICO.Value);
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
		files = Directory.GetFiles(_FullPathApplicationDir, "*.*", SearchOption.AllDirectories);
		foreach (string text3 in files)
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
				if (!(pATH_SERVICO.Key == "EDIEnvioPreco"))
				{
					InstallService(pATH_SERVICO.Key, pATH_SERVICO.Value, usuario, senha);
					RetornaMensagem($"Serviço {pATH_SERVICO.Key}, instalado com Sucesso...");
					RetornaMensagem(string.Empty);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private static void AppConfigUpdate()
	{
		Configuration configuration = ConfigurationManager.OpenExeConfiguration(_FullPathApplicationFile);
		ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
		foreach (KeyValuePair<string, SqlConnectionStringBuilder> cONEXO in CONEXOES)
		{
			if (!string.IsNullOrEmpty(cONEXO.Value.Password))
			{
				string text = EncrypterHelper.Criptografia_RijndaelManaged(cONEXO.Value.Password);
				if (!string.IsNullOrEmpty(text))
				{
					cONEXO.Value.Password = text;
				}
			}
			string connectionString = cONEXO.Value.ToString().ToString().Replace("\"", "");
			connectionStringsSection.ConnectionStrings[cONEXO.Key].ConnectionString = connectionString;
		}
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
				binding.MaxReceivedMessageSize = 2147483647L;
				binding.MaxBufferSize = int.MaxValue;
				serviceModelSectionGroup.Bindings.BasicHttpBinding.Bindings[binding.Name] = binding;
			}
		}
		configuration.Save();
	}

	public static bool ValidarAlterarStringConexao(string NAME_CONNECTION, string DATASOURCE, string DATABASE, string USER, string PASSWORD, bool AUTENTICACAO_WINDOWS, bool bancoERP)
	{
		try
		{
			if (!CONEXOES.ContainsKey(NAME_CONNECTION))
			{
				CONEXOES.Add(NAME_CONNECTION, new SqlConnectionStringBuilder());
			}
			string text = Util.BuildStringConnection(DATASOURCE, DATABASE, USER, PASSWORD, CONEXOES[NAME_CONNECTION].MaxPoolSize, AUTENTICACAO_WINDOWS, _ApplicationName);
			CONEXOES[NAME_CONNECTION] = new SqlConnectionStringBuilder(text);
			if (!bancoERP && !Util.DatabaseExists(Util.BuildStringConnection(DATASOURCE, "master", USER, PASSWORD, CONEXOES[NAME_CONNECTION].MaxPoolSize, AUTENTICACAO_WINDOWS, _ApplicationName), CONEXOES[NAME_CONNECTION].InitialCatalog))
			{
				return false;
			}
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
				if (servico.Value.ToUpper().Contains("PRINCIPAL"))
				{
					(from x in ServiceController.GetServices()
						where x.ServiceName == servico.Key
						select x).FirstOrDefault().Start();
					break;
				}
			}
		}
		catch (Exception ex)
		{
			RegistrarLog(ex, "IniciarServicos");
			throw;
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
			throw ex;
		}
	}
}
