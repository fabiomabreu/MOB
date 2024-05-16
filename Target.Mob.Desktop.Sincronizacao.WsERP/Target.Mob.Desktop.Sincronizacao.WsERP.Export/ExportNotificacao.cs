using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportNotificacao
{
	private string StringConnTargetMob;

	private string CnpjEmpresa;

	private string NomeServidorOrigem;

	private string NomeDbOrigem;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportNotificacao(string stringConnTargetMob, string cnpjEmpresa, string nomeServidorOrigem, string nomeDbOrigem, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		StringConnTargetMob = stringConnTargetMob;
		CnpjEmpresa = cnpjEmpresa;
		NomeServidorOrigem = nomeServidorOrigem;
		NomeDbOrigem = nomeDbOrigem;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Exportar()
	{
		using DbConnection dbConnection = new DbConnection(StringConnTargetMob);
		dbConnection.Open();
		NotificacaoBLL.VerificarNotificacoes(dbConnection, NomeServidorOrigem, NomeDbOrigem);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			RetornoWsModelOfInt32 retornoWsModelOfInt = wsErpSoapClient.WsERP_Notificacao_Get(validationSoapHeader, CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfInt.RetornoWs > -1 && retornoWsModelOfInt.Excecao.IDLogErro == 0)
			{
				NotificacaoTO notificacaoTO = new NotificacaoTO();
				notificacaoTO.IDNotificacao = retornoWsModelOfInt.RetornoWs;
				List<NotificacaoTO> list = NotificacaoBLL.SelectNaoTransmitidas(dbConnection, notificacaoTO);
				if (list.Count() > 0)
				{
					_ = list.Min((NotificacaoTO obj) => obj.IDNotificacao).Value;
					List<NotificacaoWsModel> list2 = new List<NotificacaoWsModel>();
					foreach (NotificacaoTO item in list)
					{
						NotificacaoWsModel notificacaoWsModel = new NotificacaoWsModel();
						notificacaoWsModel.IdNotificacaoRetaguarda = item.IDNotificacao;
						notificacaoWsModel.IdTipoNotificacao = item.IDTipoNotificacao;
						notificacaoWsModel.Titulo = item.Titulo;
						notificacaoWsModel.Descricao = item.Descricao;
						notificacaoWsModel.DataPublicacao = item.DataPublicacao;
						notificacaoWsModel.IdVendedor = item.IDVendedor.Value;
						list2.Add(notificacaoWsModel);
					}
					RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_Notificacao_Set(validationSoapHeader, CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
					if (!retornoWsModelOfBoolean.RetornoWs)
					{
						throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
					}
					NotificacaoBLL.AtualizarTransmitidos(dbConnection, retornoWsModelOfInt.RetornoWs);
				}
			}
			dbConnection.Close();
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
