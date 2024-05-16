using System;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Log;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.Factory;
using Target.Venda.IBusiness.IFluxo;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Fluxo;

public class LiberarPedidoEletronicoBLL : FluxoBaseBLL, ILiberarPedidoEletronicoBLL, IFluxoBaseBLL
{
	private ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle;

	private static object _lock = new object();

	private IModuloEstoqueBLL iEstoqueBLL;

	private IModuloPrecoBLL iPrecoBLL;

	private IModuloLogisticaBLL iLogisticaBLL;

	private IModuloComercialBLL iComercialBLL;

	private IModuloFiscalBLL iFiscalBLL;

	private IModuloFinanceiroBLL iFinanceiroBLL;

	private IModuloSistemaBLL iSistemaBLL;

	private IModuloVendaBLL iVendaBLL;

	private IModuloClienteBLL iClienteBLL;

	private IModuloProdutoBLL iProdutoBLL;

	private IModuloVendedorBLL iVendedorBLL;

	private IModuloContabilBLL iContabilBLL;

	private void InicializarFluxo(ParametrosLiberarPedidoEletronicoVO paramLiberarPedidoEle)
	{
		parametroLiberarPedidoEle = paramLiberarPedidoEle;
		iEstoqueBLL = BusinessFactory.GetEstoqueBLL();
		iEstoqueBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iPrecoBLL = BusinessFactory.GetPrecoBLL();
		iPrecoBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iLogisticaBLL = BusinessFactory.GetLogisticaBLL();
		iLogisticaBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iComercialBLL = BusinessFactory.GetComercialBLL();
		iComercialBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iFiscalBLL = BusinessFactory.GetFiscalBLL();
		iFiscalBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iFinanceiroBLL = BusinessFactory.GetFinanceiroBLL();
		iFinanceiroBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iSistemaBLL = BusinessFactory.GetSistemaBLL();
		iSistemaBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iVendaBLL = BusinessFactory.GetVendaBLL();
		iVendaBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iClienteBLL = BusinessFactory.GetClienteBLL();
		iClienteBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iProdutoBLL = BusinessFactory.GetProdutoBLL();
		iProdutoBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iVendedorBLL = BusinessFactory.GetVendedorBLL();
		iVendedorBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
		iContabilBLL = BusinessFactory.GetContabilBLL();
		iContabilBLL.EventRetornoMensagem += base.RetornaMensagemAviso;
	}

