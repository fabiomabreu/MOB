using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FrameworkTarget.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.TargetERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

public class ImportVersao
{
	public void enviarVersaoWS()
	{
		Task task = new Task(IniciarAtualizacaoAutomatica);
		task.Start();
		Task task2 = new Task(ExportaDadosProdutoTarget);
		task2.Start();
		Task.WaitAll(task, task2);
	}

	private void IniciarAtualizacaoAutomatica()
	{
		try
		{
			TargetERPSoapClient remoteAddress = getRemoteAddress();
			Version version = GetType().Assembly.GetName().Version;
			VersaoTO versaoTO = new VersaoTO();
			versaoTO.MAJOR = version.Major;
			versaoTO.MINOR = version.Minor;
			versaoTO.BUILD = version.Build;
			versaoTO.REVISION = version.Revision;
			RetornoWsTOOfProdutoVersaoTO retornoWsTOOfProdutoVersaoTO = remoteAddress.VerificaVersaoLiberadaRetaguarda(getRequestValidation(), versaoTO, GetVersaoUltimoDownload());
			if (retornoWsTOOfProdutoVersaoTO.RETORNO_WS != null)
			{
				string diretorioDownload = GetDiretorioDownload();
				if (Directory.Exists(diretorioDownload))
				{
					Directory.Delete(diretorioDownload, recursive: true);
				}
				Directory.CreateDirectory(diretorioDownload);
				File.WriteAllBytes(Path.Combine(diretorioDownload, retornoWsTOOfProdutoVersaoTO.RETORNO_WS.NomeArquivoFinal), retornoWsTOOfProdutoVersaoTO.RETORNO_WS.Arquivo);
				remoteAddress.AtualizarStatusProdutoPainel(getRequestValidation(), StatusInstalacao.DownloadConcluido, null);
			}
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		try
		{
			string pathUltimoArquivo = GetPathUltimoArquivo();
			if (!string.IsNullOrEmpty(pathUltimoArquivo) && getRemoteAddress().VerificaAtualizacaoAutomatica(getRequestValidation(), GetVersaoUltimoDownload()).RETORNO_WS)
			{
				using (Process process = new Process())
				{
					FileInfo fileInfo = new FileInfo(GetType().Assembly.Location);
					string arguments = $"/qn /i {pathUltimoArquivo} Par1=\"IA\" TARGETDIR=\"{fileInfo.Directory.Parent.FullName}\"";
					ProcessStartInfo startInfo = new ProcessStartInfo("msiexec.exe", arguments);
					process.StartInfo = startInfo;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.Start();
					return;
				}
			}
		}
		catch (Exception ex2)
		{
			MethodBase currentMethod2 = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod2.Name, ex2.Message, EventLogEntryType.Error);
		}
	}

