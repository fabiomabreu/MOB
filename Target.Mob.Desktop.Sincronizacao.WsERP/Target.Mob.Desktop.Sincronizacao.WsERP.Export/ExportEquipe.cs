using System;
using System.Collections.Generic;
using System.Diagnostics;
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

internal class ExportEquipe
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportEquipe(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.Equipe, Seguranca.getHostName());
			dbConnection.Open();
			EquipeTO[] array = EquipeBLL.Select(dbConnection, null, null, null, true, null, rowId, null);
			if (array != null)
			{
				List<EquipeWsModel> list = new List<EquipeWsModel>();
				EquipeTO[] array2 = array;
				foreach (EquipeTO equipeTO in array2)
				{
					EquipeWsModel equipeWsModel = new EquipeWsModel();
					equipeWsModel.CdEquipe = equipeTO.CdEquipe;
					equipeWsModel.Descricao = equipeTO.Descricao;
					equipeWsModel.CdVendSup = equipeTO.CdVendSup;
					equipeWsModel.Ativo = equipeTO.Ativo;
					equipeWsModel.CdGerencia = equipeTO.CdGerencia;
					equipeWsModel.RowId = equipeTO.RowId;
					equipeWsModel.CodigoEmpresa = equipeTO.CodigoEmpresa;
					list.Add(equipeWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_Equipe_Set(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), list.ToArray());
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
