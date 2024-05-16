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

internal class ExportCadastroProduto
{
	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportCadastroProduto(string stringConnTargetErp, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
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
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.ProdutoErp, Seguranca.getHostName());
			dbConnection.Open();
			ProdutoTO[] array = ProdutoBLL.Select(dbConnection, null, null, null, null, null, null, null, null, null, rowId);
			if (array == null)
			{
				return;
			}
			int num = array.Count();
			int num2 = array.Count();
			int num3 = 0;
			while (num2 > 0)
			{
				List<ProdutoErpWsModel> list = new List<ProdutoErpWsModel>();
				for (int i = num3; i < num3 + 1000; i++)
				{
					if (i < num)
					{
						ProdutoErpWsModel produtoErpWsModel = new ProdutoErpWsModel();
						produtoErpWsModel.Ativo = array[i].Ativo;
						produtoErpWsModel.BloqEnvioPalmTop = array[i].BloqEnvioPalmTop;
						produtoErpWsModel.CdProdutoErp = array[i].CdProd;
						produtoErpWsModel.DescResum = array[i].DescResum;
						produtoErpWsModel.Descricao = array[i].Descricao;
						produtoErpWsModel.CdFabricante = array[i].CdFabric;
						produtoErpWsModel.CdLinha = array[i].CdLinha;
						produtoErpWsModel.RowId = array[i].RowId;
						produtoErpWsModel.TipoCodigoBarras = array[i].TpCdBarra;
						produtoErpWsModel.CodigoBarras = array[i].CdBarra;
						produtoErpWsModel.TipoCodigoBarrasCompra = array[i].TpCdBarraCompra;
						produtoErpWsModel.CodigoBarrasCompra = array[i].CdBarraCompra;
						produtoErpWsModel.CdProdutoFabric = array[i].CdProdFabric;
						list.Add(produtoErpWsModel);
					}
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_ProdutoErp_Setar(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
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

	public void ExportarSKU(object eventosAtivos)
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		try
		{
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			byte[] rowId = wsErpSoapClient.WsERP_RowId_GetV2(validationSoapHeader, _CnpjEmpresa, EnumModel.ProdutoErpSKU, Seguranca.getHostName());
			dbConnection.Open();
			CdBarraUnprdTO[] array = CdBarraUnprdBLL.Select(dbConnection, rowId);
			if (array == null)
			{
				return;
			}
			int num = array.Count();
			int num2 = array.Count();
			int num3 = 0;
			while (num2 > 0)
			{
				List<ProdutoErpSkuWsModel> list = new List<ProdutoErpSkuWsModel>();
				for (int i = num3; i < num3 + 1000; i++)
				{
					if (i < num)
					{
						ProdutoErpSkuWsModel produtoErpSkuWsModel = new ProdutoErpSkuWsModel();
						produtoErpSkuWsModel.ProdutoErp = new ProdutoErpWsModel();
						produtoErpSkuWsModel.ProdutoErp.CdProdutoErp = array[i].CdProd;
						produtoErpSkuWsModel.Unidade = array[i].UnidVda;
						produtoErpSkuWsModel.Seq = array[i].Seq;
						produtoErpSkuWsModel.TpCdBarraUn = array[i].TpCdBarra;
						produtoErpSkuWsModel.CdBarraUn = array[i].CdBarra;
						produtoErpSkuWsModel.Ativo = array[i].Ativo;
						produtoErpSkuWsModel.RowId = array[i].RowId;
						list.Add(produtoErpSkuWsModel);
					}
				}
				RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_ProdutoErpSku_Setar(validationSoapHeader, _CnpjEmpresa, list.ToArray(), Seguranca.getHostName());
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
}
