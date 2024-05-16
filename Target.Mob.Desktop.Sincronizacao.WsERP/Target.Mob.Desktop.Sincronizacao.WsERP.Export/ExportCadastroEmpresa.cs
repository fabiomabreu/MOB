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

internal class ExportCadastroEmpresa
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroEmpresa(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.Empresa, Seguranca.getHostName());
			dbConnection.Open();
			EmpresaTO[] array = EmpresaBLL.Select(dbConnection, null, null, null, null, null, rowId);
			if (array != null)
			{
				List<EmpresaWsModel> list = new List<EmpresaWsModel>();
				EmpresaTO[] array2 = array;
				foreach (EmpresaTO empresaTO in array2)
				{
					EmpresaWsModel empresaWsModel = new EmpresaWsModel();
					empresaWsModel.CodigoEmpresa = empresaTO.CdEmp;
					empresaWsModel.RazaoSocial = empresaTO.RazSoc;
					empresaWsModel.NomeFantazia = empresaTO.NomeFant;
					empresaWsModel.CGC = empresaTO.Cgc;
					empresaWsModel.Ativo = empresaTO.Ativo;
					empresaWsModel.RowId = empresaTO.RowId;
					empresaWsModel.Endereco = empresaTO.Endereco;
					empresaWsModel.Numero = empresaTO.Numero;
					empresaWsModel.Complemento = empresaTO.Complemento;
					empresaWsModel.Bairro = empresaTO.Bairro;
					empresaWsModel.Municipio = empresaTO.Municipio;
					empresaWsModel.Cep = empresaTO.Cep;
					empresaWsModel.Estado = empresaTO.Estado;
					list.Add(empresaWsModel);
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_Empresa_Setar(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
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
