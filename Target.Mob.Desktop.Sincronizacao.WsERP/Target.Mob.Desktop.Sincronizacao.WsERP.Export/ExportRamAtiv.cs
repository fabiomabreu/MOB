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

public class ExportRamAtiv
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportRamAtiv(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.RamAtiv, Seguranca.getHostName());
			dbConnection.Open();
			RamAtivTO ramAtivTO = new RamAtivTO();
			ramAtivTO.RowId = rowId;
			List<RamAtivTO> list = RamAtivBLL.Select(dbConnection, ramAtivTO);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			List<RamAtivWsModel> list2 = new List<RamAtivWsModel>();
			foreach (RamAtivTO item in list)
			{
				RamAtivWsModel ramAtivWsModel = new RamAtivWsModel();
				ramAtivWsModel.Codigo = item.Codigo;
				ramAtivWsModel.Descricao = item.Descricao;
				ramAtivWsModel.Ativo = item.Ativo;
				ramAtivWsModel.RamAtivId = item.RamAtivId;
				ramAtivWsModel.RowId = item.RowId;
				list2.Add(ramAtivWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_RamAtiv_Set(validationSoapHeader, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
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
