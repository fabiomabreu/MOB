using System;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;

namespace Target.Venda.Business.Entidade;

public class EventoErpVendaBLL : EntidadeBaseBLL<EventoErpVendaMO>
{
	protected override EntidadeBaseDAL<EventoErpVendaMO> GetInstanceDAL()
	{
		return new EventoErpVendaDAL();
	}

	public void GerarEventoErpErro(EventoMO evento, PedidoVendaMO pedidoVenda, string codigoUsuario, string codigoFila, int codigoErro)
	{
		EventoErpVendaMO eventoErpVendaMO = new EventoErpVendaMO();
		eventoErpVendaMO.STATUS_ENTIDADE = StatusModelEnum.ADICIONADO;
		eventoErpVendaMO.SEQ_EVENTO = evento.SEQ_EVENTO;
		eventoErpVendaMO.CODIGO_EMPRESA = pedidoVenda.CODIGO_EMPRESA;
		eventoErpVendaMO.NUMERO_PEDIDO = pedidoVenda.NUMERO_PEDIDO;
		eventoErpVendaMO.SEQ_ERRO = Convert.ToInt16(codigoErro);
		eventoErpVendaMO.SEQ_ITEM_PEDIDO = null;
		eventoErpVendaMO.CODIGO_FILA = codigoFila;
		Salvar(eventoErpVendaMO);
	}
}
