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

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportRelatorios
{
	private string _StringConnTargetMob;

	private RelatorioGerencialTO _RelatorioTO;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportRelatorios(string stringConnTargetMob, string cnpjEmpresa, RelatorioGerencialTO relatorioTo, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_RelatorioTO = relatorioTo;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Exportar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetMob);
		try
		{
			dbConnection.Open();
			RelatorioGerencialWsModel relatorioGerencialWsModel = ConstruirRelatorioGerencialWs(dbConnection);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			relatorioGerencialWsModel.DtImportacao = null;
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_RelatorioGeral_Setar(validationSoapHeader, _CnpjEmpresa, relatorioGerencialWsModel, Seguranca.getHostName());
			if (retornoWsModelOfBoolean.RetornoWs)
			{
				dbConnection.Open();
				RelatorioGerencialBLL.SetTransmitido(dbConnection, _RelatorioTO);
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
		}
		finally
		{
			dbConnection.Close();
		}
	}

	private RelatorioGerencialWsModel ConstruirRelatorioGerencialWs(DbConnection connTargetMob)
	{
		return new RelatorioGerencialWsModel
		{
			IDRelatorioGerencial = _RelatorioTO.IDRelatorioGerencial,
			IDVendedor = _RelatorioTO.IDVendedor,
			CodigoVendedor = _RelatorioTO.CodigoVendedor,
			NomeArquivo = _RelatorioTO.NomeArquivo,
			ArquivoRelatorio = _RelatorioTO.ArquivoRelatorio,
			DtRecebimento = _RelatorioTO.DtRecebimento,
			DtImportacao = null
		};
	}
}
