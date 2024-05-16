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

internal class ExportCadastroVisita
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroVisita(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			dbConnection.Open();
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.AcaVisitas, Seguranca.getHostName());
			AcaVisitasTO[] array = AcaVisitasBLL.SelectExport(dbConnection, rowId);
			if (array == null || array.Count() <= 0)
			{
				return;
			}
			do
			{
				List<AcaVisitasWsModel> list = new List<AcaVisitasWsModel>();
				AcaVisitasTO[] array2 = array;
				foreach (AcaVisitasTO acaVisitasTO in array2)
				{
					AcaVisitasWsModel acaVisitasWsModel = new AcaVisitasWsModel();
					acaVisitasWsModel.SeqVisita = acaVisitasTO.SeqVisita;
					acaVisitasWsModel.CodigoVendedor = acaVisitasTO.CdVend;
					acaVisitasWsModel.CodigoCliente = acaVisitasTO.CdClien;
					acaVisitasWsModel.DtVisita = acaVisitasTO.DtVisita;
					acaVisitasWsModel.HrVisita = acaVisitasTO.HrVisita;
					acaVisitasWsModel.DtUltVisita = acaVisitasTO.DtUltVisita;
					acaVisitasWsModel.VisitaExcluida = acaVisitasTO.VisitaExcluida;
					acaVisitasWsModel.RowId = acaVisitasTO.RowId;
					acaVisitasWsModel.FrequenciaVisitaID = acaVisitasTO.FrequenciaVisitaID;
					acaVisitasWsModel.OpcoesRota = acaVisitasTO.OpcoesRota;
					acaVisitasWsModel.VisitaTelefonica = acaVisitasTO.VisitaTelefonica;
					list.Add(acaVisitasWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_AcaVisitas_Set(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), list.ToArray());
				if (!retornoWsModelOfBoolean.RetornoWs)
				{
					throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
				}
				rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.AcaVisitas, Seguranca.getHostName());
				array = AcaVisitasBLL.SelectExport(dbConnection, rowId);
			}
			while (array.Count() > 0);
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
