using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Entidade;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.IBusiness.Base;
using Target.Venda.IBusiness.IModulo;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Parametro;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Modulo;

public class ModuloVendaBLL : ModuloBaseBLL, IModuloVendaBLL, IModuloBaseBLL
{
	public PedidoEletronicoMO CarregarPedidoEletronico(ParametrosLiberarPedidoEletronicoVO liberarPedidoEle)
	{
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		PedidoEletronicoMO pedidoEletronicoMO = pedidoEletronicoBLL.ObterPedidoEletronicoParaPedidoVenda(liberarPedidoEle.CODIGO_EMPRESA_ELETRONICO, liberarPedidoEle.NUMERO_PEDIDO_ELETRONICO, liberarPedidoEle.NUMERO_SEQ_PEDIDO);
		if (pedidoEletronicoMO.CODICO_INT_PEDIDO_ELETRONICO == "TARGET PED_ELE")
		{
			pedidoEletronicoMO.PEDIDO_DIRETO = BoolEnum.True;
		}
		if (pedidoEletronicoMO.PEDIDO_DIRETO.ToBool())
		{
			ConfigERP.PARAMETROS_TELA.VENDA.CORTE_AUTO_INSUF_ESTOQUE_NAO_LIBERA_PEDIDO = false;
		}
		pedidoEletronicoMO.PEDIDO_ELETRONICO_LIBERA_AUTO = true;
		return pedidoEletronicoMO;
	}

	public PedidoVendaMO MontarPedidoVendaPeloPedidoEletronico(PedidoEletronicoMO pedidoEletronico)
	{
		RetornaMensagemAviso("Montando o Pedido de Venda - MontarPedidoVendaPeloPedidoEletronico...");
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		PedidoVendaMO pedidoVendaMO = pedidoEletronicoBLL.MontarPedidoVendaPeloPedidoEletronico(pedidoEletronico);
		RetornaMensagemAviso("Carregando empresa pelo ID...");
		EmpresaBLL empresaBLL = new EmpresaBLL();
		pedidoVendaMO.EMPRESA = empresaBLL.ObterPeloID(pedidoEletronico.CODIGO_EMPRESA_ELETRONICO);
		RetornaMensagemAviso("ObterClienteParaPedidoVenda...");
		ClienteBLL clienteBLL = new ClienteBLL();
		pedidoVendaMO.CLIENTE = clienteBLL.ObterClienteParaPedidoVenda(pedidoVendaMO.CODIGO_CLIENTE);
		RetornaMensagemAviso("VerificarSePrimeiraCompra...");
		pedidoVendaMO.CLIENTE_NOVO = clienteBLL.VerificarSePrimeiraCompra(pedidoVendaMO.CODIGO_CLIENTE);
		RetornaMensagemAviso("ObterClienteParaPedidoVenda...");
		VendedorBLL vendedorBLL = new VendedorBLL();
		pedidoVendaMO.VENDEDOR = vendedorBLL.ObterVendedorParaPedidoVenda(pedidoVendaMO.CODIGO_VENDEDOR);
		RetornaMensagemAviso("ObterTipoPedidoPeloCodigo...");
		TipoPedidoBLL tipoPedidoBLL = new TipoPedidoBLL();
		pedidoVendaMO.TIPO_PEDIDO = tipoPedidoBLL.ObterTipoPedidoPeloCodigo(pedidoVendaMO.CODIGO_TIPO_PEDIDO);
		RetornaMensagemAviso("ObterCondicaoPagamentoParaPedidoVenda...");
		PromocaoBLL promocaoBLL = new PromocaoBLL();
		pedidoVendaMO.PROMOCAO = promocaoBLL.ObterCondicaoPagamentoParaPedidoVenda(pedidoVendaMO.SEQ_PROMOCAO);
		RetornaMensagemAviso("ObterContratoOperadoraCartaoCredito...");
		ContratoOperadoraCartaoCreditoBLL contratoOperadoraCartaoCreditoBLL = new ContratoOperadoraCartaoCreditoBLL();
		pedidoVendaMO.PROMOCAO.CONTRATO = contratoOperadoraCartaoCreditoBLL.ObterContratoOperadoraCartaoCredito(pedidoVendaMO.PROMOCAO.CC_CONTRATO_OPERADORA_ID);
		RetornaMensagemAviso("ObterAcaoComercialPedido...");
		AcaoComercialBLL acaoComercialBLL = new AcaoComercialBLL();
		pedidoVendaMO.ACOES_COMERCIAIS = acaoComercialBLL.ObterAcaoComercialPedido(pedidoEletronico);
		RetornaMensagemAviso("CarregarCamposFixosPedidoVenda...");
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.CarregarCamposFixosPedidoVenda(pedidoVendaMO);
		RetornaMensagemAviso("CarregarDataFaturamentoEntregaPedido...");
		pedidoVendaBLL.CarregarDataFaturamentoEntregaPedido(pedidoVendaMO);
		RetornaMensagemAviso("CarregarTipoFretePedido...");
		pedidoVendaBLL.CarregarTipoFretePedido(pedidoVendaMO, pedidoEletronico);
		RetornaMensagemAviso("CarregarEnderecoPedido...");
		EnderecoPedidoBLL enderecoPedidoBLL = new EnderecoPedidoBLL();
		enderecoPedidoBLL.CarregarEnderecoPedido(pedidoVendaMO);
		RetornaMensagemAviso("CarregarObservacoesPedido...");
		ObservacaoPedidoBLL observacaoPedidoBLL = new ObservacaoPedidoBLL();
		observacaoPedidoBLL.CarregarObservacoesPedido(pedidoVendaMO);
		return pedidoVendaMO;
	}

