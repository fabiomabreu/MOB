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

internal class ImportPagamento
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportPagamento(string stringConnTargetMob, string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetMob = stringConnTargetMob;
		_StringConnTargetErp = stringConnTargetErp;
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
			RetornoWsModelOfListOfPagamentoWsModel retornoWsModelOfListOfPagamentoWsModel = wsErpSoapClient.WsERP_Pagamento_Get(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfListOfPagamentoWsModel.RetornoWs != null)
			{
				dbConnection.Open();
				dbConnection2.Open();
				PagamentoWsModel[] retornoWs = retornoWsModelOfListOfPagamentoWsModel.RetornoWs;
				foreach (PagamentoWsModel pagamentoWsModel in retornoWs)
				{
					PagamentoTO pagamento = construirPagamento(pagamentoWsModel);
					if (!PagamentoBLL.Exists(dbConnection, pagamento))
					{
						dbConnection.BeginTransaction();
						PagamentoBLL.Insert(dbConnection, pagamento);
						dbConnection.CommitTransaction();
					}
					wsErpSoapClient.WsERP_Pagamento_SetImport(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), pagamentoWsModel.IdPagamento);
				}
				return;
			}
			throw new Exception(retornoWsModelOfListOfPagamentoWsModel.Excecao.Erro);
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

	private PagamentoTO construirPagamento(PagamentoWsModel Pagamento)
	{
		return new PagamentoTO
		{
			CdClien = Pagamento.CodigoCliente,
			DataPgto = Pagamento.DataPgto,
			TpPgto = Pagamento.FormaPgto,
			ValorPgto = Pagamento.ValorPgto,
			CdVend = Pagamento.CodigoVendedor,
			DataImportacao = DateTime.Now
		};
	}
}
