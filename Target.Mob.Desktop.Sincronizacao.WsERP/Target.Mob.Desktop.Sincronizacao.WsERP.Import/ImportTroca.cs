using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportTroca
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private int _IdTroca;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportTroca(string stringConnTargetErp, string stringConnTargetMob, int idTroca, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_IdTroca = idTroca;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar(object eventosAtivos)
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		using DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			RetornoWsModelOfTrocaWsModel retornoWsModelOfTrocaWsModel = wsErpSoapClient.WsERP_Troca_GetV2(validationSoapHeader, _CnpjEmpresa, _IdTroca, Seguranca.getHostName());
			if (retornoWsModelOfTrocaWsModel.RetornoWs != null)
			{
				TrocaWsModel retornoWs = retornoWsModelOfTrocaWsModel.RetornoWs;
				dbConnection.Open();
				dbConnection2.Open();
				TrocaTO troca = ConstruirTroca(dbConnection, dbConnection2, retornoWs);
				dbConnection.BeginTransaction();
				TrocaBLL.Insert(dbConnection, troca);
				if (TrocaDuplicada(dbConnection, troca))
				{
					dbConnection.RollbackTransaction();
				}
				else
				{
					dbConnection.CommitTransaction();
				}
				dbConnection2.Close();
				dbConnection.Close();
				wsErpSoapClient.WsERP_Troca_SetImportar(validationSoapHeader, _CnpjEmpresa, _IdTroca, Seguranca.getHostName());
				return;
			}
			throw new Exception(retornoWsModelOfTrocaWsModel.Excecao.Erro);
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
			((CountdownEvent)eventosAtivos).Signal();
		}
	}

	private TrocaTO ConstruirTroca(DbConnection connTargetErp, DbConnection connTargetMob, TrocaWsModel trocaWs)
	{
		TrocaTO trocaTO = new TrocaTO();
		if (trocaWs.ClienteBDMovimento == true)
		{
			trocaTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(trocaWs.CnpjCpfCliente, trocaWs.IDTroca, "IDTroca", trocaWs.CodigoPais, _StringConnTargetErp).Value;
		}
		else
		{
			trocaTO.CdClien = Convert.ToInt32(trocaWs.CodigoCliente);
		}
		trocaTO.CdEmp = trocaWs.CodigoEmpresa;
		trocaTO.CdEmpEstoque = trocaWs.CodigoEmpresa;
		if (string.IsNullOrEmpty(trocaWs.CodigoMotivoTroca))
		{
			trocaTO.CdMotcanc = "TRPALM";
		}
		else
		{
			trocaTO.CdMotcanc = trocaWs.CodigoMotivoTroca;
		}
		trocaTO.CdTabela = trocaWs.CodigoTabPre;
		trocaTO.CdTrocaPalm = trocaWs.CodigoTrocaPocket.ToString();
		trocaTO.DtCad = Convert.ToDateTime(DateTime.Now.ToShortDateString());
		trocaTO.DtCadPalm = trocaWs.DtTroca;
		trocaTO.AtribuiProdLocaliza(trocaWs.LocalArmazenamentoTroca);
		trocaTO.Situacao = trocaWs.StatusTroca;
		trocaTO.AtribuiTpEnvio("PF");
		trocaTO.VlTotal = trocaWs.ValorRecebido;
		trocaTO.VlTotalRecebido = trocaWs.ValorRecebido;
		trocaTO.Indenizacao = trocaWs.Indenizacao;
		VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), trocaWs.IDVendedor);
		if (vendedorTO != null)
		{
			trocaTO.CdVend = vendedorTO.CodigoVendedor;
			ConfiguracaoVendedorTO configuracaoVendedorTO = ConfiguracaoVendedorBLL.Select(connTargetMob.GetConnection(), Convert.ToInt32(vendedorTO.IdConfiguracaoVendedor));
			if (configuracaoVendedorTO != null)
			{
				trocaTO.AtribuiTpAbatimento(configuracaoVendedorTO.TipoAbatimentoTroca);
				List<ItTrocaTO> list = new List<ItTrocaTO>();
				ItTrocaWsModel[] itTrocaWs = trocaWs.ItTrocaWs;
				foreach (ItTrocaWsModel itTrocaWsModel in itTrocaWs)
				{
					ItTrocaTO itTrocaTO = new ItTrocaTO();
					itTrocaTO.CdProd = Convert.ToInt32(itTrocaWsModel.CodigoProduto);
					itTrocaTO.Qtde = Convert.ToDecimal(itTrocaWsModel.QtdeUnidEstoque);
					itTrocaTO.VlCheio = Convert.ToDecimal(itTrocaWsModel.PrecoTabelaUnidEstoque);
					itTrocaTO.PercIndeniz = Convert.ToDecimal(itTrocaWsModel.PercIndenizacao);
					itTrocaTO.VlUnit = Convert.ToDecimal(itTrocaWsModel.ValorIndenizacao);
					itTrocaTO.QtdeReceb = default(decimal);
					itTrocaTO.VlUnitReceb = default(decimal);
					itTrocaTO.UnidVda = itTrocaWsModel.Unidade;
					itTrocaTO.FatorEstoque = Convert.ToDouble(itTrocaWsModel.Fator);
					itTrocaTO.AtribuiIndRelacao(itTrocaWsModel.IndiceRelacaoProduto);
					itTrocaTO.QtdeRecebVda = default(decimal);
					if (string.Compare(itTrocaWsModel.IndiceRelacaoProduto, "MAIOR", ignoreCase: true) == 0)
					{
						if (itTrocaWsModel.Fator > 0f)
						{
							itTrocaTO.QtdeVda = Convert.ToDecimal(itTrocaWsModel.QtdeUnidEstoque) / Convert.ToDecimal(itTrocaWsModel.Fator);
						}
						else
						{
							itTrocaTO.QtdeVda = 0m;
						}
					}
					else
					{
						itTrocaTO.QtdeVda = Convert.ToDecimal(itTrocaWsModel.QtdeUnidEstoque) * Convert.ToDecimal(itTrocaWsModel.Fator);
					}
					list.Add(itTrocaTO);
				}
				trocaTO.oItTroca = list.ToArray();
				return trocaTO;
			}
			throw new Exception($"Configuração do vendedor não localizada. IdConfiguracao: {vendedorTO.IdConfiguracaoVendedor}");
		}
		throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {trocaWs.IDVendedor}");
	}

	private bool TrocaDuplicada(DbConnection connTargetErp, TrocaTO troca)
	{
		int cdEmp = troca.CdEmp;
		string cdVend = troca.CdVend;
		int cdClien = troca.CdClien;
		DateTime dtCadPalm = Convert.ToDateTime(troca.DtCadPalm);
		string cdTrocaPalm = troca.CdTrocaPalm;
		return TrocaBLL.Count(connTargetErp, cdEmp, cdVend, cdClien, dtCadPalm, cdTrocaPalm) != 1;
	}
}
