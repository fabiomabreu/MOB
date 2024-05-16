using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class ObservacaoPedidoBLL : EntidadeBaseBLL<ObservacaoPedidoMO>
{
	protected override EntidadeBaseDAL<ObservacaoPedidoMO> GetInstanceDAL()
	{
		return new ObservacaoPedidoDAL();
	}

	public void CarregarObservacoesPedido(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		List<ObservacaoPedidoMO> list = new List<ObservacaoPedidoMO>();
		foreach (ObservacaoPedidoEletronicoMO oBSERVACO in pEDIDO_ELETRONICO.OBSERVACOES)
		{
			ObservacaoPedidoMO item = ConvertHelper.ToObject<ObservacaoPedidoMO>(oBSERVACO, Array.Empty<string>());
			list.Add(item);
		}
		pedidoVenda.OBSERVACOES = list;
	}
}
