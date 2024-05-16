using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;

namespace Target.Mob.Desktop.Servico.ERP.Base;

public class ServicoBase : ServiceBase
{
	protected const int tempoServicoPrincipal = 30000;

	protected const int tempoServicoImportarConfiguracao = 300000;

	protected const int tempoServicoMonitoramento = 600000;

	protected const int tempoServicoImportarVersao = 300000;

	private List<ServicoTO> _servicos;

	private Timer _timer;

	public List<ServicoTO> Servicos
	{
		get
		{
			if (_servicos == null)
			{
				_servicos = new List<ServicoTO>();
			}
			return _servicos;
		}
		set
		{
			_servicos = value;
		}
	}

	public Timer Timer
	{
		get
		{
			return _timer;
		}
		set
		{
			_timer = value;
		}
	}

	public string DBServer { get; set; }

	public string DBBase { get; set; }

	protected override void OnStart(string[] args)
	{
	}

	protected override void OnStop()
	{
	}

	public virtual void OnTimerEvent(object source, EventArgs e)
	{
	}

	public virtual void ValidarServicoPrincipal()
	{
		try
		{
			ServicoTO servicoTO = ServicoBLL.Select(new SqlConnection(EncrypterHelper.Descriptografia_ConnectionString(((ConnectionStringsSection)ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Target.Mob.Desktop.Servico.ERP.Principal.exe").GetSection("connectionStrings")).ConnectionStrings["ConexaoTargetMob"].ConnectionString)), new ServicoTO
			{
				Principal = true
			}).FirstOrDefault();
			if (servicoTO == null)
			{
				throw new NotImplementedException("Principal não implementado");
			}
			ValidarStatusServicoPrincipal(servicoTO);
		}
		catch (Exception)
		{
			throw new Exception("Configuração não encontrada");
		}
	}

	private void ValidarStatusServicoPrincipal(ServicoTO servico)
	{
		try
		{
			ServiceController serviceController = (from x in ServiceController.GetServices()
				where x.ServiceName == servico.Nome
				select x).FirstOrDefault();
			if (serviceController != null && serviceController.Status == ServiceControllerStatus.Stopped && servico.Status == true)
			{
				ConfiguracaoServicoTO configuracaoServico = GetConfiguracaoServico(servico);
				if (configuracaoServico != null)
				{
					serviceController.Start(new string[2]
					{
						servico.Nome,
						configuracaoServico.Intervalo.ToString()
					});
				}
			}
			else if (serviceController != null && serviceController.Status == ServiceControllerStatus.Running && servico.Status == false)
			{
				serviceController.Stop();
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public virtual ServicoTO BuscaServico(int? codigoServico)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(EncrypterHelper.Descriptografia_ConnectionString(((ConnectionStringsSection)ConfigurationManager.OpenExeConfiguration(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Target.Mob.Desktop.Servico.ERP.Principal.exe").GetSection("connectionStrings")).ConnectionStrings["ConexaoTargetMob"].ConnectionString));
			sqlConnection.Open();
			ServicoTO result = ServicoBLL.Select(sqlConnection, new ServicoTO
			{
				Status = true,
				CodigoServico = codigoServico
			}).FirstOrDefault();
			sqlConnection.Close();
			return result;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public virtual int? BuscarIntervaloServico(int codigoServico)
	{
		ServicoTO servicoTO = BuscaServico(codigoServico);
		ConfiguracaoServicoTO configuracaoServico = GetConfiguracaoServico(servicoTO);
		int? result = null;
		if (servicoTO != null && servicoTO.Status == true && configuracaoServico != null)
		{
			result = Convert.ToInt32(configuracaoServico.Intervalo * 1000);
		}
		return result;
	}

	public virtual void IniciaServico(ServicoTO servico)
	{
		try
		{
			ServiceController serviceController = (from x in ServiceController.GetServices()
				where x.ServiceName == servico.Nome
				select x).FirstOrDefault();
			if (serviceController == null || serviceController.Status != ServiceControllerStatus.Stopped || servico.Status != true)
			{
				return;
			}
			ConfiguracaoServicoTO configuracaoServico = GetConfiguracaoServico(servico);
			if (servico.Principal == true)
			{
				int num = 0;
				switch (servico.Nome)
				{
				case "Servico":
					num = 300000;
					break;
				case "Monitoramento":
					num = 600000;
					break;
				case "Versao":
					num = 300000;
					break;
				}
				serviceController.Start(new string[2]
				{
					servico.Nome,
					num.ToString()
				});
			}
			else if (configuracaoServico != null)
			{
				serviceController.Start(new string[2]
				{
					servico.Nome,
					configuracaoServico.Intervalo.ToString()
				});
			}
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Erro ao Iniciar ", ex.Message, EventLogEntryType.Error);
		}
	}

	public virtual void ParaServico(ServicoTO servico)
	{
		try
		{
			ServiceController serviceController = (from x in ServiceController.GetServices()
				where x.ServiceName == servico.Nome
				select x).FirstOrDefault();
			if (serviceController != null && serviceController.Status == ServiceControllerStatus.Running)
			{
				serviceController.Stop();
			}
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Erro ao Parar ", ex.Message, EventLogEntryType.Error);
		}
	}

	public virtual ConfiguracaoServicoTO GetConfiguracaoServico(ServicoTO servico)
	{
		try
		{
			if (servico.Principal == true || servico.ConfiguracaoServico == null)
			{
				return null;
			}
			int dia = (int)(DateTime.Now.DayOfWeek + 1);
			ConfiguracaoServicoTO configuracaoServicoTO = servico.ConfiguracaoServico.Where((ConfiguracaoServicoTO x) => x.Dia == dia).FirstOrDefault();
			if (configuracaoServicoTO != null && servico.Status == true)
			{
				TimeSpan timeSpan = new TimeSpan(int.Parse(configuracaoServicoTO.HorarioInicio.Split(':')[0]), int.Parse(configuracaoServicoTO.HorarioInicio.Split(':')[1]), 0);
				TimeSpan timeSpan2 = new TimeSpan(int.Parse(configuracaoServicoTO.HorarioTermino.Split(':')[0]), int.Parse(configuracaoServicoTO.HorarioTermino.Split(':')[1]), 0);
				TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
				if (timeOfDay >= timeSpan && timeOfDay <= timeSpan2)
				{
					return configuracaoServicoTO;
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			EventLog.WriteEntry(ex.Source + " Serviços", ex.Message, EventLogEntryType.Error);
		}
		return null;
	}
}
