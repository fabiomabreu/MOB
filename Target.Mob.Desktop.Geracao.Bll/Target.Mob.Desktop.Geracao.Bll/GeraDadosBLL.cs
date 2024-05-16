using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Target.Mob.Desktop.Geracao.Dal;
using Target.Mob.Desktop.Geracao.Enum;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Bll;

public class GeraDadosBLL
{
	private string _connStringTargetERP = "";

	private bool _multiThread;

	private GeracaoLogTO _geracao;

	public static bool Erro { get; set; }

	public static string ErroMsg { get; set; }

	public GeraDadosBLL(string connStringTargetERP, bool multiThread)
	{
		_connStringTargetERP = connStringTargetERP;
		_multiThread = multiThread;
	}

	public void Gera()
	{
		Erro = false;
		try
		{
			LogInicio();
			LogAltera("Limpando logs de alteração...");
			try
			{
				GeraDadosDAL.LimpaLogAlteracaoTabela(_connStringTargetERP);
			}
			catch (Exception)
			{
			}
			LogAltera("Limpando registro de exclusão antigo...");
			try
			{
				GeraDadosDAL.LimpaCargaEntidadeExclusaoAntigas(_connStringTargetERP);
			}
			catch (Exception)
			{
			}
			LogAltera("Carregando entidades...");
			List<CargaControleEntidadeTO> entidades = CargaControleEntidadeBLL.Select(_connStringTargetERP);
			LogAltera("Carregando templates...");
			List<CargaTemplateSqlTO> templates = CargaTemplateSqlBLL.Select(_connStringTargetERP);
			LogAltera("Tratando procedures...");
			TrataProcedures(entidades, templates, _multiThread);
			LogAltera("Ajustando triggers...");
			TrataTriggers(entidades, templates, _multiThread);
			LogAltera("Processando restrições...");
			TrataEntidadesRestricao(entidades, templates, _multiThread);
			LogAltera("Processando entidades...");
			TrataEntidades(entidades, templates, _multiThread);
			LogFim();
		}
		catch (Exception ex3)
		{
			LogErro(ex3.ToString());
			throw new Exception(ex3.ToString());
		}
	}

	private void LogInicio()
	{
		Version version = Assembly.GetEntryAssembly().GetName().Version;
		_geracao = new GeracaoLogTO
		{
			DataInicio = DateTime.Now,
			MultiThread = _multiThread,
			IdStatusGeracaoTR = StatusGeracaoTR.Processando,
			Versao = version.ToString(),
			VersaoMajor = version.Major,
			VersaoMinor = version.Minor,
			Etapa = "Iniciada"
		};
		_geracao.Id = GeraDadosDAL.LogInsert(_connStringTargetERP, _geracao);
	}

	public static bool IsVersaoCompativel(string connStringTargetERP, int versaoMajor, int versaoMinor)
	{
		return GeraDadosDAL.IsVersaoCompativel(connStringTargetERP, versaoMajor, versaoMinor);
	}

	private void LogAltera(string etapa)
	{
		_geracao.Etapa = etapa;
		GeraDadosDAL.LogUpdate(_connStringTargetERP, _geracao);
	}

	private void LogFim()
	{
		_geracao.DataFim = DateTime.Now;
		_geracao.IdStatusGeracaoTR = StatusGeracaoTR.Sucesso;
		_geracao.Etapa = "Finalizada";
		GeraDadosDAL.LogUpdate(_connStringTargetERP, _geracao);
	}

	private void LogErro(string erro)
	{
		_geracao.DataFim = DateTime.Now;
		_geracao.IdStatusGeracaoTR = StatusGeracaoTR.Erro;
		_geracao.Erro = erro;
		GeraDadosDAL.LogUpdate(_connStringTargetERP, _geracao);
	}

