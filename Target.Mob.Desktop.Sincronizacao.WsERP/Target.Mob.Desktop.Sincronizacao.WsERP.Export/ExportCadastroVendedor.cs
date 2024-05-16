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

internal class ExportCadastroVendedor
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroVendedor(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.Vendedor, Seguranca.getHostName());
			dbConnection.Open();
			VendedorErpTO[] array = VendedorErpBLL.Select(dbConnection, null, null, null, null, rowId, null);
			if (array != null)
			{
				List<VendedorWsModel> list = new List<VendedorWsModel>();
				VendedorErpTO[] array2 = array;
				foreach (VendedorErpTO vendedorErpTO in array2)
				{
					VendedorWsModel vendedorWsModel = new VendedorWsModel();
					vendedorWsModel.CodigoVendedor = vendedorErpTO.CdVend;
					vendedorWsModel.Nome = vendedorErpTO.Nome;
					vendedorWsModel.Ativo = vendedorErpTO.Ativo;
					vendedorWsModel.UtilizaPocket = vendedorErpTO.UtilizaPalmTop;
					vendedorWsModel.RowId = vendedorErpTO.RowId;
					vendedorWsModel.CdEquipe = vendedorErpTO.CdEquipe;
					vendedorWsModel.CodigoEmpresa = vendedorErpTO.CodigoEmpresa;
					vendedorWsModel.MunicRes = vendedorErpTO.MunicRes;
					vendedorWsModel.Logradouro = vendedorErpTO.Logradouro;
					vendedorWsModel.Numero = vendedorErpTO.Numero;
					vendedorWsModel.Pais = vendedorErpTO.Pais;
					vendedorWsModel.Complemento = vendedorErpTO.Complemento;
					vendedorWsModel.EstRes = vendedorErpTO.EstRes;
					vendedorWsModel.CepRes = vendedorErpTO.CepRes;
					vendedorWsModel.Latitude = vendedorErpTO.Latitude;
					vendedorWsModel.Longitude = vendedorErpTO.Longitude;
					vendedorWsModel.CPF = vendedorErpTO.CGC;
					list.Add(vendedorWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_Vendedor_Setar(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
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
