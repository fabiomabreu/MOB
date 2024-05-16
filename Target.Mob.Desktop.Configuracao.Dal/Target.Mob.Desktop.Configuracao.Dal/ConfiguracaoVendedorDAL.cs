using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Common.Util;
using Target.Mob.Desktop.Configuracao.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Configuracao.Dal;

public class ConfiguracaoVendedorDAL
{
	private const string INSERT = "uspConfiguracaoVendedorInsert";

	private const string UPDATE = "uspConfiguracaoVendedorUpdate";

	private const string SELECT = "uspConfiguracaoVendedorSelect";

	private const string EXISTS = "uspConfiguracaoVendedorExists";

	private const string MAXROWID = "uspConfiguracaoVendedorMaxRowId";

	private static void setParametros(SqlCommand cmd, ConfiguracaoVendedorTO instance)
	{
		cmd.Parameters.Clear();
		cmd.Parameters.AddWithValue("@Id", instance.Id);
		cmd.Parameters.AddWithValue("@DescricaoConfiguracaoVendedor", instance.DescricaoConfiguracaoVendedor);
		cmd.Parameters.AddWithValue("@PermitirCadastrarNovoCliente", instance.PermitirCadastrarNovoCliente);
		cmd.Parameters.AddWithValue("@TaxaJuros", instance.TaxaJuros);
		cmd.Parameters.AddWithValue("@QtdeDiasCancelamentoCotacao", instance.QtdeDiasCancelamentoCotacao);
		cmd.Parameters.AddWithValue("@UtilizaQtdeMaxPedVdaSemTransmissao", instance.UtilizaQtdeMaxPedVdaSemTransmissao);
		cmd.Parameters.AddWithValue("@QtdeMaxPedVdaSemTransmissao", instance.QtdeMaxPedVdaSemTransmissao);
		cmd.Parameters.AddWithValue("@ObrigarInformarRamoAtivPedVda", instance.ObrigarInformarRamoAtivPedVda);
		cmd.Parameters.AddWithValue("@CalcularSubstituicaoTributaria", instance.CalcularSubstituicaoTributaria);
		cmd.Parameters.AddWithValue("@ExibeSinalizadorMargemPedVda", instance.ExibeSinalizadorMargemPedVda);
		cmd.Parameters.AddWithValue("@ExibePercentualMargemPedVda", instance.ExibePercentualMargemPedVda);
		cmd.Parameters.AddWithValue("@BloquearPedVdaSituacaoCredito", instance.BloquearPedVdaSituacaoCredito);
		cmd.Parameters.AddWithValue("@PercToleranciaLimiteCredito", instance.PercToleranciaLimiteCredito);
		cmd.Parameters.AddWithValue("@QtdeDiasExibirAvisoVencAnvisa", instance.QtdeDiasExibirAvisoVencAnvisa);
		cmd.Parameters.AddWithValue("@QtdeDiasExibirAvisoVencAlvara", instance.QtdeDiasExibirAvisoVencAlvara);
		cmd.Parameters.AddWithValue("@BloquearPedVdaLimiteCredito", instance.BloquearPedVdaLimiteCredito);
		cmd.Parameters.AddWithValue("@BloquearPedVdaAnvisaVencido", instance.BloquearPedVdaAnvisaVencido);
		cmd.Parameters.AddWithValue("@BloquearPedVdaAlvaraVencido", instance.BloquearPedVdaAlvaraVencido);
		cmd.Parameters.AddWithValue("@QtdeDiasToleranciaInadimplencia", instance.QtdeDiasToleranciaInadimplencia);
		cmd.Parameters.AddWithValue("@PermitirLancarPedVdaClienteNovo", instance.PermitirLancarPedVdaClienteNovo);
		cmd.Parameters.AddWithValue("@ClienteNovoCodigoTabPre", instance.ClienteNovoCodigoTabPre);
		cmd.Parameters.AddWithValue("@ClienteNovoPrazoMedio", instance.ClienteNovoPrazoMedio);
		cmd.Parameters.AddWithValue("@ClienteNovoCodigoFormPgto", instance.ClienteNovoCodigoFormPgto);
		cmd.Parameters.AddWithValue("@ClienteNovoCodigoTpPed", instance.ClienteNovoCodigoTpPed);
		cmd.Parameters.AddWithValue("@BloquearFormPgtoBancoVendaEspecial", instance.BloquearFormPgtoBancoVendaEspecial);
		cmd.Parameters.AddWithValue("@CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial", instance.CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial);
		cmd.Parameters.AddWithValue("@PermitirAlterarFormPgtoPedVda", instance.PermitirAlterarFormPgtoPedVda);
		cmd.Parameters.AddWithValue("@LiberarTodasCondPgtoPedVda", instance.LiberarTodasCondPgtoPedVda);
		cmd.Parameters.AddWithValue("@BloquearPedVdaPorValorMinimo", instance.BloquearPedVdaPorValorMinimo);
		cmd.Parameters.AddWithValue("@UtilizaDescontoFlexPcfgTargetMob", instance.UtilizaDescontoFlexPcfgTargetMob);
		cmd.Parameters.AddWithValue("@PercDescMaxFlex", instance.PercDescMaxFlex);
		cmd.Parameters.AddWithValue("@PermitirDescontoGeral", instance.PermitirDescontoGeral);
		cmd.Parameters.AddWithValue("@PercMaxDescGeralPedVda", instance.PercMaxDescGeralPedVda);
		cmd.Parameters.AddWithValue("@UtilizaFormPgtoDepositoConta", instance.UtilizaFormPgtoDepositoConta);
		cmd.Parameters.AddWithValue("@BloquearPedVdaMargemMinima", instance.BloquearPedVdaMargemMinima);
		cmd.Parameters.AddWithValue("@ValorMinimoProposta", instance.ValorMinimoProposta);
		cmd.Parameters.AddWithValue("@QtdeDiasEstoqueInsuficiente", instance.QtdeDiasEstoqueInsuficiente);
		cmd.Parameters.AddWithValue("@ExibirEstoque", instance.ExibirEstoque);
		cmd.Parameters.AddWithValue("@BloquearVendaAcimaEstoque", instance.BloquearVendaAcimaEstoque);
		cmd.Parameters.AddWithValue("@UtilizaMotivoNaoVendaForaRoteiroDiaAnterior", instance.UtilizaMotivoNaoVendaForaRoteiroDiaAnterior);
		cmd.Parameters.AddWithValue("@BloquearVendaNormalItemEmPromocao", instance.BloquearVendaNormalItemEmPromocao);
		cmd.Parameters.AddWithValue("@ObrigarMotivoNaoVendaForaRoteiroDiaAnterior", instance.ObrigarMotivoNaoVendaForaRoteiroDiaAnterior);
		cmd.Parameters.AddWithValue("@BloqueiaAlteracaoAgendamentoVisitas", instance.BloqueiaAlteracaoAgendamentoVisitas);
		cmd.Parameters.AddWithValue("@HorarioInicioVisita", instance.HorarioInicioVisita);
		cmd.Parameters.AddWithValue("@HorarioFimVisita", instance.HorarioFimVisita);
		cmd.Parameters.AddWithValue("@LiberarCreditoVerbaPedidoNovo", instance.LiberarCreditoVerbaPedidoNovo);
		cmd.Parameters.AddWithValue("@BloquearPedVdaSaldoVerbaNegativo", instance.BloquearPedVdaSaldoVerbaNegativo);
		cmd.Parameters.AddWithValue("@PercMaxToleranciaVisitaForaRota", instance.PercMaxToleranciaVisitaForaRota);
		cmd.Parameters.AddWithValue("@ExibirVerbaFechamentoPedVda", instance.ExibirVerbaFechamentoPedVda);
		cmd.Parameters.AddWithValue("@ControlarOrdemVisitas", instance.ControlarOrdemVisitas);
		cmd.Parameters.AddWithValue("@PercIndenizacaoTroca", instance.PercIndenizacaoTroca);
		cmd.Parameters.AddWithValue("@ObrigarMotivoNaoVendaDiaAnterior", instance.ObrigarMotivoNaoVendaDiaAnterior);
		cmd.Parameters.AddWithValue("@ExibirSaldoVerba", instance.ExibirSaldoVerba);
		cmd.Parameters.AddWithValue("@TipoPedVdaHistoricoCliente", instance.TipoPedVdaHistoricoCliente);
		cmd.Parameters.AddWithValue("@QtdePedVdaHistoricoCliente", instance.QtdePedVdaHistoricoCliente);
		cmd.Parameters.AddWithValue("@TipoDescontoVerbaItemBonificado", instance.TipoDescontoVerbaItemBonificado);
		cmd.Parameters.AddWithValue("@PercMaxCreditoVerba", instance.PercMaxCreditoVerba);
		cmd.Parameters.AddWithValue("@UtilizaBonificacao", instance.UtilizaBonificacao);
		cmd.Parameters.AddWithValue("@UtilizaDescontoPromocionalAutomatico", instance.UtilizaDescontoPromocionalAutomatico);
		cmd.Parameters.AddWithValue("@QtdeDiasTitulosAVencer", instance.QtdeDiasTitulosAVencer);
		cmd.Parameters.AddWithValue("@ExibirTituloSomenteVendedor", instance.ExibirTituloSomenteVendedor);
		cmd.Parameters.AddWithValue("@DesmembraPedidoProdutoxEmpresa", instance.DesmembraPedidoProdutoxEmpresa);
		cmd.Parameters.AddWithValue("@DesmembraPedidoProdutoxGrupoProduto", instance.DesmembraPedidoProdutoxGrupoProduto);
		cmd.Parameters.AddWithValue("@RespeitaAssociacaoVendedorxTipoPedido", instance.RespeitaAssociacaoVendedorxTipoPedido);
		cmd.Parameters.AddWithValue("@RespeitaAssociacaoVendedorxProduto", instance.RespeitaAssociacaoVendedorxProduto);
		cmd.Parameters.AddWithValue("@RespeitaAssociacaoVendedorxTabelaPreco", instance.RespeitaAssociacaoVendedorxTabelaPreco);
		cmd.Parameters.AddWithValue("@EnviaSomenteUnidadesComOrdemImpressao", instance.EnviaSomenteUnidadesComOrdemImpressao);
		cmd.Parameters.AddWithValue("@RestrVendaSomenteVendedorPrioritario", instance.RestrVendaSomenteVendedorPrioritario);
		cmd.Parameters.AddWithValue("@TipoRestricaoVenda", instance.TipoRestricaoVenda);
		cmd.Parameters.AddWithValue("@TipoCusto", instance.TipoCusto);
		cmd.Parameters.AddWithValue("@TipoAbatimentoTroca", instance.TipoAbatimentoTroca);
		cmd.Parameters.AddWithValue("@NaoImportarAtualizacaoPlanoVisita", instance.NaoImportarAtualizacaoPlanoVisita);
		cmd.Parameters.AddWithValue("@LiberarPedidosAutomaticamente", instance.LiberarPedidosAutomaticamente);
		cmd.Parameters.AddWithValue("@UtilizaUnidadeVendaNaTroca", instance.UtilizaUnidadeVendaNaTroca);
		cmd.Parameters.AddWithValue("@PercDesconto", instance.PercDesconto);
		cmd.Parameters.AddWithValue("@UtilizaTroca", instance.UtilizaTroca);
		cmd.Parameters.AddWithValue("@UtilizaProposta", instance.UtilizaProposta);
		cmd.Parameters.AddWithValue("@PermiteAlterarPercIndenizacao", instance.PermiteAlterarPercIndenizacao);
		cmd.Parameters.AddWithValue("@ExibirSaldoComissao", instance.ExibirSaldoComissao);
		cmd.Parameters.AddWithValue("@QtdeMaxVisitasDia", instance.QtdeMaxVisitasDia);
		cmd.Parameters.AddWithValue("@LimiteMinimoVerbaVendedor", instance.LimiteMinimoVerbaVendedor);
		cmd.Parameters.AddWithValue("@BloquearVisitaAvulsa", instance.BloquearVisitaAvulsa);
		cmd.Parameters.AddWithValue("@SugereFiltroMixSegmentoPedVda", instance.SugereFiltroMixSegmentoPedVda);
		cmd.Parameters.AddWithValue("@JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento", instance.JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento);
		cmd.Parameters.AddWithValue("@ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto", instance.ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto);
		cmd.Parameters.AddWithValue("@NaoImportarInformacaoVisitaForaRota", instance.NaoImportarInformacaoVisitaForaRota);
		cmd.Parameters.AddWithValue("@AplicarPrazoMedioNaAssociacaoClienteCondPgto", instance.AplicarPrazoMedioNaAssociacaoClienteCondPgto);
		cmd.Parameters.AddWithValue("@UtilizaDescontoPromocionalAutomaticoPromFlex", instance.UtilizaDescontoPromocionalAutomaticoPromFlex);
		cmd.Parameters.AddWithValue("@IgnorarMotivoNaoVendaMixSegmento", instance.IgnorarMotivoNaoVendaMixSegmento);
		cmd.Parameters.AddWithValue("@ExibirProdutosNaoAssociadosCondPagto", instance.ExibirProdutosNaoAssociadosCondPagto);
		cmd.Parameters.AddWithValue("@OcultarProdutosSemEstoque", instance.OcultarProdutosSemEstoque);
		cmd.Parameters.AddWithValue("@ExibirCondPagtoDentroPrazoMedioEAssociadasCliente", instance.ExibirCondPagtoDentroPrazoMedioEAssociadasCliente);
		cmd.Parameters.AddWithValue("@BloquearAlterarTipoEntrega", instance.BloquearAlterarTipoEntrega);
		cmd.Parameters.AddWithValue("@PermiteAlterarDescontoPorQuantidade", instance.PermiteAlterarDescontoPorQuantidade);
		cmd.Parameters.AddWithValue("@SupervisorNaoReceberCargaEquipe", instance.SupervisorNaoReceberCargaEquipe);
		cmd.Parameters.AddWithValue("@TiposFiltrosItensPedidoFabricante", instance.TiposFiltrosItensPedidoFabricante);
		cmd.Parameters.AddWithValue("@TiposFiltrosItensPedidoCategoria", instance.TiposFiltrosItensPedidoCategoria);
		cmd.Parameters.AddWithValue("@TiposFiltrosItensPedidoLinha", instance.TiposFiltrosItensPedidoLinha);
		cmd.Parameters.AddWithValue("@TiposFiltrosItensPedidoDepto", instance.TiposFiltrosItensPedidoDepto);
		cmd.Parameters.AddWithValue("@TiposFiltrosItensPedidoSecao", instance.TiposFiltrosItensPedidoSecao);
		cmd.Parameters.AddWithValue("@NaoSincronizarAposLancamentoPedido", instance.NaoSincronizarAposLancamentoPedido);
		cmd.Parameters.AddWithValue("@CalcularVerbaItemKitProm", instance.CalcularVerbaItemKitProm);
		cmd.Parameters.AddWithValue("@ManterRegrasAlteracaoTabelaPrecoProposta", instance.ManterRegrasAlteracaoTabelaPrecoProposta);
		cmd.Parameters.AddWithValue("@PercMargemSegurancaGondola", instance.PercMargemSegurancaGondola);
		cmd.Parameters.AddWithValue("@RestricaoVendaLocalizacaoCliente", instance.RestricaoVendaLocalizacaoCliente);
		cmd.Parameters.AddWithValue("@UtilizaRecursoLocalizacao", instance.UtilizaRecursoLocalizacao);
		cmd.Parameters.AddWithValue("@ObrigarColetaLocalizacaoCliente", instance.ObrigarColetaLocalizacaoCliente);
		cmd.Parameters.AddWithValue("@SolicitarColetaLocalizacaoCliente", instance.SolicitarColetaLocalizacaoCliente);
		cmd.Parameters.AddWithValue("@ExibirValidadeMinimaProduto", instance.ExibirValidadeMinimaProduto);
		cmd.Parameters.AddWithValue("@ObrigarInformarGondola", instance.ObrigarInformarGondola);
		cmd.Parameters.AddWithValue("@PercMaxVendaSemApontamentoGondola", instance.PercMaxVendaSemApontamentoGondola);
		cmd.Parameters.AddWithValue("@ArredondarUnidCompraAlgoritmo", instance.ArredondarUnidCompraAlgoritmo);
		cmd.Parameters.AddWithValue("@EstoqueRespeitarTpPed", instance.EstoqueRespeitarTpPed);
		cmd.Parameters.AddWithValue("@PermitirCadastroEmailClienteLanctoPedido", instance.PermitirCadastroEmailClienteLanctoPedido);
		cmd.Parameters.AddWithValue("@ObrigarCadastroEmailClienteLanctoPedido", instance.ObrigarCadastroEmailClienteLanctoPedido);
		cmd.Parameters.AddWithValue("@UtilizarDescontoMaximoProduto", instance.UtilizarDescontoMaximoProduto);
		cmd.Parameters.AddWithValue("@ConsiderarDescontoGeral", instance.ConsiderarDescontoGeral);
		cmd.Parameters.AddWithValue("@QtdeMaxCotacaoPorVendedor", instance.QtdeMaxCotacaoPorVendedor);
		cmd.Parameters.AddWithValue("@ObrigarInformarCheckoutsCliente", instance.ObrigarInformarCheckoutsCliente);
		cmd.Parameters.AddWithValue("@AtualizarDescTrocaCondPgto", instance.AtualizarDescTrocaCondPgto);
		cmd.Parameters.AddWithValue("@QtdeDiasFrequenciaSemRoteiroVisita", instance.QtdeDiasFrequenciaSemRoteiroVisita);
		cmd.Parameters.AddWithValue("@TipoMargemSegurancaGondola", instance.TipoMargemSegurancaGondola);
		cmd.Parameters.AddWithValue("@QtdeMargemSegurancaGondola", instance.QtdeMargemSegurancaGondola);
		cmd.Parameters.AddWithValue("@UtilizarEmailComercial", instance.UtilizarEmailComercial);
		cmd.Parameters.AddWithValue("@LancarQtdeEstoqueZeroItensObrigatorios", instance.LancarQtdeEstoqueZeroItensObrigatorios);
		cmd.Parameters.AddWithValue("@EnviarPedidoAutomaticamenteAposLancamento", instance.EnviarPedidoAutomaticamenteAposLancamento);
		cmd.Parameters.AddWithValue("@UtilizarApontamentoGondola", instance.UtilizarApontamentoGondola);
		cmd.Parameters.AddWithValue("@ObrigatorioInformarEmailContatoComercial", instance.ObrigatorioInformarEmailContatoComercial);
		cmd.Parameters.AddWithValue("@PermiteEntregaOutroCliente", instance.PermiteEntregaOutroCliente);
		cmd.Parameters.AddWithValue("@ExibirStatusPositivacaoProdutos", instance.ExibirStatusPositivacaoProdutos);
		cmd.Parameters.AddWithValue("@ExibirPromFlexLancItem", instance.ExibirPromFlexLancItem);
		cmd.Parameters.AddWithValue("@ControlarHorarioAlmoco", instance.ControlarHorarioAlmoco);
		cmd.Parameters.AddWithValue("@TempoAlmoco", instance.TempoAlmoco);
		cmd.Parameters.AddWithValue("@TempoBloqueioAlmoco", instance.TempoBloqueioAlmoco);
		cmd.Parameters.AddWithValue("@HorarioIniciarAlmoco", instance.HorarioIniciarAlmoco);
		cmd.Parameters.AddWithValue("@RaioCliente", instance.RaioCliente);
		cmd.Parameters.AddWithValue("@PropostaPercMgBrutaMinima", instance.PropostaPercMgBrutaMinima);
		cmd.Parameters.AddWithValue("@ValidarVlPrecoMinimoPedido", instance.ValidarVlPrecoMinimoPedido);
		cmd.Parameters.AddWithValue("@ValidarVlPrecoMinimoProposta", instance.ValidarVlPrecoMinimoProposta);
		cmd.Parameters.AddWithValue("@ClassificacaoCurvaABCProduto", instance.ClassificacaoCurvaABCProduto);
		cmd.Parameters.AddWithValue("@BloqueiaTituloPorColigacao", instance.BloqueiaTituloPorColigacao);
		cmd.Parameters.AddWithValue("@BloqueiaTituloPorGrupo", instance.BloqueiaTituloPorGrupo);
		cmd.Parameters.AddWithValue("@InicioJornadaNoRoteiro", instance.InicioJornadaNoRoteiro);
		cmd.Parameters.AddWithValue("@FimJornadaNoRoteiro", instance.FimJornadaNoRoteiro);
		cmd.Parameters.AddWithValue("@ExibirMetaPositivFabric", instance.ExibirMetaPositivFabric);
		cmd.Parameters.AddWithValue("@InadimplenciaPrazoMedio", instance.InadimplenciaPrazoMedio);
		cmd.Parameters.AddWithValue("@UtilizaVisitaTelefonica", instance.UtilizaVisitaTelefonica);
		cmd.Parameters.AddWithValue("@PermiteIndicarMotivoNaoVendaComAcaoLigacao", instance.PermiteIndicarMotivoNaoVendaComAcaoLigacao);
		cmd.Parameters.AddWithValue("@DuracaoMinimaLigacaoVisita", instance.DuracaoMinimaLigacaoVisita);
		cmd.Parameters.AddWithValue("@UtilizaVendedorCliente", instance.UtilizaVendedorCliente);
		cmd.Parameters.AddWithValue("@UtilizaBonificacaoSomentePromocao", instance.UtilizaBonificacaoSomentePromocao);
		cmd.Parameters.AddWithValue("@UtilizaAnotacoes", instance.UtilizaAnotacoes);
		cmd.Parameters.AddWithValue("@QtdeMaxDiasExibirAnotacoes", instance.QtdeMaxDiasExibirAnotacoes);
		cmd.Parameters.AddWithValue("@EsconderAnotacoesTelaPedido", instance.EsconderAnotacoesTelaPedido);
		cmd.Parameters.AddWithValue("@ObrigarPreencherAnotacao", instance.ObrigarPreencherAnotacao);
		cmd.Parameters.AddWithValue("@TipoEnvioAnotacoes", instance.TipoEnvioAnotacoes);
		cmd.Parameters.AddWithValue("@ObrigarComoRealizouVenda", instance.ObrigarComoRealizouVenda);
		cmd.Parameters.AddWithValue("@ExibirTituloVencidoTodoVendedor", instance.ExibirTituloVencidoTodoVendedor);
		cmd.Parameters.AddWithValue("@ObrigarEnviarFotoClienteNovo", instance.ObrigarEnviarFotoClienteNovo);
		cmd.Parameters.AddWithValue("@ExibirNotaCredito", instance.ExibirNotaCredito);
		cmd.Parameters.AddWithValue("@UtilizaDescontoPorQtdeAutomatico", instance.UtilizaDescontoPorQtdeAutomatico);
		cmd.Parameters.AddWithValue("@UtilizaIndicacaoFaltaEstoquePromotor", instance.UtilizaIndicacaoFaltaEstoquePromotor);
		cmd.Parameters.AddWithValue("@QtdeMaxDiasExibirIndicacaoFaltaEstoquePromotor", instance.QtdeMaxDiasExibirIndicacaoFaltaEstoquePromotor);
		cmd.Parameters.AddWithValue("@ExibirPrecoMenorUnidadeListaItens", instance.ExibirPrecoMenorUnidadeListaItens);
		cmd.Parameters.AddWithValue("@ExibirLinhaDigitavelBoleto", instance.ExibirLinhaDigitavelBoleto);
		cmd.Parameters.AddWithValue("@SugerirFiltroMixCliente", instance.SugerirFiltroMixCliente);
		cmd.Parameters.AddWithValue("@ObrigarInformarEmailNFe", instance.ObrigarInformarEmailNFe);
		cmd.Parameters.AddWithValue("@ObrigarInformarEmailFinanceiro", instance.ObrigarInformarEmailFinanceiro);
		cmd.Parameters.AddWithValue("@ExibirAlertaProdutoComplementar", instance.ExibirAlertaProdutoComplementar);
		cmd.Parameters.AddWithValue("@ExibirAlertaProdutoSimilar", instance.ExibirAlertaProdutoSimilar);
		cmd.Parameters.AddWithValue("@RespeitarOrdemLancamentoItemPdfEmail", instance.RespeitarOrdemLancamentoItemPdfEmail);
		cmd.Parameters.AddWithValue("@EnviarObservacaoProdutoPdfEmail", instance.EnviarObservacaoProdutoPdfEmail);
		cmd.Parameters.AddWithValue("@UtilizarEmailCotacaoComImagem", instance.UtilizarEmailCotacaoComImagem);
		cmd.Parameters.AddWithValue("@ExibirHorarioRoteiroVisita", instance.ExibirHorarioRoteiroVisita);
		cmd.Parameters.AddWithValue("@BloquearPedVdaLimiteCreditoTerceiro", instance.BloquearPedVdaLimiteCreditoTerceiro);
		cmd.Parameters.AddWithValue("@PercToleranciaLimiteCreditoTerceiro", instance.PercToleranciaLimiteCreditoTerceiro);
		cmd.Parameters.AddWithValue("@ClienteCurvaABC", instance.ClienteCurvaABC);
		cmd.Parameters.AddWithValue("@ConsiderarDescontoMaximoPermitido", instance.ConsiderarDescontoMaximoPermitido);
		cmd.Parameters.AddWithValue("@SugerirFiltroProdutoReportadoEmFalta", instance.SugerirFiltroProdutoReportadoEmFalta);
		cmd.Parameters.AddWithValue("@BloquearPedVdaPeloValorMinimoGrupoProduto", instance.BloquearPedVdaPeloValorMinimoGrupoProduto);
		cmd.Parameters.AddWithValue("@ObrigarInformarDataPrevisaoEntrega", instance.ObrigarInformarDataPrevisaoEntrega);
		cmd.Parameters.AddWithValue("@ExibirValidadeProdutoPdfEmail", instance.ExibirValidadeProdutoPdfEmail);
		cmd.Parameters.AddWithValue("@ExibirPromocaoFlexLanctoItem", instance.ExibirPromocaoFlexLanctoItem);
		cmd.Parameters.AddWithValue("@ExibirPromocaoFixaLanctoItem", instance.ExibirPromocaoFixaLanctoItem);
		cmd.Parameters.AddWithValue("@PermitirVendaSomenteUnidCompra", instance.PermitirVendaSomenteUnidCompra);
	}

