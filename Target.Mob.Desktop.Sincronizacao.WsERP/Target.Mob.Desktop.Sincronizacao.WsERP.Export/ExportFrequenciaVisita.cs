using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

public class ExportFrequenciaVisita
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportFrequenciaVisita(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Exportar(object eventosAtivos)
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			byte[] rowID = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.FrequenciaVisita, Seguranca.getHostName());
			dbConnection.Open();
			FrequenciaVisitaTO frequenciaVisitaTO = new FrequenciaVisitaTO();
			frequenciaVisitaTO.RowID = rowID;
			FrequenciaVisitaTO[] array = FrequenciaVisitaBLL.Select(dbConnection, frequenciaVisitaTO);
			if (array != null && array.Count() > 0)
			{
				List<FrequenciaVisitaWsModel> list = new List<FrequenciaVisitaWsModel>();
				FrequenciaVisitaTO[] array2 = array;
				foreach (FrequenciaVisitaTO frequenciaVisitaTO2 in array2)
				{
					FrequenciaVisitaWsModel frequenciaVisitaWsModel = new FrequenciaVisitaWsModel();
					frequenciaVisitaWsModel.FrequenciaVisitaID = frequenciaVisitaTO2.FrequenciaVisitaID;
					frequenciaVisitaWsModel.Descricao = frequenciaVisitaTO2.Descricao;
					frequenciaVisitaWsModel.TipoFrequencia = frequenciaVisitaTO2.TipoFrequencia;
					frequenciaVisitaWsModel.Quantidade = frequenciaVisitaTO2.Quantidade;
					frequenciaVisitaWsModel.Ativo = frequenciaVisitaTO2.Ativo;
					frequenciaVisitaWsModel.RowID = frequenciaVisitaTO2.RowID;
					list.Add(frequenciaVisitaWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_FrequenciaVisita_Set(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), list.ToArray());
				if (!retornoWsModelOfBoolean.RetornoWs)
				{
					throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
				}
			}
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			((CountdownEvent)eventosAtivos).Signal();
		}
	}
}
