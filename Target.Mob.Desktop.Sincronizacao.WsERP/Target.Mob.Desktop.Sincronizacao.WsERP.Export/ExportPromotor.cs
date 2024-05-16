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

internal class ExportPromotor
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportPromotor(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.Promotor, Seguranca.getHostName());
			dbConnection.Open();
			PromotorTO promotorTO = new PromotorTO();
			promotorTO.RowId = rowId;
			List<PromotorTO> list = PromotorBLL.Select(dbConnection, promotorTO);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			List<PromotorWsModel> list2 = new List<PromotorWsModel>();
			foreach (PromotorTO item in list)
			{
				PromotorWsModel promotorWsModel = new PromotorWsModel();
				promotorWsModel.PromotorId = item.PromotorId;
				promotorWsModel.CdPromotor = item.CdPromotor;
				promotorWsModel.CnpjCpf = item.Cgc;
				promotorWsModel.Inscricao = item.Inscricao;
				promotorWsModel.Nome = item.Nome;
				promotorWsModel.Endereco = item.Endereco;
				promotorWsModel.Bairro = item.Bairro;
				promotorWsModel.Municipio = item.Municipio;
				promotorWsModel.Estado = item.Estado;
				promotorWsModel.Cep = item.Cep;
				promotorWsModel.TpPessoa = item.TpPessoa;
				promotorWsModel.Ativo = item.Ativo;
				promotorWsModel.CdCepMunicipio = item.CdCepMunicipio;
				promotorWsModel.Logradouro = item.Logradouro;
				promotorWsModel.Numero = item.Numero;
				promotorWsModel.Complemento = item.Complemento;
				promotorWsModel.CdPais = item.CdPais;
				promotorWsModel.Distrito = item.Distrito;
				promotorWsModel.NomeGuerra = item.NomeGuerra;
				promotorWsModel.EquipePromotorId = item.EquipePromotorId;
				promotorWsModel.Latitude = item.Latitude;
				promotorWsModel.Longitude = item.Longitude;
				promotorWsModel.Email = item.Email;
				promotorWsModel.MontagemRotVisitaId = item.MontagemRotVisitaId;
				promotorWsModel.UtilizaPocket = item.UtilizaPocket;
				promotorWsModel.RowId = item.RowId;
				montaListaTelProm(promotorWsModel, item);
				montaListaContProm(promotorWsModel, item);
				list2.Add(promotorWsModel);
			}
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_Promotor_Set(validationSoapHeader, _CnpjEmpresa, list2.ToArray(), Seguranca.getHostName());
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

	private void montaListaContProm(PromotorWsModel promWsModel, PromotorTO promotor)
	{
		List<ContPromotorWsModel> list = new List<ContPromotorWsModel>();
		foreach (ContPromotorTO item in promotor.ListContPromotor)
		{
			ContPromotorWsModel contPromotorWsModel = new ContPromotorWsModel();
			contPromotorWsModel.ContPromotorId = item.ContPromotorId;
			contPromotorWsModel.CdPromotor = item.CdPromotor;
			contPromotorWsModel.Nome = item.Nome;
			contPromotorWsModel.Cargo = item.Cargo;
			contPromotorWsModel.RowId = item.RowId;
			list.Add(contPromotorWsModel);
		}
		promWsModel.ListContPromotorWsModel = list.ToArray();
	}

	private void montaListaTelProm(PromotorWsModel promWsModel, PromotorTO promotor)
	{
		List<TelPromotorWsModel> list = new List<TelPromotorWsModel>();
		foreach (TelPromotorTO item in promotor.ListTelPromotor)
		{
			TelPromotorWsModel telPromotorWsModel = new TelPromotorWsModel();
			telPromotorWsModel.TelPromotorId = item.TelPromotorId;
			telPromotorWsModel.CdPromotor = item.CdPromotor;
			telPromotorWsModel.Ddd = item.Ddd;
			telPromotorWsModel.NuTel = item.NuTel;
			telPromotorWsModel.Ramal = item.Ramal;
			telPromotorWsModel.TpTel = item.TpTel;
			telPromotorWsModel.RowId = item.RowId;
			list.Add(telPromotorWsModel);
		}
		promWsModel.ListTelPromotorWsModel = list.ToArray();
	}
}