	public RetornoLiberarPedidoEletronicoVO Executar(ParametrosLiberarPedidoEletronicoVO objetoParametroLiberarPedidoEle)
	{
		RetornoLiberarPedidoEletronicoVO retornoLiberacaoPedido = new RetornoLiberarPedidoEletronicoVO();
		PedidoVendaMO pedidoVenda = null;
		retornoLiberacaoPedido.PARAMETRO_LIBERACAO = objetoParametroLiberarPedidoEle;
		try
		{
			string observacao = $"PED ELE: {objetoParametroLiberarPedidoEle.CODIGO_EMPRESA_ELETRONICO} - {objetoParametroLiberarPedidoEle.NUMERO_PEDIDO_ELETRONICO}";
			int codigoLogDesempenho = LogDesempenhoERP.Iniciar(observacao);
			RetornaMensagemAviso("Iniciando Fluxo: Liberar Pedido Eletronico");
			InicializarFluxo(objetoParametroLiberarPedidoEle);
			RetornaMensagemAviso("Validar Parâmetro de Liberar Pedido");
			iVendaBLL.ValidarParametroLiberarPedido(objetoParametroLiberarPedidoEle);
			RetornaMensagemAviso("Criar do Sessao Usuario");
			iSistemaBLL.CriarSessaoUsuario(objetoParametroLiberarPedidoEle.CODIGO_USUARIO, objetoParametroLiberarPedidoEle.CODIGO_EMPRESA_ELETRONICO, objetoParametroLiberarPedidoEle.NOME_PROGRAMA);
			RetornaMensagemAviso("Carregar Pedido Eletronico");
			PedidoEletronicoMO pedidoEletronico = iVendaBLL.CarregarPedidoEletronico(objetoParametroLiberarPedidoEle);
			RetornaMensagemAviso("Montando o Pedido de Venda");
			pedidoVenda = iVendaBLL.MontarPedidoVendaPeloPedidoEletronico(pedidoEletronico);
			RetornaMensagemAviso("Busca do VsControl 746221");
			VsControlBLL vsControlBLL = new VsControlBLL();
			bool VsControl746221 = vsControlBLL.ObterVsControl(746221, 1);
			RetornaMensagemAviso("Validar Cadastros Pedido Venda ");
			iVendaBLL.ValidarMontagemPedidoVenda(pedidoVenda);
			iVendaBLL.ValidarTipoPedido(pedidoVenda);
			iLogisticaBLL.ValidarEnderecoPedidoVenda(pedidoVenda);
			iContabilBLL.ValidarParametrosMargemBruta();
			iClienteBLL.ValidarCliente(pedidoVenda);
			iVendedorBLL.ValidarVendedor(pedidoVenda);
			iFinanceiroBLL.ValidarCondicaoPagamento(pedidoVenda);
			iFinanceiroBLL.ValidarFormaPagamento(pedidoVenda);
			iVendaBLL.ValidarItensPedidoEletronico(pedidoVenda);
			RetornaMensagemAviso("Carregar Mensagem de Expedição");
			iLogisticaBLL.CarregarMensagemExpedicao(pedidoVenda);
			RetornaMensagemAviso("Carrega a Troca do Pedido");
			iComercialBLL.CarregarTrocaPedido(pedidoVenda);
			RetornaMensagemAviso("Carrega a Transportadora do Pedido");
			iLogisticaBLL.CarregarTransportadoraPedido(pedidoVenda);
			RetornaMensagemAviso("Deletar ItPedvCampanha");
			iComercialBLL.DeletarCampanha(pedidoEletronico);
			RetornaMensagemAviso("Carregar Campanha");
			iComercialBLL.CarregarCampanha(pedidoEletronico, pedidoVenda);
			RetornaMensagemAviso("Realiza o Corte automático dos Itens do Pedido Eletrônico");
			iVendaBLL.CortarItensPedidoEletronico(pedidoVenda);
			RetornaMensagemAviso("Carrega os Itens do Pedido");
			iVendaBLL.CarregarItensPedido(pedidoVenda);
			RetornaMensagemAviso("Garante que o desconto aplicado e desconto 01 estejam consistentes");
			iVendaBLL.GaranteConsistenciaItensDesconto(pedidoVenda);
			RetornaMensagemAviso("Valida Dados do Produto");
			iProdutoBLL.ValidarDadosProduto(pedidoVenda);
			RetornaMensagemAviso("Carrega CFOP do Pedido");
			iFiscalBLL.CarregarCFOPdoPedido(pedidoVenda);
			RetornaMensagemAviso("Validar CFOP do Pedido");
			iFiscalBLL.ValidarCFOPdoPedido(pedidoVenda);
			RetornaMensagemAviso("Carrega as Faltas de Produtos");
			iEstoqueBLL.CarregarFaltasProdutos(pedidoVenda);
			RetornaMensagemAviso("Verifica Intermediador do Pedido");
			iVendaBLL.VerificaIntermediador(pedidoVenda, pedidoEletronico);
			RetornaMensagemAviso("Validar Desconto Geral");
			iPrecoBLL.ValidarDescontoGeral(pedidoVenda);
			RetornaMensagemAviso("Validar Transportadora");
			iLogisticaBLL.ValidarTransportadora(pedidoVenda);
			RetornaMensagemAviso("Validar KitPromocao");
			iPrecoBLL.ValidarKitPromocao(pedidoVenda);
			RetornaMensagemAviso("Percorre os Itens do Pedido (Inicio do Loop)");
			foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
			{
				RetornaMensagemAviso("PRODUTO: " + iTEN.CODIGO_PRODUTO + " - " + iTEN.DESCRICAO);
				RetornaMensagemAviso("Carregar Ação Comercial");
				iComercialBLL.CarregarAcaoComercial(iTEN, pedidoVenda);
				RetornaMensagemAviso("Tratar a Unidade do Produto");
				iEstoqueBLL.TratarUnidadeProduto(iTEN, pedidoVenda);
				RetornaMensagemAviso("Carregar o desconto da Campanha");
				iPrecoBLL.CarregarDescontoCampanha(iTEN, pedidoEletronico, pedidoVenda);
				RetornaMensagemAviso("Carregar o desconto Promocional");
				iPrecoBLL.CarregarDescontoCondicaoPagamento(iTEN, pedidoVenda);
				RetornaMensagemAviso("Carregar o desconto por Quantidade");
				iPrecoBLL.CarregarDescontoPorQuantidade(iTEN, pedidoVenda);
				RetornaMensagemAviso("Calcular Desconto Permitido");
				iPrecoBLL.CalcularDescontoPermitido(iTEN, pedidoVenda);
				RetornaMensagemAviso("Calcular o Preço de Venda");
				iPrecoBLL.CalcularPrecoVenda(iTEN, pedidoVenda);
				RetornaMensagemAviso("Calcular o Total do Item");
				iPrecoBLL.CalcularTotalItemPedido(iTEN, pedidoVenda);
				RetornaMensagemAviso(string.Empty);
			}
			GC.Collect();
			RetornaMensagemAviso("Percorre os Itens do Pedido (Fim do Loop)");
			RetornaMensagemAviso("Tratar Volume Itens");
			iLogisticaBLL.CarregarVolumesItensPedido(pedidoVenda);
			RetornaMensagemAviso("Verificar Pedido sem Itens");
			iVendaBLL.VerificarPedidoSemItens(pedidoVenda);
			RetornaMensagemAviso("Tratar Peso Itens Pedido");
			iLogisticaBLL.CalcularPesoTotalPedido(pedidoVenda);
			iLogisticaBLL.CalcularFrete(pedidoVenda, pedidoEletronico);
			RetornaMensagemAviso("Calcula o Total do Pedido");
			iPrecoBLL.CalcularTotaisPedido(pedidoVenda, pedidoEletronico);
			RetornaMensagemAviso("Calcula o Desconto Financeiro");
			iFinanceiroBLL.CalcularDescontoFinanceiro(pedidoVenda);
			RetornaMensagemAviso("Rateio de Desconto Geral");
			iPrecoBLL.RatearDescontoGeral(pedidoVenda);
			RetornaMensagemAviso("Calculo e Rateio de juros do cartao credito");
			iPrecoBLL.CalcularJurosRateioCartaoCredito(pedidoVenda);
			RetornaMensagemAviso("Gerar Parcelas Pedido");
			iFinanceiroBLL.GerarParcelasPedido(pedidoVenda);
			RetornaMensagemAviso("Calcular Verba Pedido");
			iComercialBLL.CalcularVerbaPedido(pedidoVenda);
			RetornaMensagemAviso("Calcular Custo Venda AV");
			iPrecoBLL.CalcularCustoVenda(pedidoVenda);
			iPrecoBLL.ValidarDescontoMaximoPermitidoItens(pedidoVenda);
			iEstoqueBLL.ValidarPapelCortado(pedidoVenda);
			iEstoqueBLL.ValidarQuantidadeItensPedido(pedidoVenda);
			iComercialBLL.ValidarTroca(pedidoVenda);
			iFiscalBLL.ValidarLiberacaoFiscal(pedidoVenda);
			iPrecoBLL.ValidarDesconto(pedidoVenda);
			iEstoqueBLL.ValidarUnidade(pedidoVenda);
			iPrecoBLL.ValidarPreco(pedidoVenda);
			iClienteBLL.ValidarLimiteDeVendaPFxPJ(pedidoVenda);
			iVendaBLL.ValidarLimiteDeVendasPFxPJ(pedidoVenda);
			RetornaMensagemAviso("Carrega os Locais de Estoque dos Itens do Pedido");
			iEstoqueBLL.GerarItensLocaisEstoquePedido(pedidoVenda);
			if (pedidoVenda.TIPO_PEDIDO.ESCOLHA_LOTE_AUTOMATICO && VsControl746221)
			{
				RetornaMensagemAviso("Valida estoque para pedidos com escolha de lote automático");
				iEstoqueBLL.ValidarQuantidadeLoteAutomatico(pedidoVenda, pedidoEletronico);
			}
			RetornaMensagemAviso("Registra Reserva Estoque");
			iEstoqueBLL.RegistrarReservaEstoque(pedidoVenda);
			RetornaMensagemAviso("Carregas Data Pedido");
			iVendaBLL.CarregarDataPedido(pedidoVenda);
			RetornaMensagemAviso("Atualiza Prazo Médio Pedido");
			iFinanceiroBLL.AtualizaPrazoMedioPedido(pedidoVenda);
			RetornaMensagemAviso("Tratar a Maior Unidade Variável do Produto");
			iEstoqueBLL.TratarMaiorUnidadeVariavelProduto(pedidoVenda);
			RetornaMensagemAviso("Calcular Comissão do Vendedor");
			iVendedorBLL.CalcularComissaoVendedor(pedidoVenda);
			RetornaMensagemAviso("Tratar a Quantidade de Itens");
			iEstoqueBLL.TratarQuantidadeItemPedido(pedidoVenda);
			RetornaMensagemAviso("Calcular o total de volumes do Pedido");
			iLogisticaBLL.CalcularVolumeTotalPedido(pedidoVenda);
			RetornaMensagemAviso("Tratar ICMS Diferido");
			iFiscalBLL.TratarICMSDiferido(pedidoVenda);
			RetornaMensagemAviso("Tratar Itens Bonificados");
			iPrecoBLL.TratarItensBonificados(pedidoVenda);
			RetornaMensagemAviso("Validar Geração de Número do Pedido Sem Lock");
			bool gerarNumeroPedidoSemLock = iVendaBLL.ValidarUtilizaNumeroPedidoSemLock();
			if (gerarNumeroPedidoSemLock)
			{
				RetornaMensagemAviso("Gerar Número do Pedido Sem Lock");
				iVendaBLL.GerarNumeroPedido(pedidoVenda, gerarNumeroPedidoSemLock);
			}
			RetornaMensagemAviso("Abre a Transação");
			TransactionManager.ExecutarComTransacao(delegate
			{
				try
				{
					lock (_lock)
					{
						if (!gerarNumeroPedidoSemLock)
						{
							RetornaMensagemAviso("Gerar Número do Pedido");
							iVendaBLL.GerarNumeroPedido(pedidoVenda, gerarNumeroPedidoSemLock);
						}
						if (ConfigERP.PAR_CFG.SIGLA_CLIENTE == "LAB")
						{
							RetornaMensagemAviso("Tratamento L.A. Bebidas duplicate key");
							iVendaBLL.TratamentoLABebidasOC809337(pedidoVenda);
						}
						RetornaMensagemAviso("Valida e Atualiza o Pedido Eletrônico Aberto");
						iVendaBLL.AtualizarPedidoEletronico(pedidoVenda);
						RetornaMensagemAviso("Atualiza ItPedvCampanha");
						iComercialBLL.AtualizaItPedvCampanha(pedidoEletronico, pedidoVenda);
						RetornaMensagemAviso("Carregar a Sigla de Separação");
						iLogisticaBLL.GerarSiglaSeparacao(pedidoVenda);
						RetornaMensagemAviso("Gerar Evento de Cadastro do Pedido");
						iVendaBLL.GerarEventoCadastroPedido(pedidoVenda);
						RetornaMensagemAviso("Salvar dados de Papel Cortado");
						iVendaBLL.SalvarProdutosPapelCortado(pedidoVenda);
						RetornaMensagemAviso("Calular Verba Fabricante nos Itens do Pedido");
						iComercialBLL.CalcularVerbaFabricanteItensPedido(pedidoVenda);
						RetornaMensagemAviso("Tratando arredondamento de Preço nos Itens do Pedido");
						iPrecoBLL.TratarArredondamentoPrecoBasico(pedidoVenda);
						RetornaMensagemAviso("Salvar o Pedido de Venda (Pedido/Eventos/Itens/Parcelas/Itens Locais)");
						iVendaBLL.SalvarPedidoVenda(pedidoVenda);
						RetornaMensagemAviso("Limpar ItPedvCampanha Gerado");
						iComercialBLL.DeletarCampanha(pedidoEletronico);
						if (pedidoVenda.TIPO_PEDIDO.ESCOLHA_LOTE_AUTOMATICO && VsControl746221)
						{
							RetornaMensagemAviso("Realiza reserva de lote automática");
							iEstoqueBLL.GerarItPedvLogReservarLote(pedidoVenda, VsControl746221);
						}
						RetornaMensagemAviso("Atualizar o Endereço do Cliente");
						iClienteBLL.AtualizarTransportadoraCliente(pedidoVenda);
						RetornaMensagemAviso("Gerar a Consulta de Produtos");
						iProdutoBLL.GerarConsultaProduto(pedidoVenda);
						RetornaMensagemAviso("Efetivar as Verbas do Pedido (Fabricante/Vendedor/Equipe/Empresa)");
						iComercialBLL.EfetivarVerbaPedido(pedidoVenda);
						RetornaMensagemAviso("Atualiza Ação Comercial do Fabricante");
						iComercialBLL.AtualizarAcaoComercialFabricante(pedidoVenda);
						RetornaMensagemAviso("Atualizar Condição Comercial do Cliente");
						iClienteBLL.AtualizarCondicaoComercialDoCliente(pedidoVenda);
						RetornaMensagemAviso("Verificar Valor Minimo Pedido");
						bool flag = iFinanceiroBLL.PedidoAtingiuValorMinimo(pedidoVenda, objetoParametroLiberarPedidoEle);
						if (pedidoEletronico.SEM_ESTOQUE.ToBool())
						{
							RetornaMensagemAviso("Cancelando Pedido");
							iVendaBLL.CancelarPedido(pedidoVenda);
							pedidoEletronico.SITUACAO = "CA";
							retornoLiberacaoPedido.RESULTADO_PROCESSO = ResultadoProcessoEnum.SUCESSO;
							retornoLiberacaoPedido.PEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
						}
						if (flag)
						{
							RetornaMensagemAviso("Pedido não atingiu o Valor Mínimo.");
							RetornaMensagemAviso("Atualiza horário reserva de estoque");
							iEstoqueBLL.AtualizarHorarioReservaEstoque();
							RetornaMensagemAviso("Cancela as Verbas do Pedido (Fabricante/Vendedor/Equipe/Empresa)");
							iComercialBLL.CancelarVerbaPedido(pedidoVenda);
							RetornaMensagemAviso("Cancelando Pedido");
							iVendaBLL.CancelarPedido(pedidoVenda);
							pedidoEletronico.SITUACAO = "CA";
							retornoLiberacaoPedido.RESULTADO_PROCESSO = ResultadoProcessoEnum.SUCESSO;
							retornoLiberacaoPedido.PEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
						}
						else
						{
							RetornaMensagemAviso("Associar a Trocas ao Pedido");
							iComercialBLL.AssociarTrocaPedido(pedidoVenda);
							RetornaMensagemAviso("Efetiva a Reserva de Estoque");
							iEstoqueBLL.EfetivarReservaEstoque(pedidoVenda);
							RetornaMensagemAviso("Liberar Pedido no ERP");
							iVendaBLL.LiberarPedidoERP(pedidoVenda);
							RetornaMensagemAviso("Encerra a Transação - Commit");
							retornoLiberacaoPedido.PEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
							retornoLiberacaoPedido.PEDIDO_VENDA = pedidoVenda;
							retornoLiberacaoPedido.RESULTADO_PROCESSO = ResultadoProcessoEnum.SUCESSO;
						}
					}
				}
				catch (Exception)
				{
					RetornaMensagemAviso("Encerra a Transação - RollBack");
					throw;
				}
			});
			LogDesempenhoERP.Encerrar(codigoLogDesempenho);
		}
		catch (MyException ex)
		{
			retornoLiberacaoPedido.RESULTADO_PROCESSO = ResultadoProcessoEnum.INVALIDO;
			retornoLiberacaoPedido.MENSAGEM_VALIDACAO = ex.Message;
			RetornaMensagemAviso(ex.Message);
		}
		catch (Exception ex2)
		{
			retornoLiberacaoPedido.RESULTADO_PROCESSO = ResultadoProcessoEnum.FALHOU;
			LogHelper.ErroLog(ex2);
			RetornaMensagemAviso(ex2.Message);
		}
		finally
		{
			retornoLiberacaoPedido.LOG_PROCESSO = LogEventosProcesso.ToString();
			LogHelper.AvisoLog(retornoLiberacaoPedido.LOG_PROCESSO);
			iSistemaBLL.EncerrarSessaoUsuario();
			GC.Collect();
		}
		return retornoLiberacaoPedido;
	}
}
