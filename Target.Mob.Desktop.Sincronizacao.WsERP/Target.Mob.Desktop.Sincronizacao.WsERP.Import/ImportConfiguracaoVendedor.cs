using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using Target.Mob.Common.Seguranca;
using Target.Mob.Desktop.Common.Log;
using Target.Mob.Desktop.Configuracao.Bll;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.BLL;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;
using Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.Import;

public class ImportConfiguracaoVendedor
{
	private string _StringConnTargetMob;

	private string _StringConnTargetErp;

	private string _CnpjEmpresa;

	private BasicHttpBinding _bindingBasicHttp;

	private EndpointAddress _remoteAddress;

	public ImportConfiguracaoVendedor(string stringConnTargetErp, string stringConnTargetMob, string cnpjEmpresa, BasicHttpBinding bindingBasicHttp, EndpointAddress remoteAddress)
	{
		_StringConnTargetErp = stringConnTargetErp;
		_StringConnTargetMob = stringConnTargetMob;
		_CnpjEmpresa = cnpjEmpresa;
		_bindingBasicHttp = bindingBasicHttp;
		_remoteAddress = remoteAddress;
	}

	public void Importar()
	{
		using DbConnection dbConnection = new DbConnection(_StringConnTargetMob);
		using DbConnection dbConnection2 = new DbConnection(_StringConnTargetErp);
		try
		{
			dbConnection.Open();
			dbConnection2.Open();
			dbConnection.BeginTransaction();
			dbConnection2.BeginTransaction();
			byte[] rowId = ConfiguracaoVendedorBLL.selectMaxRowId(dbConnection);
			Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader validationSoapHeader = new Target.Mob.Desktop.Sincronizacao.WsERP.WsERP.ValidationSoapHeader();
			validationSoapHeader.Token = Seguranca.GeraTokenERP(_CnpjEmpresa, DateTime.Now);
			WsErpSoapClient wsErpSoapClient = new WsErpSoapClient(_bindingBasicHttp, _remoteAddress);
			RetornoWsModelOfListOfConfiguracaoVendedorWsModel retornoWsModelOfListOfConfiguracaoVendedorWsModel = wsErpSoapClient.WsERP_Config_Vendedor_GetV3(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), rowId);
			if (retornoWsModelOfListOfConfiguracaoVendedorWsModel.RetornoWs != null)
			{
				ConfiguracaoVendedorWsModel[] retornoWs = retornoWsModelOfListOfConfiguracaoVendedorWsModel.RetornoWs;
				foreach (ConfiguracaoVendedorWsModel configuracaoVendedorWs in retornoWs)
				{
					ConfiguracaoVendedorTO instance = ConstruirConfiguracaoVendedor(configuracaoVendedorWs);
					ConfiguracaoVendedorBLL.Merge(dbConnection2.GetTransaction(), instance);
					ConfiguracaoVendedorBLL.Merge(dbConnection.GetTransaction(), instance);
				}
				byte[] rowIdPainel = VendedorBLL.selectMaxRowId(dbConnection);
				RetornoWsModelOfListOfVendedorWsModel retornoWsModelOfListOfVendedorWsModel = wsErpSoapClient.WsERP_Vendedor_GetV3(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), rowIdPainel);
				if (retornoWsModelOfListOfVendedorWsModel.RetornoWs != null)
				{
					VendedorWsModel[] retornoWs2 = retornoWsModelOfListOfVendedorWsModel.RetornoWs;
					foreach (VendedorWsModel vendedorWs in retornoWs2)
					{
						VendedorTO instance2 = ConstruirVendedor(vendedorWs);
						VendedorBLL.merge(dbConnection.GetTransaction(), instance2);
						VendedorBLL.merge(dbConnection2.GetTransaction(), instance2);
					}
					dbConnection.CommitTransaction();
					dbConnection2.CommitTransaction();
					dbConnection2.BeginTransaction();
					byte[] rowId2 = CategoriaAnotacaoBLL.selectMaxRowId(dbConnection2);
					RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt = wsErpSoapClient.WsERP_CategoriaAnotacao_GetNews(validationSoapHeader, _CnpjEmpresa, rowId2, Seguranca.getHostName());
					if (retornoWsModelOfListOfInt.RetornoWs != null && retornoWsModelOfListOfInt.RetornoWs.Length >= 0)
					{
						int[] retornoWs3 = retornoWsModelOfListOfInt.RetornoWs;
						foreach (int idCategoriaAnotacao in retornoWs3)
						{
							RetornoWsModelOfCategoriaAnotacaoWsModel retornoWsModelOfCategoriaAnotacaoWsModel = wsErpSoapClient.WsERP_CategoriaAnotacao_Get(validationSoapHeader, _CnpjEmpresa, idCategoriaAnotacao, Seguranca.getHostName());
							CategoriaAnotacaoTO categAnot = ConstruirCategoriaAnotacao(retornoWsModelOfCategoriaAnotacaoWsModel.RetornoWs);
							CategoriaAnotacaoBLL.Merge(dbConnection2, categAnot);
						}
						RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt2 = wsErpSoapClient.WsERP_Anotacao_GetNews(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
						if (retornoWsModelOfListOfInt2.RetornoWs != null && retornoWsModelOfListOfInt2.RetornoWs.Length >= 0)
						{
							retornoWs3 = retornoWsModelOfListOfInt2.RetornoWs;
							foreach (int idAnotacao in retornoWs3)
							{
								RetornoWsModelOfAnotacaoWsModel retornoWsModelOfAnotacaoWsModel = wsErpSoapClient.WsERP_Anotacao_Get(validationSoapHeader, _CnpjEmpresa, idAnotacao, Seguranca.getHostName());
								AnotacaoTO anotat = ConstruirAnotacao(dbConnection2, dbConnection, retornoWsModelOfAnotacaoWsModel.RetornoWs);
								AnotacaoBLL.Merge(dbConnection2, anotat);
								wsErpSoapClient.WsERP_Anotacao_SetImport(validationSoapHeader, _CnpjEmpresa, idAnotacao, Seguranca.getHostName());
							}
							dbConnection2.CommitTransaction();
							dbConnection2.BeginTransaction();
							RetornoWsModelOfListOfInt32 retornoWsModelOfListOfInt3 = wsErpSoapClient.WsERP_CoordenadaResidencia_GetNews(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName());
							if (retornoWsModelOfListOfInt3.RetornoWs != null)
							{
								retornoWs3 = retornoWsModelOfListOfInt3.RetornoWs;
								foreach (int idCoordenadaResidencia in retornoWs3)
								{
									RetornoWsModelOfCoordenadaResidenciaWsModel retornoWsModelOfCoordenadaResidenciaWsModel = wsErpSoapClient.WsERP_CoordenadaResidencia_Get(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), idCoordenadaResidencia);
									if (wsErpSoapClient.WsERP_CoordenadaResidencia_Get(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), idCoordenadaResidencia).RetornoWs != null)
									{
										CoordenadaResidenciaTO coordenadaResidenciaTO = ConstruirCoordenadaResidencia(retornoWsModelOfCoordenadaResidenciaWsModel.RetornoWs);
										if ("V".Equals(coordenadaResidenciaTO.TipoUsuario.ToUpper()))
										{
											VendedorErpBLL.setCoordenadaResidencia(dbConnection2, coordenadaResidenciaTO);
										}
										else if ("P".Equals(coordenadaResidenciaTO.TipoUsuario.ToUpper()))
										{
											PromotorBLL.setCoordenadaResidencia(dbConnection2, coordenadaResidenciaTO);
										}
										RetornoWsModelOfBoolean retornoWsModelOfBoolean = wsErpSoapClient.WsERP_CoordenadaResidencia_SetImport(validationSoapHeader, _CnpjEmpresa, Seguranca.getHostName(), idCoordenadaResidencia);
										if (!retornoWsModelOfBoolean.RetornoWs)
										{
											throw new Exception("Erro WsERP_CoordenadaResidencia_SetImport - TipoUsuario e Idusuario: " + coordenadaResidenciaTO.TipoUsuario + " - " + coordenadaResidenciaTO.IdUsuario + ". " + retornoWsModelOfBoolean.Excecao.ToString());
										}
									}
								}
								dbConnection2.CommitTransaction();
								return;
							}
							throw new Exception("COORDENADA RESIDENCIA " + retornoWsModelOfListOfConfiguracaoVendedorWsModel.Excecao.Erro);
						}
						throw new Exception("ANOTACAO" + retornoWsModelOfListOfConfiguracaoVendedorWsModel.Excecao.Erro);
					}
					throw new Exception("CATEGORIA ANOTACAO" + retornoWsModelOfListOfConfiguracaoVendedorWsModel.Excecao.Erro);
				}
				throw new Exception(retornoWsModelOfListOfConfiguracaoVendedorWsModel.Excecao.Erro);
			}
			throw new Exception(retornoWsModelOfListOfConfiguracaoVendedorWsModel.Excecao.Erro);
		}
		catch (Exception ex)
		{
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			Type type = GetType();
			dbConnection.RollbackTransaction();
			dbConnection2.RollbackTransaction();
			LogEvento.WriteEntry(type.Name + "." + currentMethod.Name, ex.Message, EventLogEntryType.Error);
		}
		finally
		{
			dbConnection.Close();
			dbConnection2.Close();
		}
	}

	private CoordenadaResidenciaTO ConstruirCoordenadaResidencia(CoordenadaResidenciaWsModel modelWs)
	{
		return new CoordenadaResidenciaTO
		{
			Latitude = modelWs.Latitude,
			Longitude = modelWs.Longitude,
			TipoUsuario = modelWs.TipoUsuario,
			IdUsuario = modelWs.IdUsuario,
			UsuarioLogado = modelWs.UsuarioLogado,
			IdCoordenadaResidencia = modelWs.IdCoordenadaResidencia
		};
	}

	private ConfiguracaoVendedorTO ConstruirConfiguracaoVendedor(ConfiguracaoVendedorWsModel configuracaoVendedorWs)
	{
		ConfiguracaoVendedorTO configuracaoVendedorTO = new ConfiguracaoVendedorTO();
		configuracaoVendedorTO.Id = configuracaoVendedorWs.IDConfiguracaoVendedor;
		configuracaoVendedorTO.DescricaoConfiguracaoVendedor = configuracaoVendedorWs.DescricaoConfiguracaoVendedor;
		configuracaoVendedorTO.BloquearFormPgtoBancoVendaEspecial = configuracaoVendedorWs.BloquearFormPgtoBancoVendaEspecial;
		configuracaoVendedorTO.BloquearPedVdaAlvaraVencido = configuracaoVendedorWs.BloquearPedVdaAlvaraVencido;
		configuracaoVendedorTO.BloquearPedVdaAnvisaVencido = configuracaoVendedorWs.BloquearPedVdaAnvisaVencido;
		configuracaoVendedorTO.BloquearPedVdaLimiteCredito = configuracaoVendedorWs.BloquearPedVdaLimiteCredito;
		configuracaoVendedorTO.BloquearPedVdaMargemMinima = configuracaoVendedorWs.BloquearPedVdaMargemMinima;
		configuracaoVendedorTO.BloquearPedVdaPorValorMinimo = configuracaoVendedorWs.BloquearPedVdaPorValorMinimo;
		configuracaoVendedorTO.BloquearPedVdaSaldoVerbaNegativo = configuracaoVendedorWs.BloquearPedVdaSaldoVerbaNegativo;
		configuracaoVendedorTO.BloquearPedVdaSituacaoCredito = configuracaoVendedorWs.BloquearPedVdaSituacaoCredito;
		configuracaoVendedorTO.BloquearVendaAcimaEstoque = configuracaoVendedorWs.BloquearVendaAcimaEstoque;
		configuracaoVendedorTO.BloquearVendaNormalItemEmPromocao = configuracaoVendedorWs.BloquearVendaNormalItemEmPromocao;
		configuracaoVendedorTO.BloquearVisitaAvulsa = configuracaoVendedorWs.BloquearVisitaAvulsa;
		configuracaoVendedorTO.BloqueiaAlteracaoAgendamentoVisitas = configuracaoVendedorWs.BloqueiaAlteracaoAgendamentoVisitas;
		configuracaoVendedorTO.CalcularSubstituicaoTributaria = configuracaoVendedorWs.CalcularSubstituicaoTributaria;
		configuracaoVendedorTO.ClienteNovoCodigoFormPgto = configuracaoVendedorWs.ClienteNovoCodigoFormPgto;
		configuracaoVendedorTO.ClienteNovoCodigoTabPre = configuracaoVendedorWs.ClienteNovoCodigoTabPre;
		configuracaoVendedorTO.ClienteNovoCodigoTpPed = configuracaoVendedorWs.ClienteNovoCodigoTpPed;
		configuracaoVendedorTO.ClienteNovoPrazoMedio = configuracaoVendedorWs.ClienteNovoPrazoMedio;
		configuracaoVendedorTO.CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial = configuracaoVendedorWs.CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial;
		configuracaoVendedorTO.ControlarOrdemVisitas = configuracaoVendedorWs.ControlarOrdemVisitas;
		configuracaoVendedorTO.DesmembraPedidoProdutoxEmpresa = configuracaoVendedorWs.DesmembraPedidoProdutoxEmpresa;
		configuracaoVendedorTO.DesmembraPedidoProdutoxGrupoProduto = configuracaoVendedorWs.DesmembraPedidoProdutoxGrupoProduto;
		configuracaoVendedorTO.ExibePercentualMargemPedVda = configuracaoVendedorWs.ExibePercentualMargemPedVda;
		configuracaoVendedorTO.ExibeSinalizadorMargemPedVda = configuracaoVendedorWs.ExibeSinalizadorMargemPedVda;
		configuracaoVendedorTO.ExibirEstoque = configuracaoVendedorWs.ExibirEstoque;
		configuracaoVendedorTO.ExibirSaldoComissao = configuracaoVendedorWs.ExibirSaldoComissao;
		configuracaoVendedorTO.ExibirSaldoVerba = configuracaoVendedorWs.ExibirSaldoVerba;
		configuracaoVendedorTO.ExibirTituloSomenteVendedor = configuracaoVendedorWs.ExibirTituloSomenteVendedor;
		configuracaoVendedorTO.ExibirVerbaFechamentoPedVda = configuracaoVendedorWs.ExibirVerbaFechamentoPedVda;
		configuracaoVendedorTO.HorarioFimVisita = configuracaoVendedorWs.HorarioFimVisita;
		configuracaoVendedorTO.HorarioInicioVisita = configuracaoVendedorWs.HorarioInicioVisita;
		configuracaoVendedorTO.JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento = configuracaoVendedorWs.JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento;
		configuracaoVendedorTO.LiberarCreditoVerbaPedidoNovo = configuracaoVendedorWs.LiberarCreditoVerbaPedidoNovo;
		configuracaoVendedorTO.LiberarPedidosAutomaticamente = configuracaoVendedorWs.LiberarPedidosAutomaticamente;
		configuracaoVendedorTO.LiberarTodasCondPgtoPedVda = configuracaoVendedorWs.LiberarTodasCondPgtoPedVda;
		configuracaoVendedorTO.LimiteMinimoVerbaVendedor = configuracaoVendedorWs.LimiteMinimoVerbaVendedor;
		configuracaoVendedorTO.NaoImportarAtualizacaoPlanoVisita = configuracaoVendedorWs.NaoImportarAtualizacaoPlanoVisita;
		configuracaoVendedorTO.ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto = configuracaoVendedorWs.ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto;
		configuracaoVendedorTO.ObrigarInformarRamoAtivPedVda = configuracaoVendedorWs.ObrigarInformarRamoAtivPedVda;
		configuracaoVendedorTO.ObrigarMotivoNaoVendaDiaAnterior = configuracaoVendedorWs.ObrigarMotivoNaoVendaDiaAnterior;
		configuracaoVendedorTO.ObrigarMotivoNaoVendaForaRoteiroDiaAnterior = configuracaoVendedorWs.ObrigarMotivoNaoVendaForaRoteiroDiaAnterior;
		configuracaoVendedorTO.PercDescMaxFlex = configuracaoVendedorWs.PercDescMaxFlex;
		configuracaoVendedorTO.PercDesconto = configuracaoVendedorWs.PercDesconto;
		configuracaoVendedorTO.PercIndenizacaoTroca = configuracaoVendedorWs.PercIndenizacaoTroca;
		configuracaoVendedorTO.PercMaxCreditoVerba = configuracaoVendedorWs.PercMaxCreditoVerba;
		configuracaoVendedorTO.PercMaxDescGeralPedVda = configuracaoVendedorWs.PercMaxDescGeralPedVda;
		configuracaoVendedorTO.PercMaxToleranciaVisitaForaRota = configuracaoVendedorWs.PercMaxToleranciaVisitaForaRota;
		configuracaoVendedorTO.PercToleranciaLimiteCredito = configuracaoVendedorWs.PercToleranciaLimiteCredito;
		configuracaoVendedorTO.PermiteAlterarPercIndenizacao = configuracaoVendedorWs.PermiteAlterarPercIndenizacao;
		configuracaoVendedorTO.PermitirAlterarFormPgtoPedVda = configuracaoVendedorWs.PermitirAlterarFormPgtoPedVda;
		configuracaoVendedorTO.PermitirCadastrarNovoCliente = configuracaoVendedorWs.PermitirCadastrarNovoCliente;
		configuracaoVendedorTO.PermitirDescontoGeral = configuracaoVendedorWs.PermitirDescontoGeral;
		configuracaoVendedorTO.PermitirLancarPedVdaClienteNovo = configuracaoVendedorWs.PermitirLancarPedVdaClienteNovo;
		configuracaoVendedorTO.QtdeDiasCancelamentoCotacao = configuracaoVendedorWs.QtdeDiasCancelamentoCotacao;
		configuracaoVendedorTO.QtdeDiasEstoqueInsuficiente = configuracaoVendedorWs.QtdeDiasEstoqueInsuficiente;
		configuracaoVendedorTO.QtdeDiasExibirAvisoVencAlvara = configuracaoVendedorWs.QtdeDiasExibirAvisoVencAlvara;
		configuracaoVendedorTO.QtdeDiasExibirAvisoVencAnvisa = configuracaoVendedorWs.QtdeDiasExibirAvisoVencAnvisa;
		configuracaoVendedorTO.QtdeDiasTitulosAVencer = configuracaoVendedorWs.QtdeDiasTitulosAVencer;
		configuracaoVendedorTO.QtdeDiasToleranciaInadimplencia = configuracaoVendedorWs.QtdeDiasToleranciaInadimplencia;
		configuracaoVendedorTO.QtdeMaxPedVdaSemTransmissao = configuracaoVendedorWs.QtdeMaxPedVdaSemTransmissao;
		configuracaoVendedorTO.QtdeMaxVisitasDia = configuracaoVendedorWs.QtdeMaxVisitasDia;
		configuracaoVendedorTO.QtdePedVdaHistoricoCliente = configuracaoVendedorWs.QtdePedVdaHistoricoCliente;
		configuracaoVendedorTO.RespeitaAssociacaoVendedorxProduto = configuracaoVendedorWs.RespeitaAssociacaoVendedorxProduto;
		configuracaoVendedorTO.RespeitaAssociacaoVendedorxTabelaPreco = configuracaoVendedorWs.RespeitaAssociacaoVendedorxTabelaPreco;
		configuracaoVendedorTO.RespeitaAssociacaoVendedorxTipoPedido = configuracaoVendedorWs.RespeitaAssociacaoVendedorxTipoPedido;
		configuracaoVendedorTO.SugereFiltroMixSegmentoPedVda = configuracaoVendedorWs.SugereFiltroMixSegmentoPedVda;
		configuracaoVendedorTO.TaxaJuros = configuracaoVendedorWs.TaxaJuros;
		configuracaoVendedorTO.TipoAbatimentoTroca = configuracaoVendedorWs.TipoAbatimentoTroca;
		configuracaoVendedorTO.TipoCusto = configuracaoVendedorWs.TipoCusto;
		configuracaoVendedorTO.TipoDescontoVerbaItemBonificado = configuracaoVendedorWs.TipoDescontoVerbaItemBonificado;
		configuracaoVendedorTO.TipoPedVdaHistoricoCliente = configuracaoVendedorWs.TipoPedVdaHistoricoCliente;
		configuracaoVendedorTO.TipoRestricaoVenda = configuracaoVendedorWs.TipoRestricaoVenda;
		configuracaoVendedorTO.RestrVendaSomenteVendedorPrioritario = configuracaoVendedorWs.RestrVendaSomenteVendedorPrioritario;
		configuracaoVendedorTO.UtilizaBonificacao = configuracaoVendedorWs.UtilizaBonificacao;
		configuracaoVendedorTO.UtilizaDescontoFlexPcfgTargetMob = configuracaoVendedorWs.UtilizaDescontoFlexPcfgTargetMob;
		configuracaoVendedorTO.UtilizaDescontoPromocionalAutomatico = configuracaoVendedorWs.UtilizaDescontoPromocionalAutomatico;
		configuracaoVendedorTO.UtilizaFormPgtoDepositoConta = configuracaoVendedorWs.UtilizaFormPgtoDepositoConta;
		configuracaoVendedorTO.UtilizaMotivoNaoVendaForaRoteiroDiaAnterior = configuracaoVendedorWs.UtilizaMotivoNaoVendaForaRoteiroDiaAnterior;
		configuracaoVendedorTO.UtilizaProposta = configuracaoVendedorWs.UtilizaProposta;
		configuracaoVendedorTO.UtilizaQtdeMaxPedVdaSemTransmissao = configuracaoVendedorWs.UtilizaQtdeMaxPedVdaSemTransmissao;
		configuracaoVendedorTO.UtilizaTroca = configuracaoVendedorWs.UtilizaTroca;
		configuracaoVendedorTO.UtilizaUnidadeVendaNaTroca = configuracaoVendedorWs.UtilizaUnidadeVendaNaTroca;
		configuracaoVendedorTO.ValorMinimoProposta = configuracaoVendedorWs.ValorMinimoProposta;
		configuracaoVendedorTO.NaoImportarInformacaoVisitaForaRota = configuracaoVendedorWs.NaoImportarInformacaoVisitaForaRota;
		configuracaoVendedorTO.AplicarPrazoMedioNaAssociacaoClienteCondPgto = configuracaoVendedorWs.AplicarPrazoMedioNaAssociacaoClienteCondPgto;
		configuracaoVendedorTO.UtilizaDescontoPromocionalAutomaticoPromFlex = configuracaoVendedorWs.UtilizaDescontoPromocionalAutomaticoPromFlex;
		configuracaoVendedorTO.IgnorarMotivoNaoVendaMixSegmento = configuracaoVendedorWs.IgnorarMotivoNaoVendaMixSegmento;
		configuracaoVendedorTO.ExibirProdutosNaoAssociadosCondPagto = configuracaoVendedorWs.ExibirProdutosNaoAssociadosCondPagto;
		configuracaoVendedorTO.OcultarProdutosSemEstoque = configuracaoVendedorWs.OcultarProdutosSemEstoque;
		configuracaoVendedorTO.ExibirCondPagtoDentroPrazoMedioEAssociadasCliente = configuracaoVendedorWs.ExibirCondPagtoDentroPrazoMedioEAssociadasCliente;
		configuracaoVendedorTO.BloquearAlterarTipoEntrega = configuracaoVendedorWs.BloquearAlterarTipoEntrega;
		configuracaoVendedorTO.PermiteAlterarDescontoPorQuantidade = configuracaoVendedorWs.PermiteAlterarDescontoPorQuantidade;
		configuracaoVendedorTO.SupervisorNaoReceberCargaEquipe = configuracaoVendedorWs.SupervisorNaoReceberCargaEquipe;
		configuracaoVendedorTO.TiposFiltrosItensPedidoFabricante = configuracaoVendedorWs.TiposFiltrosItensPedidoFabricante;
		configuracaoVendedorTO.TiposFiltrosItensPedidoCategoria = configuracaoVendedorWs.TiposFiltrosItensPedidoCategoria;
		configuracaoVendedorTO.TiposFiltrosItensPedidoLinha = configuracaoVendedorWs.TiposFiltrosItensPedidoLinha;
		configuracaoVendedorTO.TiposFiltrosItensPedidoDepto = configuracaoVendedorWs.TiposFiltrosItensPedidoDepto;
		configuracaoVendedorTO.TiposFiltrosItensPedidoSecao = configuracaoVendedorWs.TiposFiltrosItensPedidoSecao;
		configuracaoVendedorTO.NaoSincronizarAposLancamentoPedido = configuracaoVendedorWs.NaoSincronizarAposLancamentoPedido;
		configuracaoVendedorTO.CalcularVerbaItemKitProm = configuracaoVendedorWs.CalcularVerbaItemKitProm;
		configuracaoVendedorTO.ManterRegrasAlteracaoTabelaPrecoProposta = configuracaoVendedorWs.ManterRegrasAlteracaoTabelaPrecoProposta;
		configuracaoVendedorTO.PercMargemSegurancaGondola = configuracaoVendedorWs.PercMargemSegurancaGondola;
		configuracaoVendedorTO.SolicitarColetaLocalizacaoCliente = configuracaoVendedorWs.SolicitarColetaLocalizacaoCliente;
		configuracaoVendedorTO.ObrigarColetaLocalizacaoCliente = configuracaoVendedorWs.ObrigarColetaLocalizacaoCliente;
		configuracaoVendedorTO.UtilizaRecursoLocalizacao = configuracaoVendedorWs.UtilizaRecursoLocalizacao;
		configuracaoVendedorTO.RestricaoVendaLocalizacaoCliente = configuracaoVendedorWs.RestricaoVendaLocalizacaoCliente;
		configuracaoVendedorTO.ExibirValidadeMinimaProduto = configuracaoVendedorWs.ExibirValidadeMinimaProduto;
		configuracaoVendedorTO.ObrigarInformarGondola = configuracaoVendedorWs.ObrigarInformarGondola;
		configuracaoVendedorTO.PercMaxVendaSemApontamentoGondola = configuracaoVendedorWs.PercMaxVendaSemApontamentoGondola;
		configuracaoVendedorTO.ArredondarUnidCompraAlgoritmo = configuracaoVendedorWs.ArredondarUnidCompraAlgoritmo;
		configuracaoVendedorTO.EstoqueRespeitarTpPed = configuracaoVendedorWs.EstoqueRespeitarTpPed;
		configuracaoVendedorTO.PermitirCadastroEmailClienteLanctoPedido = configuracaoVendedorWs.PermitirCadastroEmailClienteLanctoPedido;
		configuracaoVendedorTO.ObrigarCadastroEmailClienteLanctoPedido = configuracaoVendedorWs.ObrigarCadastroEmailClienteLanctoPedido;
		configuracaoVendedorTO.UtilizarDescontoMaximoProduto = configuracaoVendedorWs.UtilizarDescontoMaximoProduto;
		configuracaoVendedorTO.ConsiderarDescontoGeral = configuracaoVendedorWs.ConsiderarDescontoGeral;
		configuracaoVendedorTO.QtdeMaxCotacaoPorVendedor = configuracaoVendedorWs.QtdeMaxCotacaoPorVendedor;
		configuracaoVendedorTO.ObrigarInformarCheckoutsCliente = configuracaoVendedorWs.ObrigarInformarCheckoutsCliente;
		configuracaoVendedorTO.AtualizarDescTrocaCondPgto = configuracaoVendedorWs.AtualizarDescTrocaCondPgto;
		configuracaoVendedorTO.QtdeDiasFrequenciaSemRoteiroVisita = configuracaoVendedorWs.QtdeDiasFrequenciaSemRoteiroVisita;
		configuracaoVendedorTO.TipoMargemSegurancaGondola = configuracaoVendedorWs.TipoMargemSegurancaGondola;
		configuracaoVendedorTO.QtdeMargemSegurancaGondola = configuracaoVendedorWs.QtdeMargemSegurancaGondola;
		configuracaoVendedorTO.UtilizarApontamentoGondola = configuracaoVendedorWs.UtilizarApontamentoGondola;
		configuracaoVendedorTO.ObrigatorioInformarEmailContatoComercial = configuracaoVendedorWs.ObrigatorioInformarEmailContatoComercial;
		configuracaoVendedorTO.PermiteEntregaOutroCliente = configuracaoVendedorWs.PermiteEntregaOutroCliente;
		configuracaoVendedorTO.ExibirStatusPositivacaoProdutos = configuracaoVendedorWs.ExibirStatusPositivacaoProdutos;
		if ((configuracaoVendedorWs.EnviarEmailPedido.HasValue && configuracaoVendedorWs.EnviarEmailPedido.Value) || (configuracaoVendedorWs.EnviarEmailPedidoAtendimento.HasValue && configuracaoVendedorWs.EnviarEmailPedidoAtendimento.Value))
		{
			configuracaoVendedorTO.UtilizarEmailComercial = true;
		}
		else
		{
			configuracaoVendedorTO.UtilizarEmailComercial = false;
		}
		configuracaoVendedorTO.LancarQtdeEstoqueZeroItensObrigatorios = configuracaoVendedorWs.LancarQtdeZeroItensObrig;
		configuracaoVendedorTO.EnviarPedidoAutomaticamenteAposLancamento = configuracaoVendedorWs.EnviarPedAutoAposLanc;
		if (configuracaoVendedorWs.ListConfiguracaoVendedorClienteNovoFormPgtoWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorClienteNovoFormPgtoWs.Length != 0)
		{
			ConfiguracaoVendedorClienteNovoFormPgtoWsModel[] listConfiguracaoVendedorClienteNovoFormPgtoWs = configuracaoVendedorWs.ListConfiguracaoVendedorClienteNovoFormPgtoWs;
			foreach (ConfiguracaoVendedorClienteNovoFormPgtoWsModel clienteNovoFormPgto in listConfiguracaoVendedorClienteNovoFormPgtoWs)
			{
				configuracaoVendedorTO.ClienteNovoFormPgto.Add(ConstruirClienteNovoFormPgtoTO(clienteNovoFormPgto));
			}
		}
		if (configuracaoVendedorWs.ListVendedorWs != null && configuracaoVendedorWs.ListVendedorWs.Length != 0)
		{
			VendedorWsModel[] listVendedorWs = configuracaoVendedorWs.ListVendedorWs;
			foreach (VendedorWsModel vendedorWs in listVendedorWs)
			{
				configuracaoVendedorTO.Vendedor.Add(ConstruirVendedor(vendedorWs));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorEstoqueWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorEstoqueWs.Length != 0)
		{
			ConfiguracaoVendedorEstoqueWsModel[] listConfiguracaoVendedorEstoqueWs = configuracaoVendedorWs.ListConfiguracaoVendedorEstoqueWs;
			foreach (ConfiguracaoVendedorEstoqueWsModel configuracaoVendedorEstoqueWs in listConfiguracaoVendedorEstoqueWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorEstoque.Add(ConstruirConfiguracaoVendedorEstoque(configuracaoVendedorEstoqueWs));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorVisitaDiasSemanaWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorVisitaDiasSemanaWs.Length != 0)
		{
			ConfiguracaoVendedorVisitaDiasSemanaWsModel[] listConfiguracaoVendedorVisitaDiasSemanaWs = configuracaoVendedorWs.ListConfiguracaoVendedorVisitaDiasSemanaWs;
			foreach (ConfiguracaoVendedorVisitaDiasSemanaWsModel configuracaoVendedorVisitaDiasSemanaWs in listConfiguracaoVendedorVisitaDiasSemanaWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorVisitaDiasSemana.Add(ConstruirConfiguracaoVendedorVisitaDiasSemana(configuracaoVendedorVisitaDiasSemanaWs));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorVisitaFrequenciaWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorVisitaFrequenciaWs.Length != 0)
		{
			ConfiguracaoVendedorVisitaFrequenciaWsModel[] listConfiguracaoVendedorVisitaFrequenciaWs = configuracaoVendedorWs.ListConfiguracaoVendedorVisitaFrequenciaWs;
			foreach (ConfiguracaoVendedorVisitaFrequenciaWsModel configuracaoVendedorVisitaFrequenciaWs in listConfiguracaoVendedorVisitaFrequenciaWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorVisitaFrequencia.Add(ConstruirConfiguracaoVendedorVisitaFrequencia(configuracaoVendedorVisitaFrequenciaWs));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorTipoNotificacaoWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorTipoNotificacaoWs.Length != 0)
		{
			ConfiguracaoVendedorTipoNotificacaoWsModel[] listConfiguracaoVendedorTipoNotificacaoWs = configuracaoVendedorWs.ListConfiguracaoVendedorTipoNotificacaoWs;
			foreach (ConfiguracaoVendedorTipoNotificacaoWsModel configuracaoVendedorTipoNotificacaoWs in listConfiguracaoVendedorTipoNotificacaoWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorTipoNotificacao.Add(ConstruirConfiguracaoVendedorTipoNotificacao(configuracaoVendedorTipoNotificacaoWs));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorOrdenacaoGondolaWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorOrdenacaoGondolaWs.Length != 0)
		{
			ConfiguracaoVendedorOrdenacaoGondolaWsModel[] listConfiguracaoVendedorOrdenacaoGondolaWs = configuracaoVendedorWs.ListConfiguracaoVendedorOrdenacaoGondolaWs;
			foreach (ConfiguracaoVendedorOrdenacaoGondolaWsModel configuracaoVendedorOrdenacaoGondolaTOWs in listConfiguracaoVendedorOrdenacaoGondolaWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorOrdenacaoGondola.Add(ConstruirConfiguracaoVendedorOrdenacaoGondola(configuracaoVendedorOrdenacaoGondolaTOWs));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorCoordenadaDiasSemanaWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorCoordenadaDiasSemanaWs.Length != 0)
		{
			ConfiguracaoVendedorCoordenadaDiasSemanaWsModel[] listConfiguracaoVendedorCoordenadaDiasSemanaWs = configuracaoVendedorWs.ListConfiguracaoVendedorCoordenadaDiasSemanaWs;
			foreach (ConfiguracaoVendedorCoordenadaDiasSemanaWsModel configuracaoVendedorCoordenadaDiasSemanaWsModel in listConfiguracaoVendedorCoordenadaDiasSemanaWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorCoordenadaDiasSemana.Add(ConstruirConfiguracaoVendedorCoordenadaDiasSemana(configuracaoVendedorCoordenadaDiasSemanaWsModel));
			}
		}
		configuracaoVendedorTO.ExibirPromFlexLancItem = configuracaoVendedorWs.ExibirPromocoesFlexiveisLancamentoItem;
		configuracaoVendedorTO.ControlarHorarioAlmoco = configuracaoVendedorWs.ControlarHorarioAlmoco;
		configuracaoVendedorTO.TempoAlmoco = configuracaoVendedorWs.TempoAlmoco;
		configuracaoVendedorTO.TempoBloqueioAlmoco = configuracaoVendedorWs.TempoBloqueioAlmoco;
		configuracaoVendedorTO.HorarioIniciarAlmoco = configuracaoVendedorWs.HorarioIniciarAlmoco;
		configuracaoVendedorTO.RaioCliente = configuracaoVendedorWs.RaioCliente;
		configuracaoVendedorTO.PropostaPercMgBrutaMinima = configuracaoVendedorWs.PropostaPercMgBrutaMinima;
		configuracaoVendedorTO.ValidarVlPrecoMinimoPedido = configuracaoVendedorWs.ValidarVlPrecoMinimoPedido;
		configuracaoVendedorTO.ValidarVlPrecoMinimoProposta = configuracaoVendedorWs.ValidarVlPrecoMinimoProposta;
		configuracaoVendedorTO.ClassificacaoCurvaABCProduto = configuracaoVendedorWs.ClassificacaoCurvaABCProduto;
		configuracaoVendedorTO.BloqueiaTituloPorColigacao = configuracaoVendedorWs.BloqueiaTituloPorColigacao;
		configuracaoVendedorTO.BloqueiaTituloPorGrupo = configuracaoVendedorWs.BloqueiaTituloPorGrupo;
		configuracaoVendedorTO.InicioJornadaNoRoteiro = configuracaoVendedorWs.InicioJornadaNoRoteiro;
		configuracaoVendedorTO.FimJornadaNoRoteiro = configuracaoVendedorWs.FimJornadaNoRoteiro;
		configuracaoVendedorTO.RowId = configuracaoVendedorWs.RowId;
		if (configuracaoVendedorWs.ListConfiguracaoVendedorPaisWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorPaisWs.Length != 0)
		{
			ConfiguracaoVendedorPaisWsModel[] listConfiguracaoVendedorPaisWs = configuracaoVendedorWs.ListConfiguracaoVendedorPaisWs;
			foreach (ConfiguracaoVendedorPaisWsModel configuracaoVendedorPaisWsModel in listConfiguracaoVendedorPaisWs)
			{
				configuracaoVendedorTO.ConfiguracaoVendedorPais.Add(ConstruirConfiguracaoVendedorPais(configuracaoVendedorPaisWsModel));
			}
		}
		if (configuracaoVendedorWs.ListConfiguracaoVendedorInadimplenciaFormPgtoWs != null && configuracaoVendedorWs.ListConfiguracaoVendedorInadimplenciaFormPgtoWs.Length != 0)
		{
			ConfiguracaoVendedorInadimplenciaFormPgtoWsModel[] listConfiguracaoVendedorInadimplenciaFormPgtoWs = configuracaoVendedorWs.ListConfiguracaoVendedorInadimplenciaFormPgtoWs;
			for (int i = 0; i < listConfiguracaoVendedorInadimplenciaFormPgtoWs.Length; i++)
			{
				ConfiguracaoVendedorInadimplenciaFormPgtoModel configuracaoVendedorInadimplenciaWs = (ConfiguracaoVendedorInadimplenciaFormPgtoModel)listConfiguracaoVendedorInadimplenciaFormPgtoWs[i];
				configuracaoVendedorTO.ConfiguracaoVendedorInadimplenciaFormPgto.Add(ConstruirConfiguracaoVendedorInadimplenciaFormPgto(configuracaoVendedorInadimplenciaWs));
			}
		}
		configuracaoVendedorTO.ExibirMetaPositivFabric = configuracaoVendedorWs.ExibirMetaPositivFabric;
		configuracaoVendedorTO.InadimplenciaPrazoMedio = configuracaoVendedorWs.InadimplenciaPrazoMedio;
		configuracaoVendedorTO.UtilizaVisitaTelefonica = configuracaoVendedorWs.UtilizaVisitaTelefonica;
		configuracaoVendedorTO.PermiteIndicarMotivoNaoVendaComAcaoLigacao = configuracaoVendedorWs.PermiteIndicarMotivoNaoVendaComAcaoLigacao;
		configuracaoVendedorTO.DuracaoMinimaLigacaoVisita = configuracaoVendedorWs.DuracaoMinimaLigacaoVisita;
		configuracaoVendedorTO.UtilizaVendedorCliente = configuracaoVendedorWs.UtilizaVendedorCliente;
		configuracaoVendedorTO.UtilizaBonificacaoSomentePromocao = configuracaoVendedorWs.UtilizaBonificacaoSomentePromocao;
		configuracaoVendedorTO.UtilizaAnotacoes = configuracaoVendedorWs.UtilizaAnotacoes;
		configuracaoVendedorTO.QtdeMaxDiasExibirAnotacoes = configuracaoVendedorWs.QtdeMaxDiasExibirAnotacoes;
		configuracaoVendedorTO.EsconderAnotacoesTelaPedido = configuracaoVendedorWs.EsconderAnotacoesTelaPedido;
		configuracaoVendedorTO.ObrigarPreencherAnotacao = configuracaoVendedorWs.ObrigarPreencherAnotacao;
		configuracaoVendedorTO.TipoEnvioAnotacoes = configuracaoVendedorWs.TipoEnvioAnotacoes;
		configuracaoVendedorTO.ObrigarComoRealizouVenda = configuracaoVendedorWs.ObrigarComoRealizouVenda;
		configuracaoVendedorTO.ExibirTituloVencidoTodoVendedor = configuracaoVendedorWs.ExibirTituloVencidoTodoVendedor;
		configuracaoVendedorTO.ObrigarEnviarFotoClienteNovo = configuracaoVendedorWs.ObrigarEnviarFotoClienteNovo;
		configuracaoVendedorTO.ExibirNotaCredito = configuracaoVendedorWs.ExibirNotaCredito;
		configuracaoVendedorTO.UtilizaDescontoPorQtdeAutomatico = configuracaoVendedorWs.UtilizaDescontoPorQtdeAutomatico;
		configuracaoVendedorTO.UtilizaIndicacaoFaltaEstoquePromotor = configuracaoVendedorWs.UtilizaIndFaltaEstoquePromotor;
		configuracaoVendedorTO.QtdeMaxDiasExibirIndicacaoFaltaEstoquePromotor = configuracaoVendedorWs.QtdeDiasAvisoFaltaProdutoPromotor;
		configuracaoVendedorTO.ExibirPrecoMenorUnidadeListaItens = configuracaoVendedorWs.ExibirPrecoMenorUnidadeListaItens;
		configuracaoVendedorTO.ExibirLinhaDigitavelBoleto = configuracaoVendedorWs.ExibirLinhaDigitavelBoleto;
		configuracaoVendedorTO.SugerirFiltroMixCliente = configuracaoVendedorWs.SugerirFiltroMixCliente;
		configuracaoVendedorTO.ObrigarInformarEmailNFe = configuracaoVendedorWs.ObrigarInformarEmailNFe;
		configuracaoVendedorTO.ObrigarInformarEmailFinanceiro = configuracaoVendedorWs.ObrigarInformarEmailFinanceiro;
		configuracaoVendedorTO.ExibirAlertaProdutoComplementar = configuracaoVendedorWs.ExibirAlertaProdutoComplementar;
		configuracaoVendedorTO.ExibirAlertaProdutoSimilar = configuracaoVendedorWs.ExibirAlertaProdutoSimilar;
		configuracaoVendedorTO.RespeitarOrdemLancamentoItemPdfEmail = configuracaoVendedorWs.RespeitarOrdemLancamentoItemPdfEmail;
		configuracaoVendedorTO.EnviarObservacaoProdutoPdfEmail = configuracaoVendedorWs.EnviarObservacaoProdutoPdfEmail;
		configuracaoVendedorTO.UtilizarEmailCotacaoComImagem = configuracaoVendedorWs.UtilizarEmailCotacaoComImagem;
		configuracaoVendedorTO.ExibirHorarioRoteiroVisita = configuracaoVendedorWs.ExibirHorarioRoteiroVisita;
		configuracaoVendedorTO.BloquearPedVdaLimiteCreditoTerceiro = configuracaoVendedorWs.BloquearPedVdaLimiteCreditoTerceiro;
		configuracaoVendedorTO.PercToleranciaLimiteCreditoTerceiro = configuracaoVendedorWs.PercToleranciaLimiteCreditoTerceiro;
		configuracaoVendedorTO.ClienteCurvaABC = configuracaoVendedorWs.ClienteCurvaABC;
		configuracaoVendedorTO.ConsiderarDescontoMaximoPermitido = configuracaoVendedorWs.ConsiderarDescontoMaximoPermitido;
		configuracaoVendedorTO.EnviaSomenteUnidadesComOrdemImpressao = configuracaoVendedorWs.EnviaSomenteUnidadesComOrdemImpressao;
		configuracaoVendedorTO.SugerirFiltroProdutoReportadoEmFalta = configuracaoVendedorWs.SugerirFiltroProdutoReportadoEmFalta;
		configuracaoVendedorTO.BloquearPedVdaPeloValorMinimoGrupoProduto = configuracaoVendedorWs.BloquearPedVdaPeloValorMinimoGrupoProduto;
		configuracaoVendedorTO.ObrigarInformarDataPrevisaoEntrega = configuracaoVendedorWs.ObrigarInformarDataPrevisaoEntrega;
		configuracaoVendedorTO.ExibirValidadeProdutoPdfEmail = configuracaoVendedorWs.ExibirValidadeProdutoPdfEmail;
		configuracaoVendedorTO.ExibirPromocaoFlexLanctoItem = configuracaoVendedorWs.ExibirPromocaoFlexLanctoItem;
		configuracaoVendedorTO.ExibirPromocaoFixaLanctoItem = configuracaoVendedorWs.ExibirPromocaoFixaLanctoItem;
		configuracaoVendedorTO.PermitirVendaSomenteUnidCompra = configuracaoVendedorWs.PermitirVendaSomenteUnidCompra;
		return configuracaoVendedorTO;
	}

	private ConfiguracaoVendedorInadimplenciaFormPgtoTO ConstruirConfiguracaoVendedorInadimplenciaFormPgto(ConfiguracaoVendedorInadimplenciaFormPgtoModel configuracaoVendedorInadimplenciaWs)
	{
		return new ConfiguracaoVendedorInadimplenciaFormPgtoTO
		{
			IdConfiguracaoVendedor = configuracaoVendedorInadimplenciaWs.IdConfiguracaoVendedor,
			CodigoFormPgto = configuracaoVendedorInadimplenciaWs.CodigoFormPagto,
			Padrao = configuracaoVendedorInadimplenciaWs.Padrao.Value
		};
	}

	private ConfiguracaoVendedorPaisTO ConstruirConfiguracaoVendedorPais(ConfiguracaoVendedorPaisWsModel ConfiguracaoVendedorPaisWsModel)
	{
		return new ConfiguracaoVendedorPaisTO
		{
			CodigoPais = ConfiguracaoVendedorPaisWsModel.CodigoPais,
			IDConfiguracaoVendedor = ConfiguracaoVendedorPaisWsModel.IDConfiguracaoVendedor
		};
	}

	private ConfiguracaoVendedorCoordenadaDiasSemanaTO ConstruirConfiguracaoVendedorCoordenadaDiasSemana(ConfiguracaoVendedorCoordenadaDiasSemanaWsModel ConfiguracaoVendedorCoordenadaDiasSemanaWsModel)
	{
		return new ConfiguracaoVendedorCoordenadaDiasSemanaTO
		{
			Id = ConfiguracaoVendedorCoordenadaDiasSemanaWsModel.IdConfiguracaoVendedorCoordenadaDiasSemana,
			IdConfiguracaoVendedor = ConfiguracaoVendedorCoordenadaDiasSemanaWsModel.IdConfiguracaoVendedor,
			CodigoCoordenadaDiaSemana = ConfiguracaoVendedorCoordenadaDiasSemanaWsModel.CodigoDiaSemanaVisita.ToString(),
			HorarioInicioCoordenada = ConfiguracaoVendedorCoordenadaDiasSemanaWsModel.HorarioInicioCoordenada,
			HorarioFimCoordenada = ConfiguracaoVendedorCoordenadaDiasSemanaWsModel.HorarioFimCoordenada
		};
	}

	private ConfiguracaoVendedorClienteNovoFormPgtoTO ConstruirClienteNovoFormPgtoTO(ConfiguracaoVendedorClienteNovoFormPgtoWsModel clienteNovoFormPgto)
	{
		return new ConfiguracaoVendedorClienteNovoFormPgtoTO
		{
			CodigoFormPgto = clienteNovoFormPgto.CodigoFormPagto,
			IdConfiguracaoVendedor = clienteNovoFormPgto.IdConfiguracaoVendedor,
			Padrao = clienteNovoFormPgto.Padrao.Value
		};
	}

	private VendedorTO ConstruirVendedor(VendedorWsModel vendedorWs)
	{
		VendedorTO vendedorTO = new VendedorTO();
		vendedorTO.Id = vendedorWs.IDVendedor;
		vendedorTO.CodigoVendedor = vendedorWs.CodigoVendedor;
		vendedorTO.Nome = vendedorWs.Nome;
		vendedorTO.IdConfiguracaoVendedor = vendedorWs.IDConfiguracaoVendedor;
		vendedorTO.Ativo = vendedorWs.Ativo;
		if (vendedorWs.ProdutoVersaoCARGA != null)
		{
			vendedorTO.Major = vendedorWs.ProdutoVersaoCARGA.Major;
			vendedorTO.Minor = vendedorWs.ProdutoVersaoCARGA.Minor;
			vendedorTO.Build = vendedorWs.ProdutoVersaoCARGA.Build;
			vendedorTO.Revision = vendedorWs.ProdutoVersaoCARGA.Revision;
		}
		else
		{
			vendedorTO.Major = null;
			vendedorTO.Minor = null;
			vendedorTO.Build = null;
			vendedorTO.Revision = null;
		}
		vendedorTO.UtilizaSincronizacaoViaApi = vendedorWs.UtilizaSincronizacaoViaAPI;
		vendedorTO.RowIdPainel = vendedorWs.RowIdPainel;
		return vendedorTO;
	}

	private ConfiguracaoVendedorEstoqueTO ConstruirConfiguracaoVendedorEstoque(ConfiguracaoVendedorEstoqueWsModel configuracaoVendedorEstoqueWs)
	{
		return new ConfiguracaoVendedorEstoqueTO
		{
			Id = configuracaoVendedorEstoqueWs.IDConfiguracaoVendedorEstoque,
			IdConfiguracaoVendedor = configuracaoVendedorEstoqueWs.IDConfiguracaoVendedor,
			CodigoEmpresaOrigem = configuracaoVendedorEstoqueWs.LocalEstoqueModel.CodigoEmpresa,
			CodigoLocalEstoqueOrigem = configuracaoVendedorEstoqueWs.LocalEstoqueModel.Local,
			CodigoEmpresaDestino = Convert.ToInt32(configuracaoVendedorEstoqueWs.CodigoEmpresaDestino)
		};
	}

	private ConfiguracaoVendedorVisitaDiasSemanaTO ConstruirConfiguracaoVendedorVisitaDiasSemana(ConfiguracaoVendedorVisitaDiasSemanaWsModel configuracaoVendedorVisitaDiasSemanaWs)
	{
		return new ConfiguracaoVendedorVisitaDiasSemanaTO
		{
			Id = configuracaoVendedorVisitaDiasSemanaWs.IDConfiguracaoVendedorVisitaDiasSemana,
			IdConfiguracaoVendedor = configuracaoVendedorVisitaDiasSemanaWs.IDConfiguracaoVendedor,
			CodigoDiaSemanaVisita = configuracaoVendedorVisitaDiasSemanaWs.Diadasemana.CodigoDiaSemanaVisita
		};
	}

	private ConfiguracaoVendedorVisitaFrequenciaTO ConstruirConfiguracaoVendedorVisitaFrequencia(ConfiguracaoVendedorVisitaFrequenciaWsModel configuracaoVendedorVisitaFrequenciaWs)
	{
		ConfiguracaoVendedorVisitaFrequenciaTO configuracaoVendedorVisitaFrequenciaTO = new ConfiguracaoVendedorVisitaFrequenciaTO();
		configuracaoVendedorVisitaFrequenciaTO.Id = configuracaoVendedorVisitaFrequenciaWs.IDConfiguracaoVendedorVisitaFrequencia;
		configuracaoVendedorVisitaFrequenciaTO.IdConfiguracaoVendedor = configuracaoVendedorVisitaFrequenciaWs.IDConfiguracaoVendedor;
		if (configuracaoVendedorVisitaFrequenciaWs.TipoFrequencia != null)
		{
			configuracaoVendedorVisitaFrequenciaTO.CodigoTipoFrequenciaVisita = configuracaoVendedorVisitaFrequenciaWs.TipoFrequencia.CodigoTipoFrequenciaVisita;
		}
		else
		{
			configuracaoVendedorVisitaFrequenciaTO.CodigoTipoFrequenciaVisita = null;
		}
		configuracaoVendedorVisitaFrequenciaTO.FrequenciaVisitaId = configuracaoVendedorVisitaFrequenciaWs.FrequenciaVisitaId;
		return configuracaoVendedorVisitaFrequenciaTO;
	}

	private ConfiguracaoVendedorTipoNotificacaoTO ConstruirConfiguracaoVendedorTipoNotificacao(ConfiguracaoVendedorTipoNotificacaoWsModel configuracaoVendedorTipoNotificacaoWs)
	{
		return new ConfiguracaoVendedorTipoNotificacaoTO
		{
			IDTipoNotificacao = configuracaoVendedorTipoNotificacaoWs.IdTipoNotificacao,
			IDConfiguracaoVendedor = configuracaoVendedorTipoNotificacaoWs.IdConfiguracaoVendedor
		};
	}

	private ConfiguracaoVendedorOrdenacaoGondolaTO ConstruirConfiguracaoVendedorOrdenacaoGondola(ConfiguracaoVendedorOrdenacaoGondolaWsModel configuracaoVendedorOrdenacaoGondolaTOWs)
	{
		return new ConfiguracaoVendedorOrdenacaoGondolaTO
		{
			Seq = configuracaoVendedorOrdenacaoGondolaTOWs.Seq,
			IdConfiguracaoVendedor = configuracaoVendedorOrdenacaoGondolaTOWs.IdConfiguracaoVendedor,
			IdConfiguracaoVendedorOrdenacaoGondola = configuracaoVendedorOrdenacaoGondolaTOWs.IdConfiguracaoVendedorOrdenacaoGondola,
			TipoOrdenacao = configuracaoVendedorOrdenacaoGondolaTOWs.TipoOrdenacao,
			ColunaOrdenacao = configuracaoVendedorOrdenacaoGondolaTOWs.ColunaOrdenacao
		};
	}

	private CategoriaAnotacaoTO ConstruirCategoriaAnotacao(CategoriaAnotacaoWsModel categoriaAnotacaoWs)
	{
		return new CategoriaAnotacaoTO
		{
			Ativo = categoriaAnotacaoWs.Ativo,
			Descricao = categoriaAnotacaoWs.Descricao,
			RowId = categoriaAnotacaoWs.RowId,
			IdCategoriaAnotacao = categoriaAnotacaoWs.IdCategoriaAnotacao
		};
	}

	private AnotacaoTO ConstruirAnotacao(DbConnection connTargetErp, DbConnection connTargetMob, AnotacaoWsModel anotacaoWsModel)
	{
		AnotacaoTO anotacaoTO = new AnotacaoTO();
		VendedorTO vendedorTO = new VendedorTO();
		VendedorTO vendedorTO2 = new VendedorTO();
		vendedorTO2.Id = anotacaoWsModel.IDVendedor;
		List<VendedorTO> list = VendedorBLL.Select(connTargetMob.GetConnection(), vendedorTO2);
		if (list != null && list.Count > 0)
		{
			vendedorTO = list[0];
		}
		anotacaoTO.CodigoVendedor = vendedorTO.CodigoVendedor;
		anotacaoTO.CodigoEmpresa = anotacaoWsModel.CodigoEmpresa;
		anotacaoTO.CodigoAnotacao = anotacaoWsModel.CodigoAnotacao;
		anotacaoTO.CodigoCategoriaAnotacao = anotacaoWsModel.CodigoCategoriaAnotacao;
		anotacaoTO.DataHora = anotacaoWsModel.DataHora;
		anotacaoTO.NumeroPedVda = anotacaoWsModel.NumeroPedVda;
		anotacaoTO.Texto = anotacaoWsModel.Texto;
		anotacaoTO.DtLembrete = anotacaoWsModel.DtLembrete;
		if (anotacaoWsModel.ClienteBDMovimento == true)
		{
			if (anotacaoWsModel.CodigoClienteProspeccao.HasValue && anotacaoWsModel.CodigoClienteProspeccao > 0)
			{
				anotacaoTO.CodigoCliente = anotacaoWsModel.CodigoClienteProspeccao;
			}
			else
			{
				anotacaoTO.CodigoCliente = ClienteBLL.getCodigoClienteByCnpj(anotacaoWsModel.CnpjCpfCliente, anotacaoWsModel.IDAnotacao.Value, "Anotacao", null, _StringConnTargetErp);
			}
		}
		else
		{
			anotacaoTO.CodigoCliente = anotacaoWsModel.CodigoCliente;
		}
		return anotacaoTO;
	}
}