	private void TrataProcedures(List<CargaControleEntidadeTO> entidades, List<CargaTemplateSqlTO> templates, bool multiThread)
	{
		using (CountdownEvent countdownEvent = new CountdownEvent(1))
		{
			foreach (CargaControleEntidadeTO entidade in entidades)
			{
				ProcedureBLL procedureBLL = new ProcedureBLL(_connStringTargetERP, entidade, templates);
				if (multiThread)
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(procedureBLL.Gera_MultiThread, countdownEvent);
				}
				else
				{
					procedureBLL.Gera_SingleThread();
				}
			}
			countdownEvent.Signal();
			countdownEvent.Wait(TimeSpan.FromSeconds(1200.0));
			if (countdownEvent.CurrentCount > 0)
			{
				throw new Exception(string.Format("Timeout TrataProcedures <CurrentCount: (0)>", countdownEvent.CurrentCount));
			}
		}
		if (Erro)
		{
			throw new Exception(ErroMsg);
		}
	}

	private void TrataTriggers(List<CargaControleEntidadeTO> entidades, List<CargaTemplateSqlTO> templates, bool multiThread)
	{
		List<string> list = TriggerBLL.Select(entidades);
		using (CountdownEvent countdownEvent = new CountdownEvent(1))
		{
			foreach (string item in list)
			{
				TriggerBLL triggerBLL = new TriggerBLL(_connStringTargetERP, item, templates);
				if (multiThread)
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(triggerBLL.Gera_MultiThread, countdownEvent);
				}
				else
				{
					triggerBLL.Gera_SingleThread();
				}
			}
			countdownEvent.Signal();
			countdownEvent.Wait(TimeSpan.FromSeconds(1200.0));
			if (countdownEvent.CurrentCount > 0)
			{
				throw new Exception(string.Format("Timeout TrataTriggers <CurrentCount: (0)>", countdownEvent.CurrentCount));
			}
		}
		if (Erro)
		{
			throw new Exception(ErroMsg);
		}
	}

	private void TrataEntidadesRestricao(List<CargaControleEntidadeTO> entidades, List<CargaTemplateSqlTO> templates, bool multiThread)
	{
		List<CargaControleEntidadeTO> list = entidades.Where((CargaControleEntidadeTO x) => x.entidadeTipoRestricao).ToList();
		foreach (int item in (from r in list.Select((CargaControleEntidadeTO r) => r.commandSqlOnda).Distinct()
			orderby r
			select r).ToList())
		{
			GeraEntidades(list, item, templates, multiThread);
		}
	}

	private void TrataEntidades(List<CargaControleEntidadeTO> entidades, List<CargaTemplateSqlTO> templates, bool multiThread)
	{
		List<CargaControleEntidadeTO> list = entidades.Where((CargaControleEntidadeTO x) => !x.entidadeTipoRestricao).ToList();
		foreach (int item in (from r in list.Select((CargaControleEntidadeTO r) => r.commandSqlOnda).Distinct()
			orderby r
			select r).ToList())
		{
			GeraEntidades(list, item, templates, multiThread);
		}
	}

	private void GeraEntidades(List<CargaControleEntidadeTO> entidadesRestricao, int o, List<CargaTemplateSqlTO> templates, bool multiThread)
	{
		using (CountdownEvent countdownEvent = new CountdownEvent(1))
		{
			foreach (CargaControleEntidadeTO item in from x in entidadesRestricao
				where x.commandSqlOnda == o
				select x into e
				orderby e.ultimaExecucaoTempoMs descending
				select e)
			{
				CargaControleEntidadeBLL cargaControleEntidadeBLL = new CargaControleEntidadeBLL(_connStringTargetERP, item, templates);
				if (multiThread)
				{
					countdownEvent.AddCount();
					ThreadPool.QueueUserWorkItem(cargaControleEntidadeBLL.Gera_MultiThread, countdownEvent);
				}
				else
				{
					cargaControleEntidadeBLL.Gera_SingleThread();
				}
			}
			countdownEvent.Signal();
			countdownEvent.Wait();
		}
		if (Erro)
		{
			throw new Exception(ErroMsg);
		}
	}
}
