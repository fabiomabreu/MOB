using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;
using Target.Venda.Model.Visao;

namespace Target.Venda.Business.Entidade;

public class EventoPedidoEletronicoBLL : EntidadeBaseBLL<EventoPedidoEletronicoMO>
{
	protected override EntidadeBaseDAL<EventoPedidoEletronicoMO> GetInstanceDAL()
	{
		return new EventoPedidoEletronicoDAL();
	}

	public EventoPedidoEletronicoVO ForcaLockRetornaSeqEvento(PedidoVendaMO pedidoVenda)
	{
		EventoPedidoEletronicoDAL eventoPedidoEletronicoDAL = BaseDAL as EventoPedidoEletronicoDAL;
		return eventoPedidoEletronicoDAL.ForcaLockRetornaSeqEvento(pedidoVenda.PEDIDO_ELETRONICO);
	}

	public void EncerrarEventoPedidoEletronico(EventoPedidoEletronicoVO evPedidoEletronicoVO)
	{
		if (evPedidoEletronicoVO.SITUACAO != "AB")
		{
			throw new MyException("Evento pedido eletronico não está com situação aberto");
		}
		EventoPedidoEletronicoMO eventoPedidoEletronicoMO = ObterPeloID(evPedidoEletronicoVO.SEQ_EVENTO);
		eventoPedidoEletronicoMO.DATA_ENCERRAMENTO = DateTimeHelper.ObterDataHoraAtualBancoDados(TipoDateTime.DataHora);
		eventoPedidoEletronicoMO.CODIGO_USUARIO_ENCERRAMENTO = LoginERP.USUARIO_LOGADO.CODIGO_USUARIO;
		eventoPedidoEletronicoMO.STATUS_ENTIDADE = StatusModelEnum.EDITADO;
		Salvar(eventoPedidoEletronicoMO);
	}
}
