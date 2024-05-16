using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

internal class ExportCadastroCliente
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroCliente(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.ClienteERP, Seguranca.getHostName());
			dbConnection.Open();
			ClienteTO[] array = ClienteBLL.SelectExport(dbConnection, rowId);
			if (array == null)
			{
				return;
			}
			int num = array.Count();
			int num2 = array.Count();
			int num3 = 0;
			while (num2 > 0)
			{
				List<ClienteERPWsModel> list = new List<ClienteERPWsModel>();
				for (int i = num3; i < num3 + 1000; i++)
				{
					if (i < num)
					{
						ClienteTO clienteTO = array[i];
						ClienteERPWsModel clienteERPWsModel = new ClienteERPWsModel();
						if (clienteTO.oEndCli != null && clienteTO.oEndCli.Length != 0)
						{
							clienteERPWsModel.CnpjCpf = clienteTO.CgcCpf;
							clienteERPWsModel.CodigoCliente = clienteTO.CdClien;
							clienteERPWsModel.CodigoGrupoCli = clienteTO.CdGrupocli;
							clienteERPWsModel.CodigoVendedor = clienteTO.CdVend;
							clienteERPWsModel.CodigoRamAtiv = clienteTO.RamAtiv;
							clienteERPWsModel.CodigoStCred = clienteTO.StCred;
							clienteERPWsModel.CodigoTpPed = clienteTO.TpPed;
							clienteERPWsModel.DtUltimaCompra = clienteTO.DtUltCompra;
							clienteERPWsModel.Email = clienteTO.EMail;
							clienteERPWsModel.Inscricao = clienteTO.Inscricao;
							clienteERPWsModel.NomeFantasia = clienteTO.NomeRes;
							clienteERPWsModel.RazaoSocial = clienteTO.Nome;
							clienteERPWsModel.TipoFrete = clienteTO.TpFrete.ToString();
							clienteERPWsModel.TipoInscricao = clienteTO.TpInscr.ToString();
							clienteERPWsModel.TipoPessoa = clienteTO.TpCliente.ToString();
							clienteERPWsModel.Ativo = clienteTO.Ativo;
							clienteERPWsModel.CdArea = clienteTO.CdArea;
							clienteERPWsModel.QtdeCheckOut = ((!clienteTO.QtdeCheckout.HasValue) ? null : ((short?)clienteTO.QtdeCheckout));
							clienteERPWsModel.RowId = clienteTO.RowId;
							clienteERPWsModel.EndCliERPWs = ConstruirWSEndereco(clienteTO.oEndCli);
							list.Add(clienteERPWsModel);
						}
					}
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_ClienteERP_Set(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), list.ToArray());
				if (!retornoWsModelOfBoolean.RetornoWs)
				{
					throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
				}
				num2 -= 1000;
				num3 += 1000;
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

	private EndCliERPWsModel[] ConstruirWSEndereco(EndCliTO[] endCliTO)
	{
		List<EndCliERPWsModel> list = new List<EndCliERPWsModel>();
		foreach (EndCliTO endCliTO2 in endCliTO)
		{
			EndCliERPWsModel endCliERPWsModel = new EndCliERPWsModel();
			endCliERPWsModel.Bairro = endCliTO2.Bairro;
			endCliERPWsModel.Cep = endCliTO2.Cep;
			endCliERPWsModel.CodigoEstado = endCliTO2.Estado;
			endCliERPWsModel.CodigoProvedorCoordenada = endCliTO2.CodigoProvedorCoordenada;
			endCliERPWsModel.Latitude = endCliTO2.Latitude;
			endCliERPWsModel.Longitude = endCliTO2.Longitude;
			endCliERPWsModel.Municipio = endCliTO2.Municipio;
			string[] array = endCliTO2.Endereco.Split(',');
			endCliERPWsModel.Logradouro = ((endCliTO2.Logradouro != null && !(endCliTO2.Logradouro == string.Empty)) ? endCliTO2.Logradouro : ((array.Length != 0) ? array[0].ToString() : endCliTO2.Logradouro));
			endCliERPWsModel.Numero = ((endCliTO2.Numero != null && !(endCliTO2.Numero == string.Empty)) ? endCliTO2.Numero : ((array.Length > 1) ? array[1].ToString() : endCliTO2.Numero));
			endCliERPWsModel.Complemento = ((endCliTO2.Complemento != null && !(endCliTO2.Complemento == string.Empty)) ? endCliTO2.Complemento : ((array.Length > 2) ? array[2].ToString() : endCliTO2.Complemento));
			endCliERPWsModel.Logradouro = ((endCliTO2.Logradouro == null || endCliTO2.Logradouro == string.Empty) ? endCliTO2.Endereco : endCliTO2.Logradouro);
			endCliERPWsModel.TipoEndereco = endCliTO2.TpEnd.ToString().ToUpper();
			list.Add(endCliERPWsModel);
		}
		return list.ToArray();
	}
}
