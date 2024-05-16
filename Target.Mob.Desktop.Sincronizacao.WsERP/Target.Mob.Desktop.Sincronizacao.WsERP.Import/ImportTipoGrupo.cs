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

public class ImportTipoGrupo
{
	private string _StringConnTargetMob;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportTipoGrupo(string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetMob);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			RetornoWsModelOfListOfTipoGrupoSPWsModel retornoWsModelOfListOfTipoGrupoSPWsModel = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_TipoGrupoSP_GetV2(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
			if (retornoWsModelOfListOfTipoGrupoSPWsModel.RetornoWs != null)
			{
				dbConnection.Open();
				dbConnection.BeginTransaction();
				TipoGrupoSPBLL.LimparTipoGrupo(dbConnection);
				TipoGrupoSPWsModel[] retornoWs = retornoWsModelOfListOfTipoGrupoSPWsModel.RetornoWs;
				foreach (TipoGrupoSPWsModel tipoGrupoWs in retornoWs)
				{
					TipoGrupoSPBLL.Merge(dbConnection, ConstruirTipoGrupo(tipoGrupoWs));
				}
				dbConnection.CommitTransaction();
				dbConnection.Close();
				return;
			}
			throw new Exception(retornoWsModelOfListOfTipoGrupoSPWsModel.Excecao.Erro);
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

	private TipoGrupoSPTO ConstruirTipoGrupo(TipoGrupoSPWsModel TipoGrupoWs)
	{
		TipoGrupoSPTO tipoGrupoSPTO = new TipoGrupoSPTO();
		tipoGrupoSPTO.IDTipoGrupoSP = TipoGrupoWs.IDTipoGrupoSP;
		tipoGrupoSPTO.IDTipoGrupo = TipoGrupoWs.IDTipoGrupo;
		tipoGrupoSPTO.IDCadastroSP = TipoGrupoWs.IDCadastroSP;
		TipoGrupoWsModel[] listTipoGrupoWs = TipoGrupoWs.ListTipoGrupoWs;
		foreach (TipoGrupoWsModel tipoGrupoWs in listTipoGrupoWs)
		{
			tipoGrupoSPTO.ListTipoGrupoTO.Add(ConstruirTipoGrupoTO(tipoGrupoWs));
		}
		CadastroSPWsModel[] listaCadastroSPWs = TipoGrupoWs.ListaCadastroSPWs;
		foreach (CadastroSPWsModel cadastroSPWS in listaCadastroSPWs)
		{
			tipoGrupoSPTO.ListaCadastroSPTO.Add(ConstruirCadastroSPTO(cadastroSPWS));
		}
		VendedorWsModel[] listaVendedorWs = TipoGrupoWs.ListaVendedorWs;
		foreach (VendedorWsModel vendedorWs in listaVendedorWs)
		{
			tipoGrupoSPTO.ListaVendedorTO.Add(ConstruirVendedorTO(vendedorWs));
		}
		return tipoGrupoSPTO;
	}

	private TipoGrupoTO ConstruirTipoGrupoTO(TipoGrupoWsModel tipoGrupoWs)
	{
		return new TipoGrupoTO
		{
			IdTipoGrupo = tipoGrupoWs.IdTipoGrupo,
			Descricao = tipoGrupoWs.Descricao,
			Ativo = tipoGrupoWs.Ativo
		};
	}

	private CadastroSPTO ConstruirCadastroSPTO(CadastroSPWsModel cadastroSPWS)
	{
		return new CadastroSPTO
		{
			IDCadastroSP = cadastroSPWS.IDCadastroSP,
			Descricao = cadastroSPWS.Descricao,
			Texto = cadastroSPWS.Texto,
			Ativo = cadastroSPWS.Ativo,
			Automatica = cadastroSPWS.Automatica
		};
	}

	private VendedorRelatorioTO ConstruirVendedorTO(VendedorWsModel vendedorWs)
	{
		return new VendedorRelatorioTO
		{
			IdVendedor = vendedorWs.IDVendedor,
			CodigoVendedor = vendedorWs.CodigoVendedor,
			IDTipoGrupo = vendedorWs.IDTipoGrupo
		};
	}
}