	public static void Insert(SqlTransaction transaction, ConfiguracaoVendedorTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorInsert", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		setParametros(sqlCommand, instance);
		sqlCommand.Parameters.Add(new SqlParameter("@RowId", SqlDbType.VarBinary, 0, ParameterDirection.Input, isNullable: false, 0, 0, "RowId", DataRowVersion.Current, instance.RowId));
		sqlCommand.ExecuteNonQuery();
	}

	public static void Update(SqlTransaction transaction, ConfiguracaoVendedorTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorUpdate", transaction.Connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		setParametros(sqlCommand, instance);
		sqlCommand.Parameters.Add(new SqlParameter("@RowId", SqlDbType.VarBinary, 0, ParameterDirection.Input, isNullable: false, 0, 0, "RowId", DataRowVersion.Current, instance.RowId));
		foreach (SqlParameter parameter in sqlCommand.Parameters)
		{
			if (parameter.Value == null)
			{
				parameter.Value = DBNull.Value;
			}
		}
		sqlCommand.ExecuteNonQuery();
	}

	public static List<ConfiguracaoVendedorTO> Select(SqlConnection connection, ConfiguracaoVendedorTO instance)
	{
		using SqlDataReader dr = SelectDR(connection, instance);
		return CreateInstance(dr);
	}

