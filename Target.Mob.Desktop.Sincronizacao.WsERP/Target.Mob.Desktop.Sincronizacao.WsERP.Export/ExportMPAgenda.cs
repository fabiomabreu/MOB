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

public class ExportMPAgenda
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportMPAgenda(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.MPAgenda, Seguranca.getHostName());
			dbConnection.Open();
			List<MPAgendaTO> list = MPAgendaBLL.SelectExport(dbConnection, rowId);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			List<MPAgendaWsModel> list2 = new List<MPAgendaWsModel>();
			foreach (MPAgendaTO item in list)
			{
				MPAgendaWsModel mPAgendaWsModel = new MPAgendaWsModel();
				mPAgendaWsModel.SeqVisita = item.SeqVisita;
				mPAgendaWsModel.PromotorId = item.PromotorId;
				mPAgendaWsModel.CodigoCliente = item.CodigoCliente;
				mPAgendaWsModel.DtVisita = item.DtVisita;
				mPAgendaWsModel.HrVisita = item.HrVisita;
				mPAgendaWsModel.DtUltVisita = item.DtUltVisita;
				mPAgendaWsModel.VisitaExcluida = item.VisitaExcluida;
				mPAgendaWsModel.VisitaTelefonica = item.VisitaTelefonica;
				mPAgendaWsModel.OpcoesRota = item.OpcoesRota;
				mPAgendaWsModel.FrequenciaVisitaID = item.FrequenciaVisitaId;
				mPAgendaWsModel.RowId = item.RowId;
				list2.Add(mPAgendaWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_MPAgenda_Set(validationSoapHeader, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
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
