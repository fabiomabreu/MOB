using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP;

namespace Target.Mob.Desktop.Servico.ERP.Base;

public class Principal : ServicoBase
{
	public int CodigoServico;

	protected Sincroniza Sincroniza;

	private IContainer components;

	public int? Intervalo { get; set; }

	public Principal()
	{
		CodigoServico = 1;
		InitializeComponent();
	}

	protected override void OnStart(string[] args)
	{
		try
		{
			TimerCallback callback = oTimer_TimerCallback;
			base.Timer = new Timer(callback);
			Intervalo = 30000;
			base.Timer.Change(1000, Intervalo.Value);
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Principal", ex.Message, EventLogEntryType.Error);
		}
	}

	protected override void OnStop()
	{
		base.Timer.Change(-1, -1);
	}

	private void oTimer_TimerCallback(object state)
	{
		try
		{
			base.Timer.Change(-1, -1);
			base.Timer.Change(Intervalo.Value, Intervalo.Value);
			CarregaServicos();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Principal", ex.Message, EventLogEntryType.Error);
		}
	}

	protected virtual void ConfiguraSincroniza()
	{
		try
		{
			if (Sincroniza == null)
			{
				Configuration configuration = ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Target.Mob.Desktop.Servico.ERP.Principal.exe");
				ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
				AppSettingsSection obj = (AppSettingsSection)configuration.GetSection("appSettings");
				string connectionString = connectionStringsSection.ConnectionStrings["ConexaoTargetErp"].ConnectionString;
				string connectionString2 = connectionStringsSection.ConnectionStrings["ConexaoTargetMob"].ConnectionString;
				string value = obj.Settings["NomeServidorOrigemReplicacao"].Value;
				_ = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
				string value2 = obj.Settings["TargetMobPath"].Value;
				string value3 = obj.Settings["SiglaCliente"].Value;
				string value4 = obj.Settings["EmailSmtpServidor"].Value;
				int emailSmtpPort = Convert.ToInt32(obj.Settings["EmailSmtpPort"].Value);
				string value5 = obj.Settings["EmailUser"].Value;
				string value6 = obj.Settings["EmailPassword"].Value;
				bool emailUseSSL = Convert.ToBoolean(obj.Settings["EmailUseSSL"].Value);
				string value7 = obj.Settings["EmailFrom"].Value;
				string value8 = obj.Settings["UriSocket"].Value;
				string value9 = obj.Settings["ApiBaseAddress"].Value;
				string value10 = obj.Settings["TargetMobPathDownload"].Value;
				string value11 = obj.Settings["TargetRelatorioPathDestino"].Value;
				string value12 = obj.Settings["TargetRelatorioPathOrigem"].Value;
				string value13 = obj.Settings["TargetRelatorioTamanho"].Value;
				int qtdeThreadSimultaneaGeral = Convert.ToInt32(obj.Settings["qtdeThreadSimultaneaGeral"].Value);
				int qtdeThreadSimultaneaIO = Convert.ToInt32(obj.Settings["QtdeThreadSimultaneaIO"].Value);
				bool geracaoLogaEtapa = Convert.ToBoolean(obj.Settings["GeracaoLogaEtapa"].Value);
				string value14 = obj.Settings["LiberaAutoNomeProcesso"].Value;
				string value15 = obj.Settings["LiberaAutoCaminhoExe"].Value;
				string value16 = obj.Settings["LiberaAutoConnOdbc"].Value;
				int liberaAutoTimeout = Convert.ToInt32(obj.Settings["LiberaAutoTimeout"].Value);
				int liberaAutoNumeroTentativas = Convert.ToInt32(obj.Settings["LiberaAutoNumeroTentativas"].Value);
				string value17 = obj.Settings["LiberaAutoUsuarioLiberacao"].Value;
				int liberaAutoQtdeLiberacaoSimultanea = Convert.ToInt32(obj.Settings["LiberaAutoQtdeLiberacaoSimultanea"].Value);
				ServiceModelSectionGroup sectionGroup = ServiceModelSectionGroup.GetSectionGroup(configuration);
				BasicHttpBinding bindingBasicHttp = BindingsSectionTOBasicHttpBinding(sectionGroup.Bindings);
				EndpointAddress remoteAddress = new EndpointAddress(sectionGroup.Client.Endpoints[0].Address);
				Sincroniza = new Sincroniza(connectionString, connectionString2, value, value2, qtdeThreadSimultaneaGeral, qtdeThreadSimultaneaIO, value14, value15, value16, liberaAutoTimeout, liberaAutoNumeroTentativas, value17, liberaAutoQtdeLiberacaoSimultanea, geracaoLogaEtapa, value11, value12, value13, value10, bindingBasicHttp, remoteAddress, value3, value4, emailSmtpPort, value5, value6, emailUseSSL, value7, value8, value9);
			}
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Principal", ex.Message, EventLogEntryType.Error);
		}
	}