	private static SqlDataReader SelectDR(SqlConnection connection, ConfiguracaoVendedorTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorSelect", connection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		setParametros(sqlCommand, instance);
		sqlCommand.Parameters.AddWithValue("@RowId", instance.RowId);
		return sqlCommand.ExecuteReader();
	}

	public static bool Exists(SqlTransaction transacao, int? id)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspConfiguracaoVendedorExists", transacao.Connection, transacao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", id);
		return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
	}

	private static List<ConfiguracaoVendedorTO> CreateInstance(SqlDataReader dr)
	{
		List<ConfiguracaoVendedorTO> list = new List<ConfiguracaoVendedorTO>();
		while (dr.Read())
		{
			ConfiguracaoVendedorTO configuracaoVendedorTO = new ConfiguracaoVendedorTO();
			configuracaoVendedorTO.Id = GetDataReader.GetInt32(dr, "Id");
			configuracaoVendedorTO.DescricaoConfiguracaoVendedor = GetDataReader.GetString(dr, "DescricaoConfiguracaoVendedor");
			configuracaoVendedorTO.PermitirCadastrarNovoCliente = GetDataReader.GetNullableBoolean(dr, "PermitirCadastrarNovoCliente");
			configuracaoVendedorTO.TaxaJuros = GetDataReader.GetNullableDecimal(dr, "TaxaJuros");
			configuracaoVendedorTO.QtdeDiasCancelamentoCotacao = GetDataReader.GetNullableDecimal(dr, "QtdeDiasCancelamentoCotacao");
			configuracaoVendedorTO.UtilizaQtdeMaxPedVdaSemTransmissao = GetDataReader.GetNullableBoolean(dr, "UtilizaQtdeMaxPedVdaSemTransmissao");
			configuracaoVendedorTO.QtdeMaxPedVdaSemTransmissao = GetDataReader.GetNullableInt16(dr, "QtdeMaxPedVdaSemTransmissao");
			configuracaoVendedorTO.ObrigarInformarRamoAtivPedVda = GetDataReader.GetNullableBoolean(dr, "ObrigarInformarRamoAtivPedVda");
			configuracaoVendedorTO.CalcularSubstituicaoTributaria = GetDataReader.GetNullableBoolean(dr, "CalcularSubstituicaoTributaria");
			configuracaoVendedorTO.ExibeSinalizadorMargemPedVda = GetDataReader.GetNullableBoolean(dr, "ExibeSinalizadorMargemPedVda");
			configuracaoVendedorTO.ExibePercentualMargemPedVda = GetDataReader.GetNullableBoolean(dr, "ExibePercentualMargemPedVda");
			configuracaoVendedorTO.BloquearPedVdaSituacaoCredito = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaSituacaoCredito");
			configuracaoVendedorTO.PercToleranciaLimiteCredito = GetDataReader.GetNullableDecimal(dr, "PercToleranciaLimiteCredito");
			configuracaoVendedorTO.QtdeDiasExibirAvisoVencAnvisa = GetDataReader.GetNullableDecimal(dr, "QtdeDiasExibirAvisoVencAnvisa");
			configuracaoVendedorTO.QtdeDiasExibirAvisoVencAlvara = GetDataReader.GetNullableDecimal(dr, "QtdeDiasExibirAvisoVencAlvara");
			configuracaoVendedorTO.BloquearPedVdaLimiteCredito = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaLimiteCredito");
			configuracaoVendedorTO.BloquearPedVdaAnvisaVencido = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaAnvisaVencido");
			configuracaoVendedorTO.BloquearPedVdaAlvaraVencido = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaAlvaraVencido");
			configuracaoVendedorTO.QtdeDiasToleranciaInadimplencia = GetDataReader.GetNullableInt16(dr, "QtdeDiasToleranciaInadimplencia");
			configuracaoVendedorTO.PermitirLancarPedVdaClienteNovo = GetDataReader.GetNullableBoolean(dr, "PermitirLancarPedVdaClienteNovo");
			configuracaoVendedorTO.ClienteNovoCodigoTabPre = GetDataReader.GetString(dr, "ClienteNovoCodigoTabPre");
			configuracaoVendedorTO.ClienteNovoPrazoMedio = GetDataReader.GetNullableInt16(dr, "ClienteNovoPrazoMedio");
			configuracaoVendedorTO.ClienteNovoCodigoFormPgto = GetDataReader.GetString(dr, "ClienteNovoCodigoFormPgto");
			configuracaoVendedorTO.ClienteNovoCodigoTpPed = GetDataReader.GetString(dr, "ClienteNovoCodigoTpPed");
			configuracaoVendedorTO.BloquearFormPgtoBancoVendaEspecial = GetDataReader.GetNullableBoolean(dr, "BloquearFormPgtoBancoVendaEspecial");
			configuracaoVendedorTO.CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial = GetDataReader.GetString(dr, "CodigoFormPgtoSubstituirFormPgtoBancoVendaEspecial");
			configuracaoVendedorTO.PermitirAlterarFormPgtoPedVda = GetDataReader.GetNullableBoolean(dr, "PermitirAlterarFormPgtoPedVda");
			configuracaoVendedorTO.LiberarTodasCondPgtoPedVda = GetDataReader.GetNullableBoolean(dr, "LiberarTodasCondPgtoPedVda");
			configuracaoVendedorTO.BloquearPedVdaPorValorMinimo = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaPorValorMinimo");
			configuracaoVendedorTO.UtilizaDescontoFlexPcfgTargetMob = GetDataReader.GetNullableBoolean(dr, "UtilizaDescontoFlexPcfgTargetMob");
			configuracaoVendedorTO.PercDescMaxFlex = GetDataReader.GetNullableDecimal(dr, "PercDescMaxFlex");
			configuracaoVendedorTO.PermitirDescontoGeral = GetDataReader.GetNullableBoolean(dr, "PermitirDescontoGeral");
			configuracaoVendedorTO.PercMaxDescGeralPedVda = GetDataReader.GetNullableDecimal(dr, "PercMaxDescGeralPedVda");
			configuracaoVendedorTO.UtilizaFormPgtoDepositoConta = GetDataReader.GetNullableBoolean(dr, "UtilizaFormPgtoDepositoConta");
			configuracaoVendedorTO.BloquearPedVdaMargemMinima = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaMargemMinima");
			configuracaoVendedorTO.ValorMinimoProposta = GetDataReader.GetNullableDecimal(dr, "ValorMinimoProposta");
			configuracaoVendedorTO.QtdeDiasEstoqueInsuficiente = GetDataReader.GetNullableInt16(dr, "QtdeDiasEstoqueInsuficiente");
			configuracaoVendedorTO.ExibirEstoque = GetDataReader.GetNullableBoolean(dr, "ExibirEstoque");
			configuracaoVendedorTO.BloquearVendaAcimaEstoque = GetDataReader.GetNullableBoolean(dr, "BloquearVendaAcimaEstoque");
			configuracaoVendedorTO.UtilizaMotivoNaoVendaForaRoteiroDiaAnterior = GetDataReader.GetNullableBoolean(dr, "UtilizaMotivoNaoVendaForaRoteiroDiaAnterior");
			configuracaoVendedorTO.BloquearVendaNormalItemEmPromocao = GetDataReader.GetNullableBoolean(dr, "BloquearVendaNormalItemEmPromocao");
			configuracaoVendedorTO.ObrigarMotivoNaoVendaForaRoteiroDiaAnterior = GetDataReader.GetNullableBoolean(dr, "ObrigarMotivoNaoVendaForaRoteiroDiaAnterior");
			configuracaoVendedorTO.BloqueiaAlteracaoAgendamentoVisitas = GetDataReader.GetNullableBoolean(dr, "BloqueiaAlteracaoAgendamentoVisitas");
			configuracaoVendedorTO.HorarioInicioVisita = GetDataReader.GetNullableDateTime(dr, "HorarioInicioVisita");
			configuracaoVendedorTO.HorarioFimVisita = GetDataReader.GetNullableDateTime(dr, "HorarioFimVisita");
			configuracaoVendedorTO.LiberarCreditoVerbaPedidoNovo = GetDataReader.GetNullableBoolean(dr, "LiberarCreditoVerbaPedidoNovo");
			configuracaoVendedorTO.BloquearPedVdaSaldoVerbaNegativo = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaSaldoVerbaNegativo");
			configuracaoVendedorTO.PercMaxToleranciaVisitaForaRota = GetDataReader.GetNullableDecimal(dr, "PercMaxToleranciaVisitaForaRota");
			configuracaoVendedorTO.ExibirVerbaFechamentoPedVda = GetDataReader.GetNullableBoolean(dr, "ExibirVerbaFechamentoPedVda");
			configuracaoVendedorTO.ControlarOrdemVisitas = GetDataReader.GetNullableBoolean(dr, "ControlarOrdemVisitas");
			configuracaoVendedorTO.PercIndenizacaoTroca = GetDataReader.GetNullableDecimal(dr, "PercIndenizacaoTroca");
			configuracaoVendedorTO.ObrigarMotivoNaoVendaDiaAnterior = GetDataReader.GetNullableBoolean(dr, "ObrigarMotivoNaoVendaDiaAnterior");
			configuracaoVendedorTO.ExibirSaldoVerba = GetDataReader.GetNullableBoolean(dr, "ExibirSaldoVerba");
			configuracaoVendedorTO.TipoPedVdaHistoricoCliente = GetDataReader.GetString(dr, "TipoPedVdaHistoricoCliente");
			configuracaoVendedorTO.QtdePedVdaHistoricoCliente = GetDataReader.GetNullableDecimal(dr, "QtdePedVdaHistoricoCliente");
			configuracaoVendedorTO.TipoDescontoVerbaItemBonificado = GetDataReader.GetString(dr, "TipoDescontoVerbaItemBonificado");
			configuracaoVendedorTO.PercMaxCreditoVerba = GetDataReader.GetNullableDecimal(dr, "PercMaxCreditoVerba");
			configuracaoVendedorTO.UtilizaBonificacao = GetDataReader.GetNullableBoolean(dr, "UtilizaBonificacao");
			configuracaoVendedorTO.UtilizaDescontoPromocionalAutomatico = GetDataReader.GetNullableBoolean(dr, "UtilizaDescontoPromocionalAutomatico");
			configuracaoVendedorTO.QtdeDiasTitulosAVencer = GetDataReader.GetNullableDecimal(dr, "QtdeDiasTitulosAVencer");
			configuracaoVendedorTO.ExibirTituloSomenteVendedor = GetDataReader.GetNullableBoolean(dr, "ExibirTituloSomenteVendedor");
			configuracaoVendedorTO.DesmembraPedidoProdutoxEmpresa = GetDataReader.GetNullableBoolean(dr, "DesmembraPedidoProdutoxEmpresa");
			configuracaoVendedorTO.DesmembraPedidoProdutoxGrupoProduto = GetDataReader.GetNullableBoolean(dr, "DesmembraPedidoProdutoxGrupoProduto");
			configuracaoVendedorTO.RespeitaAssociacaoVendedorxTipoPedido = GetDataReader.GetNullableBoolean(dr, "RespeitaAssociacaoVendedorxTipoPedido");
			configuracaoVendedorTO.RespeitaAssociacaoVendedorxProduto = GetDataReader.GetNullableBoolean(dr, "RespeitaAssociacaoVendedorxProduto");
			configuracaoVendedorTO.RespeitaAssociacaoVendedorxTabelaPreco = GetDataReader.GetNullableBoolean(dr, "RespeitaAssociacaoVendedorxTabelaPreco");
			configuracaoVendedorTO.EnviaSomenteUnidadesComOrdemImpressao = GetDataReader.GetNullableBoolean(dr, "EnviaSomenteUnidadesComOrdemImpressao");
			configuracaoVendedorTO.RestrVendaSomenteVendedorPrioritario = GetDataReader.GetNullableBoolean(dr, "RestrVendaSomenteVendedorPrioritario");
			configuracaoVendedorTO.TipoRestricaoVenda = GetDataReader.GetString(dr, "TipoRestricaoVenda");
			configuracaoVendedorTO.TipoCusto = GetDataReader.GetString(dr, "TipoCusto");
			configuracaoVendedorTO.TipoAbatimentoTroca = GetDataReader.GetString(dr, "TipoAbatimentoTroca");
			configuracaoVendedorTO.NaoImportarAtualizacaoPlanoVisita = GetDataReader.GetNullableBoolean(dr, "NaoImportarAtualizacaoPlanoVisita");
			configuracaoVendedorTO.LiberarPedidosAutomaticamente = GetDataReader.GetNullableBoolean(dr, "LiberarPedidosAutomaticamente");
			configuracaoVendedorTO.UtilizaUnidadeVendaNaTroca = GetDataReader.GetNullableBoolean(dr, "UtilizaUnidadeVendaNaTroca");
			configuracaoVendedorTO.PercDesconto = GetDataReader.GetNullableDecimal(dr, "PercDesconto");
			configuracaoVendedorTO.UtilizaTroca = GetDataReader.GetNullableBoolean(dr, "UtilizaTroca");
			configuracaoVendedorTO.UtilizaProposta = GetDataReader.GetNullableBoolean(dr, "UtilizaProposta");
			configuracaoVendedorTO.PermiteAlterarPercIndenizacao = GetDataReader.GetNullableBoolean(dr, "PermiteAlterarPercIndenizacao");
			configuracaoVendedorTO.ExibirSaldoComissao = GetDataReader.GetNullableBoolean(dr, "ExibirSaldoComissao");
			configuracaoVendedorTO.QtdeMaxVisitasDia = GetDataReader.GetNullableInt32(dr, "QtdeMaxVisitasDia");
			configuracaoVendedorTO.LimiteMinimoVerbaVendedor = GetDataReader.GetNullableDecimal(dr, "LimiteMinimoVerbaVendedor");
			configuracaoVendedorTO.BloquearVisitaAvulsa = GetDataReader.GetNullableBoolean(dr, "BloquearVisitaAvulsa");
			configuracaoVendedorTO.SugereFiltroMixSegmentoPedVda = GetDataReader.GetNullableBoolean(dr, "SugereFiltroMixSegmentoPedVda");
			configuracaoVendedorTO.JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento = GetDataReader.GetNullableBoolean(dr, "JustificarNaoVendaMixSegmentoAntesDeLancarItensForaMixSegmento");
			configuracaoVendedorTO.ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto = GetDataReader.GetNullableBoolean(dr, "ObrigaJustificativaNaoVendaMixSegmentoProdutoAProduto");
			configuracaoVendedorTO.NaoImportarInformacaoVisitaForaRota = GetDataReader.GetNullableBoolean(dr, "NaoImportarInformacaoVisitaForaRota");
			configuracaoVendedorTO.AplicarPrazoMedioNaAssociacaoClienteCondPgto = GetDataReader.GetNullableBoolean(dr, "AplicarPrazoMedioNaAssociacaoClienteCondPgto");
			configuracaoVendedorTO.UtilizaDescontoPromocionalAutomaticoPromFlex = GetDataReader.GetNullableBoolean(dr, "UtilizaDescontoPromocionalAutomaticoPromFlex");
			configuracaoVendedorTO.IgnorarMotivoNaoVendaMixSegmento = GetDataReader.GetNullableBoolean(dr, "IgnorarMotivoNaoVendaMixSegmento");
			configuracaoVendedorTO.ExibirProdutosNaoAssociadosCondPagto = GetDataReader.GetNullableBoolean(dr, "ExibirProdutosNaoAssociadosCondPagto");
			configuracaoVendedorTO.OcultarProdutosSemEstoque = GetDataReader.GetNullableBoolean(dr, "OcultarProdutosSemEstoque");
			configuracaoVendedorTO.ExibirCondPagtoDentroPrazoMedioEAssociadasCliente = GetDataReader.GetNullableBoolean(dr, "ExibirCondPagtoDentroPrazoMedioEAssociadasCliente");
			configuracaoVendedorTO.BloquearAlterarTipoEntrega = GetDataReader.GetNullableBoolean(dr, "BloquearAlterarTipoEntrega");
			configuracaoVendedorTO.PermiteAlterarDescontoPorQuantidade = GetDataReader.GetNullableBoolean(dr, "PermiteAlterarDescontoPorQuantidade");
			configuracaoVendedorTO.SupervisorNaoReceberCargaEquipe = GetDataReader.GetNullableBoolean(dr, "SupervisorNaoReceberCargaEquipe");
			configuracaoVendedorTO.OcultarProdutosSemEstoque = GetDataReader.GetNullableBoolean(dr, "OcultarProdutosSemEstoque");
			configuracaoVendedorTO.SupervisorNaoReceberCargaEquipe = GetDataReader.GetNullableBoolean(dr, "SupervisorNaoReceberCargaEquipe");
			configuracaoVendedorTO.TiposFiltrosItensPedidoFabricante = GetDataReader.GetNullableBoolean(dr, "TiposFiltrosItensPedidoFabricante");
			configuracaoVendedorTO.TiposFiltrosItensPedidoCategoria = GetDataReader.GetNullableBoolean(dr, "TiposFiltrosItensPedidoCategoria");
			configuracaoVendedorTO.TiposFiltrosItensPedidoLinha = GetDataReader.GetNullableBoolean(dr, "TiposFiltrosItensPedidoLinha");
			configuracaoVendedorTO.TiposFiltrosItensPedidoDepto = GetDataReader.GetNullableBoolean(dr, "TiposFiltrosItensPedidoDepto");
			configuracaoVendedorTO.TiposFiltrosItensPedidoSecao = GetDataReader.GetNullableBoolean(dr, "TiposFiltrosItensPedidoSecao");
			configuracaoVendedorTO.NaoSincronizarAposLancamentoPedido = GetDataReader.GetNullableBoolean(dr, "NaoSincronizarAposLancamentoPedido");
			configuracaoVendedorTO.CalcularVerbaItemKitProm = GetDataReader.GetNullableBoolean(dr, "CalcularVerbaItemKitProm");
			configuracaoVendedorTO.ManterRegrasAlteracaoTabelaPrecoProposta = GetDataReader.GetNullableBoolean(dr, "ManterRegrasAlteracaoTabelaPrecoProposta");
			configuracaoVendedorTO.QtdeMargemSegurancaGondola = GetDataReader.GetNullableDecimal(dr, "QtdeMargemSegurancaGondola");
			configuracaoVendedorTO.RestricaoVendaLocalizacaoCliente = GetDataReader.GetNullableBoolean(dr, "RestricaoVendaLocalizacaoCliente");
			configuracaoVendedorTO.UtilizaRecursoLocalizacao = GetDataReader.GetNullableBoolean(dr, "UtilizaRecursoLocalizacao");
			configuracaoVendedorTO.ObrigarColetaLocalizacaoCliente = GetDataReader.GetNullableBoolean(dr, "ObrigarColetaLocalizacaoCliente");
			configuracaoVendedorTO.SolicitarColetaLocalizacaoCliente = GetDataReader.GetNullableBoolean(dr, "SolicitarColetaLocalizacaoCliente");
			configuracaoVendedorTO.ExibirValidadeMinimaProduto = GetDataReader.GetNullableBoolean(dr, "ExibirValidadeMinimaProduto");
			configuracaoVendedorTO.ObrigarInformarGondola = GetDataReader.GetNullableBoolean(dr, "ObrigarInformarGondola");
			configuracaoVendedorTO.PercMaxVendaSemApontamentoGondola = GetDataReader.GetNullableDecimal(dr, "PercMaxVendaSemApontamentoGondola");
			configuracaoVendedorTO.ArredondarUnidCompraAlgoritmo = GetDataReader.GetNullableBoolean(dr, "ArredondarUnidCompraAlgoritmo");
			configuracaoVendedorTO.EstoqueRespeitarTpPed = GetDataReader.GetNullableBoolean(dr, "EstoqueRespeitarTpPed");
			configuracaoVendedorTO.PermitirCadastroEmailClienteLanctoPedido = GetDataReader.GetNullableBoolean(dr, "PermitirCadastroEmailClienteLanctoPedido");
			configuracaoVendedorTO.ObrigarCadastroEmailClienteLanctoPedido = GetDataReader.GetNullableBoolean(dr, "ObrigarCadastroEmailClienteLanctoPedido");
			configuracaoVendedorTO.UtilizarDescontoMaximoProduto = GetDataReader.GetNullableBoolean(dr, "UtilizarDescontoMaximoProduto");
			configuracaoVendedorTO.ConsiderarDescontoGeral = GetDataReader.GetNullableBoolean(dr, "ConsiderarDescontoGeral");
			configuracaoVendedorTO.QtdeMaxCotacaoPorVendedor = GetDataReader.GetNullableInt16(dr, "QtdeMaxCotacaoPorVendedor");
			configuracaoVendedorTO.ObrigarInformarCheckoutsCliente = GetDataReader.GetNullableBoolean(dr, "ObrigarInformarCheckoutsCliente");
			configuracaoVendedorTO.AtualizarDescTrocaCondPgto = GetDataReader.GetNullableBoolean(dr, "AtualizarDescTrocaCondPgto");
			configuracaoVendedorTO.QtdeDiasFrequenciaSemRoteiroVisita = GetDataReader.GetNullableInt32(dr, "QtdeDiasFrequenciaSemRoteiroVisita");
			configuracaoVendedorTO.TipoMargemSegurancaGondola = GetDataReader.GetString(dr, "TipoMargemSegurancaGondola");
			configuracaoVendedorTO.UtilizarEmailComercial = GetDataReader.GetNullableBoolean(dr, "UtilizarEmailComercial");
			configuracaoVendedorTO.LancarQtdeEstoqueZeroItensObrigatorios = GetDataReader.GetNullableBoolean(dr, "LancarQtdeEstoqueZeroItensObrigatorios");
			configuracaoVendedorTO.EnviarPedidoAutomaticamenteAposLancamento = GetDataReader.GetNullableBoolean(dr, "EnviarPedidoAutomaticamenteAposLancamento");
			configuracaoVendedorTO.UtilizarApontamentoGondola = GetDataReader.GetNullableBoolean(dr, "UtilizarApontamentoGondola");
			configuracaoVendedorTO.ObrigatorioInformarEmailContatoComercial = GetDataReader.GetNullableBoolean(dr, "ObrigatorioInformarEmailContatoComercial");
			configuracaoVendedorTO.PermiteEntregaOutroCliente = GetDataReader.GetNullableBoolean(dr, "PermiteEntregaOutroCliente");
			configuracaoVendedorTO.ExibirStatusPositivacaoProdutos = GetDataReader.GetNullableBoolean(dr, "ExibirStatusPositivacaoProdutos");
			configuracaoVendedorTO.ExibirPromFlexLancItem = GetDataReader.GetNullableBoolean(dr, "ExibirPromFlexLancItem");
			configuracaoVendedorTO.ControlarHorarioAlmoco = GetDataReader.GetNullableBoolean(dr, "ControlarHorarioAlmoco");
			configuracaoVendedorTO.TempoAlmoco = GetDataReader.GetNullableInt32(dr, "TempoAlmoco");
			configuracaoVendedorTO.TempoBloqueioAlmoco = GetDataReader.GetNullableInt32(dr, "TempoBloqueioAlmoco");
			configuracaoVendedorTO.HorarioIniciarAlmoco = GetDataReader.GetNullableDateTime(dr, "HorarioIniciarAlmoco");
			configuracaoVendedorTO.RaioCliente = GetDataReader.GetNullableInt16(dr, "RaioCliente");
			configuracaoVendedorTO.ClassificacaoCurvaABCProduto = GetDataReader.GetString(dr, "ClassificacaoCurvaABCProduto");
			configuracaoVendedorTO.RowId = GetDataReader.GetByteArray(dr, "RowId");
			configuracaoVendedorTO.PropostaPercMgBrutaMinima = GetDataReader.GetNullableDecimal(dr, "PropostaPercMgBrutaMinima");
			configuracaoVendedorTO.BloqueiaTituloPorColigacao = GetDataReader.GetNullableBoolean(dr, "BloqueiaTituloPorColigacao");
			configuracaoVendedorTO.BloqueiaTituloPorGrupo = GetDataReader.GetNullableBoolean(dr, "BloqueiaTituloPorGrupo");
			configuracaoVendedorTO.InicioJornadaNoRoteiro = GetDataReader.GetNullableBoolean(dr, "InicioJornadaNoRoteiro");
			configuracaoVendedorTO.FimJornadaNoRoteiro = GetDataReader.GetNullableBoolean(dr, "FimJornadaNoRoteiro");
			configuracaoVendedorTO.ExibirMetaPositivFabric = GetDataReader.GetNullableBoolean(dr, "ExibirMetaPositivFabric");
			configuracaoVendedorTO.InadimplenciaPrazoMedio = GetDataReader.GetNullableInt32(dr, "InadimplenciaPrazoMedio");
			configuracaoVendedorTO.UtilizaVisitaTelefonica = GetDataReader.GetNullableBoolean(dr, "UtilizaVisitaTelefonica");
			configuracaoVendedorTO.PermiteIndicarMotivoNaoVendaComAcaoLigacao = GetDataReader.GetNullableBoolean(dr, "PermiteIndicarMotivoNaoVendaComAcaoLigacao");
			configuracaoVendedorTO.DuracaoMinimaLigacaoVisita = GetDataReader.GetNullableInt32(dr, "DuracaoMinimaLigacaoVisita");
			configuracaoVendedorTO.UtilizaVendedorCliente = GetDataReader.GetNullableBoolean(dr, "UtilizaVendedorCliente");
			configuracaoVendedorTO.UtilizaBonificacaoSomentePromocao = GetDataReader.GetNullableBoolean(dr, "UtilizaBonificacaoSomentePromocao");
			configuracaoVendedorTO.UtilizaDescontoPorQtdeAutomatico = GetDataReader.GetNullableBoolean(dr, "UtilizaDescontoPorQtdeAutomatico");
			configuracaoVendedorTO.UtilizaIndicacaoFaltaEstoquePromotor = GetDataReader.GetNullableBoolean(dr, "UtilizaIndicacaoFaltaEstoquePromotor");
			configuracaoVendedorTO.QtdeMaxDiasExibirIndicacaoFaltaEstoquePromotor = GetDataReader.GetNullableInt32(dr, "QtdeMaxDiasExibirIndicacaoFaltaEstoquePromotor");
			configuracaoVendedorTO.ExibirPrecoMenorUnidadeListaItens = GetDataReader.GetNullableBoolean(dr, "ExibirPrecoMenorUnidadeListaItens");
			configuracaoVendedorTO.ExibirLinhaDigitavelBoleto = GetDataReader.GetNullableBoolean(dr, "ExibirLinhaDigitavelBoleto");
			configuracaoVendedorTO.SugerirFiltroMixCliente = GetDataReader.GetNullableBoolean(dr, "SugerirFiltroMixCliente");
			configuracaoVendedorTO.ObrigarInformarEmailNFe = GetDataReader.GetNullableBoolean(dr, "ObrigarInformarEmailNFe");
			configuracaoVendedorTO.ObrigarInformarEmailFinanceiro = GetDataReader.GetNullableBoolean(dr, "ObrigarInformarEmailFinanceiro");
			configuracaoVendedorTO.ExibirAlertaProdutoComplementar = GetDataReader.GetNullableBoolean(dr, "ExibirAlertaProdutoComplementar");
			configuracaoVendedorTO.ExibirAlertaProdutoSimilar = GetDataReader.GetNullableBoolean(dr, "ExibirAlertaProdutoSimilar");
			configuracaoVendedorTO.RespeitarOrdemLancamentoItemPdfEmail = GetDataReader.GetNullableBoolean(dr, "RespeitarOrdemLancamentoItemPdfEmail");
			configuracaoVendedorTO.EnviarObservacaoProdutoPdfEmail = GetDataReader.GetNullableBoolean(dr, "EnviarObservacaoProdutoPdfEmail");
			configuracaoVendedorTO.UtilizarEmailCotacaoComImagem = GetDataReader.GetNullableBoolean(dr, "UtilizarEmailCotacaoComImagem");
			configuracaoVendedorTO.ExibirHorarioRoteiroVisita = GetDataReader.GetNullableBoolean(dr, "ExibirHorarioRoteiroVisita");
			configuracaoVendedorTO.BloquearPedVdaLimiteCreditoTerceiro = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaLimiteCreditoTerceiro");
			configuracaoVendedorTO.PercToleranciaLimiteCreditoTerceiro = GetDataReader.GetNullableDecimal(dr, "PercToleranciaLimiteCreditoTerceiro");
			configuracaoVendedorTO.ClienteCurvaABC = GetDataReader.GetString(dr, "ClienteCurvaABC");
			configuracaoVendedorTO.ConsiderarDescontoMaximoPermitido = GetDataReader.GetNullableBoolean(dr, "ConsiderarDescontoMaximoPermitido");
			configuracaoVendedorTO.SugerirFiltroProdutoReportadoEmFalta = GetDataReader.GetNullableBoolean(dr, "SugerirFiltroProdutoReportadoEmFalta");
			configuracaoVendedorTO.BloquearPedVdaPeloValorMinimoGrupoProduto = GetDataReader.GetNullableBoolean(dr, "BloquearPedVdaPeloValorMinimoGrupoProduto");
			configuracaoVendedorTO.ObrigarInformarDataPrevisaoEntrega = GetDataReader.GetNullableBoolean(dr, "ObrigarInformarDataPrevisaoEntrega");
			configuracaoVendedorTO.ExibirValidadeProdutoPdfEmail = GetDataReader.GetNullableBoolean(dr, "ExibirValidadeProdutoPdfEmail");
			configuracaoVendedorTO.ExibirPromocaoFlexLanctoItem = GetDataReader.GetNullableBoolean(dr, "ExibirPromocaoFlexLanctoItem");
			configuracaoVendedorTO.ExibirPromocaoFixaLanctoItem = GetDataReader.GetNullableBoolean(dr, "ExibirPromocaoFixaLanctoItem");
			configuracaoVendedorTO.PermitirVendaSomenteUnidCompra = GetDataReader.GetNullableBoolean(dr, "PermitirVendaSomenteUnidCompra");
			list.Add(configuracaoVendedorTO);
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	public static byte[] selectMaxRowId(DbConnection connection)
	{
		byte[] result = null;
		connection.ClearParameters();
		BasicRS basicRS = connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspConfiguracaoVendedorMaxRowId");
		if (basicRS.MoveNext() && !basicRS.IsDBNull("RowId"))
		{
			result = basicRS.GetArrayByte("RowId");
		}
		basicRS.CloseRS();
		return result;
	}
}
