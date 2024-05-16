using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Export;

internal class ExportPedidoAtendimento
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private PedVdaEleTO _PedVdaEle;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ExportPedidoAtendimento(string stringConnTargetErp, string stringConnTargetMob, PedVdaEleTO pedVdaEle, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_PedVdaEle = pedVdaEle;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Exportar(object eventosAtivos)
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetErp);
		using DbConnection dbConnection2 = new DbConnection(_StringConnTargetMob);
		try
		{
			dbConnection.Open();
			dbConnection2.Open();
			PedVdaAtendimentoWsModel pedVdaAtendimentoWsModel = ConstruirPedidoAtendimento(dbConnection, dbConnection2);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			RetornoWsModelOfBoolean retornoWsModelOfBoolean = new RetornoWsModelOfBoolean();
			StatusAtendimentoEnviadoTR statusAtendimentoEnviadoTR = StatusAtendimentoEnviadoTR.SUCESSO;
			if (pedVdaAtendimentoWsModel.ItPedvAtendimentoWs.Count() == 0)
			{
				statusAtendimentoEnviadoTR = StatusAtendimentoEnviadoTR.SEM_ITEM;
			}
			if (!pedVdaAtendimentoWsModel.IDVendedor.HasValue)
			{
				statusAtendimentoEnviadoTR = StatusAtendimentoEnviadoTR.PEDIDO_SEM_VENDEDOR;
			}
			if (StatusAtendimentoEnviadoTR.SUCESSO.Equals(statusAtendimentoEnviadoTR))
			{
				retornoWsModelOfBoolean = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress).WsERP_PedidoAtendimento_Setar(validationSoapHeader, _CnpjEmpresa, pedVdaAtendimentoWsModel, Seguranca.getHostName());
			}
			if (retornoWsModelOfBoolean.RetornoWs || StatusAtendimentoEnviadoTR.SEM_ITEM.Equals(statusAtendimentoEnviadoTR) || StatusAtendimentoEnviadoTR.PEDIDO_SEM_VENDEDOR.Equals(statusAtendimentoEnviadoTR))
			{
				dbConnection.Open();
				PedVdaEleBLL.SetAtendimentoEnviado(dbConnection, _PedVdaEle, statusAtendimentoEnviadoTR);
				dbConnection.Close();
				dbConnection2.Close();
				dbConnection.Close();
				return;
			}
			throw new Exception(retornoWsModelOfBoolean.Excecao.Erro);
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

	public PedVdaAtendimentoWsModel ConstruirPedidoAtendimento(DbConnection connTargetErp, DbConnection connTargetMob)
	{
		PedVdaAtendimentoWsModel pedVdaAtendimentoWsModel = new PedVdaAtendimentoWsModel();
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@cd_emp_ele", _PedVdaEle.CdEmpEle);
		connTargetErp.AddParameters("@nu_ped_ele", _PedVdaEle.NuPedEle);
		connTargetErp.AddParameters("@seq_ped", _PedVdaEle.SeqPed);
		using (SqlDataReader sqlDataReader = connTargetErp.ExecuteReader(CommandType.StoredProcedure, "uspPedidoAtendimento"))
		{
			if (!sqlDataReader.Read())
			{
				throw new Exception($"Pedido {_PedVdaEle.NuPed} da empresa {_PedVdaEle.CdEmp} não localizado");
			}
			pedVdaAtendimentoWsModel.CodigoCliente = GetDataReader.GetDrNullableInt(sqlDataReader["CodigoCliente"]);
			pedVdaAtendimentoWsModel.CodigoCondPgto = GetDataReader.GetDrNullableInt(sqlDataReader["CodigoCondPgto"]);
			pedVdaAtendimentoWsModel.CodigoEmpresa = GetDataReader.GetDrNullableInt(sqlDataReader["CodigoEmpresa"]);
			pedVdaAtendimentoWsModel.CodigoFormPgto = GetDataReader.GetDrString(sqlDataReader["CodigoFormPgto"]);
			pedVdaAtendimentoWsModel.CodigoTabPre = GetDataReader.GetDrString(sqlDataReader["CodigoTabPre"]);
			pedVdaAtendimentoWsModel.CodigoTpPed = GetDataReader.GetDrString(sqlDataReader["CodigoTpPed"]);
			pedVdaAtendimentoWsModel.CodigoTransportadora = GetDataReader.GetDrNullableInt(sqlDataReader["CodigoTransportadora"]);
			pedVdaAtendimentoWsModel.DtPedido = GetDataReader.GetDrNullableDateTime(sqlDataReader["DtPedido"]);
			pedVdaAtendimentoWsModel.DtPrevEntrega = GetDataReader.GetDrNullableDateTime(sqlDataReader["DtPrevEntrega"]);
			pedVdaAtendimentoWsModel.DtPrevFaturamento = GetDataReader.GetDrNullableDateTime(sqlDataReader["DtPrevFaturamento"]);
			pedVdaAtendimentoWsModel.NumeroPedidoCliente = GetDataReader.GetDrString(sqlDataReader["NumeroPedidoCliente"]);
			pedVdaAtendimentoWsModel.NumeroPedVdaAtendimento = GetDataReader.GetDrNullableInt(sqlDataReader["NumeroPedVdaAtendimento"]);
			pedVdaAtendimentoWsModel.NumeroPedVdaPocket = GetDataReader.GetDrNullableInt(sqlDataReader["NumeroPedVdaPocket"]);
			pedVdaAtendimentoWsModel.DtPedVdaPocket = GetDataReader.GetDrNullableDateTime(sqlDataReader["DtPedVdaPocket"]);
			pedVdaAtendimentoWsModel.OrigemPedido = GetDataReader.GetDrString(sqlDataReader["OrigemPedido"]);
			pedVdaAtendimentoWsModel.PercDescontoGeral = GetDataReader.GetDrNullableDecimal(sqlDataReader["PercDescontoGeral"]);
			pedVdaAtendimentoWsModel.Proposta = GetDataReader.GetDrNullableBool(sqlDataReader["Proposta"]);
			pedVdaAtendimentoWsModel.StatusPedido = GetDataReader.GetDrString(sqlDataReader["StatusPedido"]);
			pedVdaAtendimentoWsModel.TipoEntrega = GetDataReader.GetDrString(sqlDataReader["TipoEntrega"]);
			pedVdaAtendimentoWsModel.TipoFrete = GetDataReader.GetDrString(sqlDataReader["TipoFrete"]);
			pedVdaAtendimentoWsModel.ValorDescontoGeral = GetDataReader.GetDrNullableDecimal(sqlDataReader["ValorDescontoGeral"]);
			pedVdaAtendimentoWsModel.ValorTotal = GetDataReader.GetDrNullableDecimal(sqlDataReader["ValorTotal"]);
			pedVdaAtendimentoWsModel.VerificacaoCredito = GetDataReader.GetDrNullableBool(sqlDataReader["VerificacaoCredito"]);
			pedVdaAtendimentoWsModel.EmailCliente = GetDataReader.GetDrString(sqlDataReader["EmailCliente"]);
			pedVdaAtendimentoWsModel.RazaoSocial = GetDataReader.GetDrString(sqlDataReader["RazaoSocial"]);
			pedVdaAtendimentoWsModel.NomeFantasia = GetDataReader.GetDrString(sqlDataReader["NomeFantasia"]);
			pedVdaAtendimentoWsModel.CnpjCpf = GetDataReader.GetDrString(sqlDataReader["CnpjCpf"]);
			pedVdaAtendimentoWsModel.RazaoSocialTransp = GetDataReader.GetDrString(sqlDataReader["RazaoSocialTransp"]);
			pedVdaAtendimentoWsModel.DescricacaoCondPgto = GetDataReader.GetDrString(sqlDataReader["DescricacaoCondPgto"]);
			pedVdaAtendimentoWsModel.Logradouro = GetDataReader.GetDrString(sqlDataReader["Logradouro"]);
			pedVdaAtendimentoWsModel.Numero = GetDataReader.GetDrString(sqlDataReader["Numero"]);
			pedVdaAtendimentoWsModel.Complemento = GetDataReader.GetDrString(sqlDataReader["Complemento"]);
			pedVdaAtendimentoWsModel.Bairro = GetDataReader.GetDrString(sqlDataReader["Bairro"]);
			pedVdaAtendimentoWsModel.Municipio = GetDataReader.GetDrString(sqlDataReader["Municipio"]);
			pedVdaAtendimentoWsModel.Cep = GetDataReader.GetDrNullableInt(sqlDataReader["Cep"]);
			pedVdaAtendimentoWsModel.Estado = GetDataReader.GetDrString(sqlDataReader["Estado"]);
			pedVdaAtendimentoWsModel.CodigoEntregaOutroCliente = GetDataReader.GetDrNullableInt(sqlDataReader["CodigoEntregaOutroCliente"]);
			pedVdaAtendimentoWsModel.cdClienAtacadista = GetDataReader.GetDrNullableInt(sqlDataReader["cdClienAtacadista"]);
			pedVdaAtendimentoWsModel.cdClienFatura = GetDataReader.GetDrNullableInt(sqlDataReader["cdClienFatura"]);
			pedVdaAtendimentoWsModel.cdClienPagamento = GetDataReader.GetDrNullableInt(sqlDataReader["cdClienPagamento"]);
			string drString = GetDataReader.GetDrString(sqlDataReader["CodigoVendedor"]);
			VendedorTO vendedorTO = VendedorBLL.Select(connTargetMob.GetConnection(), drString);
			if (vendedorTO != null)
			{
				pedVdaAtendimentoWsModel.IDVendedor = vendedorTO.Id;
			}
			else
			{
				pedVdaAtendimentoWsModel.IDVendedor = null;
			}
		}
		using (SqlDataReader sqlDataReader2 = connTargetErp.ExecuteReader(CommandType.StoredProcedure, "uspPedidoAtendimentoItem"))
		{
			List<ItPedvAtendimentoWsModel> list = new List<ItPedvAtendimentoWsModel>();
			while (sqlDataReader2.Read())
			{
				ItPedvAtendimentoWsModel itPedvAtendimentoWsModel = new ItPedvAtendimentoWsModel();
				itPedvAtendimentoWsModel.CodigoKitProm = GetDataReader.GetDrNullableInt(sqlDataReader2["CodigoKitProm"]);
				itPedvAtendimentoWsModel.CodigoProduto = Convert.ToInt32(GetDataReader.GetDrNullableInt(sqlDataReader2["CodigoProduto"]));
				itPedvAtendimentoWsModel.DtFaturamento = GetDataReader.GetDrNullableDateTime(sqlDataReader2["DtFaturamento"]);
				itPedvAtendimentoWsModel.FatorUnidVenda = GetDataReader.GetDrNullableDecimal(sqlDataReader2["FatorUnidVenda"]);
				itPedvAtendimentoWsModel.IndiceRelacaoProduto = GetDataReader.GetDrString(sqlDataReader2["IndiceRelacaoProduto"]);
				itPedvAtendimentoWsModel.NotaFiscal = GetDataReader.GetDrNullableInt(sqlDataReader2["NotaFiscal"]);
				itPedvAtendimentoWsModel.PercDesc01 = GetDataReader.GetDrNullableDecimal(sqlDataReader2["PercDesc01"]);
				itPedvAtendimentoWsModel.PercDesc02 = GetDataReader.GetDrNullableDecimal(sqlDataReader2["PercDesc02"]);
				itPedvAtendimentoWsModel.PercDescAplicado = GetDataReader.GetDrNullableDecimal(sqlDataReader2["PercDescAplicado"]);
				itPedvAtendimentoWsModel.PercDescBonificacao = GetDataReader.GetDrNullableDecimal(sqlDataReader2["PercDescBonificacao"]);
				itPedvAtendimentoWsModel.PercDescComercial = GetDataReader.GetDrNullableDecimal(sqlDataReader2["PercDescComercial"]);
				itPedvAtendimentoWsModel.PercDescFinanceiro = GetDataReader.GetDrNullableDecimal(sqlDataReader2["PercDescFinanceiro"]);
				itPedvAtendimentoWsModel.PrecoLiquidoUnidVenda = GetDataReader.GetDrDecimal(sqlDataReader2["PrecoLiquidoUnidVenda"]);
				itPedvAtendimentoWsModel.PrecoTabelaUnidEstoque = GetDataReader.GetDrDecimal(sqlDataReader2["PrecoTabelaUnidEstoque"]);
				itPedvAtendimentoWsModel.QtdeBonifUnidVenda = GetDataReader.GetDrNullableDecimal(sqlDataReader2["QtdeBonifUnidVenda"]);
				itPedvAtendimentoWsModel.QtdeUnidVenda = GetDataReader.GetDrDecimal(sqlDataReader2["QtdeUnidVenda"]);
				itPedvAtendimentoWsModel.Seq = GetDataReader.GetDrShort(sqlDataReader2["Seq"]);
				itPedvAtendimentoWsModel.StatusItemPedido = sqlDataReader2.GetString(sqlDataReader2.GetOrdinal("StatusItemPedido"));
				itPedvAtendimentoWsModel.UnidVenda = GetDataReader.GetDrString(sqlDataReader2["UnidVenda"]);
				itPedvAtendimentoWsModel.VerbaOutros = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VerbaOutros"]);
				itPedvAtendimentoWsModel.VerbaVendedor = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VerbaVendedor"]);
				itPedvAtendimentoWsModel.VlMargemBrtCUE = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VlMargemBrtCUE"]);
				itPedvAtendimentoWsModel.VlMargemBrtCRP = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VlMargemBrtCRP"]);
				itPedvAtendimentoWsModel.VlMargemBrtCMP = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VlMargemBrtCMP"]);
				itPedvAtendimentoWsModel.VlIPI = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VlIPI"]);
				itPedvAtendimentoWsModel.VlST = GetDataReader.GetDrNullableDecimal(sqlDataReader2["VlST"]);
				itPedvAtendimentoWsModel.ValorVendaAVista = GetDataReader.GetDrNullableDecimal(sqlDataReader2["ValorVendaAVista"]);
				itPedvAtendimentoWsModel.CodigoCondPgto = GetDataReader.GetDrNullableInt(sqlDataReader2["CodigoCondPgto"]);
				list.Add(itPedvAtendimentoWsModel);
			}
			pedVdaAtendimentoWsModel.ItPedvAtendimentoWs = list.ToArray();
		}
		using (SqlDataReader sqlDataReader3 = connTargetErp.ExecuteReader(CommandType.StoredProcedure, "uspPedidoAtendimentoMensagem"))
		{
			List<PedVdaAtendimentoMensagemWsModel> list2 = new List<PedVdaAtendimentoMensagemWsModel>();
			while (sqlDataReader3.Read())
			{
				PedVdaAtendimentoMensagemWsModel pedVdaAtendimentoMensagemWsModel = new PedVdaAtendimentoMensagemWsModel();
				pedVdaAtendimentoMensagemWsModel.CodigoSetorMsg = GetDataReader.GetDrString(sqlDataReader3["CodigoSetorMsg"]);
				pedVdaAtendimentoMensagemWsModel.Texto = GetDataReader.GetDrString(sqlDataReader3["Texto"]);
				list2.Add(pedVdaAtendimentoMensagemWsModel);
			}
			pedVdaAtendimentoWsModel.PedVdaAtendimentoMensagemWs = list2.ToArray();
		}
		using SqlDataReader sqlDataReader4 = connTargetErp.ExecuteReader(CommandType.StoredProcedure, "uspPedidoAtendimentoTextoGravacao");
		List<PedVdaAtendimentoTextoGravacaoWsModel> list3 = new List<PedVdaAtendimentoTextoGravacaoWsModel>();
		while (sqlDataReader4.Read())
		{
			PedVdaAtendimentoTextoGravacaoWsModel pedVdaAtendimentoTextoGravacaoWsModel = new PedVdaAtendimentoTextoGravacaoWsModel();
			pedVdaAtendimentoTextoGravacaoWsModel.nuLinha = GetDataReader.GetDrShort(sqlDataReader4["nuLinha"]);
			pedVdaAtendimentoTextoGravacaoWsModel.texto = GetDataReader.GetDrString(sqlDataReader4["texto"]);
			list3.Add(pedVdaAtendimentoTextoGravacaoWsModel);
		}
		pedVdaAtendimentoWsModel.pedVdaAtendimentoTextoGravacao = list3.ToArray();
		return pedVdaAtendimentoWsModel;
	}
}
