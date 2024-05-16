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

internal class ExportEquipePromotor
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportEquipePromotor(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.EquipePromotor, Seguranca.getHostName());
			dbConnection.Open();
			EquipePromotorTO equipePromotorTO = new EquipePromotorTO();
			equipePromotorTO.RowId = rowId;
			List<EquipePromotorTO> list = EquipePromotorBLL.SelectRowId(dbConnection, equipePromotorTO);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			List<EquipePromotorWsModel> list2 = new List<EquipePromotorWsModel>();
			foreach (EquipePromotorTO item in list)
			{
				EquipePromotorWsModel equipePromotorWsModel = new EquipePromotorWsModel();
				equipePromotorWsModel.EquipePromotorId = item.EquipePromotorId;
				equipePromotorWsModel.CdEmp = item.CdEmp;
				equipePromotorWsModel.CdEquipe = item.CdEquipe;
				equipePromotorWsModel.Descricao = item.Descricao;
				equipePromotorWsModel.CdPromotorSupervisor = item.CdPromotorSupervisor;
				equipePromotorWsModel.Ativo = item.Ativo;
				equipePromotorWsModel.GerenciaPromotorId = item.GerenciaPromotorId;
				equipePromotorWsModel.RowId = item.RowId;
				list2.Add(equipePromotorWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_EquipePromotor_Set(validationSoapHeader, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
			if (!retornoWsModelOfBoolean.RetornoWs)
			{
				throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
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
