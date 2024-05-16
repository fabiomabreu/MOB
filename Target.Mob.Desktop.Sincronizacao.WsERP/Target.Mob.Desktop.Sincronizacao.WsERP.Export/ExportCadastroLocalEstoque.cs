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

internal class ExportCadastroLocalEstoque
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroLocalEstoque(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.LocalEstoque, Seguranca.getHostName());
			dbConnection.Open();
			LocalTO[] array = LocalBLL.Select(dbConnection, null, null, null, rowId);
			if (array != null)
			{
				List<LocalEstoqueWsModel> list = new List<LocalEstoqueWsModel>();
				LocalTO[] array2 = array;
				foreach (LocalTO localTO in array2)
				{
					LocalEstoqueWsModel localEstoqueWsModel = new LocalEstoqueWsModel();
					localEstoqueWsModel.CodigoEmpresa = localTO.CdEmp;
					localEstoqueWsModel.Local = localTO.CdLocal;
					localEstoqueWsModel.Ativo = localTO.Ativo;
					localEstoqueWsModel.RowId = localTO.RowID;
					list.Add(localEstoqueWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_LocalEstoque_Setar(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
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
