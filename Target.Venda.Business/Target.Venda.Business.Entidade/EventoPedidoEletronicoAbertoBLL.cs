using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Enum;

namespace Target.Venda.Business.Entidade;

public class EventoPedidoEletronicoAbertoBLL : EntidadeBaseBLL<EventoPedidoEletronicoAbertoMO>
{
	protected override EntidadeBaseDAL<EventoPedidoEletronicoAbertoMO> GetInstanceDAL()
	{
		return new EventoPedidoEletronicoAbertoDAL();
	}

	public void DeletarEventoPedidoEletronicoAberto(PedidoEletronicoMO pedidoEletronico)
	{
		foreach (EventoPedidoEletronicoMO item in pedidoEletronico.EVENTOS_PEDIDO_ELETRONICO)
		{
			EventoPedidoEletronicoAbertoMO eVENTO_PEDIDO_ELETRONICO_AB = item.EVENTO_PEDIDO_ELETRONICO_AB;
			if (eVENTO_PEDIDO_ELETRONICO_AB != null)
			{
				eVENTO_PEDIDO_ELETRONICO_AB = ObterPeloID(eVENTO_PEDIDO_ELETRONICO_AB.SEQ_EVENTO);
				eVENTO_PEDIDO_ELETRONICO_AB.STATUS_ENTIDADE = StatusModelEnum.DELETADO;
				Salvar(eVENTO_PEDIDO_ELETRONICO_AB);
			}
		}
	}
}
