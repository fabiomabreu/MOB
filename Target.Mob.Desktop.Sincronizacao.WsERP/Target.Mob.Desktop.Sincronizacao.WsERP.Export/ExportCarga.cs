using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Geracao.Bll;
using Target.Mob.Desktop.Geracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportCarga
{
	private string _StringConnTargetMob;

	private CargaTO _Carga;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCarga(string stringConnTargetMob, string cnpjEmpresa, CargaTO carga, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_Carga = carga;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Exportar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetMob);
		try
		{
			dbConnection.Open();
			CargaWsModel cargaWs = ConstruirCargaWs(dbConnection);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_Carga_Setar(validationSoapHeader, _CnpjEmpresa, cargaWs, Seguranca.getHostName());
			if (retornoWsModelOfBoolean.RetornoWs)
			{
				dbConnection.Open();
				CargaBLL.SetTransmitido(dbConnection.GetConnection(), _Carga.Id);
				dbConnection.Close();
				dbConnection.Close();
				return;
			}
			throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
			throw ex;
		}
		finally
		{
			dbConnection.Close();
		}
	}

	private CargaWsModel ConstruirCargaWs(DbConnection connTargetMob)
	{
		CargaWsModel obj = new CargaWsModel
		{
			CodigoCarga = _Carga.Id,
			DataGeracao = _Carga.DataGeracao,
			IDVersaoCarga = Convert.ToInt32(_Carga.IdVersaoCarga),
			IDGeracao = _Carga.IdGeracao,
			IDTipoCargaTR = Convert.ToInt32(_Carga.TipoCarga),
			ArquivoCarga = _Carga.ArquivoCarga,
			IDVendedor = _Carga.IdVendedor
		};
		VersaoCargaTO versaoCargaTO = VersaoCargaBLL.Select(connTargetMob.GetConnection(), Convert.ToInt32(_Carga.IdVersaoCarga));
		obj.Major = versaoCargaTO.Major;
		obj.Minor = versaoCargaTO.Minor;
		obj.Build = versaoCargaTO.Build;
		obj.Revision = versaoCargaTO.Revision;
		return obj;
	}
}
