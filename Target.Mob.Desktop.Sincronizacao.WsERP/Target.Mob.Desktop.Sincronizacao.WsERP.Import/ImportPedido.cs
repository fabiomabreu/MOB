using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Api.BLL;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

internal class ImportPedido
{
	private string _StringConnTargetErp;

	private string _StringConnTargetMob;

	private int _IdPedido;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportPedido(string stringConnTargetErp, string stringConnTargetMob, int idPedido, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_IdPedido = idPedido;
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
			RetornoWsModelOfPedVdaWsModel retornoWsModelOfPedVdaWsModel = wsErpSoapClient.WsERP_Pedido_GetV2(validationSoapHeader, _CnpjEmpresa, _IdPedido, Seguranca.getHostName());
			if (retornoWsModelOfPedVdaWsModel.RetornoWs != null)
			{
				PedVdaWsModel retornoWs = retornoWsModelOfPedVdaWsModel.RetornoWs;
				dbConnection.Open();
				dbConnection2.Open();
				VendedorTO vendedorTO = VendedorBLL.Select(dbConnection2.GetConnection(), Convert.ToInt32(retornoWs.IDVendedor));
				if (vendedorTO == null)
				{
					throw new Exception($"Vendedor não localizado na tabela de configuração de vendedores. IdVendedor: {retornoWs.IDVendedor}");
				}
				ConfiguracaoVendedorTO configuracaoVendedorTO = ConfiguracaoVendedorBLL.Select(dbConnection2.GetConnection(), Convert.ToInt32(vendedorTO.IdConfiguracaoVendedor));
				if (configuracaoVendedorTO == null)
				{
					throw new Exception($"Configuração do vendedor não localizada. IdConfiguracao: {vendedorTO.IdConfiguracaoVendedor}");
				}
				List<EventoPdelAbTO> list = ConstruirEventoPdelAb(dbConnection, dbConnection2, retornoWs, configuracaoVendedorTO, vendedorTO);
				foreach (EventoPdelAbTO item in list)
				{
					int nuPedEle = SeqPedvEleBLL.GeraSeqPorEmpresa(dbConnection, item.oPedVdaEle.CdEmpEle);
					item.oPedVdaEle.NuPedEle = nuPedEle;
					item.oEventoPdel.NuPedEle = nuPedEle;
				}
				dbConnection.BeginTransaction();
				foreach (EventoPdelAbTO item2 in list)
				{
					EventoPdelAbBLL.Insert(dbConnection, item2);
					AcaVisitasForaRotaBLL.InsertVisitaForaRota(dbConnection, item2.oPedVdaEle.CdClien.Value, item2.oPedVdaEle.CdVend, item2.oPedVdaEle.DtPed.Value, configuracaoVendedorTO);
				}
				if (PedidoDuplicado(dbConnection, list))
				{
					dbConnection.RollbackTransaction();
				}
				else
				{
					dbConnection.CommitTransaction();
				}
				dbConnection2.Close();
				dbConnection.Close();
				wsErpSoapClient.WsERP_Pedido_SetImportar(validationSoapHeader, _CnpjEmpresa, _IdPedido, Seguranca.getHostName());
				return;
			}
			throw new Exception(retornoWsModelOfPedVdaWsModel.Excecao.Erro);
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

	private static bool PedidoDuplicado(DbConnection connTargetErp, List<EventoPdelAbTO> listaEventoPdelAb)
	{
		int num = 0;
		string text = "";
		string text2 = "";
		if (listaEventoPdelAb.Count > 0)
		{
			int? num2 = null;
			foreach (EventoPdelAbTO item in listaEventoPdelAb.OrderBy((EventoPdelAbTO x) => x.oPedVdaEle.CdEmpEle))
			{
				if (item.oPedVdaEle.CdEmpEle != num2)
				{
					int cdEmpEle = item.oPedVdaEle.CdEmpEle;
					int cdClien = Convert.ToInt32(item.oPedVdaEle.CdClien);
					DateTime dtPed = Convert.ToDateTime(item.oPedVdaEle.DtPed);
					text = item.oPedVdaEle.CdVend;
					text2 = item.oPedVdaEle.NuPedPalm;
					num += PedVdaEleBLL.Count(connTargetErp, cdEmpEle, text, cdClien, dtPed, text2);
					num2 = item.oPedVdaEle.CdEmpEle;
				}
			}
		}
		if (num < listaEventoPdelAb.Count)
		{
			throw new Exception("Quantidade de pedidos inseridos menor. NuPedPalm: " + text2 + " CdVend: " + text);
		}
		return num != listaEventoPdelAb.Count;
	}

	private List<EventoPdelAbTO> ConstruirEventoPdelAb(DbConnection connTargetErp, DbConnection connTargetMob, PedVdaWsModel pedidoWs, ConfiguracaoVendedorTO configuracaoVendedor, VendedorTO vendedor)
	{
		PedVdaEleTO pedVdaEleTO = new PedVdaEleTO();
		if (pedidoWs.ClienteBDMovimento == true)
		{
			if (pedidoWs.CodigoClienteProspeccao.HasValue && pedidoWs.CodigoClienteProspeccao > 0)
			{
				pedVdaEleTO.CdClien = pedidoWs.CodigoClienteProspeccao;
			}
			else
			{
				pedVdaEleTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(pedidoWs.CnpjCpfCliente, pedidoWs.IDPedVda.Value, "PedVda", pedidoWs.CodigoPais, _StringConnTargetErp);
			}
		}
		else
		{
			pedVdaEleTO.CdClien = pedidoWs.CodigoCliente;
		}
		pedVdaEleTO.CdEmpEle = Convert.ToInt32(pedidoWs.CodigoEmpresa);
		pedVdaEleTO.CdForn = pedidoWs.CodigoTransportadora;
		pedVdaEleTO.CdIntPedEle = "TARGET MOB";
		pedVdaEleTO.CdTabela = pedidoWs.CodigoTabPre;
		pedVdaEleTO.DtEntrega = pedidoWs.DtPrevEntrega;
		pedVdaEleTO.DtPed = (pedidoWs.DtPedido.HasValue ? new DateTime?(new DateTime(pedidoWs.DtPedido.Value.Year, pedidoWs.DtPedido.Value.Month, pedidoWs.DtPedido.Value.Day, pedidoWs.DtPedido.Value.Hour, pedidoWs.DtPedido.Value.Minute, 0)) : pedidoWs.DtPedido);
		pedVdaEleTO.DtPrevFatu = pedidoWs.DtPrevFaturamento;
		pedVdaEleTO.Formpgto = pedidoWs.CodigoFormPgto;
		pedVdaEleTO.ImpViaSp = 0;
		pedVdaEleTO.NfCanc = 0;
		pedVdaEleTO.NuDiasDescFin = default(decimal);
		pedVdaEleTO.NuPedCli = pedidoWs.NumeroPedidoCliente;
		pedVdaEleTO.NuPedPalm = pedidoWs.NumeroPedVda.ToString();
		pedVdaEleTO.AtribuiOrigPedido(pedidoWs.OrigemPedido);
		pedVdaEleTO.PedidoDireto = 0;
		pedVdaEleTO.PercDescGeral = pedidoWs.PercDescontoGeral;
		pedVdaEleTO.PerDescFin = default(decimal);
		pedVdaEleTO.PropostaVda = pedidoWs.Proposta;
		pedVdaEleTO.SeqPed = 1m;
		pedVdaEleTO.SeqProm = pedidoWs.CodigoCondPgto;
		pedVdaEleTO.AtribuiSituacao(pedidoWs.StatusPedido);
		pedVdaEleTO.AtribuiTpEntrega(pedidoWs.TipoEntrega);
		pedVdaEleTO.TpEstab = TipoEstabelecimento.Comercial;
		pedVdaEleTO.AtribuiTpFrete(pedidoWs.TipoFrete);
		pedVdaEleTO.TpPed = pedidoWs.CodigoTpPed;
		pedVdaEleTO.ValorTot = pedidoWs.ValorTotal;
		pedVdaEleTO.VlDescFin = default(decimal);
		pedVdaEleTO.VlDescGeral = pedidoWs.ValorDescontoGeral;
		pedVdaEleTO.VlFrete = default(decimal);
		pedVdaEleTO.CodigoEntregaOutroCliente = pedidoWs.CodigoEntregaOutroCliente;
		pedVdaEleTO.cdClienAtacadista = ((pedidoWs.cdClienAtacadista > 0) ? pedidoWs.cdClienAtacadista : null);
		pedVdaEleTO.cdClienFatura = ((pedidoWs.cdClienFatura > 0) ? pedidoWs.cdClienFatura : null);
		pedVdaEleTO.cdClienPagamento = ((pedidoWs.cdClienPagamento > 0) ? pedidoWs.cdClienPagamento : null);
		pedVdaEleTO.PromPadrCli = CliEmpFormPgtoBLL.IsPrincipal(connTargetErp, pedVdaEleTO.CdEmpEle, pedVdaEleTO.CdClien, pedVdaEleTO.Formpgto);
		pedVdaEleTO.CdVend = vendedor.CodigoVendedor;
		pedVdaEleTO.LiberacaoAutomatica = configuracaoVendedor.LiberarPedidosAutomaticamente;
		pedVdaEleTO.cdComoRealizouVenda = pedidoWs.CodigoComoRealizouVenda;
		pedVdaEleTO.TextoComoRealizouVenda = null;
		if (pedVdaEleTO.cdComoRealizouVenda.HasValue && pedVdaEleTO.cdComoRealizouVenda.Equals(-1))
		{
			pedVdaEleTO.TextoComoRealizouVenda = pedidoWs.TextoComoRealizouVenda;
		}
		List<ItPedvEleTO> list = new List<ItPedvEleTO>();
		ItPedvWsModel[] itPedvWs = pedidoWs.ItPedvWs;
		int num = 0;
		while (num < itPedvWs.Length)
		{
			ItPedvWsModel itPedvWsModel = itPedvWs[num];
			ItPedvEleTO itPedvEleTO = new ItPedvEleTO();
			itPedvEleTO.CdProd = Convert.ToInt32(itPedvWsModel.CodigoProduto);
			itPedvEleTO.UnidPed = itPedvWsModel.UnidVenda;
			itPedvEleTO.FatorEstPed = Convert.ToDouble(itPedvWsModel.FatorUnidVenda);
			itPedvEleTO.AtribuiIndRelacao(itPedvWsModel.IndiceRelacaoProduto);
			itPedvEleTO.PrecoUnit = Convert.ToDecimal(itPedvWsModel.PrecoTabelaUnidEstoque);
			itPedvEleTO.Desc01 = itPedvWsModel.PercDesc01;
			if (itPedvWsModel.PercDescAuxPeG.HasValue)
			{
				decimal? percDescAuxPeG = itPedvWsModel.PercDescAuxPeG;
				if ((percDescAuxPeG.GetValueOrDefault() > default(decimal)) & percDescAuxPeG.HasValue)
				{
					itPedvWsModel.PercDescAuxQtde = itPedvWsModel.PercDescAuxQtde.GetValueOrDefault();
					itPedvEleTO.Desc02 = itPedvWsModel.PercDescAuxQtde;
					decimal value = 1;
					decimal value2 = 1;
					decimal? desc = itPedvEleTO.Desc01;
					decimal? num2 = (decimal?)value2 - desc;
					value2 = 1;
					desc = itPedvEleTO.Desc02;
					decimal? num3 = num2 * ((decimal?)value2 - desc);
					itPedvEleTO.DescApl = (decimal?)value - num3;
					itPedvWsModel.PercDescAplicado = itPedvEleTO.DescApl;
					if (itPedvEleTO.FatorEstPed == 1.0 && Math.Abs(itPedvEleTO.PrecoUnit - itPedvWsModel.PrecoLiquidoUnidVenda.Value / (1m - itPedvWsModel.PercDescAplicado.Value)) <= 0.01m)
					{
						itPedvWsModel.PrecoLiquidoUnidVenda = itPedvWsModel.PrecoTabelaUnidEstoque;
					}
					else
					{
						percDescAuxPeG = itPedvWsModel.PrecoLiquidoUnidVenda;
						value = 1;
						num2 = itPedvWsModel.PercDescAuxPeG;
						itPedvWsModel.PrecoLiquidoUnidVenda = percDescAuxPeG / ((decimal?)value - num2);
					}
					goto IL_072e;
				}
			}
			itPedvEleTO.Desc02 = itPedvWsModel.PercDesc02;
			itPedvEleTO.DescApl = itPedvWsModel.PercDescAplicado;
			goto IL_072e;
			IL_072e:
			itPedvEleTO.DescGrdBon = itPedvWsModel.PercDescBonificacao;
			itPedvEleTO.DescGrdCom = itPedvWsModel.PercDescComercial;
			itPedvEleTO.DescGrdFin = itPedvWsModel.PercDescFinanceiro;
			itPedvEleTO.VlUnitPed = itPedvWsModel.PrecoBrutoUnidVenda;
			decimal? vlUnitPed;
			if (itPedvEleTO.VlUnitPed.HasValue)
			{
				vlUnitPed = itPedvEleTO.VlUnitPed;
				if (!((vlUnitPed.GetValueOrDefault() == default(decimal)) & vlUnitPed.HasValue))
				{
					goto IL_0aee;
				}
			}
			decimal num4 = itPedvWsModel.PrecoTabelaUnidEstoque.Value * (1m - itPedvWsModel.PercDescAplicado.Value);
			vlUnitPed = itPedvWsModel.PrecoLiquidoUnidVenda;
			if ((vlUnitPed.GetValueOrDefault() > default(decimal)) & vlUnitPed.HasValue)
			{
				if (itPedvWsModel.PercDescAplicado.HasValue)
				{
					vlUnitPed = itPedvWsModel.PercDescAplicado;
					if (!((vlUnitPed.GetValueOrDefault() == default(decimal)) & vlUnitPed.HasValue))
					{
						if (itPedvEleTO.FatorEstPed == 1.0 && (Math.Abs(num4 - itPedvWsModel.PrecoLiquidoUnidVenda.Value) <= 0.01m || Math.Abs(itPedvEleTO.PrecoUnit - itPedvWsModel.PrecoLiquidoUnidVenda.Value / (1m - itPedvWsModel.PercDescAplicado.Value)) <= 0.015m || Math.Abs(itPedvWsModel.PercDescAplicado.Value - (1m - itPedvWsModel.PrecoLiquidoUnidVenda.Value / itPedvEleTO.PrecoUnit)) <= 0.0005m))
						{
							itPedvEleTO.VlUnitPed = itPedvEleTO.PrecoUnit;
						}
						else
						{
							vlUnitPed = itPedvWsModel.PrecoLiquidoUnidVenda;
							decimal value = 1;
							decimal? num2 = itPedvWsModel.PercDescAplicado;
							itPedvEleTO.VlUnitPed = vlUnitPed / ((decimal?)value - num2);
						}
						goto IL_0aee;
					}
				}
				itPedvEleTO.VlUnitPed = itPedvWsModel.PrecoLiquidoUnidVenda;
			}
			else if (itPedvWsModel.IndiceRelacaoProduto == "MENOR")
			{
				if (itPedvWsModel.FatorUnidVenda.HasValue)
				{
					decimal? percDescAuxPeG = itPedvWsModel.FatorUnidVenda;
					if (!((percDescAuxPeG.GetValueOrDefault() == default(decimal)) & percDescAuxPeG.HasValue))
					{
						itPedvEleTO.VlUnitPed = itPedvWsModel.PrecoTabelaUnidEstoque / itPedvWsModel.FatorUnidVenda;
						goto IL_0aee;
					}
				}
				itPedvEleTO.VlUnitPed = default(decimal);
			}
			else
			{
				itPedvEleTO.VlUnitPed = itPedvWsModel.PrecoTabelaUnidEstoque * itPedvWsModel.FatorUnidVenda;
			}
			goto IL_0aee;
			IL_0aee:
			if (itPedvWsModel.CodigoKitProm > 0)
			{
				itPedvEleTO.SeqKit = itPedvWsModel.CodigoKitProm;
			}
			TpPedTO[] array = TpPedBLL.Select(connTargetErp, new TpPedTO
			{
				TpPed = pedidoWs.CodigoTpPed
			});
			if (array != null)
			{
				if (array[0].Bonificacao == true && (!itPedvWsModel.CodigoKitProm.HasValue || itPedvWsModel.CodigoKitProm == 0) && (!itPedvWsModel.PercDescAplicado.HasValue || !itPedvWsModel.PercDescAplicado.Equals(1)))
				{
					itPedvWsModel.QtdeUnidVenda = Convert.ToDecimal(itPedvWsModel.QtdeUnidVenda) + Convert.ToDecimal(itPedvWsModel.QtdeBonifUnidVenda);
					itPedvWsModel.QtdeBonifUnidVenda = default(decimal);
				}
				itPedvEleTO.CodigoCondPgto = itPedvWsModel.CodigoCondPgto;
				decimal? percDescAuxPeG = itPedvWsModel.QtdeUnidVenda;
				if ((percDescAuxPeG.GetValueOrDefault() > default(decimal)) & percDescAuxPeG.HasValue)
				{
					itPedvEleTO.Bonificado = 0;
					itPedvEleTO.QtdeUnidPed = itPedvWsModel.QtdeUnidVenda;
					itPedvEleTO.VlVerba = itPedvWsModel.VerbaVendedor + itPedvWsModel.VerbaOutros;
					if (itPedvEleTO.IndRelacao == IndiceRelacao.Maior)
					{
						itPedvEleTO.Qtde = Convert.ToDecimal(itPedvWsModel.QtdeUnidVenda * itPedvWsModel.FatorUnidVenda);
					}
					else
					{
						percDescAuxPeG = itPedvWsModel.FatorUnidVenda;
						if ((percDescAuxPeG.GetValueOrDefault() > default(decimal)) & percDescAuxPeG.HasValue)
						{
							itPedvEleTO.Qtde = Convert.ToDecimal(itPedvWsModel.QtdeUnidVenda / itPedvWsModel.FatorUnidVenda);
						}
						else
						{
							itPedvEleTO.Qtde = 0m;
						}
					}
					list.Add(itPedvEleTO);
				}
				vlUnitPed = itPedvWsModel.QtdeBonifUnidVenda;
				if ((vlUnitPed.GetValueOrDefault() > default(decimal)) & vlUnitPed.HasValue)
				{
					ItPedvEleTO itPedvEleTO2 = itPedvEleTO.Clone();
					itPedvEleTO2.Bonificado = 1;
					itPedvEleTO2.QtdeUnidPed = itPedvWsModel.QtdeBonifUnidVenda;
					itPedvEleTO2.DescApl = 1;
					itPedvEleTO2.Desc01 = 1;
					if (!itPedvEleTO2.VlVerba.HasValue)
					{
						itPedvEleTO2.VlVerba = itPedvWsModel.VerbaVendedor + itPedvWsModel.VerbaOutros;
					}
					else
					{
						itPedvEleTO2.VlVerba = default(decimal);
					}
					if (itPedvEleTO2.IndRelacao == IndiceRelacao.Maior)
					{
						itPedvEleTO2.Qtde = Convert.ToDecimal(itPedvWsModel.QtdeBonifUnidVenda * itPedvWsModel.FatorUnidVenda);
					}
					else
					{
						vlUnitPed = itPedvWsModel.FatorUnidVenda;
						if ((vlUnitPed.GetValueOrDefault() > default(decimal)) & vlUnitPed.HasValue)
						{
							itPedvEleTO2.Qtde = Convert.ToDecimal(itPedvWsModel.QtdeBonifUnidVenda / itPedvWsModel.FatorUnidVenda);
						}
						else
						{
							itPedvEleTO2.Qtde = 0m;
						}
					}
					list.Add(itPedvEleTO2);
				}
				num++;
				continue;
			}
			throw new Exception($"Tipo de pedido com código {pedidoWs.CodigoTpPed} não localizado.");
		}
		pedVdaEleTO.oItPedvEle = list.ToArray();
		List<ObsPedEleTO> list2 = new List<ObsPedEleTO>();
		PedVdaMensagemWsModel[] pedVdaMensagemWs = pedidoWs.PedVdaMensagemWs;
		for (num = 0; num < pedVdaMensagemWs.Length; num++)
		{
			PedVdaMensagemModel pedVdaMensagemModel = (PedVdaMensagemModel)pedVdaMensagemWs[num];
			if (pedVdaMensagemModel.Texto != null && pedVdaMensagemModel.Texto.Trim().Length > 0)
			{
				ObsPedEleTO obsPedEleTO = new ObsPedEleTO();
				TextoTO textoTO = new TextoTO();
				textoTO.GeraTexto(pedVdaMensagemModel.Texto);
				TextoBLL.Insert(connTargetErp, textoTO);
				obsPedEleTO.CdTexto = textoTO.CdTexto;
				switch (pedVdaMensagemModel.CodigoSetorMsg)
				{
				case "SEPA":
					obsPedEleTO.Setor = "SEPARACAO";
					break;
				case "EXPE":
					obsPedEleTO.Setor = "EXPEDICAO";
					break;
				case "FATU":
					obsPedEleTO.Setor = "FATURAMENTO";
					break;
				case "CRED":
					obsPedEleTO.Setor = "CREDITO";
					break;
				case "GERV":
					obsPedEleTO.Setor = "GERVENDA";
					break;
				case "ADMV":
					obsPedEleTO.Setor = "ADMVENDAS";
					break;
				default:
					obsPedEleTO.Setor = pedVdaMensagemModel.CodigoSetorMsg;
					break;
				}
				list2.Add(obsPedEleTO);
			}
		}
		pedVdaEleTO.oObsPedEle = list2.ToArray();
		List<PedVdaEleTextoGravacaoTO> list3 = new List<PedVdaEleTextoGravacaoTO>();
		PedVdaTextoGravacaoWsModel[] pedVdaTextoGravacao = pedidoWs.pedVdaTextoGravacao;
		foreach (PedVdaTextoGravacaoWsModel pedVdaTextoGravacaoWsModel in pedVdaTextoGravacao)
		{
			PedVdaEleTextoGravacaoTO pedVdaEleTextoGravacaoTO = new PedVdaEleTextoGravacaoTO();
			pedVdaEleTextoGravacaoTO.nuLinha = pedVdaTextoGravacaoWsModel.nuLinha;
			pedVdaEleTextoGravacaoTO.texto = pedVdaTextoGravacaoWsModel.texto;
			list3.Add(pedVdaEleTextoGravacaoTO);
		}
		pedVdaEleTO.oPedVdaEleTextoGravacao = list3.ToArray();
		TrocaTO trocaTO = new TrocaTO();
		if (pedidoWs.TrocaWs != null)
		{
			if (pedidoWs.TrocaWs.ClienteBDMovimento == true)
			{
				trocaTO.CdClien = ClienteBLL.getCodigoClienteByCnpj(pedidoWs.TrocaWs.CnpjCpfCliente, pedidoWs.TrocaWs.IDTroca, "IDTroca", pedidoWs.CodigoPais, _StringConnTargetErp).Value;
			}
			else
			{
				trocaTO.CdClien = Convert.ToInt32(pedidoWs.TrocaWs.CodigoCliente);
			}
			trocaTO.CdEmp = pedidoWs.TrocaWs.CodigoEmpresa;
			trocaTO.CdEmpEstoque = pedidoWs.TrocaWs.CodigoEmpresa;
			trocaTO.CdMotcanc = pedidoWs.TrocaWs.CodigoMotivoTroca;
			trocaTO.CdTabela = pedidoWs.TrocaWs.CodigoTabPre;
			trocaTO.CdTrocaPalm = pedidoWs.TrocaWs.CodigoTrocaPocket.ToString();
			trocaTO.DtCad = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			trocaTO.DtCadPalm = pedidoWs.TrocaWs.DtTroca;
			trocaTO.AtribuiProdLocaliza(pedidoWs.TrocaWs.LocalArmazenamentoTroca);
			trocaTO.Situacao = pedidoWs.TrocaWs.StatusTroca;
			trocaTO.AtribuiTpEnvio("PF");
			trocaTO.VlTotal = pedidoWs.TrocaWs.ValorRecebido;
			trocaTO.VlTotalRecebido = pedidoWs.TrocaWs.ValorRecebido;
			trocaTO.Indenizacao = pedidoWs.TrocaWs.Indenizacao;
			trocaTO.CdVend = vendedor.CodigoVendedor;
			trocaTO.AtribuiTpAbatimento(configuracaoVendedor.TipoAbatimentoTroca);
			List<ItTrocaTO> list4 = new List<ItTrocaTO>();
			ItTrocaWsModel[] itTrocaWs = pedidoWs.TrocaWs.ItTrocaWs;
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
				list4.Add(itTrocaTO);
			}
			trocaTO.oItTroca = list4.ToArray();
			pedVdaEleTO.oTrocaPedvEle = trocaTO;
		}
		TrocaTO oTrocaPedvEle = pedVdaEleTO.oTrocaPedvEle;
		pedVdaEleTO.oTrocaPedvEle = null;
		List<PedVdaEleTO> list5 = new List<PedVdaEleTO>();
		list5.Add(pedVdaEleTO);
		if (configuracaoVendedor.DesmembraPedidoProdutoxEmpresa.HasValue && configuracaoVendedor.DesmembraPedidoProdutoxEmpresa.Value && isDesmembrarWA(connTargetErp, pedVdaEleTO))
		{
			list5 = DesmembraPedidoEmpresa(connTargetErp, list5);
		}
		if (configuracaoVendedor.DesmembraPedidoProdutoxGrupoProduto == true)
		{
			list5 = DesmembraPedidoGrupo(connTargetErp, list5);
		}
		list5.OrderByDescending((PedVdaEleTO x) => x.ValorTot).First().oTrocaPedvEle = oTrocaPedvEle;
		List<EventoPdelAbTO> list6 = new List<EventoPdelAbTO>();
		foreach (PedVdaEleTO item in list5)
		{
			EventoPdelTO eventoPdelTO = new EventoPdelTO();
			eventoPdelTO.CdUsrGer = "SUPER";
			eventoPdelTO.DtCriacao = DateTime.Now;
			EventoPdelAbTO eventoPdelAbTO = new EventoPdelAbTO();
			eventoPdelAbTO.oPedVdaEle = item;
			eventoPdelAbTO.oEventoPdel = eventoPdelTO;
			list6.Add(eventoPdelAbTO);
		}
		return list6;
	}

