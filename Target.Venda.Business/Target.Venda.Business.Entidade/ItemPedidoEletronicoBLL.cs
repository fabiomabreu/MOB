using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ItemPedidoEletronicoBLL : EntidadeBaseBLL<ItemPedidoEletronicoMO>
{
	protected override EntidadeBaseDAL<ItemPedidoEletronicoMO> GetInstanceDAL()
	{
		return new ItemPedidoEletronicoDAL();
	}

	public List<ItemPedidoEletronicoMO> ObterItensDoPedidoEletronico(int codigoEmpresa, int numeroPedido, decimal seqPedido)
	{
		return (BaseDAL as ItemPedidoEletronicoDAL).ObterPeloExemplo(new ItemPedidoEletronicoMO
		{
			CODIGO_EMPRESA_ELETRONICO = codigoEmpresa,
			NUMERO_PEDIDO_ELETRONICO = numeroPedido,
			SEQ_PEDIDO = seqPedido
		});
	}

	public void CancelarItensPedidoEletronicoSemEstoque(PedidoEletronicoMO pedidoEletronico)
	{
		(BaseDAL as ItemPedidoEletronicoDAL).CancelarItensPedidoEletronicoSemEstoque(pedidoEletronico);
	}
}
