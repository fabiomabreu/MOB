using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Geracao.Bll;
using Target.Mob.Desktop.Geracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;
using Target.Mob.Desktop.Util.Bll;
using Target.Mob.Desktop.Util.Model;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportMonitoramento
{
	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	private string _stringConnTargetERP;

	private string _targetMobPath;

	private string _nomeServidorOrigemReplicacao;

	private string _nomeDbOrigemReplicacao;

	private static string _SiglaCliente;

	public ExportMonitoramento(string targetMobPath, string stringConnTargetMob, string stringConnTargetERP, string cnpjEmpresa, string nomeServidorOrigemReplicacao, string nomeDbOrigemReplicacao, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress, string siglaCliente)
	{
		_targetMobPath = targetMobPath;
		_StringConnTargetMob = stringConnTargetMob;
		_stringConnTargetERP = stringConnTargetERP;
		_nomeServidorOrigemReplicacao = nomeServidorOrigemReplicacao;
		_nomeDbOrigemReplicacao = nomeDbOrigemReplicacao;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
		_SiglaCliente = siglaCliente;
	}

	public void Exportar()
	{
		using DbConnection dbConnection2 = new DbConnection(_stringConnTargetERP);
		using DbConnection dbConnection = new DbConnection(_StringConnTargetMob);
		try
		{
			dbConnection.Open();
			dbConnection2.Open();
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			geraMonitGeracao20(wsErpSoapClient, validationSoapHeader);
			MonitRetagWsModel monitRetagWsModel = new MonitRetagWsModel();
			DateTime? dateTime = null;
			DateTime? dateTime2 = null;
			DateTime? CargaPendEnvioMaisAntigo = null;
			DateTime? dateTime3 = null;
			DateTime? RelatorioPendEnvioMaisAntigo = null;
			int? RelatorioPendEnvioQtde = 0;
			int? CargaPendEnvioQtde = 0;
			try
			{
				enviaGeracoesPendentes(dbConnection, validationSoapHeader, wsErpSoapClient);
			}
			catch (Exception ex)
			{
				MethodBase currentMethod = MethodBase.GetCurrentMethod();
				LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, "MonitoramentoRetaguarda.enviaGeracoesPendentes. " + ex.Message, EventLogEntryType.Error);
			}
			try
			{
				monitRetagWsModel.Data = DateTime.Now;
				monitRetagWsModel.VersaoRetaguarda = retornaVersaoRetaguarda();
				monitRetagWsModel.EspacoLivreDiscoAPP = Convert.ToInt32(retornaEspacoDiscoApp() / 1024 / 1024);
				MonitRetagCPUWsModel[] MonitRetagCPU = null;
				monitRetagWsModel.UtilizacaoCPU = Convert.ToInt32(retornaUtilizacaoCPU(dbConnection, out MonitRetagCPU));
				monitRetagWsModel.MonitRetagCPU = MonitRetagCPU;
				monitRetagWsModel.QtdeServicosInstalados = retornaQtdServicos(dbConnection);
				monitRetagWsModel.PedidosPendLibManualQtde = PedVdaEleBLL.LiberacaoPendenciaQtde(dbConnection2, TipoLiberacaoTR.Manual);
				monitRetagWsModel.PedidosPendLibAutoQtde = PedVdaEleBLL.LiberacaoPendenciaQtde(dbConnection2, TipoLiberacaoTR.Automatica);
				monitRetagWsModel.AtendimentoPendEnvioQtde = 0;
				monitRetagWsModel.AtendimentoPendEnvioQtde = retornaQtdAtendimentosPendentes(dbConnection2);
				try
				{
					monitRetagWsModel.MonitRetagEspacoLivreUnidade = retornaEspacoLivreBD(dbConnection);
				}
				catch (Exception ex2)
				{
					MethodBase currentMethod2 = MethodBase.GetCurrentMethod();
					LogEvento.WriteEntry(GetType().Name + "." + currentMethod2.Name, "MonitoramentoRetaguarda.MonitRetagEspacoLivreUnidade. " + ex2.Message, EventLogEntryType.Error);
				}
				try
				{
					monitRetagWsModel.MonitRetagInformacoesFileDB = retornaFileDB(dbConnection2, dbConnection);
				}
				catch (Exception ex3)
				{
					MethodBase currentMethod3 = MethodBase.GetCurrentMethod();
					LogEvento.WriteEntry(GetType().Name + "." + currentMethod3.Name, "MonitoramentoRetaguarda.InfoDB. " + ex3.Message, EventLogEntryType.Error);
				}
				retornaCargasPendentes(dbConnection, ref CargaPendEnvioQtde, ref CargaPendEnvioMaisAntigo);
				retornaRelatoriosPendentes(dbConnection, ref RelatorioPendEnvioQtde, ref RelatorioPendEnvioMaisAntigo);
				dateTime = PedVdaEleBLL.LiberacaoPendenciaMaisAntiga(dbConnection2, TipoLiberacaoTR.Manual);
				dateTime2 = PedVdaEleBLL.LiberacaoPendenciaMaisAntiga(dbConnection2, TipoLiberacaoTR.Automatica);
				dateTime3 = PedVdaEleBLL.AtendimentoPendenciaMaisAntiga(dbConnection2);
				monitRetagWsModel.PedidosPendLibManualMaisAntigo = ((monitRetagWsModel.PedidosPendLibManualQtde <= 0) ? null : dateTime);
				monitRetagWsModel.PedidosPendLibAutoMaisAntigo = ((monitRetagWsModel.PedidosPendLibAutoQtde <= 0) ? null : dateTime2);
				monitRetagWsModel.CargaPendEnvioQtde = CargaPendEnvioQtde;
				monitRetagWsModel.CargaPendEnvioMaisAntigo = CargaPendEnvioMaisAntigo;
				monitRetagWsModel.AtendimentoPendEnvioMaisAntigo = ((monitRetagWsModel.AtendimentoPendEnvioQtde <= 0) ? null : dateTime3);
				monitRetagWsModel.RelatorioPendEnvioQtde = RelatorioPendEnvioQtde;
				monitRetagWsModel.RelatorioPendEnvioMaisAntigo = RelatorioPendEnvioMaisAntigo;
			}
			catch (Exception ex4)
			{
				MethodBase currentMethod4 = MethodBase.GetCurrentMethod();
				LogEvento.WriteEntry(GetType().Name + "." + currentMethod4.Name, "MonitoramentoRetaguarda.monitRetagWsModel. " + ex4.Message, EventLogEntryType.Error);
			}
			List<MonitRetagWsModel> list = new List<MonitRetagWsModel>();
			try
			{
				list.Add(monitRetagWsModel);
			}
			catch (Exception ex5)
			{
				MethodBase currentMethod5 = MethodBase.GetCurrentMethod();
				LogEvento.WriteEntry(GetType().Name + "." + currentMethod5.Name, "MonitoramentoRetaguarda.adiciona_array. " + ex5.Message, EventLogEntryType.Error);
			}
			try
			{
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_MonitoramentoRetaguarda_Set(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
				if (!retornoWsModelOfBoolean.RetornoWs)
				{
					throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
				}
			}
			catch (Exception ex6)
			{
				MethodBase currentMethod6 = MethodBase.GetCurrentMethod();
				LogEvento.WriteEntry(GetType().Name + "." + currentMethod6.Name, "MonitoramentoRetaguarda.WsERP_MonitoramentoRetaguarda_Set. " + ex6.Message, EventLogEntryType.Error);
			}
		}
		catch (Exception ex7)
		{
			MethodBase currentMethod7 = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod7.Name, ex7.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			dbConnection2.Close();
		}
	}

	private void geraMonitGeracao20(WsErpSoapClient ws, Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader wsValidation)
	{
		List<EstatisticaResumoGeralTO> list = (List<EstatisticaResumoGeralTO>)CargaEstatisticaDAL.SelectResumoGeral(_stringConnTargetERP);
		EstatisticaResumoGeralTO estatisticaResumoGeralTO = null;
		if (list == null || list.Count == 0)
		{
			return;
		}
		estatisticaResumoGeralTO = list[0];
		MonitGerarDadosWsModel monitGerarDadosWsModel = new MonitGerarDadosWsModel();
		monitGerarDadosWsModel.DtUltimaAtualizacao = estatisticaResumoGeralTO.DataUltimaAtualizacao;
		monitGerarDadosWsModel.TempoUltimaAtualizacao = estatisticaResumoGeralTO.DuracaoUltimaAtualizacaoEmSegundos;
		monitGerarDadosWsModel.MaiorTempoDoDia = estatisticaResumoGeralTO.MaiorDuracaoDoDiaEmSegundos;
		monitGerarDadosWsModel.MenorTempoDoDia = estatisticaResumoGeralTO.MenorDuracaoDoDiaEmSegundos;
		monitGerarDadosWsModel.QtdeDeAtualizacoesDoDia = estatisticaResumoGeralTO.QtdeDeAtualizacoesNoDia;
		monitGerarDadosWsModel.VersaoRetaguardaUltimaAtualizacao = estatisticaResumoGeralTO.VersaoRetaguardaUltimaAtualizacao;
		monitGerarDadosWsModel.MediaTempoDoDia = estatisticaResumoGeralTO.MediaDuracaoDoDiaEmSegundos;
		using (DbConnection dbConnection = new DbConnection(_StringConnTargetMob))
		{
			try
			{
				dbConnection.Open();
				ServicoTO servicoTO = new ServicoTO();
				servicoTO.CodigoServico = 29;
				List<ServicoTO> list2 = ServicoBLL.Select(dbConnection.GetConnection(), servicoTO);
				if (list2 != null && list2.Count > 0)
				{
					servicoTO = list2[0];
					short diaSemana = (short)DateTime.Now.DayOfWeek;
					ConfiguracaoServicoTO configuracaoServicoTO = servicoTO.ConfiguracaoServico.Where((ConfiguracaoServicoTO o) => o.Dia == diaSemana).FirstOrDefault();
					monitGerarDadosWsModel.IntervaloDoDia = (configuracaoServicoTO.Intervalo.HasValue ? configuracaoServicoTO.Intervalo.Value : 0);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(" ExportMonitoramento.geraMonitGeracao20 " + ex.Message);
			}
			finally
			{
				dbConnection.Close();
			}
		}
		try
		{
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = ws.WsERP_MonitGerarDados_Set(wsValidation, _CnpjEmpresa, monitGerarDadosWsModel, Seguranca.getHostName());
			if (!retornoWsModelOfBoolean.RetornoWs)
			{
				throw new Exception(" MonitoramentoRetaguarda.WsERP_MonitGerarDados_Set " + retornoWsModelOfBoolean.Excecao.Erro);
			}
		}
		catch (Exception ex2)
		{
			throw ex2;
		}
	}

	private MonitRetagInformacoesFileDBWsModel[] retornaFileDB(DbConnection connTargetERP, DbConnection connTargetMob)
	{
		List<InfoDBTO> list = new List<InfoDBTO>();
		if (!string.IsNullOrEmpty(_nomeServidorOrigemReplicacao))
		{
			list = InfoDBBLL.Select(connTargetMob.GetConnection(), _nomeDbOrigemReplicacao, _nomeServidorOrigemReplicacao, "Target ERP");
			list.AddRange(InfoDBBLL.Select(connTargetMob.GetConnection(), "TempDB", _nomeServidorOrigemReplicacao, "Target ERP"));
		}
		else
		{
			list = InfoDBBLL.Select(connTargetMob.GetConnection(), _nomeDbOrigemReplicacao, "");
		}
		string database = connTargetMob.GetConnection().Database;
		list.AddRange(InfoDBBLL.Select(connTargetMob.GetConnection(), database, (!string.IsNullOrEmpty(_nomeServidorOrigemReplicacao)) ? database : string.Empty));
		list.AddRange(InfoDBBLL.Select(connTargetMob.GetConnection(), "TempDB", (!string.IsNullOrEmpty(_nomeServidorOrigemReplicacao)) ? database : string.Empty));
		List<MonitRetagInformacoesFileDBWsModel> list2 = new List<MonitRetagInformacoesFileDBWsModel>();
		foreach (InfoDBTO item in list)
		{
			MonitRetagInformacoesFileDBWsModel monitRetagInformacoesFileDBWsModel = new MonitRetagInformacoesFileDBWsModel();
			monitRetagInformacoesFileDBWsModel.BaseDados = item.DataBase;
			monitRetagInformacoesFileDBWsModel.FileName = item.FileName;
			if (!item.CurrentlyAllocatedSpace.HasValue)
			{
				monitRetagInformacoesFileDBWsModel.CurrentlyAllocatedSpace = null;
			}
			else
			{
				monitRetagInformacoesFileDBWsModel.CurrentlyAllocatedSpace = Convert.ToInt64(item.CurrentlyAllocatedSpace);
			}
			if (!item.SpaceUsed.HasValue)
			{
				monitRetagInformacoesFileDBWsModel.SpaceUsed = null;
			}
			else
			{
				monitRetagInformacoesFileDBWsModel.SpaceUsed = Convert.ToInt64(item.SpaceUsed);
			}
			if (!item.AvailableSpace.HasValue)
			{
				monitRetagInformacoesFileDBWsModel.AvailableSpace = null;
			}
			else
			{
				monitRetagInformacoesFileDBWsModel.AvailableSpace = Convert.ToInt64(item.AvailableSpace);
			}
			monitRetagInformacoesFileDBWsModel.ContextoAppServer = item.ContextoAppServer;
			list2.Add(monitRetagInformacoesFileDBWsModel);
		}
		if (list2.Count > 0)
		{
			return list2.ToArray();
		}
		return null;
	}

	private MonitRetagEspacoLivreUnidadeWsModel[] retornaEspacoLivreBD(DbConnection connTargetMob)
	{
		new List<UnidadeTO>();
		List<UnidadeTO> list = UnidadeBLL.Select(connTargetMob.GetConnection(), _nomeServidorOrigemReplicacao);
		List<MonitRetagEspacoLivreUnidadeWsModel> list2 = new List<MonitRetagEspacoLivreUnidadeWsModel>();
		foreach (UnidadeTO item in list)
		{
			MonitRetagEspacoLivreUnidadeWsModel monitRetagEspacoLivreUnidadeWsModel = new MonitRetagEspacoLivreUnidadeWsModel();
			monitRetagEspacoLivreUnidadeWsModel.Unidade = item.Nome;
			monitRetagEspacoLivreUnidadeWsModel.EspacoLivre = item.EspacoLivre;
			monitRetagEspacoLivreUnidadeWsModel.ContextoAppServer = item.ContextoAppServer;
			list2.Add(monitRetagEspacoLivreUnidadeWsModel);
		}
		if (list2.Count > 0)
		{
			return list2.ToArray();
		}
		return null;
	}

	private void enviaGeracoesPendentes(DbConnection connTargetMob, Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader wsValidation, WsErpSoapClient ws)
	{
		try
		{
			GeracaoTO geracaoTO = new GeracaoTO();
			geracaoTO.RowId = ws.WsERP_RowId_GetV2(wsValidation, _CnpjEmpresa, EnumModel.MonitoramentoGeracao, Seguranca.getHostName());
			List<GeracaoTO> list = GeracaoBLL.SelectQtdeVendedor(connTargetMob.GetConnection(), geracaoTO);
			List<MonitoramentoGeracaoWsModel> list2 = new List<MonitoramentoGeracaoWsModel>();
			foreach (GeracaoTO item in list)
			{
				MonitoramentoGeracaoWsModel monitoramentoGeracaoWsModel = new MonitoramentoGeracaoWsModel();
				monitoramentoGeracaoWsModel.IdMonitoramentoGeracao = item.Id.Value;
				monitoramentoGeracaoWsModel.DataInicio = item.DataInicio;
				monitoramentoGeracaoWsModel.DataFim = item.DataFim;
				monitoramentoGeracaoWsModel.QtdeVendedores = item.QtdeVendedores;
				monitoramentoGeracaoWsModel.Status = item.StatusGeracao.ToString();
				monitoramentoGeracaoWsModel.RowId = item.RowId;
				list2.Add(monitoramentoGeracaoWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = ws.WsERP_MonitoramentoGeracao_Set(wsValidation, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
			if (!retornoWsModelOfBoolean.RetornoWs)
			{
				throw new Exception(" MonitoramentoGeracao " + retornoWsModelOfBoolean.Excecao.Erro);
			}
		}
		catch (Exception ex)
		{
			throw new Exception(" MonitoramentoGeracao " + ex.Message);
		}
	}

	private static void retornaRelatoriosPendentes(DbConnection connTargetMob, ref int? RelatorioPendEnvioQtde, ref DateTime? RelatorioPendEnvioMaisAntigo)
	{
		try
		{
			RelatorioGerencialTO relatorioGerencialTO = new RelatorioGerencialTO();
			relatorioGerencialTO.DtImportacao = null;
			RelatorioGerencialTO[] array = RelatorioGerencialBLL.Select_Arquivo(connTargetMob, relatorioGerencialTO);
			if (array != null)
			{
				array.OrderBy((RelatorioGerencialTO x) => x.DtRecebimento);
				RelatorioPendEnvioQtde = array.Count();
				RelatorioPendEnvioMaisAntigo = array[0].DtRecebimento;
			}
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("Array Serviço", "Deu erro nos relatórios Pendentes " + ex.Message, EventLogEntryType.Error);
		}
	}

	private static int? retornaQtdAtendimentosPendentes(DbConnection connTargetERP)
	{
		return PedVdaEleBLL.AtendimentoPendenciaQtd(connTargetERP);
	}

	private static void retornaCargasPendentes(DbConnection connTargetMob, ref int? CargaPendEnvioQtde, ref DateTime? CargaPendEnvioMaisAntigo)
	{
		try
		{
			CargaBLL.SelectMonitoramento(connTargetMob.GetConnection(), ref CargaPendEnvioQtde, ref CargaPendEnvioMaisAntigo);
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("Array Serviço", "Deu erro nas Cargas Pendentes " + ex.Message, EventLogEntryType.Error);
		}
	}

	private static int retornaQtdServicos(DbConnection connTargetMob)
	{
		int num = 0;
		try
		{
			foreach (ServicoTO servico in ServicoBLL.Select(connTargetMob.GetConnection(), new ServicoTO()))
			{
				if ((from x in ServiceController.GetServices()
					where x.ServiceName == servico.Nome
					select x).FirstOrDefault() != null)
				{
					num++;
				}
			}
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("Array Serviço", "Deu erro no select Serviço " + ex.Message, EventLogEntryType.Error);
		}
		return num;
	}

	private static MonitRetagCPUWsModel[] retornaTopProcessos(List<ServicoTO> servicos, out List<PerformanceCounter> contadores)
	{
		try
		{
			List<MonitRetagCPUWsModel> list = new List<MonitRetagCPUWsModel>();
			contadores = new List<PerformanceCounter>();
			foreach (ServicoTO servico in servicos)
			{
				if ("TargetMobApi".Equals(servico.Nome))
				{
					servico.Nome = "Api";
				}
				MonitRetagCPUWsModel monitRetagCPUWsModel = new MonitRetagCPUWsModel();
				monitRetagCPUWsModel.Processo = "Target.Mob.Desktop.Servico.ERP." + servico.Nome;
				if (!string.IsNullOrEmpty(_SiglaCliente))
				{
					monitRetagCPUWsModel.Processo = monitRetagCPUWsModel.Processo.Replace(_SiglaCliente + ".", "");
				}
				if (monitRetagCPUWsModel.Processo.Length > 50)
				{
					monitRetagCPUWsModel.Processo = monitRetagCPUWsModel.Processo.Substring(0, 50);
				}
				PerformanceCounter performanceCounter = new PerformanceCounter("Process", "% Processor Time", monitRetagCPUWsModel.Processo, Seguranca.getHostName());
				try
				{
					monitRetagCPUWsModel.UtilizacaoCPU = Convert.ToInt32(performanceCounter.NextValue());
					list.Add(monitRetagCPUWsModel);
					contadores.Add(performanceCounter);
				}
				catch (Exception ex)
				{
					LogEvento.WriteEntry("retornaTopProcessos", " Processo não encontrado para o serviço" + ex.Message, EventLogEntryType.Error);
				}
			}
			if (list.Count > 0)
			{
				return list.ToArray();
			}
		}
		catch (Exception)
		{
			LogEvento.WriteEntry("Process %", "Deu erro no array processo", EventLogEntryType.Error);
		}
		contadores = null;
		return null;
	}

	private static float retornaUtilizacaoCPU(DbConnection connTargetMob, out MonitRetagCPUWsModel[] MonitRetagCPU)
	{
		float num = 0f;
		MonitRetagCPU = null;
		List<ServicoTO> list = ServicoBLL.Select(connTargetMob.GetConnection(), new ServicoTO());
		List<ServicoTO> list2 = new List<ServicoTO>(list);
		foreach (ServicoTO item in list)
		{
			ServiceController serviceController = (from x in ServiceController.GetServices()
				where x.ServiceName == item.Nome
				select x).FirstOrDefault();
			if (serviceController == null || serviceController.Status == ServiceControllerStatus.Stopped || item.Status == false || "TargetMobApi".Equals(serviceController.ServiceName))
			{
				list2.Remove(item);
			}
		}
		try
		{
			PerformanceCounter performanceCounter;
			using (performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", Seguranca.getHostName()))
			{
				num = performanceCounter.NextValue();
				List<PerformanceCounter> contadores = null;
				MonitRetagCPU = retornaTopProcessos(list2, out contadores);
				if (num == 0f)
				{
					Thread.Sleep(1000);
					num = performanceCounter.NextValue();
					foreach (PerformanceCounter item2 in contadores)
					{
						MonitRetagCPU[contadores.IndexOf(item2)].UtilizacaoCPU = Convert.ToInt32(item2.NextValue());
					}
				}
			}
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("Process %", "Deu erro no process count. " + ex.Message, EventLogEntryType.Error);
		}
		return num;
	}

	private long retornaEspacoDiscoApp()
	{
		long result = 0L;
		DriveInfo[] drives = DriveInfo.GetDrives();
		foreach (DriveInfo driveInfo in drives)
		{
			if (driveInfo.Name.Equals(_targetMobPath.Substring(0, driveInfo.Name.Length)))
			{
				result = driveInfo.TotalFreeSpace;
			}
		}
		return result;
	}

	private static string retornaVersaoRetaguarda()
	{
		Version version = typeof(Sincroniza).Assembly.GetName().Version;
		return version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;
	}
}