	private bool isDesmembrarWA(DbConnection connTargetErp, PedVdaEleTO pedido)
	{
		if (pedido.CdEmpEle == 4)
		{
			ParCfgTO parCfgTO = new ParCfgBLL().SelectByCdEmp(connTargetErp, pedido.CdEmpEle);
			if ("BGR".Equals(parCfgTO.SiglaClien.ToUpper()))
			{
				return false;
			}
		}
		return true;
	}

	private List<PedVdaEleTO> DesmembraPedidoEmpresa(DbConnection connTargetErp, List<PedVdaEleTO> listPedVdaEle)
	{
		List<PedVdaEleTO> list = new List<PedVdaEleTO>();
		foreach (PedVdaEleTO item in listPedVdaEle)
		{
			foreach (PedVdaEleTO item2 in DesmembraPedidoEmpresa(connTargetErp, item))
			{
				list.Add(item2);
			}
		}
		return list;
	}

	private List<PedVdaEleTO> DesmembraPedidoEmpresa(DbConnection connTargetErp, PedVdaEleTO PedVdaEle)
	{
		Dictionary<int?, PedVdaEleTO> dictionary = new Dictionary<int?, PedVdaEleTO>();
		ItPedvEleTO[] oItPedvEle = PedVdaEle.oItPedvEle;
		foreach (ItPedvEleTO itPedvEleTO in oItPedvEle)
		{
			ProdutoTO produtoTO = ProdutoBLL.Select(connTargetErp, Convert.ToInt32(PedVdaEle.CdEmpEle), itPedvEleTO.CdProd);
			if (produtoTO == null)
			{
				throw new Exception("Produto não localizado");
			}
			if (!produtoTO.CdEmp.HasValue)
			{
				produtoTO.CdEmp = PedVdaEle.CdEmpEle;
			}
			if (!dictionary.ContainsKey(produtoTO.CdEmp))
			{
				PedVdaEleTO pedVdaEleTO = PedVdaEle.Clone();
				pedVdaEleTO.CdEmpEle = Convert.ToInt32(produtoTO.CdEmp);
				pedVdaEleTO.oItPedvEle = null;
				dictionary.Add(produtoTO.CdEmp, pedVdaEleTO);
			}
			dictionary[produtoTO.CdEmp].IncluiItPedvEle(itPedvEleTO);
		}
		foreach (KeyValuePair<int?, PedVdaEleTO> item in dictionary)
		{
			PedidoCalculaTotais(item.Value);
		}
		return new List<PedVdaEleTO>(dictionary.Values);
	}