	public void CarregarItensPedido(PedidoVendaMO pedidoVenda)
	{
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		pedidoVenda.ITENS = itemPedidoBLL.ObterItensPedido(pedidoVenda);
	}

	public void CarregarDataPedido(PedidoVendaMO pedidoVenda)
	{
		DateTime dateTime = DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.DataHora);
		pedidoVenda.DATA_CADASTRO = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
		pedidoVenda.DATA_PEDIDO = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
		pedidoVenda.DATA_FECHAMENTO_PEDIDO = pedidoVenda.DATA_CADASTRO;
	}

	public void GerarNumeroPedido(PedidoVendaMO pedidoVenda, bool gerarNumeroPedidoSemLock)
	{
		PedidoVendaDAL pedidoVendaDAL = new PedidoVendaDAL();
		pedidoVendaDAL.GerarNumeroPedido(pedidoVenda, gerarNumeroPedidoSemLock);
	}

	public bool ValidarUtilizaNumeroPedidoSemLock()
	{
		PedidoVendaDAL pedidoVendaDAL = new PedidoVendaDAL();
		return pedidoVendaDAL.ValidarUtilizaNumeroPedidoSemLock();
	}

	public void AtualizarPedidoEletronico(PedidoVendaMO pedidoVenda)
	{
		EventoPedidoEletronicoBLL eventoPedidoEletronicoBLL = new EventoPedidoEletronicoBLL();
		EventoPedidoEletronicoVO evPedidoEletronicoVO = eventoPedidoEletronicoBLL.ForcaLockRetornaSeqEvento(pedidoVenda);
		eventoPedidoEletronicoBLL.EncerrarEventoPedidoEletronico(evPedidoEletronicoVO);
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		EventoPedidoEletronicoAbertoBLL eventoPedidoEletronicoAbertoBLL = new EventoPedidoEletronicoAbertoBLL();
		eventoPedidoEletronicoAbertoBLL.DeletarEventoPedidoEletronicoAberto(pEDIDO_ELETRONICO);
	}

	public void ValidarParametroLiberarPedido(ParametrosLiberarPedidoEletronicoVO parametroLiberarPedidoEle)
	{
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		pedidoEletronicoBLL.ValidarParametroLiberacao(parametroLiberarPedidoEle);
	}

	public void ValidarParametroCancelarPedido(ParametrosCancelarPedidoVO parametroCancelarPedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.ValidarParametroCancelamento(parametroCancelarPedidoVenda);
	}

	public void ValidarItensPedidoEletronico(PedidoVendaMO pedidoVenda)
	{
		MyException ex = new MyException();
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		string text = pedidoEletronicoBLL.ValidarCadastrosItensPedidoEletronico(pedidoVenda.PEDIDO_ELETRONICO);
		if (!string.IsNullOrEmpty(text))
		{
			ex.AddErro(text);
		}
		ex.ThrowException();
	}

	public void CortarItensPedidoEletronico(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		if (ConfigHelper.getBoolAppConfig("ReservarEstoqueComCorte"))
		{
			pedidoEletronicoBLL.RealizarReservaCorteItensPedidoEletronico(pedidoVenda.PEDIDO_ELETRONICO, SessaoErpManager.CURRENT.SESSAO_DB_TEMP.NOME_TABELA_TEMPORARIA);
		}
		else
		{
			pedidoEletronicoBLL.RealizarCorteItensPedidoEletronico(pedidoVenda.PEDIDO_ELETRONICO);
		}
	}

	public void LiberarPedidoERP(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		ParametrosLiberarPedidoErpVO paramLiberacaoPedidoErp = new ParametrosLiberarPedidoErpVO
		{
			CODIGO_EMPRESA = LoginERP.EMPRESA_LOGADA.CODIGO_EMPRESA,
			NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO,
			CODIGO_USUARIO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO,
			UTILIZA_FRETE = false,
			CODIGO_FILA_ATUAL = "CAPV"
		};
		ResultadoLiberarPedidoErpVO resultadoLiberarPedidoErpVO = pedidoVendaBLL.ProcessarLiberacaoPedidoErp(paramLiberacaoPedidoErp, pedidoVenda);
		if (resultadoLiberarPedidoErpVO.ERROS == null || resultadoLiberarPedidoErpVO.ERROS.Count <= 0)
		{
			return;
		}
		MyException ex = new MyException(base.RetornaMensagemAviso);
		foreach (ErroErpVO eRRO in resultadoLiberarPedidoErpVO.ERROS)
		{
			ex.AddAviso(eRRO.DESCRICAO);
		}
		ex.ThrowException();
	}

	public void CancelarPedido(PedidoVendaMO pedidoVenda)
	{
		EstoqueBLL estoqueBLL = new EstoqueBLL();
		estoqueBLL.RemoverReservaEstoque(pedidoVenda);
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.CancelarPedido(pedidoVenda);
		EventoBLL eventoBLL = new EventoBLL();
		eventoBLL.GerarLogCancelamentoPedido(pedidoVenda);
		eventoBLL.CancelarEventosAbertosPedidoVenda(pedidoVenda);
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		pedidoEletronicoBLL.CancelarPedidoEletronico(pedidoVenda);
	}

	public void GerarEventoCadastroPedido(PedidoVendaMO pedidoVenda)
	{
		UsuarioMO uSUARIO_LOGADO = LoginERP.USUARIO_LOGADO;
		DateTime dATA_ABERTURA_PEDIDO = pedidoVenda.DATA_ABERTURA_PEDIDO;
		DateTime dATA_FECHAMENTO_PEDIDO = pedidoVenda.DATA_FECHAMENTO_PEDIDO;
		EventoBLL eventoBLL = new EventoBLL();
		eventoBLL.GerarEventoCadastroPedido(pedidoVenda, uSUARIO_LOGADO, dATA_ABERTURA_PEDIDO, dATA_FECHAMENTO_PEDIDO);
	}

	public void SalvarPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		pedidoVenda.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.Salvar(pedidoVenda);
	}

	public void SalvarProdutosPapelCortado(PedidoVendaMO pedidoVenda)
	{
		List<ItemPedidoMO> list = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => x.PAPEL_CORTADO.ToBool());
		ItemPedidoDAL itemPedidoDAL = new ItemPedidoDAL();
		foreach (ItemPedidoMO item in list)
		{
			itemPedidoDAL.IncluirPapelCortado(pedidoVenda, item);
		}
	}

	public void VerificarPedidoSemItens(PedidoVendaMO pedidoVenda)
	{
		List<ItemPedidoMO> itensRemovidos = pedidoVenda.ITENS.FindAll((ItemPedidoMO x) => x.STATUS_ENTIDADE == StatusModelEnum.DELETADO);
		ItemPedidoBLL itemPedidoBLL = new ItemPedidoBLL();
		itemPedidoBLL.RemoverItens(pedidoVenda.ITENS, (ItemPedidoMO x) => x.STATUS_ENTIDADE == StatusModelEnum.DELETADO);
		if (pedidoVenda.ITENS.Count > 0)
		{
			return;
		}
		foreach (ItemPedidoMO item in itensRemovidos)
		{
			item.PRECO_UNITARIO = item.PRECO_BASICO;
		}
		TransactionManager.ExecutarComTransacao(delegate
		{
			try
			{
				EstoqueBLL estoqueBLL = new EstoqueBLL();
				estoqueBLL.RemoverReservaEstoque(pedidoVenda);
				IModuloEstoqueBLL moduloEstoqueBLL = new ModuloEstoqueBLL();
				moduloEstoqueBLL.RegistrarFaltasEstoque(pedidoVenda, itensRemovidos);
				PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
				pedidoEletronicoBLL.CancelarPedidoEletronico(pedidoVenda);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		});
		new MyException("O pedido foi cancelado pois todos os itens estão sem estoque.").ThrowException();
	}

	public PedidoVendaMO ObterPedidoVendaPeloID(int codigoEmpresa, int numeroPedido)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		PedidoVendaMO pedidoVendaMO = pedidoVendaBLL.ObterPeloID(codigoEmpresa, numeroPedido);
		TipoPedidoBLL tipoPedidoBLL = new TipoPedidoBLL();
		pedidoVendaMO.TIPO_PEDIDO = tipoPedidoBLL.ObterTipoPedidoPeloCodigo(pedidoVendaMO.CODIGO_TIPO_PEDIDO);
		pedidoVendaMO.DATA_ABERTURA_PEDIDO = DateTimeHelper.ObterDataHoraAtualBancoDados();
		pedidoVendaMO.DATA_FECHAMENTO_PEDIDO = pedidoVendaMO.DATA_CADASTRO;
		PedidoEletronicoBLL pedidoEletronicoBLL = new PedidoEletronicoBLL();
		PedidoEletronicoMO pedidoEletronicoMO = new PedidoEletronicoMO();
		pedidoEletronicoMO.NUMERO_PEDIDO = numeroPedido;
		pedidoEletronicoMO.CODIGO_EMPRESA = codigoEmpresa;
		PedidoEletronicoMO pedidoEletronicoMO2 = pedidoEletronicoBLL.ObterUnicoPeloExemplo(pedidoEletronicoMO);
		pedidoVendaMO.PEDIDO_ELETRONICO = pedidoEletronicoBLL.ObterPedidoEletronicoParaPedidoVenda(pedidoEletronicoMO2.CODIGO_EMPRESA_ELETRONICO, pedidoEletronicoMO2.NUMERO_PEDIDO_ELETRONICO, Convert.ToInt32(pedidoEletronicoMO2.SEQ_PEDIDO_ELETRONICO));
		return pedidoVendaMO;
	}

	public void ValidarTipoPedido(PedidoVendaMO pedidoVenda)
	{
		MyException ex = new MyException(base.RetornaMensagemAviso);
		TipoPedidoVO tIPO_PEDIDO = pedidoVenda.TIPO_PEDIDO;
		if (string.IsNullOrEmpty(tIPO_PEDIDO.CODIGO_TIPO_PEDIDO))
		{
			ex.AddErro("{0} do pedido eletrônico não informado.", "Tipo de Pedido");
			ex.ThrowException();
		}
		if (tIPO_PEDIDO.SERVICO)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Serviço");
		}
		if (tIPO_PEDIDO.INVENTARIO)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Inventário");
		}
		if (tIPO_PEDIDO.LOTE_MANUAL)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Lote Manual");
		}
		if (tIPO_PEDIDO.DEVOLUCAO_FORNECEDOR)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Devolução Fornecedor");
		}
		if (tIPO_PEDIDO.PEDIDO_NF_ENTRADA_DEVOLUCAO_CLIENTE)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Entrada de Devolução de Cliente");
		}
		if (tIPO_PEDIDO.ISENTA_PIS_COFINS)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "com Isensão de PIS e COFINS");
		}
		if (tIPO_PEDIDO.VENDA_BALCAO)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Venda Balcão");
		}
		if (tIPO_PEDIDO.VENDA_POS_CONSIGNACAO)
		{
			ex.AddErro("O Tipo de Pedido: {0}, não é suportado pela Interface.", "Venda Pós Consignação");
		}
		if (tIPO_PEDIDO.SUFRAMA && !pedidoVenda.CLIENTE.SUFRAMA.ToBool())
		{
			ex.AddErro("O Tipo de Pedido é Suframa e o Cliente não tem suframa.");
		}
		if (tIPO_PEDIDO.SUFRAMA && pedidoVenda.CLIENTE.SUFRAMA.ToBool())
		{
			pedidoVenda.SUFRAMA = BoolEnum.True;
		}
	}

	public void ValidarMontagemPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		if (string.IsNullOrEmpty(pedidoVenda.CODIGO_TABELA))
		{
			throw new MyException("Tabela de preço não informada");
		}
	}

	public void ValidarLimiteDeVendasPFxPJ(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.ValidarLimiteDeVenda(pedidoVenda);
	}

	public void VerificaIntermediador(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico)
	{
		PedidoVendaBLL pedidoVendaBLL = new PedidoVendaBLL();
		pedidoVendaBLL.VerificaIntermediador(pedidoVenda, pedidoEletronico.INTERMEDIADOR_PEDIDO, pedidoEletronico.CNPJ_INTERMEDIADOR);
	}

	public void GaranteConsistenciaItensDesconto(PedidoVendaMO pedidoVenda)
	{
		foreach (ItemPedidoMO iTEN in pedidoVenda.ITENS)
		{
			iTEN.DESCONTO_APLICADO = ((!iTEN.DESCONTO_APLICADO.HasValue) ? new decimal?(default(decimal)) : iTEN.DESCONTO_APLICADO);
			iTEN.DESCONTO_01 = ((!iTEN.DESCONTO_01.HasValue) ? new decimal?(default(decimal)) : iTEN.DESCONTO_01);
			decimal? dESCONTO_ = iTEN.DESCONTO_01;
			if ((dESCONTO_.GetValueOrDefault() == default(decimal)) & dESCONTO_.HasValue)
			{
				dESCONTO_ = iTEN.DESCONTO_APLICADO;
				if ((dESCONTO_.GetValueOrDefault() > default(decimal)) & dESCONTO_.HasValue)
				{
					iTEN.DESCONTO_01 = iTEN.DESCONTO_APLICADO;
				}
			}
		}
	}

	public void TratamentoLABebidasOC809337(PedidoVendaMO pedidoVenda)
	{
		PedidoVendaDAL pedidoVendaDAL = new PedidoVendaDAL();
		int num = pedidoVendaDAL.BuscaNuPedMax(pedidoVenda.CODIGO_EMPRESA);
		if (num >= pedidoVenda.NUMERO_PEDIDO)
		{
			pedidoVendaDAL.AjusteNuPedDuplicateKeyPedVda(pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO, num);
			pedidoVenda.NUMERO_PEDIDO = num;
		}
	}
}
