using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Target.Mob.Common.Log;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Venda.IBusiness.Factory;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class LiberacaoPedidoBLL
{
	private const int TARGET_VENDAS_API = 1;

	public static void LiberaPedidos(DbConnection conexERP, DbConnection conexMOB, string processName, string appLiberacao, string connOdbc, double tmpLimMataProcesso, int nuMaxTentativasLib, string usrLiberacao, string cdVend, int? qtdePedidos)
	{
		try
		{
			LiberaPendEletronico(conexERP, conexMOB, appLiberacao, connOdbc, nuMaxTentativasLib, usrLiberacao, tmpLimMataProcesso, processName);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	internal static void LiberaPendEletronico(DbConnection conexERP, DbConnection conexMOB, string appLiberacao, string connOdbc, int nuMaxTentativasLib, string usrLiberacao, double tmpLimMataProcesso, string processName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			foreach (Process obj in processesByName)
			{
				stringBuilder.Append("Passo 1 - Mata o processo antes de iniciar: " + processName);
				stringBuilder.AppendLine();
				obj.Kill();
			}
			List<EventoPdelAbTO> list = ObterPedidoEletronicos(conexERP);
			if (list.Count == 0)
			{
				return;
			}
			stringBuilder.Append("Total de Pedidos para importar: " + list.Count);
			stringBuilder.AppendLine();
			foreach (EventoPdelAbTO item in list)
			{
				stringBuilder.Append("Iniciando importação do pedido: " + item.oPedVdaEle.ToString());
				stringBuilder.AppendLine();
				for (int j = 0; j < nuMaxTentativasLib; j++)
				{
					stringBuilder.Append("Iniciando importação do pedido tentativa: " + (j + 1));
					stringBuilder.AppendLine();
					string text = "";
					Process process = new Process();
					text = usrLiberacao + " " + item.oPedVdaEle.CdClien + " " + item.oPedVdaEle.CdEmpEle + " " + item.oPedVdaEle.NuPedEle + " " + item.oPedVdaEle.SeqPed + " " + connOdbc;
					stringBuilder.Append("Chamando a aplicação - linha de comando " + appLiberacao + " " + text);
					stringBuilder.AppendLine();
					ProcessStartInfo processStartInfo = new ProcessStartInfo(appLiberacao, text);
					processStartInfo.WorkingDirectory = Path.GetDirectoryName(appLiberacao);
					process.StartInfo = processStartInfo;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.Start();
					if (!process.WaitForExit((int)tmpLimMataProcesso * 1000) && j + 1 == nuMaxTentativasLib)
					{
						stringBuilder.Append("Não conseguiu importar - pedido manual");
						stringBuilder.AppendLine();
						EnviarLiberacaoManual(conexERP, conexMOB, item.oPedVdaEle.CdEmpEle, item.oPedVdaEle.NuPedEle, item.oPedVdaEle.SeqPed);
					}
					else
					{
						stringBuilder.Append("Confirmar se o pedido foi importado.");
						stringBuilder.AppendLine();
						item.oPedVdaEle = PedVdaEleBLL.Select(conexERP, ApenasCabecalho: true, item.oPedVdaEle.CdEmpEle, item.oPedVdaEle.NuPedEle, item.oPedVdaEle.SeqPed);
						stringBuilder.Append("Seleciona o pedido no ERP - dados: Situação [" + item.oPedVdaEle.Situacao.ToString() + "] - Numero [" + item.oPedVdaEle.NuPed + "]");
						stringBuilder.AppendLine();
						if (item.oPedVdaEle.Situacao != SituacaoPedido.EmAberto || item.oPedVdaEle.NuPed.HasValue)
						{
							stringBuilder.Append("Pedido importado com sucesso");
							stringBuilder.AppendLine();
							MatarProcesso(process, processStartInfo);
							break;
						}
						stringBuilder.Append("Pedido não importado, verifica quantidade de tentativas");
						stringBuilder.AppendLine();
						if (j + 1 == nuMaxTentativasLib)
						{
							stringBuilder.Append("Não conseguiu importar, pedido em aberto e com data nula - pedido manual");
							stringBuilder.AppendLine();
							EnviarLiberacaoManual(conexERP, conexMOB, item.oPedVdaEle.CdEmpEle, item.oPedVdaEle.NuPedEle, item.oPedVdaEle.SeqPed);
						}
					}
					MatarProcesso(process, processStartInfo);
				}
			}
		}
		catch (Exception ex)
		{
			stringBuilder.Append("Ocorreu um Erro:" + ex.ToString());
			stringBuilder.AppendLine();
		}
		try
		{
			string source = "Target Mob";
			string logName = "Log Liberação Pedido";
			if (!EventLog.SourceExists(source))
			{
				EventLog.CreateEventSource(source, logName);
			}
			EventLog.WriteEntry(source, stringBuilder.ToString());
		}
		catch (Exception ex2)
		{
			throw ex2;
		}
	}

	private static void MatarProcesso(Process exec, ProcessStartInfo start)
	{
		start = null;
		if (!exec.HasExited)
		{
			exec.Kill();
		}
		exec = null;
	}

	private static List<EventoPdelAbTO> ObterPedidoEletronicos(DbConnection conexERP)
	{
		EventoPdelAbTO[] array = EventoPdelAbBLL.Select(conexERP, null, null, int.MaxValue);
		if (array == null)
		{
			return new List<EventoPdelAbTO>();
		}
		return array.Where((EventoPdelAbTO item) => item.oPedVdaEle.LiberacaoAutomatica == true).ToList();
	}

	private static void EnviarLiberacaoManual(DbConnection conexaoERP, DbConnection conexaoMOB, int cdEmpEle, int nuPedEle, decimal seqPed)
	{
		PedVdaEleTO pedVdaEleTO = PedVdaEleBLL.Select(conexaoERP, ApenasCabecalho: true, cdEmpEle, nuPedEle, seqPed);
		if (!SituacaoPedido.Cancelado.Equals(pedVdaEleTO.Situacao) && !pedVdaEleTO.NuPed.HasValue)
		{
			pedVdaEleTO.LiberacaoAutomatica = false;
			PedVdaEleDAL.Update(conexaoERP, pedVdaEleTO);
			LogLibAutoTimeOutTO logLibAutoTimeOutTO = new LogLibAutoTimeOutTO();
			logLibAutoTimeOutTO.CdEmpEle = pedVdaEleTO.CdEmpEle;
			logLibAutoTimeOutTO.NuPedEle = pedVdaEleTO.NuPedEle;
			LogLibAutoTimeOutDAL.Insert(conexaoMOB, logLibAutoTimeOutTO);
		}
	}

	public static void LiberaPedidosNovaLiberacao(DbConnection connTargetErp, DbConnection connTargetMOB)
	{
		List<EventoPdelAbTO> list = ObterPedidoEletronicos(connTargetErp);
		List<PedVdaEleTO> list2 = new List<PedVdaEleTO>();
		string appConfig = ConfigHelper.getAppConfig("MultiThread");
		foreach (EventoPdelAbTO item in list)
		{
			if (!string.IsNullOrEmpty(appConfig) && appConfig.ToUpper().Equals("TRUE"))
			{
				list2.Add(item.oPedVdaEle);
			}
			else
			{
				ChamarLiberacaoERPNova(connTargetErp, connTargetMOB, item.oPedVdaEle);
			}
		}
		if (list2.Count > 0)
		{
			ChamarLiberacaoMultiThreadERP(connTargetErp, connTargetMOB, list2);
		}
	}

	private static void ChamarLiberacaoMultiThreadERP(DbConnection connTargetErp, DbConnection connTargetMOB, List<PedVdaEleTO> listaPedidosEletronicos)
	{
		try
		{
			List<ParametrosLiberarPedidoEletronicoVO> list = new List<ParametrosLiberarPedidoEletronicoVO>();
			foreach (PedVdaEleTO listaPedidosEletronico in listaPedidosEletronicos)
			{
				ParametrosLiberarPedidoEletronicoVO parametrosLiberarPedidoEletronicoVO = new ParametrosLiberarPedidoEletronicoVO();
				parametrosLiberarPedidoEletronicoVO.CODIGO_EMPRESA_ELETRONICO = listaPedidosEletronico.CdEmpEle;
				parametrosLiberarPedidoEletronicoVO.CODIGO_USUARIO = "SUPER";
				parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO = listaPedidosEletronico.NuPedEle;
				parametrosLiberarPedidoEletronicoVO.NUMERO_SEQ_PEDIDO = Convert.ToInt32(listaPedidosEletronico.SeqPed);
				parametrosLiberarPedidoEletronicoVO.NOME_PROGRAMA = "TARGET MOB";
				parametrosLiberarPedidoEletronicoVO.VALOR_MINIMO_INTEGRACAO = 0m;
				list.Add(parametrosLiberarPedidoEletronicoVO);
			}
			ILiberarMultiplosPedidosEletronicosBLL liberarMultiplosPedidosEletronicosBLL = BusinessFactory.GetLiberarMultiplosPedidosEletronicosBLL();
			liberarMultiplosPedidosEletronicosBLL.EventRetornoMensagem += liberar_EventRetornoMensagem;
			foreach (RetornoLiberarPedidoEletronicoVO pedido in liberarMultiplosPedidosEletronicosBLL.ExecutarMultiplosPedidos(list))
			{
				PedVdaEleTO pedVdaEleTO = listaPedidosEletronicos.Find((PedVdaEleTO x) => x.CdEmpEle == pedido.PARAMETRO_LIBERACAO.CODIGO_EMPRESA_ELETRONICO && x.NuPedEle == pedido.PARAMETRO_LIBERACAO.NUMERO_PEDIDO_ELETRONICO && x.SeqPed == (decimal)pedido.PARAMETRO_LIBERACAO.NUMERO_SEQ_PEDIDO);
				if (pedido.RESULTADO_PROCESSO != ResultadoProcessoEnum.SUCESSO)
				{
					EnviarLiberacaoManual(connTargetErp, connTargetMOB, pedVdaEleTO.CdEmpEle, pedVdaEleTO.NuPedEle, pedVdaEleTO.SeqPed);
					string message = "Liberação MultiThread.: Cod.Emp.: " + pedido.PARAMETRO_LIBERACAO.CODIGO_EMPRESA_ELETRONICO + "NuPedEle: " + pedido.PARAMETRO_LIBERACAO.NUMERO_PEDIDO_ELETRONICO + "Mensagem.: " + pedido.MENSAGEM_VALIDACAO + "Resultado.: " + pedido.RESULTADO_PROCESSO;
					LogEvento.WriteEntry("ChamarLiberacaoMultiThreadERP", message, EventLogEntryType.Warning);
				}
			}
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry("LiberaPedidoEletronicoBLL." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
	}

	private static void ChamarLiberacaoERPNova(DbConnection connTargetErp, DbConnection connTargetMOB, PedVdaEleTO pedidoEletronico)
	{
		try
		{
			ILiberarPedidoEletronicoBLL liberarPedidoEletronicoBLL = BusinessFactory.GetLiberarPedidoEletronicoBLL();
			liberarPedidoEletronicoBLL.EventRetornoMensagem += liberar_EventRetornoMensagem;
			ParametrosLiberarPedidoEletronicoVO parametrosLiberarPedidoEletronicoVO = new ParametrosLiberarPedidoEletronicoVO();
			parametrosLiberarPedidoEletronicoVO.CODIGO_EMPRESA_ELETRONICO = pedidoEletronico.CdEmpEle;
			parametrosLiberarPedidoEletronicoVO.CODIGO_USUARIO = "SUPER";
			parametrosLiberarPedidoEletronicoVO.NUMERO_PEDIDO_ELETRONICO = pedidoEletronico.NuPedEle;
			parametrosLiberarPedidoEletronicoVO.NUMERO_SEQ_PEDIDO = Convert.ToInt32(pedidoEletronico.SeqPed);
			parametrosLiberarPedidoEletronicoVO.NOME_PROGRAMA = "TARGET MOB";
			parametrosLiberarPedidoEletronicoVO.VALOR_MINIMO_INTEGRACAO = 0m;
			RetornoLiberarPedidoEletronicoVO retornoLiberarPedidoEletronicoVO = null;
			try
			{
				retornoLiberarPedidoEletronicoVO = liberarPedidoEletronicoBLL.Executar(parametrosLiberarPedidoEletronicoVO);
			}
			catch (Exception)
			{
				TrataFalhaLiberacaoPedidoEletronico(connTargetErp, connTargetMOB, pedidoEletronico, retornoLiberarPedidoEletronicoVO);
			}
			if (retornoLiberarPedidoEletronicoVO == null || retornoLiberarPedidoEletronicoVO.RESULTADO_PROCESSO != ResultadoProcessoEnum.SUCESSO)
			{
				TrataFalhaLiberacaoPedidoEletronico(connTargetErp, connTargetMOB, pedidoEletronico, retornoLiberarPedidoEletronicoVO);
			}
		}
		catch (Exception ex2)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry("LiberaPedidoEletronicoBLL." + currentMethod.Name, ex2.Message, EventLogEntryType.Error);
		}
	}

	private static void TrataFalhaLiberacaoPedidoEletronico(DbConnection connTargetErp, DbConnection connTargetMOB, PedVdaEleTO pedidoEletronico, RetornoLiberarPedidoEletronicoVO resultadoLiberacao)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("Erro na liberação do Pedido Eletrônico: {0}", pedidoEletronico.NuPedEle);
		if (resultadoLiberacao != null)
		{
			if (!string.IsNullOrEmpty(resultadoLiberacao.MENSAGEM_VALIDACAO))
			{
				stringBuilder.AppendLine("Mensagem:" + resultadoLiberacao.MENSAGEM_VALIDACAO);
			}
			if (!string.IsNullOrEmpty(resultadoLiberacao.LOG_PROCESSO))
			{
				stringBuilder.AppendLine("Descrição do Processo de Liberação: ");
				stringBuilder.AppendLine(resultadoLiberacao.LOG_PROCESSO);
			}
		}
		EnviarLiberacaoManual(connTargetErp, connTargetMOB, pedidoEletronico.CdEmpEle, pedidoEletronico.NuPedEle, pedidoEletronico.SeqPed);
		MethodBase currentMethod = MethodBase.GetCurrentMethod();
		LogEvento.WriteEntry("LiberaPedidoEletronicoBLL." + currentMethod.Name, stringBuilder.ToString(), EventLogEntryType.Error);
	}

	private static void liberar_EventRetornoMensagem(string message)
	{
	}

	public static bool isVendasAPIDisponivel(DbConnection connTargetErp)
	{
		TargetServicosTO targetServicosTO = TargetServicosBLL.Select(connTargetErp, 1);
		if (targetServicosTO != null && !string.IsNullOrEmpty(targetServicosTO.Endereco) && targetServicosTO.Porta.HasValue && targetServicosTO.Porta > 0)
		{
			return true;
		}
		return false;
	}

	public static void LiberaPedidoVendasApi(DbConnection connTargetErp, DbConnection connTargetMob)
	{
		List<EventoPdelAbTO> list = ObterPedidoEletronicos(connTargetErp);
		TargetServicosTO targetServicosTO = TargetServicosBLL.Select(connTargetErp, 1);
		if (targetServicosTO == null)
		{
			throw new Exception("Sem configuração para acessar o serviço do Target Vendas Api.");
		}
		foreach (EventoPdelAbTO item in list)
		{
			ChamarLiberacaoViaApi(connTargetErp, connTargetMob, item.oPedVdaEle, targetServicosTO);
		}
	}

	public static void ChamarLiberacaoViaApi(DbConnection connTargetErp, DbConnection connTargetMob, PedVdaEleTO pedidoEletronico, TargetServicosTO targetServ)
	{
		RetornoTargetVendasTO retornoTargetVendasTO = new RetornoTargetVendasTO();
		MethodBase currentMethod = MethodBase.GetCurrentMethod();
		try
		{
			ParametrosLiberarPedidoEletronicoTO parametrosLiberarPedidoEletronicoTO = new ParametrosLiberarPedidoEletronicoTO();
			parametrosLiberarPedidoEletronicoTO.CODIGO_EMPRESA_ELETRONICO = pedidoEletronico.CdEmpEle;
			parametrosLiberarPedidoEletronicoTO.CODIGO_USUARIO = "SUPER";
			parametrosLiberarPedidoEletronicoTO.NUMERO_PEDIDO_ELETRONICO = pedidoEletronico.NuPedEle;
			parametrosLiberarPedidoEletronicoTO.NUMERO_SEQ_PEDIDO = Convert.ToInt32(pedidoEletronico.SeqPed);
			parametrosLiberarPedidoEletronicoTO.NOME_PROGRAMA = "TARGET MOB";
			string baseUrl = "http://" + targetServ.Endereco + ":" + targetServ.Porta;
			string appConfig = ConfigHelper.getAppConfig("RotaVendasPedidos");
			appConfig = (string.IsNullOrEmpty(appConfig) ? "/api/Pedido" : appConfig);
			RestRequest restRequest = new RestRequest(appConfig, Method.POST);
			RestClient restClient = new RestClient(baseUrl);
			restRequest.AddJsonBody(parametrosLiberarPedidoEletronicoTO);
			IRestResponse restResponse = restClient.Execute(restRequest);
			if (restResponse == null || restResponse.Content == null || restResponse.Content == "[]" || string.IsNullOrEmpty(restResponse.Content))
			{
				throw new Exception("Retorno inválido da chamada do Vendas Api. Pedido.CdEmp: " + pedidoEletronico.CdEmpEle + " - Pedido.NuPedEle: " + pedidoEletronico.NuPedEle);
			}
			retornoTargetVendasTO = JsonConvert.DeserializeObject<RetornoTargetVendasTO>(restResponse.Content);
			if (retornoTargetVendasTO == null || retornoTargetVendasTO.RESULTADO_PROCESSO != 1 || !ResponseStatus.Completed.Equals(restResponse.ResponseStatus))
			{
				EnviarLiberacaoManual(connTargetErp, connTargetMob, pedidoEletronico.CdEmpEle, pedidoEletronico.NuPedEle, pedidoEletronico.SeqPed);
				string text = (string.IsNullOrEmpty(retornoTargetVendasTO.MENSAGEM_VALIDACAO) ? "SEM_INFORMACAO" : retornoTargetVendasTO.MENSAGEM_VALIDACAO);
				LogEvento.WriteEntry("LiberaPedidoBLL." + currentMethod.Name, "Liberação Target Vendas Api, MENSAGEM: " + text, EventLogEntryType.Error);
			}
		}
		catch (Exception ex)
		{
			LogEvento.WriteEntry("LiberaPedidoBLL." + currentMethod.Name, "Erro na chamada do Target Vendas, método ChamarLiberacaoViaApi(...): " + ex.Message, EventLogEntryType.Error);
			EnviarLiberacaoManual(connTargetErp, connTargetMob, pedidoEletronico.CdEmpEle, pedidoEletronico.NuPedEle, pedidoEletronico.SeqPed);
		}
	}
}