	private List<PedVdaEleTO> DesmembraPedidoGrupo(DbConnection connTargetErp, List<PedVdaEleTO> listPedVdaEle)
	{
		List<PedVdaEleTO> list = new List<PedVdaEleTO>();
		foreach (PedVdaEleTO item in listPedVdaEle)
		{
			foreach (PedVdaEleTO item2 in DesmembraPedidoGrupo(connTargetErp, item))
			{
				list.Add(item2);
			}
		}
		return list;
	}

	private List<PedVdaEleTO> DesmembraPedidoGrupo(DbConnection connTargetErp, PedVdaEleTO PedVdaEle)
	{
		Dictionary<string, PedVdaEleTO> dictionary = new Dictionary<string, PedVdaEleTO>();
		ItPedvEleTO[] oItPedvEle = PedVdaEle.oItPedvEle;
		foreach (ItPedvEleTO itPedvEleTO in oItPedvEle)
		{
			ProdutoTO produtoTO = ProdutoBLL.Select(connTargetErp, Convert.ToInt32(PedVdaEle.CdEmpEle), itPedvEleTO.CdProd);
			if (produtoTO == null)
			{
				throw new Exception("Produto não localizado");
			}
			if (produtoTO.CdGrupoPrd == null)
			{
				produtoTO.CdGrupoPrd = "";
			}
			if (!dictionary.ContainsKey(produtoTO.CdGrupoPrd))
			{
				PedVdaEleTO pedVdaEleTO = PedVdaEle.Clone();
				pedVdaEleTO.CdEmpEle = Convert.ToInt32(PedVdaEle.CdEmpEle);
				pedVdaEleTO.oItPedvEle = null;
				dictionary.Add(produtoTO.CdGrupoPrd, pedVdaEleTO);
			}
			dictionary[produtoTO.CdGrupoPrd].IncluiItPedvEle(itPedvEleTO);
		}
		foreach (KeyValuePair<string, PedVdaEleTO> item in dictionary)
		{
			PedidoCalculaTotais(item.Value);
		}
		return new List<PedVdaEleTO>(dictionary.Values);
	}

