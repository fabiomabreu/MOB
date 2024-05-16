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

public class ExportGrupoCli
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportGrupoCli(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.GrupoCli, Seguranca.getHostName());
			dbConnection.Open();
			GrupoCliTO grupoCliTO = new GrupoCliTO();
			grupoCliTO.RowId = rowId;
			List<GrupoCliTO> list = GrupoCliBLL.Select(dbConnection, grupoCliTO);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			List<GrupoCliWsModel> list2 = new List<GrupoCliWsModel>();
			foreach (GrupoCliTO item in list)
			{
				GrupoCliWsModel grupoCliWsModel = new GrupoCliWsModel();
				grupoCliWsModel.Codigo = item.Codigo;
				grupoCliWsModel.Descricao = item.Descricao;
				grupoCliWsModel.Ativo = item.Ativo;
				grupoCliWsModel.GrupoCliId = item.GrupoCliId;
				grupoCliWsModel.RowId = item.RowId;
				list2.Add(grupoCliWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_GrupoCli_Set(validationSoapHeader, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
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
