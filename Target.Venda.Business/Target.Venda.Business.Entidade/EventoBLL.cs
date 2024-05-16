using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class EventoBLL : EntidadeBaseBLL<EventoMO>
{
	protected override EntidadeBaseDAL<EventoMO> GetInstanceDAL()
	{
		return new EventoDAL();
	}

	protected override void Inserir(EventoMO objeto)
	{
		EventoDAL eventoDAL = BaseDAL as EventoDAL;
		objeto.SEQ_EVENTO = eventoDAL.GerarSeq("seq_even");
		base.Inserir(objeto);
	}

	public void GerarEventoCadastroPedido(PedidoVendaMO pedidoVenda, UsuarioMO usuario, DateTime dataAbertura, DateTime dataFechamento)
	{
		EventoMO eventoMO = new EventoMO();
		eventoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoMO.CODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE;
		eventoMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		eventoMO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		eventoMO.CODIGO_FILA = "CAPV";
		eventoMO.CODIGO_USUARIO_ENCERRAMENTO = usuario.CODIGO_USUARIO;
		eventoMO.CODIGO_USUARIO_GERENTE = usuario.CODIGO_USUARIO;
		eventoMO.CODIGO_USUARIO_RESPONSAVEL = null;
		eventoMO.DATA_CRIACAO = dataAbertura;
		eventoMO.DATA_ENCERRAMENTO = dataFechamento;
		eventoMO.DATA_FOLLOW = eventoMO.DATA_CRIACAO;
		eventoMO.NUMERO_FOLLOW = 0;
		eventoMO.SITUACAO = "EN";
		Salvar(eventoMO);
	}

	public void GerarEventoErroPedido(PedidoVendaMO pedidoVenda, UsuarioMO usuario, string codigoFila, int codigoErro, string nomeTabTemporaria)
	{
		EventoMO eventoMO = new EventoMO();
		eventoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoMO.CODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE;
		eventoMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		eventoMO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		eventoMO.CODIGO_FILA = "ERPV";
		eventoMO.SITUACAO = "AB";
		eventoMO.CODIGO_USUARIO_GERENTE = usuario.CODIGO_USUARIO;
		eventoMO.CODIGO_USUARIO_RESPONSAVEL = null;
		DateTime value = (eventoMO.DATA_CRIACAO = DateTimeHelper.ObterDataHoraAtualBancoDados());
		eventoMO.DATA_FOLLOW = value;
		eventoMO.NUMERO_FOLLOW = 0;
		Salvar(eventoMO);
		InserirEventoErroNaTabelaTemp(nomeTabTemporaria, codigoErro);
	}

	public void GerarLogCancelamentoPedido(PedidoVendaMO pedidoVenda)
	{
		EventoMO eventoMO = new EventoMO();
		eventoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		eventoMO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		eventoMO.CODIGO_FILA = "CPED";
		eventoMO.CODIGO_USUARIO_ENCERRAMENTO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
		eventoMO.CODIGO_USUARIO_GERENTE = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
		eventoMO.DATA_CRIACAO = DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.DataHora);
		eventoMO.DATA_ENCERRAMENTO = pedidoVenda.DATA_FECHAMENTO_PEDIDO;
		eventoMO.DATA_FOLLOW = eventoMO.DATA_CRIACAO;
		eventoMO.SITUACAO = "EN";
		eventoMO.NUMERO_FOLLOW = 0;
		eventoMO.CODIGO_CLIENTE = 0;
		eventoMO.COMENTARIO = null;
		Salvar(eventoMO);
		EventoCancelPedidoMO eventoCancelPedidoMO = new EventoCancelPedidoMO();
		eventoCancelPedidoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoCancelPedidoMO.CODIGO_MOTIVO_CANCELAMENTO = "VLMICP";
		eventoCancelPedidoMO.SEQ_EVENTO = eventoMO.SEQ_EVENTO;
		EventoCancelPedidoBLL eventoCancelPedidoBLL = new EventoCancelPedidoBLL();
		eventoCancelPedidoBLL.Salvar(eventoCancelPedidoMO);
	}

	public void CancelarEventosAbertosPedidoEletronico(PedidoEletronicoMO pedidoEletronico)
	{
		EventoDAL eventoDAL = BaseDAL as EventoDAL;
		List<EventoPedidoEletronicoMO> eVENTOS_PEDIDO_ELETRONICO = pedidoEletronico.EVENTOS_PEDIDO_ELETRONICO;
		foreach (EventoPedidoEletronicoMO item in eVENTOS_PEDIDO_ELETRONICO)
		{
			eventoDAL.CancelarEventoPedidoEletronico(item);
		}
	}

	public void CancelarEventosAbertosPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		EventoDAL eventoDAL = BaseDAL as EventoDAL;
		List<EventoMO> list = ObterAbertosEventosPeloPedidoVenda(pedidoVenda);
		foreach (EventoMO item in list)
		{
			eventoDAL.CancelarEvento(item);
		}
	}

	public List<EventoMO> ObterAbertosEventosPeloPedidoVenda(PedidoVendaMO pedidoVenda)
	{
		EventoDAL eventoDAL = BaseDAL as EventoDAL;
		EventoMO exampleInstance = new EventoMO
		{
			NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO,
			CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA,
			SITUACAO = "AB"
		};
		return ObterPeloExemplo(exampleInstance);
	}

	public void InserirEventoErroNaTabelaTemp(string nomeTabelaTemp, int codigoErro)
	{
		(BaseDAL as EventoDAL).InserirEventoErroNaTabelaTemp(nomeTabelaTemp, codigoErro);
	}

	public void GerarEventoTroca(TrocaMO troca, UsuarioMO usuario)
	{
		EventoLogBLL eventoLogBLL = new EventoLogBLL();
		EventoLogMO eventoLogMO = new EventoLogMO();
		eventoLogMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoLogMO.DATA_CRIACAO = DateTimeHelper.ObterDataHoraAtualBancoDados();
		eventoLogMO.CODIGO_TEXTO = null;
		eventoLogMO.CODIGO_FILA = "TPED";
		eventoLogMO.CODIGO_USUARIO = usuario.CODIGO_USUARIO;
		eventoLogBLL.Salvar(eventoLogMO);
		EventoLogTrocaBLL eventoLogTrocaBLL = new EventoLogTrocaBLL();
		EventoLogTrocaMO eventoLogTrocaMO = new EventoLogTrocaMO();
		eventoLogTrocaMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoLogTrocaMO.SEQ_TROCA = troca.SEQ_TROCA;
		eventoLogTrocaMO.SEQ_EVENTO_LOG = eventoLogMO.SEQ_EVENTO_LOG;
		if (troca.PRODUTO_LOCALIZA == "E" && troca.VALOR_TOTAL_RECEBIDO != troca.VALOR_TOTAL && troca.SITUACAO != "CA")
		{
			eventoLogTrocaMO.CODIGO_LOCAL_ESTOQUE = troca.CODIGO_LOCAL_ESTOQUE;
			eventoLogTrocaMO.PRODUTO_LOCALIZA = troca.PRODUTO_LOCALIZA;
			eventoLogTrocaMO.CODIGO_EMPRESA_ESTOQUE = troca.CODIGO_EMPRESA_ESTOQUE;
		}
		eventoLogTrocaBLL.Salvar(eventoLogTrocaMO);
	}

	public void GerarEventoAlteracaoPreco(AcaoComercialProdutoPrecoVO acaoComercProdutoPreco, PedidoVendaMO pedidoVenda, string tipoAlteracaoEvento)
	{
		EventoAlteracaoPrecoBLL eventoAlteracaoPrecoBLL = new EventoAlteracaoPrecoBLL();
		if (tipoAlteracaoEvento == "PRE" || tipoAlteracaoEvento == "CPR")
		{
			EventoAlteracaoPrecoMO eventoAlteracaoPrecoMO = new EventoAlteracaoPrecoMO();
			eventoAlteracaoPrecoMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
			eventoAlteracaoPrecoMO.CODIGO_PRODUTO = acaoComercProdutoPreco.CODIGO_PRODUTO;
			eventoAlteracaoPrecoMO.CODIGO_USUARIO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
			eventoAlteracaoPrecoMO.CODIGO_TABELA = acaoComercProdutoPreco.CODIGO_TABELA;
			eventoAlteracaoPrecoMO.VALOR_PRECO_ANTERIOR = acaoComercProdutoPreco.VALOR_PRECO_TABELA;
			eventoAlteracaoPrecoMO.VALOR_PRECO_NOVO = acaoComercProdutoPreco.VALOR_PRECO_ATUALIZADO;
			eventoAlteracaoPrecoMO.PROGRAMA_ORIGEM = LoginERP.PROGRAMA_ORIGEM;
			eventoAlteracaoPrecoMO.DATA_CRIACAO = DateTime.Now;
			eventoAlteracaoPrecoBLL.Salvar(eventoAlteracaoPrecoMO);
		}
		IntPedidoLiberaProdutoBLL intPedidoLiberaProdutoBLL = new IntPedidoLiberaProdutoBLL();
		intPedidoLiberaProdutoBLL.GerarIntPedidoLiberaProduto(acaoComercProdutoPreco.CODIGO_PRODUTO, tipoAlteracaoEvento, acaoComercProdutoPreco.CODIGO_TABELA);
		intPedidoLiberaProdutoBLL.AlterarIntPedidoLiberaProduto(acaoComercProdutoPreco.CODIGO_PRODUTO, tipoAlteracaoEvento, emiteEtiqueta: false);
	}
}
