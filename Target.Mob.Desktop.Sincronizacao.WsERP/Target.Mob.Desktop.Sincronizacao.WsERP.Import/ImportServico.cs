using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

public class ImportServico
{
	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportServico(string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetMob);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			RetornoWsModelOfListOfServicoWsModel retornoWsModelOfListOfServicoWsModel = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Servicos_GetV2(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfListOfServicoWsModel.RetornoWs != null)
			{
				ServicoWsModel[] retornoWs = retornoWsModelOfListOfServicoWsModel.RetornoWs;
				dbConnection.Open();
				List<ServicoTO> list = new List<ServicoTO>();
				ServicoWsModel[] array = retornoWs;
				foreach (ServicoWsModel servicoWs in array)
				{
					list.Add(ConstruirServico(servicoWs));
				}
				dbConnection.BeginTransaction();
				ServicoBLL.Delete(dbConnection.GetTransaction(), new ServicoTO());
				foreach (ServicoTO item in list)
				{
					ServicoBLL.Insert(dbConnection.GetTransaction(), item);
				}
				dbConnection.CommitTransaction();
				dbConnection.Close();
				return;
			}
			throw new Exception(retornoWsModelOfListOfServicoWsModel.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
		}
	}

	private ServicoTO ConstruirServico(ServicoWsModel servicoWs)
	{
		ServicoTO servicoTO = new ServicoTO();
		servicoTO.Id = servicoWs.IDServico;
		servicoTO.CodigoServico = servicoWs.CodigoServico;
		servicoTO.Nome = servicoWs.Nome;
		servicoTO.Principal = servicoWs.Principal;
		servicoTO.Status = Convert.ToBoolean(servicoWs.Status);
		List<ConfiguracaoServicoTO> list = new List<ConfiguracaoServicoTO>();
		ConfiguracaoServicoWsModel[] configuracaoServico = servicoWs.ConfiguracaoServico;
		foreach (ConfiguracaoServicoWsModel configuracaoServicoWsModel in configuracaoServico)
		{
			ConfiguracaoServicoTO configuracaoServicoTO = new ConfiguracaoServicoTO();
			configuracaoServicoTO.Dia = configuracaoServicoWsModel.Dia;
			configuracaoServicoTO.HorarioInicio = configuracaoServicoWsModel.HorarioInicio;
			configuracaoServicoTO.HorarioTermino = configuracaoServicoWsModel.HorarioTermino;
			configuracaoServicoTO.Id = configuracaoServicoWsModel.IDConfiguracaoServico;
			configuracaoServicoTO.IdServico = configuracaoServicoWsModel.IDServico;
			configuracaoServicoTO.Intervalo = configuracaoServicoWsModel.Intervalo;
			list.Add(configuracaoServicoTO);
		}
		servicoTO.ConfiguracaoServico = list;
		return servicoTO;
	}
}