	public void PedidoCalculaTotais(PedVdaEleTO PedVdaEle)
	{
		PedVdaEle.ValorTot = default(decimal);
		PedVdaEle.VlDescGeral = default(decimal);
		decimal num = default(decimal);
		ItPedvEleTO[] oItPedvEle = PedVdaEle.oItPedvEle;
		foreach (ItPedvEleTO itPedvEleTO in oItPedvEle)
		{
			if (itPedvEleTO.Bonificado.Equals(0))
			{
				num = ((!IndiceRelacao.Maior.Equals(itPedvEleTO.IndRelacao)) ? (itPedvEleTO.PrecoUnit / Convert.ToDecimal(itPedvEleTO.FatorEstPed)) : (itPedvEleTO.PrecoUnit * Convert.ToDecimal(itPedvEleTO.FatorEstPed)));
				decimal? valorTot = PedVdaEle.ValorTot;
				decimal value = num;
				decimal value2 = 1;
				decimal? descApl = itPedvEleTO.DescApl;
				decimal? num2 = (decimal?)value2 - descApl;
				PedVdaEle.ValorTot = valorTot + (decimal?)Math.Round(((decimal?)value * num2 * itPedvEleTO.QtdeUnidPed).Value, 2);
			}
		}
		if (!PedVdaEle.ValorTot.Equals(0))
		{
			PedVdaEle.VlDescGeral = PedVdaEle.ValorTot * PedVdaEle.PercDescGeral;
		}
	}
}
