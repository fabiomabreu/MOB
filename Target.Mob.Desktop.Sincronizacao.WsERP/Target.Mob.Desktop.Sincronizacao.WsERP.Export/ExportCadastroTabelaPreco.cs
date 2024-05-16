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

internal class ExportCadastroTabelaPreco
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroTabelaPreco(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.TabelaPreco, Seguranca.getHostName());
			dbConnection.Open();
			TabPreTO[] array = TabPreBLL.Select(dbConnection, null, null, null, rowId);
			if (array != null)
			{
				List<TabelaPrecoWsModel> list = new List<TabelaPrecoWsModel>();
				TabPreTO[] array2 = array;
				foreach (TabPreTO tabPreTO in array2)
				{
					TabelaPrecoWsModel tabelaPrecoWsModel = new TabelaPrecoWsModel();
					tabelaPrecoWsModel.Codigo = tabPreTO.CdTabela;
					tabelaPrecoWsModel.Descricao = tabPreTO.Descricao;
					tabelaPrecoWsModel.Ativo = tabPreTO.Ativo;
					tabelaPrecoWsModel.RowId = tabPreTO.RowId;
					list.Add(tabelaPrecoWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_TabelaPreco_Setar(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
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
