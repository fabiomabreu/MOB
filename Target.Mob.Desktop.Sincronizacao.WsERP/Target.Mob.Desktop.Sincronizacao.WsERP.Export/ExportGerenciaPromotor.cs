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

internal class ExportGerenciaPromotor
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportGerenciaPromotor(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.GerenciaPromotor, Seguranca.getHostName());
			dbConnection.Open();
			GerenciaPromotorTO gerenciaPromotorTO = new GerenciaPromotorTO();
			gerenciaPromotorTO.RowId = rowId;
			List<GerenciaPromotorTO> list = GerenciaPromotorBLL.SelectRowId(dbConnection, gerenciaPromotorTO);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			List<GerenciaPromotorWsModel> list2 = new List<GerenciaPromotorWsModel>();
			foreach (GerenciaPromotorTO item in list)
			{
				GerenciaPromotorWsModel gerenciaPromotorWsModel = new GerenciaPromotorWsModel();
				gerenciaPromotorWsModel.GerenciaPromotorId = item.GerenciaPromotorId;
				gerenciaPromotorWsModel.CdEmp = item.CdEmp;
				gerenciaPromotorWsModel.CdGerencia = item.CdGerencia;
				gerenciaPromotorWsModel.Descricao = item.Descricao;
				gerenciaPromotorWsModel.CdPromotorGerente = item.CdPromotorGerente;
				gerenciaPromotorWsModel.Ativo = item.Ativo;
				gerenciaPromotorWsModel.RowId = item.RowId;
				list2.Add(gerenciaPromotorWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_GerenciaPromotor_Set(validationSoapHeader, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
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
