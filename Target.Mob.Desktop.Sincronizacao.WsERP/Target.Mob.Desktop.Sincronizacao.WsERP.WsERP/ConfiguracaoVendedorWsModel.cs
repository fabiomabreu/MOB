using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(ConfiguracaoVendedorModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorWsModel : INotifyPropertyChanged
{
	private int? iDConfiguracaoVendedorField;

	private string descricaoConfiguracaoVendedorField;

	private bool? permitirCadastrarNovoClienteField;

	private decimal? taxaJurosField;

	private decimal? qtdeDiasCancelamentoCotacaoField;

	private bool? utilizaQtdeMaxPedVdaSemTransmissaoField;

	private short? qtdeMaxPedVdaSemTransmissaoField;

	private bool? obrigarInformarRamoAtivPedVdaField;

	private bool? calcularSubstituicaoTributariaField;

	private bool? exibeSinalizadorMargemPedVdaField;

	private bool? exibePercentualMargemPedVdaField;

	private bool? bloquearPedVdaSituacaoCreditoField;

	private decimal? percToleranciaLimiteCreditoField;

	private decimal? qtdeDiasExibirAvisoVencAnvisaField;

	private decimal? qtdeDiasExibirAvisoVencAlvaraField;

	private bool? bloquearPedVdaLimiteCreditoField;

	private bool? bloquearPedVdaAnvisaVencidoField;

	private bool? bloquearPedVdaAlvaraVencidoField;

	private short? qtdeDiasToleranciaInadimplenciaField;

	private bool? permitirLancarPedVdaClienteNovoField;

	private string clienteNovoCodigoTabPreField;

	private short? clienteNovoPrazoMedioField;

	private string clienteNovoCodigoFormPgtoField;

	private string clienteNovoCodigoTpPedField;

	private bool? bloquearFormPgtoBancoVendaEspecialField;

	private string codigoFormPgtoSubstituirFormPgtoBancoVendaEspecialField;

	private bool? permitirAlterarFormPgtoPedVdaField;

	private bool? liberarTodasCondPgtoPedVdaField;

	private bool? bloquearPedVdaPorValorMinimoField;

	private bool? utilizaDescontoFlexPcfgTargetMobField;

	private decimal? percDescMaxFlexField;

	private bool? permitirDescontoGeralField;

	private decimal? percMaxDescGeralPedVdaField;

	private bool? utilizaFormPgtoDepositoContaField;

	private bool? bloquearPedVdaMargemMinimaField;

	private decimal? valorMinimoPropostaField;

	private short? qtdeDiasEstoqueInsuficienteField;

	private bool? exibirEstoqueField;

	private bool? bloquearVendaAcimaEstoqueField;

	private bool? utilizaMotivoNaoVendaForaRoteiroDiaAnteriorField;

	private bool? bloquearVendaNormalItemEmPromocaoField;

	private bool? obrigarMotivoNaoVendaForaRoteiroDiaAnteriorField;

	private bool? bloqueiaAlteracaoAgendamentoVisitasField;

	private DateTime? horarioInicioVisitaField;

	private DateTime? horarioFimVisitaField;

	private bool? liberarCreditoVerbaPedidoNovoField;

	private bool? bloquearPedVdaSaldoVerbaNegativoField;

	private decimal? percMaxToleranciaVisitaForaRotaField;

	private bool? exibirVerbaFechamentoPedVdaField;

	private bool? controlarOrdemVisitasField;

	private decimal? percIndenizacaoTrocaField;

	private bool? obrigarMotivoNaoVendaDiaAnteriorField;

	private bool? exibirSaldoVerbaField;

	private string tipoPedVdaHistoricoClienteField;

	private decimal? qtdePedVdaHistoricoClienteField;

	private string tipoDescontoVerbaItemBonificadoField;

	private decimal? percMaxCreditoVerbaField;

	private bool? utilizaBonificacaoField;

	private bool? utilizaDescontoPromocionalAutomaticoField;

	private decimal? qtdeDiasTitulosAVencerField;

	private bool? exibirTituloSomenteVendedorField;

	private bool? desmembraPedidoProdutoxEmpresaField;

	private bool? desmembraPedidoProdutoxGrupoProdutoField;

	private bool? respeitaAssociacaoVendedorxTipoPedidoField;

	private bool? respeitaAssociacaoVendedorxProdutoField;

	private bool? respeitaAssociacaoVendedorxTabelaPrecoField;

	private bool? enviaSomenteUnidadesComOrdemImpressaoField;

	private bool? restrVendaSomenteVendedorPrioritarioField;

	private string tipoRestricaoVendaField;

	private string tipoCustoField;

	private string tipoAbatimentoTrocaField;

	private bool? naoImportarAtualizacaoPlanoVisitaField;

	private bool? liberarPedidosAutomaticamenteField;

	private bool? utilizaUnidadeVendaNaTrocaField;

	private decimal? percDescontoField;

	private bool? utilizaTrocaField;

	private bool? utilizaPropostaField;

	private bool? permiteAlterarPercIndenizacaoField;

	private bool? exibirSaldoComissaoField;

	private int? qtdeMaxVisitasDiaField;

	private decimal? limiteMinimoVerbaVendedorField;

	private bool? bloquearVisitaAvulsaField;

	private bool? sugereFiltroMixSegmentoPedVdaField;

	private bool? justificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmentoField;

	private bool? obrigaJustificativaNaoVendaMixSegmentoProdutoAProdutoField;

	private ConfiguracaoVendedorEstoqueWsModel[] listConfiguracaoVendedorEstoqueWsField;

	private ConfiguracaoVendedorVisitaFrequenciaWsModel[] listConfiguracaoVendedorVisitaFrequenciaWsField;

	private ConfiguracaoVendedorVisitaDiasSemanaWsModel[] listConfiguracaoVendedorVisitaDiasSemanaWsField;

	private VendedorWsModel[] listVendedorWsField;

	private LocalEstoqueWsModel[] listLocalEstoqueWsField;

	private TipoFrequenciaVisitaWsModel[] listaTipoFrequeciaVisitaWsField;

	private DiaSemanaVisitaWsModel[] listaDiaSemanaVisitaWsField;

	private bool? permitirDownloadPacoteDadosField;

	private bool? permitirDownloadSincField;

	private int? limitePacoteDadosField;

	private int? limiteDownloadSincField;

	private bool? naoImportarInformacaoVisitaForaRotaField;

	private bool? ignorarMotivoNaoVendaMixSegmentoField;

	private bool? aplicarPrazoMedioNaAssociacaoClienteCondPgtoField;

	private bool? utilizaDescontoPromocionalAutomaticoPromFlexField;

	private bool? exibirProdutosNaoAssociadosCondPagtoField;

	private bool? exibirCondPagtoDentroPrazoMedioEAssociadasClienteField;

	private bool? supervisorNaoReceberCargaEquipeField;

	private bool? bloquearAlterarTipoEntregaField;

	private bool? manterRegrasAlteracaoTabelaPrecoPropostaField;

	private bool? permiteAlterarDescontoPorQuantidadeField;

	private bool? ocultarProdutosSemEstoqueField;

	private bool? naoSincronizarAposLancamentoPedidoField;

	private bool? tiposFiltrosItensPedidoFabricanteField;

	private bool? tiposFiltrosItensPedidoCategoriaField;

	private bool? tiposFiltrosItensPedidoLinhaField;

	private bool? tiposFiltrosItensPedidoDeptoField;

	private bool? tiposFiltrosItensPedidoSecaoField;

	private ConfiguracaoVendedorClienteNovoFormPgtoWsModel[] listConfiguracaoVendedorClienteNovoFormPgtoWsField;

	private FormaPagamentoWsModel[] listaFormaPagamentoWsField;

	private bool? calcularVerbaItemKitPromField;

	private decimal? percMargemSegurancaGondolaField;

	private ConfiguracaoVendedorTipoNotificacaoWsModel[] listConfiguracaoVendedorTipoNotificacaoWsField;

	private bool? exibirValidadeMinimaProdutoField;

	private bool? solicitarColetaLocalizacaoClienteField;

	private bool? utilizaRecursoLocalizacaoField;

	private bool? obrigarColetaLocalizacaoClienteField;

	private bool? restricaoVendaLocalizacaoClienteField;

	private bool? estoqueRespeitarTpPedField;

	private bool? obrigarInformarGondolaField;

	private decimal? percMaxVendaSemApontamentoGondolaField;

	private ConfiguracaoVendedorOrdenacaoGondolaWsModel[] listConfiguracaoVendedorOrdenacaoGondolaWsField;

	private ConfiguracaoVendedorCoordenadaDiasSemanaWsModel[] listConfiguracaoVendedorCoordenadaDiasSemanaWsField;

	private bool? arredondarUnidCompraAlgoritmoField;

	private int? qtdeMaxCotacaoPorVendedorField;

	private bool? permitirCadastroEmailClienteLanctoPedidoField;

	private bool? obrigarCadastroEmailClienteLanctoPedidoField;

	private bool? utilizarDescontoMaximoProdutoField;

	private bool? considerarDescontoGeralField;

	private bool? obrigarInformarCheckoutsClienteField;

	private bool? atualizarDescTrocaCondPgtoField;

	private int? qtdeDiasFrequenciaSemRoteiroVisitaField;

	private string tipoMargemSegurancaGondolaField;

	private decimal? qtdeMargemSegurancaGondolaField;

	private bool? enviarEmailPedidoField;

	private bool? enviarEmailPedidoAtendimentoField;

	private bool? enviarPedAutoAposLancField;

	private bool? lancarQtdeZeroItensObrigField;

	private bool? obrigatorioInformarEmailContatoComercialField;

	private bool? utilizarApontamentoGondolaField;

	private bool? permiteEntregaOutroClienteField;

	private bool? exibirStatusPositivacaoProdutosField;

	private bool? exibirPromocoesFlexiveisLancamentoItemField;

	private bool? controlarHorarioAlmocoField;

	private int? tempoAlmocoField;

	private int? tempoBloqueioAlmocoField;

	private DateTime? horarioIniciarAlmocoField;

	private bool? horarioSincronizacaoRestritoField;

	private ConfiguracaoVendedorHorarioConexaoWsModel[] listConfiguracaoVendedorHorarioConexaoWsField;

	private byte[] rowIdField;

	private short? raioClienteField;

	private decimal? propostaPercMgBrutaMinimaField;

	private bool? validarVlPrecoMinimoPedidoField;

	private bool? validarVlPrecoMinimoPropostaField;

	private string classificacaoCurvaABCProdutoField;

	private bool? bloqueiaTituloPorColigacaoField;

	private bool? bloqueiaTituloPorGrupoField;

	private ConfiguracaoVendedorPaisWsModel[] listConfiguracaoVendedorPaisWsField;

	private bool? inicioJornadaNoRoteiroField;

	private bool? fimJornadaNoRoteiroField;

	private bool? exportaDadosRelatorioVendedorField;

	private bool? exportaDadosPermanenciaField;

	private bool? exibirMetaPositivFabricField;

	private int? inadimplenciaPrazoMedioField;

	private ConfiguracaoVendedorInadimplenciaFormPgtoWsModel[] listConfiguracaoVendedorInadimplenciaFormPgtoWsField;

	private bool? utilizaVisitaTelefonicaField;

	private bool? permiteIndicarMotivoNaoVendaComAcaoLigacaoField;

	private int? duracaoMinimaLigacaoVisitaField;

	private bool? utilizaVendedorClienteField;

	private bool? utilizaBonificacaoSomentePromocaoField;

	private bool? utilizaAnotacoesField;

	private int? qtdeMaxDiasExibirAnotacoesField;

	private bool? esconderAnotacoesTelaPedidoField;

	private bool? obrigarPreencherAnotacaoField;

	private string tipoEnvioAnotacoesField;

	private bool? exibirTituloVencidoTodoVendedorField;

	private bool? exibirNotaCreditoField;

	private bool? obrigarEnviarFotoClienteNovoField;

	private bool? obrigarComoRealizouVendaField;

	private bool? utilizaDescontoPorQtdeAutomaticoField;

	private bool? utilizaIndFaltaEstoquePromotorField;

	private int? qtdeDiasAvisoFaltaProdutoPromotorField;

	private bool? exibirPrecoMenorUnidadeListaItensField;

	private bool? exibirLinhaDigitavelBoletoField;

	private bool? sugerirFiltroMixClienteField;

	private bool? obrigarInformarEmailNFeField;

	private bool? obrigarInformarEmailFinanceiroField;

	private bool? exibirAlertaProdutoComplementarField;

	private bool? exibirAlertaProdutoSimilarField;

	private bool? respeitarOrdemLancamentoItemPdfEmailField;

	private bool? enviarObservacaoProdutoPdfEmailField;

	private bool? utilizarEmailCotacaoComImagemField;

	private bool? exibirHorarioRoteiroVisitaField;

	private bool? bloquearPedVdaLimiteCreditoTerceiroField;

	private decimal? percToleranciaLimiteCreditoTerceiroField;

	private string clienteCurvaABCField;

	private bool? considerarDescontoMaximoPermitidoField;

	private bool? sugerirFiltroProdutoReportadoEmFaltaField;

	private bool? bloquearPedVdaPeloValorMinimoGrupoProdutoField;

	private bool? obrigarInformarDataPrevisaoEntregaField;

	private bool? exibirValidadeProdutoPdfEmailField;

	private bool? exibirPromocaoFlexLanctoItemField;

	private bool? exibirPromocaoFixaLanctoItemField;

	private bool? permitirVendaSomenteUnidCompraField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IDConfiguracaoVendedor
	{
		get
		{
			return iDConfiguracaoVendedorField;
		}
		set
		{
			iDConfiguracaoVendedorField = value;
			RaisePropertyChanged("IDConfiguracaoVendedor");
		}
	}

	[XmlElement(Order = 1)]
	public string DescricaoConfiguracaoVendedor
	{
		get
		{
			return descricaoConfiguracaoVendedorField;
		}
		set
		{
			descricaoConfiguracaoVendedorField = value;
			RaisePropertyChanged("DescricaoConfiguracaoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public bool? PermitirCadastrarNovoCliente
	{
		get
		{
			return permitirCadastrarNovoClienteField;
		}
		set
		{
			permitirCadastrarNovoClienteField = value;
			RaisePropertyChanged("PermitirCadastrarNovoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public decimal? TaxaJuros
	{
		get
		{
			return taxaJurosField;
		}
		set
		{
			taxaJurosField = value;
			RaisePropertyChanged("TaxaJuros");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public decimal? QtdeDiasCancelamentoCotacao
	{
		get
		{
			return qtdeDiasCancelamentoCotacaoField;
		}
		set
		{
			qtdeDiasCancelamentoCotacaoField = value;
			RaisePropertyChanged("QtdeDiasCancelamentoCotacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public bool? UtilizaQtdeMaxPedVdaSemTransmissao
	{
		get
		{
			return utilizaQtdeMaxPedVdaSemTransmissaoField;
		}
		set
		{
			utilizaQtdeMaxPedVdaSemTransmissaoField = value;
			RaisePropertyChanged("UtilizaQtdeMaxPedVdaSemTransmissao");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public short? QtdeMaxPedVdaSemTransmissao
	{
		get
		{
			return qtdeMaxPedVdaSemTransmissaoField;
		}
		set
		{
			qtdeMaxPedVdaSemTransmissaoField = value;
			RaisePropertyChanged("QtdeMaxPedVdaSemTransmissao");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public bool? ObrigarInformarRamoAtivPedVda
	{
		get
		{
			return obrigarInformarRamoAtivPedVdaField;
		}
		set
		{
			obrigarInformarRamoAtivPedVdaField = value;
			RaisePropertyChanged("ObrigarInformarRamoAtivPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 8)]
	public bool? CalcularSubstituicaoTributaria
	{
		get
		{
			return calcularSubstituicaoTributariaField;
		}
		set
		{
			calcularSubstituicaoTributariaField = value;
			RaisePropertyChanged("CalcularSubstituicaoTributaria");
		}
	}

	[XmlElement(IsNullable = true, Order = 9)]
	public bool? ExibeSinalizadorMargemPedVda
	{
		get
		{
			return exibeSinalizadorMargemPedVdaField;
		}
		set
		{
			exibeSinalizadorMargemPedVdaField = value;
			RaisePropertyChanged("ExibeSinalizadorMargemPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 10)]
	public bool? ExibePercentualMargemPedVda
	{
		get
		{
			return exibePercentualMargemPedVdaField;
		}
		set
		{
			exibePercentualMargemPedVdaField = value;
			RaisePropertyChanged("ExibePercentualMargemPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 11)]
	public bool? BloquearPedVdaSituacaoCredito
	{
		get
		{
			return bloquearPedVdaSituacaoCreditoField;
		}
		set
		{
			bloquearPedVdaSituacaoCreditoField = value;
			RaisePropertyChanged("BloquearPedVdaSituacaoCredito");
		}
	}

	[XmlElement(IsNullable = true, Order = 12)]
	public decimal? PercToleranciaLimiteCredito
	{
		get
		{
			return percToleranciaLimiteCreditoField;
		}
		set
		{
			percToleranciaLimiteCreditoField = value;
			RaisePropertyChanged("PercToleranciaLimiteCredito");
		}
	}

	[XmlElement(IsNullable = true, Order = 13)]
	public decimal? QtdeDiasExibirAvisoVencAnvisa
	{
		get
		{
			return qtdeDiasExibirAvisoVencAnvisaField;
		}
		set
		{
			qtdeDiasExibirAvisoVencAnvisaField = value;
			RaisePropertyChanged("QtdeDiasExibirAvisoVencAnvisa");
		}
	}

	[XmlElement(IsNullable = true, Order = 14)]
	public decimal? QtdeDiasExibirAvisoVencAlvara
	{
		get
		{
			return qtdeDiasExibirAvisoVencAlvaraField;
		}
		set
		{
			qtdeDiasExibirAvisoVencAlvaraField = value;
			RaisePropertyChanged("QtdeDiasExibirAvisoVencAlvara");
		}
	}

	[XmlElement(IsNullable = true, Order = 15)]
	public bool? BloquearPedVdaLimiteCredito
	{
		get
		{
			return bloquearPedVdaLimiteCreditoField;
		}
		set
		{
			bloquearPedVdaLimiteCreditoField = value;
			RaisePropertyChanged("BloquearPedVdaLimiteCredito");
		}
	}

	[XmlElement(IsNullable = true, Order = 16)]
	public bool? BloquearPedVdaAnvisaVencido
	{
		get
		{
			return bloquearPedVdaAnvisaVencidoField;
		}
		set
		{
			bloquearPedVdaAnvisaVencidoField = value;
			RaisePropertyChanged("BloquearPedVdaAnvisaVencido");
		}
	}

	[XmlElement(IsNullable = true, Order = 17)]
	public bool? BloquearPedVdaAlvaraVencido
	{
		get
		{
			return bloquearPedVdaAlvaraVencidoField;
		}
		set
		{
			bloquearPedVdaAlvaraVencidoField = value;
			RaisePropertyChanged("BloquearPedVdaAlvaraVencido");
		}
	}

	[XmlElement(IsNullable = true, Order = 18)]
	public short? QtdeDiasToleranciaInadimplencia
	{
		get
		{
			return qtdeDiasToleranciaInadimplenciaField;
		}
		set
		{
			qtdeDiasToleranciaInadimplenciaField = value;
			RaisePropertyChanged("QtdeDiasToleranciaInadimplencia");
		}
	}

	[XmlElement(IsNullable = true, Order = 19)]
	public bool? PermitirLancarPedVdaClienteNovo
	{
		get
		{
			return permitirLancarPedVdaClienteNovoField;
		}
		set
		{
			permitirLancarPedVdaClienteNovoField = value;
			RaisePropertyChanged("PermitirLancarPedVdaClienteNovo");
		}
	}

	[XmlElement(Order = 20)]
	public string ClienteNovoCodigoTabPre
	{
		get
		{
			return clienteNovoCodigoTabPreField;
		}
		set
		{
			clienteNovoCodigoTabPreField = value;
			RaisePropertyChanged("ClienteNovoCodigoTabPre");
		}
	}

	[XmlElement(IsNullable = true, Order = 21)]
	public short? ClienteNovoPrazoMedio
	{
		get
		{
			return clienteNovoPrazoMedioField;
		}
		set
		{
			clienteNovoPrazoMedioField = value;
			RaisePropertyChanged("ClienteNovoPrazoMedio");
		}
	}

	[XmlElement(Order = 22)]
	public string ClienteNovoCodigoFormPgto
	{
		get
		{
			return clienteNovoCodigoFormPgtoField;
		}
		set
		{
			clienteNovoCodigoFormPgtoField = value;
			RaisePropertyChanged("ClienteNovoCodigoFormPgto");
		}
	}

	[XmlElement(Order = 23)]
	public string ClienteNovoCodigoTpPed
	{
		get
		{
			return clienteNovoCodigoTpPedField;
		}
		set
		{
			clienteNovoCodigoTpPedField = value;
			RaisePropertyChanged("ClienteNovoCodigoTpPed");
		}
	}

	[XmlElement(IsNullable = true, Order = 24)]
	public bool? BloquearFormPgtoBancoVendaEspecial
	{
		get
		{
			return bloquearFormPgtoBancoVendaEspecialField;
		}
		set
		{
			bloquearFormPgtoBancoVendaEspecialField = value;
			RaisePropertyChanged("BloquearFormPgtoBancoVendaEspecial");
		}
	}

	[XmlElement(Order = 25)]
	public string CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial
	{
		get
		{
			return codigoFormPgtoSubstituirFormPgtoBancoVendaEspecialField;
		}
		set
		{
			codigoFormPgtoSubstituirFormPgtoBancoVendaEspecialField = value;
			RaisePropertyChanged("CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial");
		}
	}

	[XmlElement(IsNullable = true, Order = 26)]
	public bool? PermitirAlterarFormPgtoPedVda
	{
		get
		{
			return permitirAlterarFormPgtoPedVdaField;
		}
		set
		{
			permitirAlterarFormPgtoPedVdaField = value;
			RaisePropertyChanged("PermitirAlterarFormPgtoPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public bool? LiberarTodasCondPgtoPedVda
	{
		get
		{
			return liberarTodasCondPgtoPedVdaField;
		}
		set
		{
			liberarTodasCondPgtoPedVdaField = value;
			RaisePropertyChanged("LiberarTodasCondPgtoPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 28)]
	public bool? BloquearPedVdaPorValorMinimo
	{
		get
		{
			return bloquearPedVdaPorValorMinimoField;
		}
		set
		{
			bloquearPedVdaPorValorMinimoField = value;
			RaisePropertyChanged("BloquearPedVdaPorValorMinimo");
		}
	}

	[XmlElement(IsNullable = true, Order = 29)]
	public bool? UtilizaDescontoFlexPcfgTargetMob
	{
		get
		{
			return utilizaDescontoFlexPcfgTargetMobField;
		}
		set
		{
			utilizaDescontoFlexPcfgTargetMobField = value;
			RaisePropertyChanged("UtilizaDescontoFlexPcfgTargetMob");
		}
	}

	[XmlElement(IsNullable = true, Order = 30)]
	public decimal? PercDescMaxFlex
	{
		get
		{
			return percDescMaxFlexField;
		}
		set
		{
			percDescMaxFlexField = value;
			RaisePropertyChanged("PercDescMaxFlex");
		}
	}

	[XmlElement(IsNullable = true, Order = 31)]
	public bool? PermitirDescontoGeral
	{
		get
		{
			return permitirDescontoGeralField;
		}
		set
		{
			permitirDescontoGeralField = value;
			RaisePropertyChanged("PermitirDescontoGeral");
		}
	}

	[XmlElement(IsNullable = true, Order = 32)]
	public decimal? PercMaxDescGeralPedVda
	{
		get
		{
			return percMaxDescGeralPedVdaField;
		}
		set
		{
			percMaxDescGeralPedVdaField = value;
			RaisePropertyChanged("PercMaxDescGeralPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 33)]
	public bool? UtilizaFormPgtoDepositoConta
	{
		get
		{
			return utilizaFormPgtoDepositoContaField;
		}
		set
		{
			utilizaFormPgtoDepositoContaField = value;
			RaisePropertyChanged("UtilizaFormPgtoDepositoConta");
		}
	}

	[XmlElement(IsNullable = true, Order = 34)]
	public bool? BloquearPedVdaMargemMinima
	{
		get
		{
			return bloquearPedVdaMargemMinimaField;
		}
		set
		{
			bloquearPedVdaMargemMinimaField = value;
			RaisePropertyChanged("BloquearPedVdaMargemMinima");
		}
	}

	[XmlElement(IsNullable = true, Order = 35)]
	public decimal? ValorMinimoProposta
	{
		get
		{
			return valorMinimoPropostaField;
		}
		set
		{
			valorMinimoPropostaField = value;
			RaisePropertyChanged("ValorMinimoProposta");
		}
	}

	[XmlElement(IsNullable = true, Order = 36)]
	public short? QtdeDiasEstoqueInsuficiente
	{
		get
		{
			return qtdeDiasEstoqueInsuficienteField;
		}
		set
		{
			qtdeDiasEstoqueInsuficienteField = value;
			RaisePropertyChanged("QtdeDiasEstoqueInsuficiente");
		}
	}

	[XmlElement(IsNullable = true, Order = 37)]
	public bool? ExibirEstoque
	{
		get
		{
			return exibirEstoqueField;
		}
		set
		{
			exibirEstoqueField = value;
			RaisePropertyChanged("ExibirEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 38)]
	public bool? BloquearVendaAcimaEstoque
	{
		get
		{
			return bloquearVendaAcimaEstoqueField;
		}
		set
		{
			bloquearVendaAcimaEstoqueField = value;
			RaisePropertyChanged("BloquearVendaAcimaEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 39)]
	public bool? UtilizaMotivoNaoVendaForaRoteiroDiaAnterior
	{
		get
		{
			return utilizaMotivoNaoVendaForaRoteiroDiaAnteriorField;
		}
		set
		{
			utilizaMotivoNaoVendaForaRoteiroDiaAnteriorField = value;
			RaisePropertyChanged("UtilizaMotivoNaoVendaForaRoteiroDiaAnterior");
		}
	}

	[XmlElement(IsNullable = true, Order = 40)]
	public bool? BloquearVendaNormalItemEmPromocao
	{
		get
		{
			return bloquearVendaNormalItemEmPromocaoField;
		}
		set
		{
			bloquearVendaNormalItemEmPromocaoField = value;
			RaisePropertyChanged("BloquearVendaNormalItemEmPromocao");
		}
	}

	[XmlElement(IsNullable = true, Order = 41)]
	public bool? ObrigarMotivoNaoVendaForaRoteiroDiaAnterior
	{
		get
		{
			return obrigarMotivoNaoVendaForaRoteiroDiaAnteriorField;
		}
		set
		{
			obrigarMotivoNaoVendaForaRoteiroDiaAnteriorField = value;
			RaisePropertyChanged("ObrigarMotivoNaoVendaForaRoteiroDiaAnterior");
		}
	}

	[XmlElement(IsNullable = true, Order = 42)]
	public bool? BloqueiaAlteracaoAgendamentoVisitas
	{
		get
		{
			return bloqueiaAlteracaoAgendamentoVisitasField;
		}
		set
		{
			bloqueiaAlteracaoAgendamentoVisitasField = value;
			RaisePropertyChanged("BloqueiaAlteracaoAgendamentoVisitas");
		}
	}

	[XmlElement(IsNullable = true, Order = 43)]
	public DateTime? HorarioInicioVisita
	{
		get
		{
			return horarioInicioVisitaField;
		}
		set
		{
			horarioInicioVisitaField = value;
			RaisePropertyChanged("HorarioInicioVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 44)]
	public DateTime? HorarioFimVisita
	{
		get
		{
			return horarioFimVisitaField;
		}
		set
		{
			horarioFimVisitaField = value;
			RaisePropertyChanged("HorarioFimVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 45)]
	public bool? LiberarCreditoVerbaPedidoNovo
	{
		get
		{
			return liberarCreditoVerbaPedidoNovoField;
		}
		set
		{
			liberarCreditoVerbaPedidoNovoField = value;
			RaisePropertyChanged("LiberarCreditoVerbaPedidoNovo");
		}
	}

	[XmlElement(IsNullable = true, Order = 46)]
	public bool? BloquearPedVdaSaldoVerbaNegativo
	{
		get
		{
			return bloquearPedVdaSaldoVerbaNegativoField;
		}
		set
		{
			bloquearPedVdaSaldoVerbaNegativoField = value;
			RaisePropertyChanged("BloquearPedVdaSaldoVerbaNegativo");
		}
	}

	[XmlElement(IsNullable = true, Order = 47)]
	public decimal? PercMaxToleranciaVisitaForaRota
	{
		get
		{
			return percMaxToleranciaVisitaForaRotaField;
		}
		set
		{
			percMaxToleranciaVisitaForaRotaField = value;
			RaisePropertyChanged("PercMaxToleranciaVisitaForaRota");
		}
	}

	[XmlElement(IsNullable = true, Order = 48)]
	public bool? ExibirVerbaFechamentoPedVda
	{
		get
		{
			return exibirVerbaFechamentoPedVdaField;
		}
		set
		{
			exibirVerbaFechamentoPedVdaField = value;
			RaisePropertyChanged("ExibirVerbaFechamentoPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 49)]
	public bool? ControlarOrdemVisitas
	{
		get
		{
			return controlarOrdemVisitasField;
		}
		set
		{
			controlarOrdemVisitasField = value;
			RaisePropertyChanged("ControlarOrdemVisitas");
		}
	}

	[XmlElement(IsNullable = true, Order = 50)]
	public decimal? PercIndenizacaoTroca
	{
		get
		{
			return percIndenizacaoTrocaField;
		}
		set
		{
			percIndenizacaoTrocaField = value;
			RaisePropertyChanged("PercIndenizacaoTroca");
		}
	}

	[XmlElement(IsNullable = true, Order = 51)]
	public bool? ObrigarMotivoNaoVendaDiaAnterior
	{
		get
		{
			return obrigarMotivoNaoVendaDiaAnteriorField;
		}
		set
		{
			obrigarMotivoNaoVendaDiaAnteriorField = value;
			RaisePropertyChanged("ObrigarMotivoNaoVendaDiaAnterior");
		}
	}

	[XmlElement(IsNullable = true, Order = 52)]
	public bool? ExibirSaldoVerba
	{
		get
		{
			return exibirSaldoVerbaField;
		}
		set
		{
			exibirSaldoVerbaField = value;
			RaisePropertyChanged("ExibirSaldoVerba");
		}
	}

	[XmlElement(Order = 53)]
	public string TipoPedVdaHistoricoCliente
	{
		get
		{
			return tipoPedVdaHistoricoClienteField;
		}
		set
		{
			tipoPedVdaHistoricoClienteField = value;
			RaisePropertyChanged("TipoPedVdaHistoricoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 54)]
	public decimal? QtdePedVdaHistoricoCliente
	{
		get
		{
			return qtdePedVdaHistoricoClienteField;
		}
		set
		{
			qtdePedVdaHistoricoClienteField = value;
			RaisePropertyChanged("QtdePedVdaHistoricoCliente");
		}
	}

	[XmlElement(Order = 55)]
	public string TipoDescontoVerbaItemBonificado
	{
		get
		{
			return tipoDescontoVerbaItemBonificadoField;
		}
		set
		{
			tipoDescontoVerbaItemBonificadoField = value;
			RaisePropertyChanged("TipoDescontoVerbaItemBonificado");
		}
	}

	[XmlElement(IsNullable = true, Order = 56)]
	public decimal? PercMaxCreditoVerba
	{
		get
		{
			return percMaxCreditoVerbaField;
		}
		set
		{
			percMaxCreditoVerbaField = value;
			RaisePropertyChanged("PercMaxCreditoVerba");
		}
	}

	[XmlElement(IsNullable = true, Order = 57)]
	public bool? UtilizaBonificacao
	{
		get
		{
			return utilizaBonificacaoField;
		}
		set
		{
			utilizaBonificacaoField = value;
			RaisePropertyChanged("UtilizaBonificacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 58)]
	public bool? UtilizaDescontoPromocionalAutomatico
	{
		get
		{
			return utilizaDescontoPromocionalAutomaticoField;
		}
		set
		{
			utilizaDescontoPromocionalAutomaticoField = value;
			RaisePropertyChanged("UtilizaDescontoPromocionalAutomatico");
		}
	}

	[XmlElement(IsNullable = true, Order = 59)]
	public decimal? QtdeDiasTitulosAVencer
	{
		get
		{
			return qtdeDiasTitulosAVencerField;
		}
		set
		{
			qtdeDiasTitulosAVencerField = value;
			RaisePropertyChanged("QtdeDiasTitulosAVencer");
		}
	}

	[XmlElement(IsNullable = true, Order = 60)]
	public bool? ExibirTituloSomenteVendedor
	{
		get
		{
			return exibirTituloSomenteVendedorField;
		}
		set
		{
			exibirTituloSomenteVendedorField = value;
			RaisePropertyChanged("ExibirTituloSomenteVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 61)]
	public bool? DesmembraPedidoProdutoxEmpresa
	{
		get
		{
			return desmembraPedidoProdutoxEmpresaField;
		}
		set
		{
			desmembraPedidoProdutoxEmpresaField = value;
			RaisePropertyChanged("DesmembraPedidoProdutoxEmpresa");
		}
	}

	[XmlElement(IsNullable = true, Order = 62)]
	public bool? DesmembraPedidoProdutoxGrupoProduto
	{
		get
		{
			return desmembraPedidoProdutoxGrupoProdutoField;
		}
		set
		{
			desmembraPedidoProdutoxGrupoProdutoField = value;
			RaisePropertyChanged("DesmembraPedidoProdutoxGrupoProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 63)]
	public bool? RespeitaAssociacaoVendedorxTipoPedido
	{
		get
		{
			return respeitaAssociacaoVendedorxTipoPedidoField;
		}
		set
		{
			respeitaAssociacaoVendedorxTipoPedidoField = value;
			RaisePropertyChanged("RespeitaAssociacaoVendedorxTipoPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 64)]
	public bool? RespeitaAssociacaoVendedorxProduto
	{
		get
		{
			return respeitaAssociacaoVendedorxProdutoField;
		}
		set
		{
			respeitaAssociacaoVendedorxProdutoField = value;
			RaisePropertyChanged("RespeitaAssociacaoVendedorxProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 65)]
	public bool? RespeitaAssociacaoVendedorxTabelaPreco
	{
		get
		{
			return respeitaAssociacaoVendedorxTabelaPrecoField;
		}
		set
		{
			respeitaAssociacaoVendedorxTabelaPrecoField = value;
			RaisePropertyChanged("RespeitaAssociacaoVendedorxTabelaPreco");
		}
	}

	[XmlElement(IsNullable = true, Order = 66)]
	public bool? EnviaSomenteUnidadesComOrdemImpressao
	{
		get
		{
			return enviaSomenteUnidadesComOrdemImpressaoField;
		}
		set
		{
			enviaSomenteUnidadesComOrdemImpressaoField = value;
			RaisePropertyChanged("EnviaSomenteUnidadesComOrdemImpressao");
		}
	}

	[XmlElement(IsNullable = true, Order = 67)]
	public bool? RestrVendaSomenteVendedorPrioritario
	{
		get
		{
			return restrVendaSomenteVendedorPrioritarioField;
		}
		set
		{
			restrVendaSomenteVendedorPrioritarioField = value;
			RaisePropertyChanged("RestrVendaSomenteVendedorPrioritario");
		}
	}

	[XmlElement(Order = 68)]
	public string TipoRestricaoVenda
	{
		get
		{
			return tipoRestricaoVendaField;
		}
		set
		{
			tipoRestricaoVendaField = value;
			RaisePropertyChanged("TipoRestricaoVenda");
		}
	}

	[XmlElement(Order = 69)]
	public string TipoCusto
	{
		get
		{
			return tipoCustoField;
		}
		set
		{
			tipoCustoField = value;
			RaisePropertyChanged("TipoCusto");
		}
	}

	[XmlElement(Order = 70)]
	public string TipoAbatimentoTroca
	{
		get
		{
			return tipoAbatimentoTrocaField;
		}
		set
		{
			tipoAbatimentoTrocaField = value;
			RaisePropertyChanged("TipoAbatimentoTroca");
		}
	}

	[XmlElement(IsNullable = true, Order = 71)]
	public bool? NaoImportarAtualizacaoPlanoVisita
	{
		get
		{
			return naoImportarAtualizacaoPlanoVisitaField;
		}
		set
		{
			naoImportarAtualizacaoPlanoVisitaField = value;
			RaisePropertyChanged("NaoImportarAtualizacaoPlanoVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 72)]
	public bool? LiberarPedidosAutomaticamente
	{
		get
		{
			return liberarPedidosAutomaticamenteField;
		}
		set
		{
			liberarPedidosAutomaticamenteField = value;
			RaisePropertyChanged("LiberarPedidosAutomaticamente");
		}
	}

	[XmlElement(IsNullable = true, Order = 73)]
	public bool? UtilizaUnidadeVendaNaTroca
	{
		get
		{
			return utilizaUnidadeVendaNaTrocaField;
		}
		set
		{
			utilizaUnidadeVendaNaTrocaField = value;
			RaisePropertyChanged("UtilizaUnidadeVendaNaTroca");
		}
	}

	[XmlElement(IsNullable = true, Order = 74)]
	public decimal? PercDesconto
	{
		get
		{
			return percDescontoField;
		}
		set
		{
			percDescontoField = value;
			RaisePropertyChanged("PercDesconto");
		}
	}

	[XmlElement(IsNullable = true, Order = 75)]
	public bool? UtilizaTroca
	{
		get
		{
			return utilizaTrocaField;
		}
		set
		{
			utilizaTrocaField = value;
			RaisePropertyChanged("UtilizaTroca");
		}
	}

	[XmlElement(IsNullable = true, Order = 76)]
	public bool? UtilizaProposta
	{
		get
		{
			return utilizaPropostaField;
		}
		set
		{
			utilizaPropostaField = value;
			RaisePropertyChanged("UtilizaProposta");
		}
	}

	[XmlElement(IsNullable = true, Order = 77)]
	public bool? PermiteAlterarPercIndenizacao
	{
		get
		{
			return permiteAlterarPercIndenizacaoField;
		}
		set
		{
			permiteAlterarPercIndenizacaoField = value;
			RaisePropertyChanged("PermiteAlterarPercIndenizacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 78)]
	public bool? ExibirSaldoComissao
	{
		get
		{
			return exibirSaldoComissaoField;
		}
		set
		{
			exibirSaldoComissaoField = value;
			RaisePropertyChanged("ExibirSaldoComissao");
		}
	}

	[XmlElement(IsNullable = true, Order = 79)]
	public int? QtdeMaxVisitasDia
	{
		get
		{
			return qtdeMaxVisitasDiaField;
		}
		set
		{
			qtdeMaxVisitasDiaField = value;
			RaisePropertyChanged("QtdeMaxVisitasDia");
		}
	}

	[XmlElement(IsNullable = true, Order = 80)]
	public decimal? LimiteMinimoVerbaVendedor
	{
		get
		{
			return limiteMinimoVerbaVendedorField;
		}
		set
		{
			limiteMinimoVerbaVendedorField = value;
			RaisePropertyChanged("LimiteMinimoVerbaVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 81)]
	public bool? BloquearVisitaAvulsa
	{
		get
		{
			return bloquearVisitaAvulsaField;
		}
		set
		{
			bloquearVisitaAvulsaField = value;
			RaisePropertyChanged("BloquearVisitaAvulsa");
		}
	}

	[XmlElement(IsNullable = true, Order = 82)]
	public bool? SugereFiltroMixSegmentoPedVda
	{
		get
		{
			return sugereFiltroMixSegmentoPedVdaField;
		}
		set
		{
			sugereFiltroMixSegmentoPedVdaField = value;
			RaisePropertyChanged("SugereFiltroMixSegmentoPedVda");
		}
	}

	[XmlElement(IsNullable = true, Order = 83)]
	public bool? JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento
	{
		get
		{
			return justificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmentoField;
		}
		set
		{
			justificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmentoField = value;
			RaisePropertyChanged("JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento");
		}
	}

	[XmlElement(IsNullable = true, Order = 84)]
	public bool? ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto
	{
		get
		{
			return obrigaJustificativaNaoVendaMixSegmentoProdutoAProdutoField;
		}
		set
		{
			obrigaJustificativaNaoVendaMixSegmentoProdutoAProdutoField = value;
			RaisePropertyChanged("ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto");
		}
	}

	[XmlArray(Order = 85)]
	public ConfiguracaoVendedorEstoqueWsModel[] ListConfiguracaoVendedorEstoqueWs
	{
		get
		{
			return listConfiguracaoVendedorEstoqueWsField;
		}
		set
		{
			listConfiguracaoVendedorEstoqueWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorEstoqueWs");
		}
	}

	[XmlArray(Order = 86)]
	public ConfiguracaoVendedorVisitaFrequenciaWsModel[] ListConfiguracaoVendedorVisitaFrequenciaWs
	{
		get
		{
			return listConfiguracaoVendedorVisitaFrequenciaWsField;
		}
		set
		{
			listConfiguracaoVendedorVisitaFrequenciaWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorVisitaFrequenciaWs");
		}
	}

	[XmlArray(Order = 87)]
	public ConfiguracaoVendedorVisitaDiasSemanaWsModel[] ListConfiguracaoVendedorVisitaDiasSemanaWs
	{
		get
		{
			return listConfiguracaoVendedorVisitaDiasSemanaWsField;
		}
		set
		{
			listConfiguracaoVendedorVisitaDiasSemanaWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorVisitaDiasSemanaWs");
		}
	}

	[XmlArray(Order = 88)]
	public VendedorWsModel[] ListVendedorWs
	{
		get
		{
			return listVendedorWsField;
		}
		set
		{
			listVendedorWsField = value;
			RaisePropertyChanged("ListVendedorWs");
		}
	}

	[XmlArray(Order = 89)]
	public LocalEstoqueWsModel[] ListLocalEstoqueWs
	{
		get
		{
			return listLocalEstoqueWsField;
		}
		set
		{
			listLocalEstoqueWsField = value;
			RaisePropertyChanged("ListLocalEstoqueWs");
		}
	}

	[XmlArray(Order = 90)]
	public TipoFrequenciaVisitaWsModel[] ListaTipoFrequeciaVisitaWs
	{
		get
		{
			return listaTipoFrequeciaVisitaWsField;
		}
		set
		{
			listaTipoFrequeciaVisitaWsField = value;
			RaisePropertyChanged("ListaTipoFrequeciaVisitaWs");
		}
	}

	[XmlArray(Order = 91)]
	public DiaSemanaVisitaWsModel[] ListaDiaSemanaVisitaWs
	{
		get
		{
			return listaDiaSemanaVisitaWsField;
		}
		set
		{
			listaDiaSemanaVisitaWsField = value;
			RaisePropertyChanged("ListaDiaSemanaVisitaWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 92)]
	public bool? PermitirDownloadPacoteDados
	{
		get
		{
			return permitirDownloadPacoteDadosField;
		}
		set
		{
			permitirDownloadPacoteDadosField = value;
			RaisePropertyChanged("PermitirDownloadPacoteDados");
		}
	}

	[XmlElement(IsNullable = true, Order = 93)]
	public bool? PermitirDownloadSinc
	{
		get
		{
			return permitirDownloadSincField;
		}
		set
		{
			permitirDownloadSincField = value;
			RaisePropertyChanged("PermitirDownloadSinc");
		}
	}

	[XmlElement(IsNullable = true, Order = 94)]
	public int? LimitePacoteDados
	{
		get
		{
			return limitePacoteDadosField;
		}
		set
		{
			limitePacoteDadosField = value;
			RaisePropertyChanged("LimitePacoteDados");
		}
	}

	[XmlElement(IsNullable = true, Order = 95)]
	public int? LimiteDownloadSinc
	{
		get
		{
			return limiteDownloadSincField;
		}
		set
		{
			limiteDownloadSincField = value;
			RaisePropertyChanged("LimiteDownloadSinc");
		}
	}

	[XmlElement(IsNullable = true, Order = 96)]
	public bool? NaoImportarInformacaoVisitaForaRota
	{
		get
		{
			return naoImportarInformacaoVisitaForaRotaField;
		}
		set
		{
			naoImportarInformacaoVisitaForaRotaField = value;
			RaisePropertyChanged("NaoImportarInformacaoVisitaForaRota");
		}
	}

	[XmlElement(IsNullable = true, Order = 97)]
	public bool? IgnorarMotivoNaoVendaMixSegmento
	{
		get
		{
			return ignorarMotivoNaoVendaMixSegmentoField;
		}
		set
		{
			ignorarMotivoNaoVendaMixSegmentoField = value;
			RaisePropertyChanged("IgnorarMotivoNaoVendaMixSegmento");
		}
	}

	[XmlElement(IsNullable = true, Order = 98)]
	public bool? AplicarPrazoMedioNaAssociacaoClienteCondPgto
	{
		get
		{
			return aplicarPrazoMedioNaAssociacaoClienteCondPgtoField;
		}
		set
		{
			aplicarPrazoMedioNaAssociacaoClienteCondPgtoField = value;
			RaisePropertyChanged("AplicarPrazoMedioNaAssociacaoClienteCondPgto");
		}
	}

	[XmlElement(IsNullable = true, Order = 99)]
	public bool? UtilizaDescontoPromocionalAutomaticoPromFlex
	{
		get
		{
			return utilizaDescontoPromocionalAutomaticoPromFlexField;
		}
		set
		{
			utilizaDescontoPromocionalAutomaticoPromFlexField = value;
			RaisePropertyChanged("UtilizaDescontoPromocionalAutomaticoPromFlex");
		}
	}

	[XmlElement(IsNullable = true, Order = 100)]
	public bool? ExibirProdutosNaoAssociadosCondPagto
	{
		get
		{
			return exibirProdutosNaoAssociadosCondPagtoField;
		}
		set
		{
			exibirProdutosNaoAssociadosCondPagtoField = value;
			RaisePropertyChanged("ExibirProdutosNaoAssociadosCondPagto");
		}
	}

	[XmlElement(IsNullable = true, Order = 101)]
	public bool? ExibirCondPagtoDentroPrazoMedioEAssociadasCliente
	{
		get
		{
			return exibirCondPagtoDentroPrazoMedioEAssociadasClienteField;
		}
		set
		{
			exibirCondPagtoDentroPrazoMedioEAssociadasClienteField = value;
			RaisePropertyChanged("ExibirCondPagtoDentroPrazoMedioEAssociadasCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 102)]
	public bool? SupervisorNaoReceberCargaEquipe
	{
		get
		{
			return supervisorNaoReceberCargaEquipeField;
		}
		set
		{
			supervisorNaoReceberCargaEquipeField = value;
			RaisePropertyChanged("SupervisorNaoReceberCargaEquipe");
		}
	}

	[XmlElement(IsNullable = true, Order = 103)]
	public bool? BloquearAlterarTipoEntrega
	{
		get
		{
			return bloquearAlterarTipoEntregaField;
		}
		set
		{
			bloquearAlterarTipoEntregaField = value;
			RaisePropertyChanged("BloquearAlterarTipoEntrega");
		}
	}

	[XmlElement(IsNullable = true, Order = 104)]
	public bool? ManterRegrasAlteracaoTabelaPrecoProposta
	{
		get
		{
			return manterRegrasAlteracaoTabelaPrecoPropostaField;
		}
		set
		{
			manterRegrasAlteracaoTabelaPrecoPropostaField = value;
			RaisePropertyChanged("ManterRegrasAlteracaoTabelaPrecoProposta");
		}
	}

	[XmlElement(IsNullable = true, Order = 105)]
	public bool? PermiteAlterarDescontoPorQuantidade
	{
		get
		{
			return permiteAlterarDescontoPorQuantidadeField;
		}
		set
		{
			permiteAlterarDescontoPorQuantidadeField = value;
			RaisePropertyChanged("PermiteAlterarDescontoPorQuantidade");
		}
	}

	[XmlElement(IsNullable = true, Order = 106)]
	public bool? OcultarProdutosSemEstoque
	{
		get
		{
			return ocultarProdutosSemEstoqueField;
		}
		set
		{
			ocultarProdutosSemEstoqueField = value;
			RaisePropertyChanged("OcultarProdutosSemEstoque");
		}
	}

	[XmlElement(IsNullable = true, Order = 107)]
	public bool? NaoSincronizarAposLancamentoPedido
	{
		get
		{
			return naoSincronizarAposLancamentoPedidoField;
		}
		set
		{
			naoSincronizarAposLancamentoPedidoField = value;
			RaisePropertyChanged("NaoSincronizarAposLancamentoPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 108)]
	public bool? TiposFiltrosItensPedidoFabricante
	{
		get
		{
			return tiposFiltrosItensPedidoFabricanteField;
		}
		set
		{
			tiposFiltrosItensPedidoFabricanteField = value;
			RaisePropertyChanged("TiposFiltrosItensPedidoFabricante");
		}
	}

	[XmlElement(IsNullable = true, Order = 109)]
	public bool? TiposFiltrosItensPedidoCategoria
	{
		get
		{
			return tiposFiltrosItensPedidoCategoriaField;
		}
		set
		{
			tiposFiltrosItensPedidoCategoriaField = value;
			RaisePropertyChanged("TiposFiltrosItensPedidoCategoria");
		}
	}

	[XmlElement(IsNullable = true, Order = 110)]
	public bool? TiposFiltrosItensPedidoLinha
	{
		get
		{
			return tiposFiltrosItensPedidoLinhaField;
		}
		set
		{
			tiposFiltrosItensPedidoLinhaField = value;
			RaisePropertyChanged("TiposFiltrosItensPedidoLinha");
		}
	}

	[XmlElement(IsNullable = true, Order = 111)]
	public bool? TiposFiltrosItensPedidoDepto
	{
		get
		{
			return tiposFiltrosItensPedidoDeptoField;
		}
		set
		{
			tiposFiltrosItensPedidoDeptoField = value;
			RaisePropertyChanged("TiposFiltrosItensPedidoDepto");
		}
	}

	[XmlElement(IsNullable = true, Order = 112)]
	public bool? TiposFiltrosItensPedidoSecao
	{
		get
		{
			return tiposFiltrosItensPedidoSecaoField;
		}
		set
		{
			tiposFiltrosItensPedidoSecaoField = value;
			RaisePropertyChanged("TiposFiltrosItensPedidoSecao");
		}
	}

	[XmlArray(Order = 113)]
	public ConfiguracaoVendedorClienteNovoFormPgtoWsModel[] ListConfiguracaoVendedorClienteNovoFormPgtoWs
	{
		get
		{
			return listConfiguracaoVendedorClienteNovoFormPgtoWsField;
		}
		set
		{
			listConfiguracaoVendedorClienteNovoFormPgtoWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorClienteNovoFormPgtoWs");
		}
	}

	[XmlArray(Order = 114)]
	public FormaPagamentoWsModel[] ListaFormaPagamentoWs
	{
		get
		{
			return listaFormaPagamentoWsField;
		}
		set
		{
			listaFormaPagamentoWsField = value;
			RaisePropertyChanged("ListaFormaPagamentoWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 115)]
	public bool? CalcularVerbaItemKitProm
	{
		get
		{
			return calcularVerbaItemKitPromField;
		}
		set
		{
			calcularVerbaItemKitPromField = value;
			RaisePropertyChanged("CalcularVerbaItemKitProm");
		}
	}

	[XmlElement(IsNullable = true, Order = 116)]
	public decimal? PercMargemSegurancaGondola
	{
		get
		{
			return percMargemSegurancaGondolaField;
		}
		set
		{
			percMargemSegurancaGondolaField = value;
			RaisePropertyChanged("PercMargemSegurancaGondola");
		}
	}

	[XmlArray(Order = 117)]
	public ConfiguracaoVendedorTipoNotificacaoWsModel[] ListConfiguracaoVendedorTipoNotificacaoWs
	{
		get
		{
			return listConfiguracaoVendedorTipoNotificacaoWsField;
		}
		set
		{
			listConfiguracaoVendedorTipoNotificacaoWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorTipoNotificacaoWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 118)]
	public bool? ExibirValidadeMinimaProduto
	{
		get
		{
			return exibirValidadeMinimaProdutoField;
		}
		set
		{
			exibirValidadeMinimaProdutoField = value;
			RaisePropertyChanged("ExibirValidadeMinimaProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 119)]
	public bool? SolicitarColetaLocalizacaoCliente
	{
		get
		{
			return solicitarColetaLocalizacaoClienteField;
		}
		set
		{
			solicitarColetaLocalizacaoClienteField = value;
			RaisePropertyChanged("SolicitarColetaLocalizacaoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 120)]
	public bool? UtilizaRecursoLocalizacao
	{
		get
		{
			return utilizaRecursoLocalizacaoField;
		}
		set
		{
			utilizaRecursoLocalizacaoField = value;
			RaisePropertyChanged("UtilizaRecursoLocalizacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 121)]
	public bool? ObrigarColetaLocalizacaoCliente
	{
		get
		{
			return obrigarColetaLocalizacaoClienteField;
		}
		set
		{
			obrigarColetaLocalizacaoClienteField = value;
			RaisePropertyChanged("ObrigarColetaLocalizacaoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 122)]
	public bool? RestricaoVendaLocalizacaoCliente
	{
		get
		{
			return restricaoVendaLocalizacaoClienteField;
		}
		set
		{
			restricaoVendaLocalizacaoClienteField = value;
			RaisePropertyChanged("RestricaoVendaLocalizacaoCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 123)]
	public bool? EstoqueRespeitarTpPed
	{
		get
		{
			return estoqueRespeitarTpPedField;
		}
		set
		{
			estoqueRespeitarTpPedField = value;
			RaisePropertyChanged("EstoqueRespeitarTpPed");
		}
	}

	[XmlElement(IsNullable = true, Order = 124)]
	public bool? ObrigarInformarGondola
	{
		get
		{
			return obrigarInformarGondolaField;
		}
		set
		{
			obrigarInformarGondolaField = value;
			RaisePropertyChanged("ObrigarInformarGondola");
		}
	}

	[XmlElement(IsNullable = true, Order = 125)]
	public decimal? PercMaxVendaSemApontamentoGondola
	{
		get
		{
			return percMaxVendaSemApontamentoGondolaField;
		}
		set
		{
			percMaxVendaSemApontamentoGondolaField = value;
			RaisePropertyChanged("PercMaxVendaSemApontamentoGondola");
		}
	}

	[XmlArray(Order = 126)]
	public ConfiguracaoVendedorOrdenacaoGondolaWsModel[] ListConfiguracaoVendedorOrdenacaoGondolaWs
	{
		get
		{
			return listConfiguracaoVendedorOrdenacaoGondolaWsField;
		}
		set
		{
			listConfiguracaoVendedorOrdenacaoGondolaWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorOrdenacaoGondolaWs");
		}
	}

	[XmlArray(Order = 127)]
	public ConfiguracaoVendedorCoordenadaDiasSemanaWsModel[] ListConfiguracaoVendedorCoordenadaDiasSemanaWs
	{
		get
		{
			return listConfiguracaoVendedorCoordenadaDiasSemanaWsField;
		}
		set
		{
			listConfiguracaoVendedorCoordenadaDiasSemanaWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorCoordenadaDiasSemanaWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 128)]
	public bool? ArredondarUnidCompraAlgoritmo
	{
		get
		{
			return arredondarUnidCompraAlgoritmoField;
		}
		set
		{
			arredondarUnidCompraAlgoritmoField = value;
			RaisePropertyChanged("ArredondarUnidCompraAlgoritmo");
		}
	}

	[XmlElement(IsNullable = true, Order = 129)]
	public int? QtdeMaxCotacaoPorVendedor
	{
		get
		{
			return qtdeMaxCotacaoPorVendedorField;
		}
		set
		{
			qtdeMaxCotacaoPorVendedorField = value;
			RaisePropertyChanged("QtdeMaxCotacaoPorVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 130)]
	public bool? PermitirCadastroEmailClienteLanctoPedido
	{
		get
		{
			return permitirCadastroEmailClienteLanctoPedidoField;
		}
		set
		{
			permitirCadastroEmailClienteLanctoPedidoField = value;
			RaisePropertyChanged("PermitirCadastroEmailClienteLanctoPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 131)]
	public bool? ObrigarCadastroEmailClienteLanctoPedido
	{
		get
		{
			return obrigarCadastroEmailClienteLanctoPedidoField;
		}
		set
		{
			obrigarCadastroEmailClienteLanctoPedidoField = value;
			RaisePropertyChanged("ObrigarCadastroEmailClienteLanctoPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 132)]
	public bool? UtilizarDescontoMaximoProduto
	{
		get
		{
			return utilizarDescontoMaximoProdutoField;
		}
		set
		{
			utilizarDescontoMaximoProdutoField = value;
			RaisePropertyChanged("UtilizarDescontoMaximoProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 133)]
	public bool? ConsiderarDescontoGeral
	{
		get
		{
			return considerarDescontoGeralField;
		}
		set
		{
			considerarDescontoGeralField = value;
			RaisePropertyChanged("ConsiderarDescontoGeral");
		}
	}

	[XmlElement(IsNullable = true, Order = 134)]
	public bool? ObrigarInformarCheckoutsCliente
	{
		get
		{
			return obrigarInformarCheckoutsClienteField;
		}
		set
		{
			obrigarInformarCheckoutsClienteField = value;
			RaisePropertyChanged("ObrigarInformarCheckoutsCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 135)]
	public bool? AtualizarDescTrocaCondPgto
	{
		get
		{
			return atualizarDescTrocaCondPgtoField;
		}
		set
		{
			atualizarDescTrocaCondPgtoField = value;
			RaisePropertyChanged("AtualizarDescTrocaCondPgto");
		}
	}

	[XmlElement(IsNullable = true, Order = 136)]
	public int? QtdeDiasFrequenciaSemRoteiroVisita
	{
		get
		{
			return qtdeDiasFrequenciaSemRoteiroVisitaField;
		}
		set
		{
			qtdeDiasFrequenciaSemRoteiroVisitaField = value;
			RaisePropertyChanged("QtdeDiasFrequenciaSemRoteiroVisita");
		}
	}

	[XmlElement(Order = 137)]
	public string TipoMargemSegurancaGondola
	{
		get
		{
			return tipoMargemSegurancaGondolaField;
		}
		set
		{
			tipoMargemSegurancaGondolaField = value;
			RaisePropertyChanged("TipoMargemSegurancaGondola");
		}
	}

	[XmlElement(IsNullable = true, Order = 138)]
	public decimal? QtdeMargemSegurancaGondola
	{
		get
		{
			return qtdeMargemSegurancaGondolaField;
		}
		set
		{
			qtdeMargemSegurancaGondolaField = value;
			RaisePropertyChanged("QtdeMargemSegurancaGondola");
		}
	}

	[XmlElement(IsNullable = true, Order = 139)]
	public bool? EnviarEmailPedido
	{
		get
		{
			return enviarEmailPedidoField;
		}
		set
		{
			enviarEmailPedidoField = value;
			RaisePropertyChanged("EnviarEmailPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 140)]
	public bool? EnviarEmailPedidoAtendimento
	{
		get
		{
			return enviarEmailPedidoAtendimentoField;
		}
		set
		{
			enviarEmailPedidoAtendimentoField = value;
			RaisePropertyChanged("EnviarEmailPedidoAtendimento");
		}
	}

	[XmlElement(IsNullable = true, Order = 141)]
	public bool? EnviarPedAutoAposLanc
	{
		get
		{
			return enviarPedAutoAposLancField;
		}
		set
		{
			enviarPedAutoAposLancField = value;
			RaisePropertyChanged("EnviarPedAutoAposLanc");
		}
	}

	[XmlElement(IsNullable = true, Order = 142)]
	public bool? LancarQtdeZeroItensObrig
	{
		get
		{
			return lancarQtdeZeroItensObrigField;
		}
		set
		{
			lancarQtdeZeroItensObrigField = value;
			RaisePropertyChanged("LancarQtdeZeroItensObrig");
		}
	}

	[XmlElement(IsNullable = true, Order = 143)]
	public bool? ObrigatorioInformarEmailContatoComercial
	{
		get
		{
			return obrigatorioInformarEmailContatoComercialField;
		}
		set
		{
			obrigatorioInformarEmailContatoComercialField = value;
			RaisePropertyChanged("ObrigatorioInformarEmailContatoComercial");
		}
	}

	[XmlElement(IsNullable = true, Order = 144)]
	public bool? UtilizarApontamentoGondola
	{
		get
		{
			return utilizarApontamentoGondolaField;
		}
		set
		{
			utilizarApontamentoGondolaField = value;
			RaisePropertyChanged("UtilizarApontamentoGondola");
		}
	}

	[XmlElement(IsNullable = true, Order = 145)]
	public bool? PermiteEntregaOutroCliente
	{
		get
		{
			return permiteEntregaOutroClienteField;
		}
		set
		{
			permiteEntregaOutroClienteField = value;
			RaisePropertyChanged("PermiteEntregaOutroCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 146)]
	public bool? ExibirStatusPositivacaoProdutos
	{
		get
		{
			return exibirStatusPositivacaoProdutosField;
		}
		set
		{
			exibirStatusPositivacaoProdutosField = value;
			RaisePropertyChanged("ExibirStatusPositivacaoProdutos");
		}
	}

	[XmlElement(IsNullable = true, Order = 147)]
	public bool? ExibirPromocoesFlexiveisLancamentoItem
	{
		get
		{
			return exibirPromocoesFlexiveisLancamentoItemField;
		}
		set
		{
			exibirPromocoesFlexiveisLancamentoItemField = value;
			RaisePropertyChanged("ExibirPromocoesFlexiveisLancamentoItem");
		}
	}

	[XmlElement(IsNullable = true, Order = 148)]
	public bool? ControlarHorarioAlmoco
	{
		get
		{
			return controlarHorarioAlmocoField;
		}
		set
		{
			controlarHorarioAlmocoField = value;
			RaisePropertyChanged("ControlarHorarioAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 149)]
	public int? TempoAlmoco
	{
		get
		{
			return tempoAlmocoField;
		}
		set
		{
			tempoAlmocoField = value;
			RaisePropertyChanged("TempoAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 150)]
	public int? TempoBloqueioAlmoco
	{
		get
		{
			return tempoBloqueioAlmocoField;
		}
		set
		{
			tempoBloqueioAlmocoField = value;
			RaisePropertyChanged("TempoBloqueioAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 151)]
	public DateTime? HorarioIniciarAlmoco
	{
		get
		{
			return horarioIniciarAlmocoField;
		}
		set
		{
			horarioIniciarAlmocoField = value;
			RaisePropertyChanged("HorarioIniciarAlmoco");
		}
	}

	[XmlElement(IsNullable = true, Order = 152)]
	public bool? HorarioSincronizacaoRestrito
	{
		get
		{
			return horarioSincronizacaoRestritoField;
		}
		set
		{
			horarioSincronizacaoRestritoField = value;
			RaisePropertyChanged("HorarioSincronizacaoRestrito");
		}
	}

	[XmlArray(Order = 153)]
	public ConfiguracaoVendedorHorarioConexaoWsModel[] ListConfiguracaoVendedorHorarioConexaoWs
	{
		get
		{
			return listConfiguracaoVendedorHorarioConexaoWsField;
		}
		set
		{
			listConfiguracaoVendedorHorarioConexaoWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorHorarioConexaoWs");
		}
	}

	[XmlElement(DataType = "base64Binary", Order = 154)]
	public byte[] RowId
	{
		get
		{
			return rowIdField;
		}
		set
		{
			rowIdField = value;
			RaisePropertyChanged("RowId");
		}
	}

	[XmlElement(IsNullable = true, Order = 155)]
	public short? RaioCliente
	{
		get
		{
			return raioClienteField;
		}
		set
		{
			raioClienteField = value;
			RaisePropertyChanged("RaioCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 156)]
	public decimal? PropostaPercMgBrutaMinima
	{
		get
		{
			return propostaPercMgBrutaMinimaField;
		}
		set
		{
			propostaPercMgBrutaMinimaField = value;
			RaisePropertyChanged("PropostaPercMgBrutaMinima");
		}
	}

	[XmlElement(IsNullable = true, Order = 157)]
	public bool? ValidarVlPrecoMinimoPedido
	{
		get
		{
			return validarVlPrecoMinimoPedidoField;
		}
		set
		{
			validarVlPrecoMinimoPedidoField = value;
			RaisePropertyChanged("ValidarVlPrecoMinimoPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 158)]
	public bool? ValidarVlPrecoMinimoProposta
	{
		get
		{
			return validarVlPrecoMinimoPropostaField;
		}
		set
		{
			validarVlPrecoMinimoPropostaField = value;
			RaisePropertyChanged("ValidarVlPrecoMinimoProposta");
		}
	}

	[XmlElement(Order = 159)]
	public string ClassificacaoCurvaABCProduto
	{
		get
		{
			return classificacaoCurvaABCProdutoField;
		}
		set
		{
			classificacaoCurvaABCProdutoField = value;
			RaisePropertyChanged("ClassificacaoCurvaABCProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 160)]
	public bool? BloqueiaTituloPorColigacao
	{
		get
		{
			return bloqueiaTituloPorColigacaoField;
		}
		set
		{
			bloqueiaTituloPorColigacaoField = value;
			RaisePropertyChanged("BloqueiaTituloPorColigacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 161)]
	public bool? BloqueiaTituloPorGrupo
	{
		get
		{
			return bloqueiaTituloPorGrupoField;
		}
		set
		{
			bloqueiaTituloPorGrupoField = value;
			RaisePropertyChanged("BloqueiaTituloPorGrupo");
		}
	}

	[XmlArray(Order = 162)]
	public ConfiguracaoVendedorPaisWsModel[] ListConfiguracaoVendedorPaisWs
	{
		get
		{
			return listConfiguracaoVendedorPaisWsField;
		}
		set
		{
			listConfiguracaoVendedorPaisWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorPaisWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 163)]
	public bool? InicioJornadaNoRoteiro
	{
		get
		{
			return inicioJornadaNoRoteiroField;
		}
		set
		{
			inicioJornadaNoRoteiroField = value;
			RaisePropertyChanged("InicioJornadaNoRoteiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 164)]
	public bool? FimJornadaNoRoteiro
	{
		get
		{
			return fimJornadaNoRoteiroField;
		}
		set
		{
			fimJornadaNoRoteiroField = value;
			RaisePropertyChanged("FimJornadaNoRoteiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 165)]
	public bool? ExportaDadosRelatorioVendedor
	{
		get
		{
			return exportaDadosRelatorioVendedorField;
		}
		set
		{
			exportaDadosRelatorioVendedorField = value;
			RaisePropertyChanged("ExportaDadosRelatorioVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 166)]
	public bool? ExportaDadosPermanencia
	{
		get
		{
			return exportaDadosPermanenciaField;
		}
		set
		{
			exportaDadosPermanenciaField = value;
			RaisePropertyChanged("ExportaDadosPermanencia");
		}
	}

	[XmlElement(IsNullable = true, Order = 167)]
	public bool? ExibirMetaPositivFabric
	{
		get
		{
			return exibirMetaPositivFabricField;
		}
		set
		{
			exibirMetaPositivFabricField = value;
			RaisePropertyChanged("ExibirMetaPositivFabric");
		}
	}

	[XmlElement(IsNullable = true, Order = 168)]
	public int? InadimplenciaPrazoMedio
	{
		get
		{
			return inadimplenciaPrazoMedioField;
		}
		set
		{
			inadimplenciaPrazoMedioField = value;
			RaisePropertyChanged("InadimplenciaPrazoMedio");
		}
	}

	[XmlArray(Order = 169)]
	public ConfiguracaoVendedorInadimplenciaFormPgtoWsModel[] ListConfiguracaoVendedorInadimplenciaFormPgtoWs
	{
		get
		{
			return listConfiguracaoVendedorInadimplenciaFormPgtoWsField;
		}
		set
		{
			listConfiguracaoVendedorInadimplenciaFormPgtoWsField = value;
			RaisePropertyChanged("ListConfiguracaoVendedorInadimplenciaFormPgtoWs");
		}
	}

	[XmlElement(IsNullable = true, Order = 170)]
	public bool? UtilizaVisitaTelefonica
	{
		get
		{
			return utilizaVisitaTelefonicaField;
		}
		set
		{
			utilizaVisitaTelefonicaField = value;
			RaisePropertyChanged("UtilizaVisitaTelefonica");
		}
	}

	[XmlElement(IsNullable = true, Order = 171)]
	public bool? PermiteIndicarMotivoNaoVendaComAcaoLigacao
	{
		get
		{
			return permiteIndicarMotivoNaoVendaComAcaoLigacaoField;
		}
		set
		{
			permiteIndicarMotivoNaoVendaComAcaoLigacaoField = value;
			RaisePropertyChanged("PermiteIndicarMotivoNaoVendaComAcaoLigacao");
		}
	}

	[XmlElement(IsNullable = true, Order = 172)]
	public int? DuracaoMinimaLigacaoVisita
	{
		get
		{
			return duracaoMinimaLigacaoVisitaField;
		}
		set
		{
			duracaoMinimaLigacaoVisitaField = value;
			RaisePropertyChanged("DuracaoMinimaLigacaoVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 173)]
	public bool? UtilizaVendedorCliente
	{
		get
		{
			return utilizaVendedorClienteField;
		}
		set
		{
			utilizaVendedorClienteField = value;
			RaisePropertyChanged("UtilizaVendedorCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 174)]
	public bool? UtilizaBonificacaoSomentePromocao
	{
		get
		{
			return utilizaBonificacaoSomentePromocaoField;
		}
		set
		{
			utilizaBonificacaoSomentePromocaoField = value;
			RaisePropertyChanged("UtilizaBonificacaoSomentePromocao");
		}
	}

	[XmlElement(IsNullable = true, Order = 175)]
	public bool? UtilizaAnotacoes
	{
		get
		{
			return utilizaAnotacoesField;
		}
		set
		{
			utilizaAnotacoesField = value;
			RaisePropertyChanged("UtilizaAnotacoes");
		}
	}

	[XmlElement(IsNullable = true, Order = 176)]
	public int? QtdeMaxDiasExibirAnotacoes
	{
		get
		{
			return qtdeMaxDiasExibirAnotacoesField;
		}
		set
		{
			qtdeMaxDiasExibirAnotacoesField = value;
			RaisePropertyChanged("QtdeMaxDiasExibirAnotacoes");
		}
	}

	[XmlElement(IsNullable = true, Order = 177)]
	public bool? EsconderAnotacoesTelaPedido
	{
		get
		{
			return esconderAnotacoesTelaPedidoField;
		}
		set
		{
			esconderAnotacoesTelaPedidoField = value;
			RaisePropertyChanged("EsconderAnotacoesTelaPedido");
		}
	}

	[XmlElement(IsNullable = true, Order = 178)]
	public bool? ObrigarPreencherAnotacao
	{
		get
		{
			return obrigarPreencherAnotacaoField;
		}
		set
		{
			obrigarPreencherAnotacaoField = value;
			RaisePropertyChanged("ObrigarPreencherAnotacao");
		}
	}

	[XmlElement(Order = 179)]
	public string TipoEnvioAnotacoes
	{
		get
		{
			return tipoEnvioAnotacoesField;
		}
		set
		{
			tipoEnvioAnotacoesField = value;
			RaisePropertyChanged("TipoEnvioAnotacoes");
		}
	}

	[XmlElement(IsNullable = true, Order = 180)]
	public bool? ExibirTituloVencidoTodoVendedor
	{
		get
		{
			return exibirTituloVencidoTodoVendedorField;
		}
		set
		{
			exibirTituloVencidoTodoVendedorField = value;
			RaisePropertyChanged("ExibirTituloVencidoTodoVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 181)]
	public bool? ExibirNotaCredito
	{
		get
		{
			return exibirNotaCreditoField;
		}
		set
		{
			exibirNotaCreditoField = value;
			RaisePropertyChanged("ExibirNotaCredito");
		}
	}

	[XmlElement(IsNullable = true, Order = 182)]
	public bool? ObrigarEnviarFotoClienteNovo
	{
		get
		{
			return obrigarEnviarFotoClienteNovoField;
		}
		set
		{
			obrigarEnviarFotoClienteNovoField = value;
			RaisePropertyChanged("ObrigarEnviarFotoClienteNovo");
		}
	}

	[XmlElement(IsNullable = true, Order = 183)]
	public bool? ObrigarComoRealizouVenda
	{
		get
		{
			return obrigarComoRealizouVendaField;
		}
		set
		{
			obrigarComoRealizouVendaField = value;
			RaisePropertyChanged("ObrigarComoRealizouVenda");
		}
	}

	[XmlElement(IsNullable = true, Order = 184)]
	public bool? UtilizaDescontoPorQtdeAutomatico
	{
		get
		{
			return utilizaDescontoPorQtdeAutomaticoField;
		}
		set
		{
			utilizaDescontoPorQtdeAutomaticoField = value;
			RaisePropertyChanged("UtilizaDescontoPorQtdeAutomatico");
		}
	}

	[XmlElement(IsNullable = true, Order = 185)]
	public bool? UtilizaIndFaltaEstoquePromotor
	{
		get
		{
			return utilizaIndFaltaEstoquePromotorField;
		}
		set
		{
			utilizaIndFaltaEstoquePromotorField = value;
			RaisePropertyChanged("UtilizaIndFaltaEstoquePromotor");
		}
	}

	[XmlElement(IsNullable = true, Order = 186)]
	public int? QtdeDiasAvisoFaltaProdutoPromotor
	{
		get
		{
			return qtdeDiasAvisoFaltaProdutoPromotorField;
		}
		set
		{
			qtdeDiasAvisoFaltaProdutoPromotorField = value;
			RaisePropertyChanged("QtdeDiasAvisoFaltaProdutoPromotor");
		}
	}

	[XmlElement(IsNullable = true, Order = 187)]
	public bool? ExibirPrecoMenorUnidadeListaItens
	{
		get
		{
			return exibirPrecoMenorUnidadeListaItensField;
		}
		set
		{
			exibirPrecoMenorUnidadeListaItensField = value;
			RaisePropertyChanged("ExibirPrecoMenorUnidadeListaItens");
		}
	}

	[XmlElement(IsNullable = true, Order = 188)]
	public bool? ExibirLinhaDigitavelBoleto
	{
		get
		{
			return exibirLinhaDigitavelBoletoField;
		}
		set
		{
			exibirLinhaDigitavelBoletoField = value;
			RaisePropertyChanged("ExibirLinhaDigitavelBoleto");
		}
	}

	[XmlElement(IsNullable = true, Order = 189)]
	public bool? SugerirFiltroMixCliente
	{
		get
		{
			return sugerirFiltroMixClienteField;
		}
		set
		{
			sugerirFiltroMixClienteField = value;
			RaisePropertyChanged("SugerirFiltroMixCliente");
		}
	}

	[XmlElement(IsNullable = true, Order = 190)]
	public bool? ObrigarInformarEmailNFe
	{
		get
		{
			return obrigarInformarEmailNFeField;
		}
		set
		{
			obrigarInformarEmailNFeField = value;
			RaisePropertyChanged("ObrigarInformarEmailNFe");
		}
	}

	[XmlElement(IsNullable = true, Order = 191)]
	public bool? ObrigarInformarEmailFinanceiro
	{
		get
		{
			return obrigarInformarEmailFinanceiroField;
		}
		set
		{
			obrigarInformarEmailFinanceiroField = value;
			RaisePropertyChanged("ObrigarInformarEmailFinanceiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 192)]
	public bool? ExibirAlertaProdutoComplementar
	{
		get
		{
			return exibirAlertaProdutoComplementarField;
		}
		set
		{
			exibirAlertaProdutoComplementarField = value;
			RaisePropertyChanged("ExibirAlertaProdutoComplementar");
		}
	}

	[XmlElement(IsNullable = true, Order = 193)]
	public bool? ExibirAlertaProdutoSimilar
	{
		get
		{
			return exibirAlertaProdutoSimilarField;
		}
		set
		{
			exibirAlertaProdutoSimilarField = value;
			RaisePropertyChanged("ExibirAlertaProdutoSimilar");
		}
	}

	[XmlElement(IsNullable = true, Order = 194)]
	public bool? RespeitarOrdemLancamentoItemPdfEmail
	{
		get
		{
			return respeitarOrdemLancamentoItemPdfEmailField;
		}
		set
		{
			respeitarOrdemLancamentoItemPdfEmailField = value;
			RaisePropertyChanged("RespeitarOrdemLancamentoItemPdfEmail");
		}
	}

	[XmlElement(IsNullable = true, Order = 195)]
	public bool? EnviarObservacaoProdutoPdfEmail
	{
		get
		{
			return enviarObservacaoProdutoPdfEmailField;
		}
		set
		{
			enviarObservacaoProdutoPdfEmailField = value;
			RaisePropertyChanged("EnviarObservacaoProdutoPdfEmail");
		}
	}

	[XmlElement(IsNullable = true, Order = 196)]
	public bool? UtilizarEmailCotacaoComImagem
	{
		get
		{
			return utilizarEmailCotacaoComImagemField;
		}
		set
		{
			utilizarEmailCotacaoComImagemField = value;
			RaisePropertyChanged("UtilizarEmailCotacaoComImagem");
		}
	}

	[XmlElement(IsNullable = true, Order = 197)]
	public bool? ExibirHorarioRoteiroVisita
	{
		get
		{
			return exibirHorarioRoteiroVisitaField;
		}
		set
		{
			exibirHorarioRoteiroVisitaField = value;
			RaisePropertyChanged("ExibirHorarioRoteiroVisita");
		}
	}

	[XmlElement(IsNullable = true, Order = 198)]
	public bool? BloquearPedVdaLimiteCreditoTerceiro
	{
		get
		{
			return bloquearPedVdaLimiteCreditoTerceiroField;
		}
		set
		{
			bloquearPedVdaLimiteCreditoTerceiroField = value;
			RaisePropertyChanged("BloquearPedVdaLimiteCreditoTerceiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 199)]
	public decimal? PercToleranciaLimiteCreditoTerceiro
	{
		get
		{
			return percToleranciaLimiteCreditoTerceiroField;
		}
		set
		{
			percToleranciaLimiteCreditoTerceiroField = value;
			RaisePropertyChanged("PercToleranciaLimiteCreditoTerceiro");
		}
	}

	[XmlElement(Order = 200)]
	public string ClienteCurvaABC
	{
		get
		{
			return clienteCurvaABCField;
		}
		set
		{
			clienteCurvaABCField = value;
			RaisePropertyChanged("ClienteCurvaABC");
		}
	}

	[XmlElement(IsNullable = true, Order = 201)]
	public bool? ConsiderarDescontoMaximoPermitido
	{
		get
		{
			return considerarDescontoMaximoPermitidoField;
		}
		set
		{
			considerarDescontoMaximoPermitidoField = value;
			RaisePropertyChanged("ConsiderarDescontoMaximoPermitido");
		}
	}

	[XmlElement(IsNullable = true, Order = 202)]
	public bool? SugerirFiltroProdutoReportadoEmFalta
	{
		get
		{
			return sugerirFiltroProdutoReportadoEmFaltaField;
		}
		set
		{
			sugerirFiltroProdutoReportadoEmFaltaField = value;
			RaisePropertyChanged("SugerirFiltroProdutoReportadoEmFalta");
		}
	}

	[XmlElement(IsNullable = true, Order = 203)]
	public bool? BloquearPedVdaPeloValorMinimoGrupoProduto
	{
		get
		{
			return bloquearPedVdaPeloValorMinimoGrupoProdutoField;
		}
		set
		{
			bloquearPedVdaPeloValorMinimoGrupoProdutoField = value;
			RaisePropertyChanged("BloquearPedVdaPeloValorMinimoGrupoProduto");
		}
	}

	[XmlElement(IsNullable = true, Order = 204)]
	public bool? ObrigarInformarDataPrevisaoEntrega
	{
		get
		{
			return obrigarInformarDataPrevisaoEntregaField;
		}
		set
		{
			obrigarInformarDataPrevisaoEntregaField = value;
			RaisePropertyChanged("ObrigarInformarDataPrevisaoEntrega");
		}
	}

	[XmlElement(IsNullable = true, Order = 205)]
	public bool? ExibirValidadeProdutoPdfEmail
	{
		get
		{
			return exibirValidadeProdutoPdfEmailField;
		}
		set
		{
			exibirValidadeProdutoPdfEmailField = value;
			RaisePropertyChanged("ExibirValidadeProdutoPdfEmail");
		}
	}

	[XmlElement(IsNullable = true, Order = 206)]
	public bool? ExibirPromocaoFlexLanctoItem
	{
		get
		{
			return exibirPromocaoFlexLanctoItemField;
		}
		set
		{
			exibirPromocaoFlexLanctoItemField = value;
			RaisePropertyChanged("ExibirPromocaoFlexLanctoItem");
		}
	}

	[XmlElement(IsNullable = true, Order = 207)]
	public bool? ExibirPromocaoFixaLanctoItem
	{
		get
		{
			return exibirPromocaoFixaLanctoItemField;
		}
		set
		{
			exibirPromocaoFixaLanctoItemField = value;
			RaisePropertyChanged("ExibirPromocaoFixaLanctoItem");
		}
	}

	[XmlElement(IsNullable = true, Order = 208)]
	public bool? PermitirVendaSomenteUnidCompra
	{
		get
		{
			return permitirVendaSomenteUnidCompraField;
		}
		set
		{
			permitirVendaSomenteUnidCompraField = value;
			RaisePropertyChanged("PermitirVendaSomenteUnidCompra");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