	private static BasicHttpBinding BindingsSectionTOBasicHttpBinding(BindingsSection bindingsSection)
	{
		return new BasicHttpBinding
		{
			Name = bindingsSection.BasicHttpBinding.Bindings[0].Name,
			CloseTimeout = bindingsSection.BasicHttpBinding.Bindings[0].CloseTimeout,
			AllowCookies = bindingsSection.BasicHttpBinding.Bindings[0].AllowCookies,
			BypassProxyOnLocal = bindingsSection.BasicHttpBinding.Bindings[0].BypassProxyOnLocal,
			HostNameComparisonMode = bindingsSection.BasicHttpBinding.Bindings[0].HostNameComparisonMode,
			MaxBufferPoolSize = bindingsSection.BasicHttpBinding.Bindings[0].MaxBufferPoolSize,
			MaxBufferSize = bindingsSection.BasicHttpBinding.Bindings[0].MaxBufferSize,
			MaxReceivedMessageSize = bindingsSection.BasicHttpBinding.Bindings[0].MaxReceivedMessageSize,
			MessageEncoding = bindingsSection.BasicHttpBinding.Bindings[0].MessageEncoding,
			ProxyAddress = bindingsSection.BasicHttpBinding.Bindings[0].ProxyAddress,
			ReceiveTimeout = bindingsSection.BasicHttpBinding.Bindings[0].ReceiveTimeout,
			SendTimeout = bindingsSection.BasicHttpBinding.Bindings[0].SendTimeout,
			TextEncoding = bindingsSection.BasicHttpBinding.Bindings[0].TextEncoding,
			TransferMode = bindingsSection.BasicHttpBinding.Bindings[0].TransferMode,
			UseDefaultWebProxy = bindingsSection.BasicHttpBinding.Bindings[0].UseDefaultWebProxy,
			ReaderQuotas = 
			{
				MaxStringContentLength = bindingsSection.BasicHttpBinding.Bindings[0].ReaderQuotas.MaxStringContentLength,
				MaxArrayLength = bindingsSection.BasicHttpBinding.Bindings[0].ReaderQuotas.MaxArrayLength,
				MaxBytesPerRead = bindingsSection.BasicHttpBinding.Bindings[0].ReaderQuotas.MaxBytesPerRead,
				MaxDepth = bindingsSection.BasicHttpBinding.Bindings[0].ReaderQuotas.MaxDepth,
				MaxNameTableCharCount = bindingsSection.BasicHttpBinding.Bindings[0].ReaderQuotas.MaxNameTableCharCount
			}
		};
	}

	private void CarregaServicos()
	{
		try
		{
			if (!Carregar())
			{
				return;
			}
			foreach (ServicoTO servico in base.Servicos)
			{
				new ServiceExecute(servico).IniciarCarregamentoServicos();
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private bool Carregar()
	{
		try
		{
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Target.Mob.Desktop.Servico.ERP.Principal.exe");
			ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
			_ = (AppSettingsSection)configuration.GetSection("appSettings");
			SqlConnection sqlConnection = new SqlConnection(EncrypterHelper.Descriptografia_ConnectionString(connectionStringsSection.ConnectionStrings["ConexaoTargetMob"].ConnectionString));
			sqlConnection.Open();
			base.Servicos = (from x in ServicoBLL.Select(sqlConnection, new ServicoTO())
				where x.CodigoServico != 1
				select x).ToList();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return base.Servicos.Count > 0;
	}

	public override void OnTimerEvent(object source, EventArgs e)
	{
		try
		{
			CarregaServicos();
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Principal", ex.Message, EventLogEntryType.Error);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		components = new Container();
		base.ServiceName = "Principal";
	}
}
