using System;
using System.Collections.Generic;

namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorTO
{
	private int? _Id;

	private string _DescricaoConfiguracaoVendedor;

	private bool? _PermitirCadastrarNovoCliente;

	private decimal? _TaxaJuros;

	private decimal? _QtdeDiasCancelamentoCotacao;

	private bool? _UtilizaQtdeMaxPedVdaSemTransmissao;

	private short? _QtdeMaxPedVdaSemTransmissao;

	private bool? _ObrigarInformarRamoAtivPedVda;

	private bool? _CalcularSubstituicaoTributaria;

	private bool? _ExibeSinalizadorMargemPedVda;

	private bool? _ExibePercentualMargemPedVda;

	private bool? _BloquearPedVdaSituacaoCredito;

	private decimal? _PercToleranciaLimiteCredito;

	private decimal? _QtdeDiasExibirAvisoVencAnvisa;

	private decimal? _QtdeDiasExibirAvisoVencAlvara;

	private bool? _BloquearPedVdaLimiteCredito;

	private bool? _BloquearPedVdaAnvisaVencido;

	private bool? _BloquearPedVdaAlvaraVencido;

	private short? _QtdeDiasToleranciaInadimplencia;

	private bool? _PermitirLancarPedVdaClienteNovo;

	private string _ClienteNovoCodigoTabPre;

	private short? _ClienteNovoPrazoMedio;

	private string _ClienteNovoCodigoFormPgto;

	private string _ClienteNovoCodigoTpPed;

	private bool? _BloquearFormPgtoBancoVendaEspecial;

	private string _CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial;

	private bool? _PermitirAlterarFormPgtoPedVda;

	private bool? _LiberarTodasCondPgtoPedVda;

	private bool? _BloquearPedVdaPorValorMinimo;

	private bool? _UtilizaDescontoFlexPcfgTargetMob;

	private decimal? _PercDescMaxFlex;

	private bool? _PermitirDescontoGeral;

	private decimal? _PercMaxDescGeralPedVda;

	private bool? _UtilizaFormPgtoDepositoConta;

	private bool? _BloquearPedVdaMargemMinima;

	private decimal? _ValorMinimoProposta;

	private short? _QtdeDiasEstoqueInsuficiente;

	private bool? _ExibirEstoque;

	private bool? _BloquearVendaAcimaEstoque;

	private bool? _UtilizaMotivoNaoVendaForaRoteiroDiaAnterior;

	private bool? _BloquearVendaNormalItemEmPromocao;

	private bool? _ObrigarMotivoNaoVendaForaRoteiroDiaAnterior;

	private bool? _BloqueiaAlteracaoAgendamentoVisitas;

	private DateTime? _HorarioInicioVisita;

	private DateTime? _HorarioFimVisita;

	private bool? _LiberarCreditoVerbaPedidoNovo;

	private bool? _BloquearPedVdaSaldoVerbaNegativo;

	private decimal? _PercMaxToleranciaVisitaForaRota;

	private bool? _ExibirVerbaFechamentoPedVda;

	private bool? _ControlarOrdemVisitas;

	private decimal? _PercIndenizacaoTroca;

	private bool? _ObrigarMotivoNaoVendaDiaAnterior;

	private bool? _ExibirSaldoVerba;

	private string _TipoPedVdaHistoricoCliente;

	private decimal? _QtdePedVdaHistoricoCliente;

	private string _TipoDescontoVerbaItemBonificado;

	private decimal? _PercMaxCreditoVerba;

	private bool? _UtilizaBonificacao;

	private bool? _UtilizaDescontoPromocionalAutomatico;

	private decimal? _QtdeDiasTitulosAVencer;

	private bool? _ExibirTituloSomenteVendedor;

	private bool? _DesmembraPedidoProdutoxEmpresa;

	private bool? _DesmembraPedidoProdutoxGrupoProduto;

	private bool? _RespeitaAssociacaoVendedorxTipoPedido;

	private bool? _RespeitaAssociacaoVendedorxProduto;

	private bool? _RespeitaAssociacaoVendedorxTabelaPreco;

	private bool? _EnviaSomenteUnidadesComOrdemImpressao;

	private bool? _RestrVendaSomenteVendedorPrioritario;

	private string _TipoRestricaoVenda;

	private string _TipoCusto;

	private string _TipoAbatimentoTroca;

	private bool? _NaoImportarAtualizacaoPlanoVisita;

	private bool? _LiberarPedidosAutomaticamente;

	private bool? _UtilizaUnidadeVendaNaTroca;

	private decimal? _PercDesconto;

	private bool? _UtilizaTroca;

	private bool? _UtilizaProposta;

	private bool? _PermiteAlterarPercIndenizacao;

	private bool? _ExibirSaldoComissao;

	private int? _QtdeMaxVisitasDia;

	private decimal? _LimiteMinimoVerbaVendedor;

	private bool? _BloquearVisitaAvulsa;

	private bool? _SugereFiltroMixSegmentoPedVda;

	private bool? _JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento;

	private bool? _ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto;

	private bool? _PermitirDownloadPacoteDados;

	private bool? _PermitirDownloadSinc;

	private int? _LimitePacoteDados;

	private int? _LimiteDownloadSinc;

	private bool? _NaoImportarInformacaoVisitaForaRota;

	private bool? _AplicarPrazoMedioNaAssociacaoClienteCondPgto;

	private bool? _UtilizaDescontoPromocionalAutomaticoPromFlex;

	private bool? _IgnorarMotivoNaoVendaMixSegmento;

	private bool? _ExibirProdutosNaoAssociadosCondPagto;

	private bool? _OcultarProdutosSemEstoque;

	private bool? _ExibirCondPagtoDentroPrazoMedioEAssociadasCliente;

	private bool? _BloquearAlterarTipoEntrega;

	private bool? _PermiteAlterarDescontoPorQuantidade;

	private bool? _SupervisorNaoReceberCargaEquipe;

	private bool? _TiposFiltrosItensPedidoFabricante;

	private bool? _TiposFiltrosItensPedidoCategoria;

	private bool? _TiposFiltrosItensPedidoLinha;

	private bool? _TiposFiltrosItensPedidoDepto;

	private bool? _TiposFiltrosItensPedidoSecao;

	private bool? _NaoSincronizarAposLancamentoPedido;

	private bool? _CalcularVerbaItemKitProm;

	private bool? _ManterRegrasAlteracaoTabelaPrecoProposta;

	private decimal? _PercMargemSegurancaGondola;

	private bool? _RestricaoVendaLocalizacaoCliente;

	private bool? _UtilizaRecursoLocalizacao;

	private bool? _ObrigarColetaLocalizacaoCliente;

	private bool? _SolicitarColetaLocalizacaoCliente;

	private bool? _ExibirValidadeMinimaProduto;

	private bool? _ObrigarInformarGondola;

	private decimal? _PercMaxVendaSemApontamentoGondola;

	private bool? _ArredondarUnidCompraAlgoritmo;

	private bool? _EstoqueRespeitarTpPed;

	private bool? _PermitirCadastroEmailClienteLanctoPedido;

	private bool? _ObrigarCadastroEmailClienteLanctoPedido;

	private bool? _UtilizarDescontoMaximoProduto;

	private bool? _ConsiderarDescontoGeral;

	private int? _QtdeMaxCotacaoPorVendedor;

	private bool? _ObrigarInformarCheckoutsCliente;

	private bool? _AtualizarDescTrocaCondPgto;

	private int? _QtdeDiasFrequenciaSemRoteiroVisita;

	private string _TipoMargemSegurancaGondola;

	private decimal? _QtdeMargemSegurancaGondola;

	private bool? _UtilizarEmailComercial;

	private bool? _LancarQtdeEstoqueZeroItensObrigatorios;

	private bool? _EnviarPedidoAutomaticamenteAposLancamento;

	private bool? _UtilizarApontamentoGondola;

	private bool? _ObrigatorioInformarEmailContatoComercial;

	private bool? _PermiteEntregaOutroCliente;

	private bool? _ExibirStatusPositivacaoProdutos;

	private bool? _ExibirPromFlexLancItem;

	private bool? _ControlarHorarioAlmoco;

	private int? _TempoAlmoco;

	private int? _TempoBloqueioAlmoco;

	private DateTime? _HorarioIniciarAlmoco;

	private byte[] _RowId;

	private short? _RaioCliente;

	private decimal? _PropostaPercMgBrutaMinima;

	private bool? _ValidarVlPrecoMinimoPedido;

	private bool? _ValidarVlPrecoMinimoProposta;

	private string _ClassificacaoCurvaABCProduto;

	private bool? _BloqueiaTituloPorColigacao;

	private bool? _BloqueiaTituloPorGrupo;

	private bool? _InicioJornadaNoRoteiro;

	private bool? _FimJornadaNoRoteiro;

	private bool? _ExibirMetaPositivFabric;

	private int? _InadimplenciaPrazoMedio;

	private bool? _UtilizaVisitaTelefonica;

	private bool? _PermiteIndicarMotivoNaoVendaComAcaoLigacao;

	private int? _DuracaoMinimaLigacaoVisita;

	private bool? _UtilizaVendedorCliente;

	private bool? _UtilizaBonificacaoSomentePromocao;

	private bool? _UtilizaAnotacoes;

	private int? _QtdeMaxDiasExibirAnotacoes;

	private bool? _EsconderAnotacoesTelaPedido;

	private bool? _ObrigarPreencherAnotacao;

	private List<VendedorTO> _Vendedor = new List<VendedorTO>();

	private List<ConfiguracaoVendedorClienteNovoFormPgtoTO> _ClienteNovoFormPgto = new List<ConfiguracaoVendedorClienteNovoFormPgtoTO>();

	private List<ConfiguracaoVendedorEstoqueTO> _ConfiguracaoVendedorEstoque = new List<ConfiguracaoVendedorEstoqueTO>();

	private List<ConfiguracaoVendedorVisitaDiasSemanaTO> _ConfiguracaoVendedorVisitaDiasSemana = new List<ConfiguracaoVendedorVisitaDiasSemanaTO>();

	private List<ConfiguracaoVendedorVisitaFrequenciaTO> _ConfiguracaoVendedorVisitaFrequencia = new List<ConfiguracaoVendedorVisitaFrequenciaTO>();

	private List<ConfiguracaoVendedorTipoNotificacaoTO> _ConfiguracaoVendedorTipoNotificacao = new List<ConfiguracaoVendedorTipoNotificacaoTO>();

	private List<ConfiguracaoVendedorOrdenacaoGondolaTO> _ConfiguracaoVendedorOrdenacaoGondola = new List<ConfiguracaoVendedorOrdenacaoGondolaTO>();

	private List<ConfiguracaoVendedorCoordenadaDiasSemanaTO> _ConfiguracaoVendedorCoordenadaDiasSemana = new List<ConfiguracaoVendedorCoordenadaDiasSemanaTO>();

	private List<ConfiguracaoVendedorPaisTO> _ConfiguracaoVendedorPais = new List<ConfiguracaoVendedorPaisTO>();

	private List<ConfiguracaoVendedorInadimplenciaFormPgtoTO> _ConfiguracaoVendedorInadimplenciaFormPgto = new List<ConfiguracaoVendedorInadimplenciaFormPgtoTO>();

	public int? Id
	{
		get
		{
			return _Id;
		}
		set
		{
			_Id = value;
		}
	}

	public string DescricaoConfiguracaoVendedor
	{
		get
		{
			return _DescricaoConfiguracaoVendedor;
		}
		set
		{
			_DescricaoConfiguracaoVendedor = value;
		}
	}

	public bool? PermitirCadastrarNovoCliente
	{
		get
		{
			return _PermitirCadastrarNovoCliente;
		}
		set
		{
			_PermitirCadastrarNovoCliente = value;
		}
	}

	public decimal? TaxaJuros
	{
		get
		{
			return _TaxaJuros;
		}
		set
		{
			_TaxaJuros = value;
		}
	}

	public decimal? QtdeDiasCancelamentoCotacao
	{
		get
		{
			return _QtdeDiasCancelamentoCotacao;
		}
		set
		{
			_QtdeDiasCancelamentoCotacao = value;
		}
	}

	public bool? UtilizaQtdeMaxPedVdaSemTransmissao
	{
		get
		{
			return _UtilizaQtdeMaxPedVdaSemTransmissao;
		}
		set
		{
			_UtilizaQtdeMaxPedVdaSemTransmissao = value;
		}
	}

	public short? QtdeMaxPedVdaSemTransmissao
	{
		get
		{
			return _QtdeMaxPedVdaSemTransmissao;
		}
		set
		{
			_QtdeMaxPedVdaSemTransmissao = value;
		}
	}

	public bool? ObrigarInformarRamoAtivPedVda
	{
		get
		{
			return _ObrigarInformarRamoAtivPedVda;
		}
		set
		{
			_ObrigarInformarRamoAtivPedVda = value;
		}
	}

	public bool? CalcularSubstituicaoTributaria
	{
		get
		{
			return _CalcularSubstituicaoTributaria;
		}
		set
		{
			_CalcularSubstituicaoTributaria = value;
		}
	}

	public bool? ExibeSinalizadorMargemPedVda
	{
		get
		{
			return _ExibeSinalizadorMargemPedVda;
		}
		set
		{
			_ExibeSinalizadorMargemPedVda = value;
		}
	}

	public bool? ExibePercentualMargemPedVda
	{
		get
		{
			return _ExibePercentualMargemPedVda;
		}
		set
		{
			_ExibePercentualMargemPedVda = value;
		}
	}

	public bool? BloquearPedVdaSituacaoCredito
	{
		get
		{
			return _BloquearPedVdaSituacaoCredito;
		}
		set
		{
			_BloquearPedVdaSituacaoCredito = value;
		}
	}

	public decimal? PercToleranciaLimiteCredito
	{
		get
		{
			return _PercToleranciaLimiteCredito;
		}
		set
		{
			_PercToleranciaLimiteCredito = value;
		}
	}

	public decimal? QtdeDiasExibirAvisoVencAnvisa
	{
		get
		{
			return _QtdeDiasExibirAvisoVencAnvisa;
		}
		set
		{
			_QtdeDiasExibirAvisoVencAnvisa = value;
		}
	}

	public decimal? QtdeDiasExibirAvisoVencAlvara
	{
		get
		{
			return _QtdeDiasExibirAvisoVencAlvara;
		}
		set
		{
			_QtdeDiasExibirAvisoVencAlvara = value;
		}
	}

	public bool? BloquearPedVdaLimiteCredito
	{
		get
		{
			return _BloquearPedVdaLimiteCredito;
		}
		set
		{
			_BloquearPedVdaLimiteCredito = value;
		}
	}

	public bool? BloquearPedVdaAnvisaVencido
	{
		get
		{
			return _BloquearPedVdaAnvisaVencido;
		}
		set
		{
			_BloquearPedVdaAnvisaVencido = value;
		}
	}

	public bool? BloquearPedVdaAlvaraVencido
	{
		get
		{
			return _BloquearPedVdaAlvaraVencido;
		}
		set
		{
			_BloquearPedVdaAlvaraVencido = value;
		}
	}

	public short? QtdeDiasToleranciaInadimplencia
	{
		get
		{
			return _QtdeDiasToleranciaInadimplencia;
		}
		set
		{
			_QtdeDiasToleranciaInadimplencia = value;
		}
	}

	public bool? PermitirLancarPedVdaClienteNovo
	{
		get
		{
			return _PermitirLancarPedVdaClienteNovo;
		}
		set
		{
			_PermitirLancarPedVdaClienteNovo = value;
		}
	}

	public string ClienteNovoCodigoTabPre
	{
		get
		{
			return _ClienteNovoCodigoTabPre;
		}
		set
		{
			_ClienteNovoCodigoTabPre = value;
		}
	}

	public short? ClienteNovoPrazoMedio
	{
		get
		{
			return _ClienteNovoPrazoMedio;
		}
		set
		{
			_ClienteNovoPrazoMedio = value;
		}
	}

	public string ClienteNovoCodigoFormPgto
	{
		get
		{
			return _ClienteNovoCodigoFormPgto;
		}
		set
		{
			_ClienteNovoCodigoFormPgto = value;
		}
	}

	public string ClienteNovoCodigoTpPed
	{
		get
		{
			return _ClienteNovoCodigoTpPed;
		}
		set
		{
			_ClienteNovoCodigoTpPed = value;
		}
	}

	public bool? BloquearFormPgtoBancoVendaEspecial
	{
		get
		{
			return _BloquearFormPgtoBancoVendaEspecial;
		}
		set
		{
			_BloquearFormPgtoBancoVendaEspecial = value;
		}
	}

	public string CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial
	{
		get
		{
			return _CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial;
		}
		set
		{
			_CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial = value;
		}
	}

	public bool? PermitirAlterarFormPgtoPedVda
	{
		get
		{
			return _PermitirAlterarFormPgtoPedVda;
		}
		set
		{
			_PermitirAlterarFormPgtoPedVda = value;
		}
	}

	public bool? LiberarTodasCondPgtoPedVda
	{
		get
		{
			return _LiberarTodasCondPgtoPedVda;
		}
		set
		{
			_LiberarTodasCondPgtoPedVda = value;
		}
	}

	public bool? BloquearPedVdaPorValorMinimo
	{
		get
		{
			return _BloquearPedVdaPorValorMinimo;
		}
		set
		{
			_BloquearPedVdaPorValorMinimo = value;
		}
	}

	public bool? UtilizaDescontoFlexPcfgTargetMob
	{
		get
		{
			return _UtilizaDescontoFlexPcfgTargetMob;
		}
		set
		{
			_UtilizaDescontoFlexPcfgTargetMob = value;
		}
	}

	public decimal? PercDescMaxFlex
	{
		get
		{
			return _PercDescMaxFlex;
		}
		set
		{
			_PercDescMaxFlex = value;
		}
	}

	public bool? PermitirDescontoGeral
	{
		get
		{
			return _PermitirDescontoGeral;
		}
		set
		{
			_PermitirDescontoGeral = value;
		}
	}

	public decimal? PercMaxDescGeralPedVda
	{
		get
		{
			return _PercMaxDescGeralPedVda;
		}
		set
		{
			_PercMaxDescGeralPedVda = value;
		}
	}

	public bool? UtilizaFormPgtoDepositoConta
	{
		get
		{
			return _UtilizaFormPgtoDepositoConta;
		}
		set
		{
			_UtilizaFormPgtoDepositoConta = value;
		}
	}

	public bool? BloquearPedVdaMargemMinima
	{
		get
		{
			return _BloquearPedVdaMargemMinima;
		}
		set
		{
			_BloquearPedVdaMargemMinima = value;
		}
	}

	public decimal? ValorMinimoProposta
	{
		get
		{
			return _ValorMinimoProposta;
		}
		set
		{
			_ValorMinimoProposta = value;
		}
	}

	public short? QtdeDiasEstoqueInsuficiente
	{
		get
		{
			return _QtdeDiasEstoqueInsuficiente;
		}
		set
		{
			_QtdeDiasEstoqueInsuficiente = value;
		}
	}

	public bool? ExibirEstoque
	{
		get
		{
			return _ExibirEstoque;
		}
		set
		{
			_ExibirEstoque = value;
		}
	}

	public bool? BloquearVendaAcimaEstoque
	{
		get
		{
			return _BloquearVendaAcimaEstoque;
		}
		set
		{
			_BloquearVendaAcimaEstoque = value;
		}
	}

	public bool? UtilizaMotivoNaoVendaForaRoteiroDiaAnterior
	{
		get
		{
			return _UtilizaMotivoNaoVendaForaRoteiroDiaAnterior;
		}
		set
		{
			_UtilizaMotivoNaoVendaForaRoteiroDiaAnterior = value;
		}
	}

	public bool? BloquearVendaNormalItemEmPromocao
	{
		get
		{
			return _BloquearVendaNormalItemEmPromocao;
		}
		set
		{
			_BloquearVendaNormalItemEmPromocao = value;
		}
	}

	public bool? ObrigarMotivoNaoVendaForaRoteiroDiaAnterior
	{
		get
		{
			return _ObrigarMotivoNaoVendaForaRoteiroDiaAnterior;
		}
		set
		{
			_ObrigarMotivoNaoVendaForaRoteiroDiaAnterior = value;
		}
	}

	public bool? BloqueiaAlteracaoAgendamentoVisitas
	{
		get
		{
			return _BloqueiaAlteracaoAgendamentoVisitas;
		}
		set
		{
			_BloqueiaAlteracaoAgendamentoVisitas = value;
		}
	}

	public DateTime? HorarioInicioVisita
	{
		get
		{
			return _HorarioInicioVisita;
		}
		set
		{
			_HorarioInicioVisita = value;
		}
	}

	public DateTime? HorarioFimVisita
	{
		get
		{
			return _HorarioFimVisita;
		}
		set
		{
			_HorarioFimVisita = value;
		}
	}

	public bool? LiberarCreditoVerbaPedidoNovo
	{
		get
		{
			return _LiberarCreditoVerbaPedidoNovo;
		}
		set
		{
			_LiberarCreditoVerbaPedidoNovo = value;
		}
	}

	public bool? BloquearPedVdaSaldoVerbaNegativo
	{
		get
		{
			return _BloquearPedVdaSaldoVerbaNegativo;
		}
		set
		{
			_BloquearPedVdaSaldoVerbaNegativo = value;
		}
	}

	public decimal? PercMaxToleranciaVisitaForaRota
	{
		get
		{
			return _PercMaxToleranciaVisitaForaRota;
		}
		set
		{
			_PercMaxToleranciaVisitaForaRota = value;
		}
	}

	public bool? ExibirVerbaFechamentoPedVda
	{
		get
		{
			return _ExibirVerbaFechamentoPedVda;
		}
		set
		{
			_ExibirVerbaFechamentoPedVda = value;
		}
	}

	public bool? ControlarOrdemVisitas
	{
		get
		{
			return _ControlarOrdemVisitas;
		}
		set
		{
			_ControlarOrdemVisitas = value;
		}
	}

	public decimal? PercIndenizacaoTroca
	{
		get
		{
			return _PercIndenizacaoTroca;
		}
		set
		{
			_PercIndenizacaoTroca = value;
		}
	}

	public bool? ObrigarMotivoNaoVendaDiaAnterior
	{
		get
		{
			return _ObrigarMotivoNaoVendaDiaAnterior;
		}
		set
		{
			_ObrigarMotivoNaoVendaDiaAnterior = value;
		}
	}

	public bool? ExibirSaldoVerba
	{
		get
		{
			return _ExibirSaldoVerba;
		}
		set
		{
			_ExibirSaldoVerba = value;
		}
	}

	public string TipoPedVdaHistoricoCliente
	{
		get
		{
			return _TipoPedVdaHistoricoCliente;
		}
		set
		{
			_TipoPedVdaHistoricoCliente = value;
		}
	}

	public decimal? QtdePedVdaHistoricoCliente
	{
		get
		{
			return _QtdePedVdaHistoricoCliente;
		}
		set
		{
			_QtdePedVdaHistoricoCliente = value;
		}
	}

	public string TipoDescontoVerbaItemBonificado
	{
		get
		{
			return _TipoDescontoVerbaItemBonificado;
		}
		set
		{
			_TipoDescontoVerbaItemBonificado = value;
		}
	}

	public decimal? PercMaxCreditoVerba
	{
		get
		{
			return _PercMaxCreditoVerba;
		}
		set
		{
			_PercMaxCreditoVerba = value;
		}
	}

	public bool? UtilizaBonificacao
	{
		get
		{
			return _UtilizaBonificacao;
		}
		set
		{
			_UtilizaBonificacao = value;
		}
	}

	public bool? UtilizaDescontoPromocionalAutomatico
	{
		get
		{
			return _UtilizaDescontoPromocionalAutomatico;
		}
		set
		{
			_UtilizaDescontoPromocionalAutomatico = value;
		}
	}

	public decimal? QtdeDiasTitulosAVencer
	{
		get
		{
			return _QtdeDiasTitulosAVencer;
		}
		set
		{
			_QtdeDiasTitulosAVencer = value;
		}
	}

	public bool? ExibirTituloSomenteVendedor
	{
		get
		{
			return _ExibirTituloSomenteVendedor;
		}
		set
		{
			_ExibirTituloSomenteVendedor = value;
		}
	}

	public bool? DesmembraPedidoProdutoxEmpresa
	{
		get
		{
			return _DesmembraPedidoProdutoxEmpresa;
		}
		set
		{
			_DesmembraPedidoProdutoxEmpresa = value;
		}
	}

	public bool? DesmembraPedidoProdutoxGrupoProduto
	{
		get
		{
			return _DesmembraPedidoProdutoxGrupoProduto;
		}
		set
		{
			_DesmembraPedidoProdutoxGrupoProduto = value;
		}
	}

	public bool? RespeitaAssociacaoVendedorxTipoPedido
	{
		get
		{
			return _RespeitaAssociacaoVendedorxTipoPedido;
		}
		set
		{
			_RespeitaAssociacaoVendedorxTipoPedido = value;
		}
	}

	public bool? RespeitaAssociacaoVendedorxProduto
	{
		get
		{
			return _RespeitaAssociacaoVendedorxProduto;
		}
		set
		{
			_RespeitaAssociacaoVendedorxProduto = value;
		}
	}

	public bool? RespeitaAssociacaoVendedorxTabelaPreco
	{
		get
		{
			return _RespeitaAssociacaoVendedorxTabelaPreco;
		}
		set
		{
			_RespeitaAssociacaoVendedorxTabelaPreco = value;
		}
	}

	public bool? EnviaSomenteUnidadesComOrdemImpressao
	{
		get
		{
			return _EnviaSomenteUnidadesComOrdemImpressao;
		}
		set
		{
			_EnviaSomenteUnidadesComOrdemImpressao = value;
		}
	}

	public bool? RestrVendaSomenteVendedorPrioritario
	{
		get
		{
			return _RestrVendaSomenteVendedorPrioritario;
		}
		set
		{
			_RestrVendaSomenteVendedorPrioritario = value;
		}
	}

	public string TipoRestricaoVenda
	{
		get
		{
			return _TipoRestricaoVenda;
		}
		set
		{
			_TipoRestricaoVenda = value;
		}
	}

	public string TipoCusto
	{
		get
		{
			return _TipoCusto;
		}
		set
		{
			_TipoCusto = value;
		}
	}

	public string TipoAbatimentoTroca
	{
		get
		{
			return _TipoAbatimentoTroca;
		}
		set
		{
			_TipoAbatimentoTroca = value;
		}
	}

	public bool? NaoImportarAtualizacaoPlanoVisita
	{
		get
		{
			return _NaoImportarAtualizacaoPlanoVisita;
		}
		set
		{
			_NaoImportarAtualizacaoPlanoVisita = value;
		}
	}

	public bool? LiberarPedidosAutomaticamente
	{
		get
		{
			return _LiberarPedidosAutomaticamente;
		}
		set
		{
			_LiberarPedidosAutomaticamente = value;
		}
	}

	public bool? UtilizaUnidadeVendaNaTroca
	{
		get
		{
			return _UtilizaUnidadeVendaNaTroca;
		}
		set
		{
			_UtilizaUnidadeVendaNaTroca = value;
		}
	}

	public decimal? PercDesconto
	{
		get
		{
			return _PercDesconto;
		}
		set
		{
			_PercDesconto = value;
		}
	}

	public bool? UtilizaTroca
	{
		get
		{
			return _UtilizaTroca;
		}
		set
		{
			_UtilizaTroca = value;
		}
	}

	public bool? UtilizaProposta
	{
		get
		{
			return _UtilizaProposta;
		}
		set
		{
			_UtilizaProposta = value;
		}
	}

	public bool? PermiteAlterarPercIndenizacao
	{
		get
		{
			return _PermiteAlterarPercIndenizacao;
		}
		set
		{
			_PermiteAlterarPercIndenizacao = value;
		}
	}

	public bool? ExibirSaldoComissao
	{
		get
		{
			return _ExibirSaldoComissao;
		}
		set
		{
			_ExibirSaldoComissao = value;
		}
	}

	public int? QtdeMaxVisitasDia
	{
		get
		{
			return _QtdeMaxVisitasDia;
		}
		set
		{
			_QtdeMaxVisitasDia = value;
		}
	}

	public decimal? LimiteMinimoVerbaVendedor
	{
		get
		{
			return _LimiteMinimoVerbaVendedor;
		}
		set
		{
			_LimiteMinimoVerbaVendedor = value;
		}
	}

	public bool? BloquearVisitaAvulsa
	{
		get
		{
			return _BloquearVisitaAvulsa;
		}
		set
		{
			_BloquearVisitaAvulsa = value;
		}
	}

	public bool? SugereFiltroMixSegmentoPedVda
	{
		get
		{
			return _SugereFiltroMixSegmentoPedVda;
		}
		set
		{
			_SugereFiltroMixSegmentoPedVda = value;
		}
	}

	public bool? JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento
	{
		get
		{
			return _JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento;
		}
		set
		{
			_JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento = value;
		}
	}

	public bool? ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto
	{
		get
		{
			return _ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto;
		}
		set
		{
			_ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto = value;
		}
	}

	public bool? PermitirDownloadPacoteDados
	{
		get
		{
			return _PermitirDownloadPacoteDados;
		}
		set
		{
			_PermitirDownloadPacoteDados = value;
		}
	}

	public bool? PermitirDownloadSinc
	{
		get
		{
			return _PermitirDownloadSinc;
		}
		set
		{
			_PermitirDownloadSinc = value;
		}
	}

	public int? LimitePacoteDados
	{
		get
		{
			return _LimitePacoteDados;
		}
		set
		{
			_LimitePacoteDados = value;
		}
	}

	public int? LimiteDownloadSinc
	{
		get
		{
			return _LimiteDownloadSinc;
		}
		set
		{
			_LimiteDownloadSinc = value;
		}
	}

	public bool? NaoImportarInformacaoVisitaForaRota
	{
		get
		{
			return _NaoImportarInformacaoVisitaForaRota;
		}
		set
		{
			_NaoImportarInformacaoVisitaForaRota = value;
		}
	}

	public bool? AplicarPrazoMedioNaAssociacaoClienteCondPgto
	{
		get
		{
			return _AplicarPrazoMedioNaAssociacaoClienteCondPgto;
		}
		set
		{
			_AplicarPrazoMedioNaAssociacaoClienteCondPgto = value;
		}
	}

	public bool? UtilizaDescontoPromocionalAutomaticoPromFlex
	{
		get
		{
			return _UtilizaDescontoPromocionalAutomaticoPromFlex;
		}
		set
		{
			_UtilizaDescontoPromocionalAutomaticoPromFlex = value;
		}
	}

	public bool? IgnorarMotivoNaoVendaMixSegmento
	{
		get
		{
			return _IgnorarMotivoNaoVendaMixSegmento;
		}
		set
		{
			_IgnorarMotivoNaoVendaMixSegmento = value;
		}
	}

	public bool? ExibirProdutosNaoAssociadosCondPagto
	{
		get
		{
			return _ExibirProdutosNaoAssociadosCondPagto;
		}
		set
		{
			_ExibirProdutosNaoAssociadosCondPagto = value;
		}
	}

	public int? InadimplenciaPrazoMedio
	{
		get
		{
			return _InadimplenciaPrazoMedio;
		}
		set
		{
			_InadimplenciaPrazoMedio = value;
		}
	}

	public List<VendedorTO> Vendedor
	{
		get
		{
			return _Vendedor;
		}
		set
		{
			_Vendedor = value;
		}
	}

	public List<ConfiguracaoVendedorEstoqueTO> ConfiguracaoVendedorEstoque
	{
		get
		{
			return _ConfiguracaoVendedorEstoque;
		}
		set
		{
			_ConfiguracaoVendedorEstoque = value;
		}
	}

	public List<ConfiguracaoVendedorVisitaDiasSemanaTO> ConfiguracaoVendedorVisitaDiasSemana
	{
		get
		{
			return _ConfiguracaoVendedorVisitaDiasSemana;
		}
		set
		{
			_ConfiguracaoVendedorVisitaDiasSemana = value;
		}
	}

	public List<ConfiguracaoVendedorVisitaFrequenciaTO> ConfiguracaoVendedorVisitaFrequencia
	{
		get
		{
			return _ConfiguracaoVendedorVisitaFrequencia;
		}
		set
		{
			_ConfiguracaoVendedorVisitaFrequencia = value;
		}
	}

	public List<ConfiguracaoVendedorClienteNovoFormPgtoTO> ClienteNovoFormPgto
	{
		get
		{
			return _ClienteNovoFormPgto;
		}
		set
		{
			_ClienteNovoFormPgto = value;
		}
	}

	public List<ConfiguracaoVendedorTipoNotificacaoTO> ConfiguracaoVendedorTipoNotificacao
	{
		get
		{
			return _ConfiguracaoVendedorTipoNotificacao;
		}
		set
		{
			_ConfiguracaoVendedorTipoNotificacao = value;
		}
	}

	public List<ConfiguracaoVendedorOrdenacaoGondolaTO> ConfiguracaoVendedorOrdenacaoGondola
	{
		get
		{
			return _ConfiguracaoVendedorOrdenacaoGondola;
		}
		set
		{
			_ConfiguracaoVendedorOrdenacaoGondola = value;
		}
	}

	public List<ConfiguracaoVendedorCoordenadaDiasSemanaTO> ConfiguracaoVendedorCoordenadaDiasSemana
	{
		get
		{
			return _ConfiguracaoVendedorCoordenadaDiasSemana;
		}
		set
		{
			_ConfiguracaoVendedorCoordenadaDiasSemana = value;
		}
	}

	public List<ConfiguracaoVendedorPaisTO> ConfiguracaoVendedorPais
	{
		get
		{
			return _ConfiguracaoVendedorPais;
		}
		set
		{
			_ConfiguracaoVendedorPais = value;
		}
	}

	public List<ConfiguracaoVendedorInadimplenciaFormPgtoTO> ConfiguracaoVendedorInadimplenciaFormPgto
	{
		get
		{
			return _ConfiguracaoVendedorInadimplenciaFormPgto;
		}
		set
		{
			_ConfiguracaoVendedorInadimplenciaFormPgto = value;
		}
	}

	public bool? UtilizaVisitaTelefonica
	{
		get
		{
			return _UtilizaVisitaTelefonica;
		}
		set
		{
			_UtilizaVisitaTelefonica = value;
		}
	}

	public int? DuracaoMinimaLigacaoVisita
	{
		get
		{
			return _DuracaoMinimaLigacaoVisita;
		}
		set
		{
			_DuracaoMinimaLigacaoVisita = value;
		}
	}

	public bool? PermiteIndicarMotivoNaoVendaComAcaoLigacao
	{
		get
		{
			return _PermiteIndicarMotivoNaoVendaComAcaoLigacao;
		}
		set
		{
			_PermiteIndicarMotivoNaoVendaComAcaoLigacao = value;
		}
	}

	public bool? UtilizaVendedorCliente
	{
		get
		{
			return _UtilizaVendedorCliente;
		}
		set
		{
			_UtilizaVendedorCliente = value;
		}
	}

	public byte[] RowId
	{
		get
		{
			return _RowId;
		}
		set
		{
			_RowId = value;
		}
	}

	public bool? ExibirStatusPositivacaoProdutos
	{
		get
		{
			return _ExibirStatusPositivacaoProdutos;
		}
		set
		{
			_ExibirStatusPositivacaoProdutos = value;
		}
	}

	public bool? PermiteEntregaOutroCliente
	{
		get
		{
			return _PermiteEntregaOutroCliente;
		}
		set
		{
			_PermiteEntregaOutroCliente = value;
		}
	}

	public bool? ObrigatorioInformarEmailContatoComercial
	{
		get
		{
			return _ObrigatorioInformarEmailContatoComercial;
		}
		set
		{
			_ObrigatorioInformarEmailContatoComercial = value;
		}
	}

	public bool? UtilizarApontamentoGondola
	{
		get
		{
			return _UtilizarApontamentoGondola;
		}
		set
		{
			_UtilizarApontamentoGondola = value;
		}
	}

	public bool? LancarQtdeEstoqueZeroItensObrigatorios
	{
		get
		{
			return _LancarQtdeEstoqueZeroItensObrigatorios;
		}
		set
		{
			_LancarQtdeEstoqueZeroItensObrigatorios = value;
		}
	}

	public bool? EnviarPedidoAutomaticamenteAposLancamento
	{
		get
		{
			return _EnviarPedidoAutomaticamenteAposLancamento;
		}
		set
		{
			_EnviarPedidoAutomaticamenteAposLancamento = value;
		}
	}

	public bool? UtilizarEmailComercial
	{
		get
		{
			return _UtilizarEmailComercial;
		}
		set
		{
			_UtilizarEmailComercial = value;
		}
	}

	public decimal? QtdeMargemSegurancaGondola
	{
		get
		{
			return _QtdeMargemSegurancaGondola;
		}
		set
		{
			_QtdeMargemSegurancaGondola = value;
		}
	}

	public string TipoMargemSegurancaGondola
	{
		get
		{
			return _TipoMargemSegurancaGondola;
		}
		set
		{
			_TipoMargemSegurancaGondola = value;
		}
	}

	public int? QtdeDiasFrequenciaSemRoteiroVisita
	{
		get
		{
			return _QtdeDiasFrequenciaSemRoteiroVisita;
		}
		set
		{
			_QtdeDiasFrequenciaSemRoteiroVisita = value;
		}
	}

	public bool? AtualizarDescTrocaCondPgto
	{
		get
		{
			return _AtualizarDescTrocaCondPgto;
		}
		set
		{
			_AtualizarDescTrocaCondPgto = value;
		}
	}

	public bool? ObrigarInformarCheckoutsCliente
	{
		get
		{
			return _ObrigarInformarCheckoutsCliente;
		}
		set
		{
			_ObrigarInformarCheckoutsCliente = value;
		}
	}

	public int? QtdeMaxCotacaoPorVendedor
	{
		get
		{
			return _QtdeMaxCotacaoPorVendedor;
		}
		set
		{
			_QtdeMaxCotacaoPorVendedor = value;
		}
	}

	public bool? ConsiderarDescontoGeral
	{
		get
		{
			return _ConsiderarDescontoGeral;
		}
		set
		{
			_ConsiderarDescontoGeral = value;
		}
	}

	public bool? UtilizarDescontoMaximoProduto
	{
		get
		{
			return _UtilizarDescontoMaximoProduto;
		}
		set
		{
			_UtilizarDescontoMaximoProduto = value;
		}
	}

	public bool? ObrigarCadastroEmailClienteLanctoPedido
	{
		get
		{
			return _ObrigarCadastroEmailClienteLanctoPedido;
		}
		set
		{
			_ObrigarCadastroEmailClienteLanctoPedido = value;
		}
	}

	public bool? PermitirCadastroEmailClienteLanctoPedido
	{
		get
		{
			return _PermitirCadastroEmailClienteLanctoPedido;
		}
		set
		{
			_PermitirCadastroEmailClienteLanctoPedido = value;
		}
	}

	public bool? EstoqueRespeitarTpPed
	{
		get
		{
			return _EstoqueRespeitarTpPed;
		}
		set
		{
			_EstoqueRespeitarTpPed = value;
		}
	}

	public bool? ArredondarUnidCompraAlgoritmo
	{
		get
		{
			return _ArredondarUnidCompraAlgoritmo;
		}
		set
		{
			_ArredondarUnidCompraAlgoritmo = value;
		}
	}

	public decimal? PercMaxVendaSemApontamentoGondola
	{
		get
		{
			return _PercMaxVendaSemApontamentoGondola;
		}
		set
		{
			_PercMaxVendaSemApontamentoGondola = value;
		}
	}

	public bool? ObrigarInformarGondola
	{
		get
		{
			return _ObrigarInformarGondola;
		}
		set
		{
			_ObrigarInformarGondola = value;
		}
	}

	public bool? ExibirValidadeMinimaProduto
	{
		get
		{
			return _ExibirValidadeMinimaProduto;
		}
		set
		{
			_ExibirValidadeMinimaProduto = value;
		}
	}

	public bool? SolicitarColetaLocalizacaoCliente
	{
		get
		{
			return _SolicitarColetaLocalizacaoCliente;
		}
		set
		{
			_SolicitarColetaLocalizacaoCliente = value;
		}
	}

	public bool? ObrigarColetaLocalizacaoCliente
	{
		get
		{
			return _ObrigarColetaLocalizacaoCliente;
		}
		set
		{
			_ObrigarColetaLocalizacaoCliente = value;
		}
	}

	public bool? UtilizaRecursoLocalizacao
	{
		get
		{
			return _UtilizaRecursoLocalizacao;
		}
		set
		{
			_UtilizaRecursoLocalizacao = value;
		}
	}

	public bool? RestricaoVendaLocalizacaoCliente
	{
		get
		{
			return _RestricaoVendaLocalizacaoCliente;
		}
		set
		{
			_RestricaoVendaLocalizacaoCliente = value;
		}
	}

	public decimal? PercMargemSegurancaGondola
	{
		get
		{
			return _PercMargemSegurancaGondola;
		}
		set
		{
			_PercMargemSegurancaGondola = value;
		}
	}

	public bool? ManterRegrasAlteracaoTabelaPrecoProposta
	{
		get
		{
			return _ManterRegrasAlteracaoTabelaPrecoProposta;
		}
		set
		{
			_ManterRegrasAlteracaoTabelaPrecoProposta = value;
		}
	}

	public bool? CalcularVerbaItemKitProm
	{
		get
		{
			return _CalcularVerbaItemKitProm;
		}
		set
		{
			_CalcularVerbaItemKitProm = value;
		}
	}

	public bool? NaoSincronizarAposLancamentoPedido
	{
		get
		{
			return _NaoSincronizarAposLancamentoPedido;
		}
		set
		{
			_NaoSincronizarAposLancamentoPedido = value;
		}
	}

	public bool? PermiteAlterarDescontoPorQuantidade
	{
		get
		{
			return _PermiteAlterarDescontoPorQuantidade;
		}
		set
		{
			_PermiteAlterarDescontoPorQuantidade = value;
		}
	}

	public bool? BloquearAlterarTipoEntrega
	{
		get
		{
			return _BloquearAlterarTipoEntrega;
		}
		set
		{
			_BloquearAlterarTipoEntrega = value;
		}
	}

	public bool? SupervisorNaoReceberCargaEquipe
	{
		get
		{
			return _SupervisorNaoReceberCargaEquipe;
		}
		set
		{
			_SupervisorNaoReceberCargaEquipe = value;
		}
	}

	public bool? ExibirCondPagtoDentroPrazoMedioEAssociadasCliente
	{
		get
		{
			return _ExibirCondPagtoDentroPrazoMedioEAssociadasCliente;
		}
		set
		{
			_ExibirCondPagtoDentroPrazoMedioEAssociadasCliente = value;
		}
	}

	public bool? OcultarProdutosSemEstoque
	{
		get
		{
			return _OcultarProdutosSemEstoque;
		}
		set
		{
			_OcultarProdutosSemEstoque = value;
		}
	}

	public bool? TiposFiltrosItensPedidoFabricante
	{
		get
		{
			return _TiposFiltrosItensPedidoFabricante;
		}
		set
		{
			_TiposFiltrosItensPedidoFabricante = value;
		}
	}

	public bool? TiposFiltrosItensPedidoCategoria
	{
		get
		{
			return _TiposFiltrosItensPedidoCategoria;
		}
		set
		{
			_TiposFiltrosItensPedidoCategoria = value;
		}
	}

	public bool? TiposFiltrosItensPedidoLinha
	{
		get
		{
			return _TiposFiltrosItensPedidoLinha;
		}
		set
		{
			_TiposFiltrosItensPedidoLinha = value;
		}
	}

	public bool? TiposFiltrosItensPedidoDepto
	{
		get
		{
			return _TiposFiltrosItensPedidoDepto;
		}
		set
		{
			_TiposFiltrosItensPedidoDepto = value;
		}
	}

	public bool? TiposFiltrosItensPedidoSecao
	{
		get
		{
			return _TiposFiltrosItensPedidoSecao;
		}
		set
		{
			_TiposFiltrosItensPedidoSecao = value;
		}
	}

	public bool? ExibirPromFlexLancItem
	{
		get
		{
			return _ExibirPromFlexLancItem;
		}
		set
		{
			_ExibirPromFlexLancItem = value;
		}
	}

	public bool? ControlarHorarioAlmoco
	{
		get
		{
			return _ControlarHorarioAlmoco;
		}
		set
		{
			_ControlarHorarioAlmoco = value;
		}
	}

	public int? TempoAlmoco
	{
		get
		{
			return _TempoAlmoco;
		}
		set
		{
			_TempoAlmoco = value;
		}
	}

	public int? TempoBloqueioAlmoco
	{
		get
		{
			return _TempoBloqueioAlmoco;
		}
		set
		{
			_TempoBloqueioAlmoco = value;
		}
	}

	public DateTime? HorarioIniciarAlmoco
	{
		get
		{
			return _HorarioIniciarAlmoco;
		}
		set
		{
			_HorarioIniciarAlmoco = value;
		}
	}

	public short? RaioCliente
	{
		get
		{
			return _RaioCliente;
		}
		set
		{
			_RaioCliente = value;
		}
	}

	public decimal? PropostaPercMgBrutaMinima
	{
		get
		{
			return _PropostaPercMgBrutaMinima;
		}
		set
		{
			_PropostaPercMgBrutaMinima = value;
		}
	}

	public bool? ValidarVlPrecoMinimoPedido
	{
		get
		{
			return _ValidarVlPrecoMinimoPedido;
		}
		set
		{
			_ValidarVlPrecoMinimoPedido = value;
		}
	}

	public bool? ValidarVlPrecoMinimoProposta
	{
		get
		{
			return _ValidarVlPrecoMinimoProposta;
		}
		set
		{
			_ValidarVlPrecoMinimoProposta = value;
		}
	}

	public string ClassificacaoCurvaABCProduto
	{
		get
		{
			return _ClassificacaoCurvaABCProduto;
		}
		set
		{
			_ClassificacaoCurvaABCProduto = value;
		}
	}

	public bool? BloqueiaTituloPorColigacao
	{
		get
		{
			return _BloqueiaTituloPorColigacao;
		}
		set
		{
			_BloqueiaTituloPorColigacao = value;
		}
	}

	public bool? BloqueiaTituloPorGrupo
	{
		get
		{
			return _BloqueiaTituloPorGrupo;
		}
		set
		{
			_BloqueiaTituloPorGrupo = value;
		}
	}

	public bool? InicioJornadaNoRoteiro
	{
		get
		{
			return _InicioJornadaNoRoteiro;
		}
		set
		{
			_InicioJornadaNoRoteiro = value;
		}
	}

	public bool? FimJornadaNoRoteiro
	{
		get
		{
			return _FimJornadaNoRoteiro;
		}
		set
		{
			_FimJornadaNoRoteiro = value;
		}
	}

	public bool? ExibirMetaPositivFabric
	{
		get
		{
			return _ExibirMetaPositivFabric;
		}
		set
		{
			_ExibirMetaPositivFabric = value;
		}
	}

	public bool? UtilizaBonificacaoSomentePromocao
	{
		get
		{
			return _UtilizaBonificacaoSomentePromocao;
		}
		set
		{
			_UtilizaBonificacaoSomentePromocao = value;
		}
	}

	public bool? UtilizaAnotacoes
	{
		get
		{
			return _UtilizaAnotacoes;
		}
		set
		{
			_UtilizaAnotacoes = value;
		}
	}

	public int? QtdeMaxDiasExibirAnotacoes
	{
		get
		{
			return _QtdeMaxDiasExibirAnotacoes;
		}
		set
		{
			_QtdeMaxDiasExibirAnotacoes = value;
		}
	}

	public bool? EsconderAnotacoesTelaPedido
	{
		get
		{
			return _EsconderAnotacoesTelaPedido;
		}
		set
		{
			_EsconderAnotacoesTelaPedido = value;
		}
	}

	public bool? ObrigarPreencherAnotacao
	{
		get
		{
			return _ObrigarPreencherAnotacao;
		}
		set
		{
			_ObrigarPreencherAnotacao = value;
		}
	}

	public string TipoEnvioAnotacoes { get; set; }

	public bool? ObrigarComoRealizouVenda { get; set; }

	public bool? ExibirTituloVencidoTodoVendedor { get; set; }

	public bool? ObrigarEnviarFotoClienteNovo { get; set; }

	public bool? ExibirNotaCredito { get; set; }

	public bool? UtilizaDescontoPorQtdeAutomatico { get; set; }

	public bool? UtilizaIndicacaoFaltaEstoquePromotor { get; set; }

	public int? QtdeMaxDiasExibirIndicacaoFaltaEstoquePromotor { get; set; }

	public bool? ExibirPrecoMenorUnidadeListaItens { get; set; }

	public bool? ExibirLinhaDigitavelBoleto { get; set; }

	public bool? SugerirFiltroMixCliente { get; set; }

	public bool? ObrigarInformarEmailNFe { get; set; }

	public bool? ObrigarInformarEmailFinanceiro { get; set; }

	public bool? ExibirAlertaProdutoComplementar { get; set; }

	public bool? ExibirAlertaProdutoSimilar { get; set; }

	public bool? RespeitarOrdemLancamentoItemPdfEmail { get; set; }

	public bool? EnviarObservacaoProdutoPdfEmail { get; set; }

	public bool? UtilizarEmailCotacaoComImagem { get; set; }

	public bool? ExibirHorarioRoteiroVisita { get; set; }

	public bool? BloquearPedVdaLimiteCreditoTerceiro { get; set; }

	public decimal? PercToleranciaLimiteCreditoTerceiro { get; set; }

	public string ClienteCurvaABC { get; set; }

	public bool? ConsiderarDescontoMaximoPermitido { get; set; }

	public bool? SugerirFiltroProdutoReportadoEmFalta { get; set; }

	public bool? BloquearPedVdaPeloValorMinimoGrupoProduto { get; set; }

	public bool? ObrigarInformarDataPrevisaoEntrega { get; set; }

	public bool? ExibirValidadeProdutoPdfEmail { get; set; }

	public bool? ExibirPromocaoFlexLanctoItem { get; set; }

	public bool? ExibirPromocaoFixaLanctoItem { get; set; }

	public bool? PermitirVendaSomenteUnidCompra { get; set; }
}
