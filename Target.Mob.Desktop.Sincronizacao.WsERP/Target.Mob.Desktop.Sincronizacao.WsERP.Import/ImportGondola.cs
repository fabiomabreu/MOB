using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportGondola
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportGondola(string stringConnTargetErp, string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		using DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			RetornoWsModelOfListOfGondolaWsModel retornoWsModelOfListOfGondolaWsModel = wsErpSoapClient.WsERP_Gondola_Get(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfListOfGondolaWsModel.RetornoWs != null)
			{
				dbConnection.Open();
				dbConnection2.Open();
				GondolaWsModel[] retornoWs = retornoWsModelOfListOfGondolaWsModel.RetornoWs;
				foreach (GondolaWsModel gondolaWsModel in retornoWs)
				{
					GondolaTO gondola = construirGondola(gondolaWsModel);
					GondolaBLL.InsertOrReplace(dbConnection, gondola);
					wsErpSoapClient.WsERP_Gondola_SetImport(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), gondolaWsModel.IdGondola);
				}
				return;
			}
			throw new Exception(retornoWsModelOfListOfGondolaWsModel.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			LogEvento.WriteEntry(GetType().Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			dbConnection2.Close();
		}
	}

	private GondolaTO construirGondola(GondolaWsModel modelWs)
	{
		return new GondolaTO
		{
			Codigo = modelWs.Codigo,
			CodigoCliente = modelWs.CodigoCliente,
			CodigoEmpresa = modelWs.CodigoEmpresa,
			CodigoProduto = modelWs.CodigoProduto,
			Data = modelWs.Data,
			NumeroPedido = modelWs.NumeroPedido,
			PrecoGondola = modelWs.PrecoGondola,
			QtdeEstoqueCliente = modelWs.QtdeEstoqueCliente,
			QtdeGiro = modelWs.QtdeGiro,
			QtdeSaldo = modelWs.QtdeSaldo,
			QtdeSeguranca = modelWs.QtdeSeguranca,
			QtdeSugerida = modelWs.QtdeSugerida,
			QtdeVendaMedia = modelWs.QtdeVendaMedia,
			QtdeVendida = modelWs.QtdeVendida,
			Markup = modelWs.Markup,
			IdVendedor = modelWs.IdVendedor
		};
	}
}
