using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportForcaCargaCompleta
{
	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportForcaCargaCompleta(string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			RetornoWsModelOfListOfVendedorWsModel retornoWsModelOfListOfVendedorWsModel = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Forca_Carga_CompletaV2(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfListOfVendedorWsModel.RetornoWs != null)
			{
				dbConnection.Open();
				VendedorWsModel[] retornoWs = retornoWsModelOfListOfVendedorWsModel.RetornoWs;
				foreach (VendedorWsModel vendedorWsModel in retornoWs)
				{
					VendedorBLL.ForcaCargaCompleta(dbConnection.GetConnection(), vendedorWsModel.IDVendedor);
				}
				dbConnection.Close();
				return;
			}
			throw new Exception(retornoWsModelOfListOfVendedorWsModel.Excecao.Erro);
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
}