	public void SetAtualizacaoErroInstalacao()
	{
		try
		{
			getRemoteAddress().AtualizarStatusProdutoPainel(getRequestValidation(), StatusInstalacao.AtualizacaoErro, null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private VersaoTO GetVersaoUltimoDownload()
	{
		try
		{
			string pathUltimoArquivo = GetPathUltimoArquivo();
			if (string.IsNullOrEmpty(pathUltimoArquivo))
			{
				return null;
			}
			string[] array = Path.GetFileName(pathUltimoArquivo).Split('.');
			VersaoTO versaoTO = new VersaoTO();
			versaoTO.MAJOR = Convert.ToInt32(array[0]);
			versaoTO.MINOR = Convert.ToInt32(array[1]);
			versaoTO.BUILD = Convert.ToInt32(array[2]);
			versaoTO.REVISION = Convert.ToInt32(array[3].Split('_')[0]);
			return versaoTO;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private string GetPathUltimoArquivo()
	{
		try
		{
			string diretorioDownload = GetDiretorioDownload();
			if (!Directory.Exists(diretorioDownload))
			{
				return null;
			}
			StringBuilder expressao = new StringBuilder();
			expressao.Append("^");
			expressao.Append("([0-9])*");
			expressao.Append("\\.{1}");
			expressao.Append("([0-9])*");
			expressao.Append("\\.{1}");
			expressao.Append("([0-9])*");
			expressao.Append("\\.{1}");
			expressao.Append("([0-9])*");
			expressao.Append("\\.{1}");
			expressao.Append("([_]){1}");
			expressao.Append("([A-Za-z0-9_])*");
			expressao.Append("\\.{1}");
			expressao.Append("([A-Za-z0-9_])*");
			expressao.Append("$");
			List<string> list = Directory.GetFiles(diretorioDownload).ToList();
			list.RemoveAll((string x) => Regex.IsMatch(Path.GetFileName(x), expressao.ToString()));
			if (list.Count == 0)
			{
				return null;
			}
			list = list.OrderByDescending((string x) => new FileInfo(x).CreationTime).ToList();
			return list.First();
		}
		catch (Exception)
		{
			return null;
		}
	}

	private string GetDiretorioDownload()
	{
		return new FileInfo(Assembly.GetEntryAssembly().Location).Directory.Parent.Parent.FullName + "\\Download";
	}

	private static TargetERPSoapClient getRemoteAddress()
	{
		BasicHttpBinding basicBindingConfig = WebServiceHelper.getBasicBindingConfig("TargetERPSoap");
		EndpointAddress endPointConfig = WebServiceHelper.getEndPointConfig("TargetERPSoap");
		return new TargetERPSoapClient(basicBindingConfig, endPointConfig);
	}

	public virtual ValidationRequestTO getRequestValidation()
	{
		ValidationRequestTO validationRequestTO = new ValidationRequestTO();
		using (DbConnection dbConnection = new DbConnection(ConfigHelper.getStringConnectionERP()))
		{
			dbConnection.Open();
			EmpresaTO empresaTO = EmpresaBLL.Select(dbConnection, null, null, null, null, true).FirstOrDefault();
			validationRequestTO.CNPJ_DISTRIBUIDORA = empresaTO.Cgc;
			dbConnection.Close();
		}
		validationRequestTO.CHAVE_RETAGUARDA = MaquinaID.ObterMaquinaIDV2();
		validationRequestTO.ID_PRODUTO_PAINEL = 1;
		validationRequestTO.HOSTNAME = Environment.MachineName;
		validationRequestTO.TOKEN = "%$#targetws#$%";
		return validationRequestTO;
	}

	private void ExportaDadosProdutoTarget()
	{
		try
		{
			TargetERPSoapClient remoteAddress = getRemoteAddress();
			EnviarProdutoPainelTO enviarProdutoPainelTO = new EnviarProdutoPainelTO();
			Version version = GetType().Assembly.GetName().Version;
			FileInfo fileInfo = new FileInfo(GetType().Assembly.Location);
			enviarProdutoPainelTO.MAJOR = version.Major;
			enviarProdutoPainelTO.MINOR = version.Minor;
			enviarProdutoPainelTO.BUILD = version.Build;
			enviarProdutoPainelTO.REVISION = version.Revision;
			enviarProdutoPainelTO.DIRETORIO_INSTALADO = fileInfo.Directory.Parent.FullName;
			enviarProdutoPainelTO.CONTROLA_LICENCA = false;
			RetornoWsTOOfBoolean retornoWsTOOfBoolean = remoteAddress.EnviarDadosProdutoPainel(getRequestValidation(), enviarProdutoPainelTO);
			if (!retornoWsTOOfBoolean.RETORNO_WS && retornoWsTOOfBoolean.EXCECAO != null)
			{
				MethodBase currentMethod = MethodBase.GetCurrentMethod();
				LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, retornoWsTOOfBoolean.EXCECAO.Erro, EventLogEntryType.Warning);
				ConfigHelper.setAppConfig("Autenticado", "false");
				return;
			}
			string appConfig = ConfigHelper.getAppConfig("Autenticado");
			if (string.IsNullOrEmpty(appConfig) || !appConfig.ToUpper().Trim().Equals("TRUE"))
			{
				ConfigHelper.setAppConfig("Autenticado", "true");
				restartServico("TargetMobApi");
			}
		}
		catch (Exception ex)
		{
			MethodBase currentMethod2 = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod2.Name, ex.Message, EventLogEntryType.Error);
		}
	}

	private void restartServico(string nomeServico)
	{
		ServiceController serviceController = (from x in ServiceController.GetServices()
			where x.ServiceName == nomeServico
			select x).FirstOrDefault();
		pararServico(serviceController, nomeServico);
		serviceController.Start();
	}

	private static void pararServico(ServiceController servico, string processo)
	{
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
			matarServico(servico.ServiceName, text);
		}
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
}
