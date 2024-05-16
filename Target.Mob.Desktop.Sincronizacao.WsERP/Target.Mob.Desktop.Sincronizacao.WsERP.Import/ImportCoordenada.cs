using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportCoordenada
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportCoordenada(string stringConnTargetErp, string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			RetornoWsModelOfListOfCoordenadaClienteWsModel retornoWsModelOfListOfCoordenadaClienteWsModel = wsErpSoapClient.WsERP_CoordenadaCliente_Get(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfListOfCoordenadaClienteWsModel.RetornoWs != null)
			{
				CoordenadaClienteWsModel[] retornoWs = retornoWsModelOfListOfCoordenadaClienteWsModel.RetornoWs;
				foreach (CoordenadaClienteWsModel coordenadaClienteWsModel in retornoWs)
				{
					if (coordenadaClienteWsModel.ClienteBDMovimento == false)
					{
						dbConnection.Open();
						dbConnection2.Open();
						bool atualiza = false;
						EndCliTO endCli = ConstruirEndereco(dbConnection, coordenadaClienteWsModel, ref atualiza);
						if (atualiza)
						{
							EndCliBLL.Update(dbConnection, endCli);
						}
						else
						{
							string codigoVendedor = null;
							if (coordenadaClienteWsModel.IdVendedor.HasValue)
							{
								VendedorTO vendedorTO = VendedorBLL.Select(dbConnection2.GetConnection(), coordenadaClienteWsModel.IdVendedor.Value);
								if (vendedorTO != null)
								{
									codigoVendedor = vendedorTO.CodigoVendedor;
								}
							}
							else if (coordenadaClienteWsModel.PromotorId.HasValue)
							{
								codigoVendedor = PromotorBLL.SelectById(dbConnection, coordenadaClienteWsModel.PromotorId.Value).CdPromotor;
							}
							CoordenadaClienteBLL.InsereCoordenadaCliente(dbConnection, coordenadaClienteWsModel.CodigoCliente, coordenadaClienteWsModel.Latitude, coordenadaClienteWsModel.Longitude, codigoVendedor, coordenadaClienteWsModel.DtCoordenada);
						}
					}
					wsErpSoapClient.WsERP_CoordenadaCliente_SetImport(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), coordenadaClienteWsModel.IdCoordenadaCliente);
				}
				return;
			}
			throw new Exception(retornoWsModelOfListOfCoordenadaClienteWsModel.Excecao.Erro);
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

	public EndCliTO ConstruirEndereco(DbConnection connTargetErp, CoordenadaClienteWsModel coordenadaClienteWs, ref bool atualiza)
	{
		EndCliTO endCliTO = new EndCliTO();
		int num = 0;
		endCliTO.CdClien = coordenadaClienteWs.CodigoCliente.Value;
		if (coordenadaClienteWs.CodigoTipoEndereco.Equals("CO"))
		{
			num = 1;
		}
		else if (coordenadaClienteWs.CodigoTipoEndereco.Equals("FA"))
		{
			num = 3;
		}
		else if (coordenadaClienteWs.CodigoTipoEndereco.Equals("EN"))
		{
			num = 2;
		}
		endCliTO.TpEnd = (TipoEndereco)Enum.Parse(typeof(TipoEndereco), num.ToString());
		EndCliTO[] array = EndCliBLL.Select(connTargetErp, coordenadaClienteWs.CodigoCliente, coordenadaClienteWs.CodigoTipoEndereco);
		if (array != null && array.Length != 0)
		{
			endCliTO = array[0];
			if (endCliTO.Latitude.HasValue)
			{
				decimal? latitude = endCliTO.Latitude;
				if (!((latitude.GetValueOrDefault() == default(decimal)) & latitude.HasValue) && endCliTO.Longitude.HasValue)
				{
					latitude = endCliTO.Longitude;
					if (!((latitude.GetValueOrDefault() == default(decimal)) & latitude.HasValue))
					{
						goto IL_013a;
					}
				}
			}
			endCliTO.Latitude = coordenadaClienteWs.Latitude;
			endCliTO.Longitude = coordenadaClienteWs.Longitude;
			endCliTO.CodigoProvedorCoordenada = coordenadaClienteWs.CodigoProvedorCoordenada;
			atualiza = true;
		}
		goto IL_013a;
		IL_013a:
		return endCliTO;
	}
}
