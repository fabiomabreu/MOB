using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ItemPedidoEletronicoDAL : EntidadeBaseDAL<ItemPedidoEletronicoMO>
{
	protected override Expression<Func<ItemPedidoEletronicoMO, bool>> GetWhere(Expression<Func<ItemPedidoEletronicoMO, bool>> whereClause, ItemPedidoEletronicoMO exemplo)
	{
		if (exemplo.CODIGO_EMPRESA_ELETRONICO > 0)
		{
			whereClause = whereClause.And((ItemPedidoEletronicoMO x) => x.CODIGO_EMPRESA_ELETRONICO == exemplo.CODIGO_EMPRESA_ELETRONICO);
		}
		if (exemplo.NUMERO_PEDIDO_ELETRONICO > 0)
		{
			whereClause = whereClause.And((ItemPedidoEletronicoMO x) => x.NUMERO_PEDIDO_ELETRONICO == exemplo.NUMERO_PEDIDO_ELETRONICO);
		}
		if (exemplo.SEQ_PEDIDO > 0m)
		{
			whereClause = whereClause.And((ItemPedidoEletronicoMO x) => x.SEQ_PEDIDO == exemplo.SEQ_PEDIDO);
		}
		return whereClause;
	}

	public void CancelarItensPedidoEletronicoSemEstoque(PedidoEletronicoMO pedidoEletronico)
	{
		string comando = " UPDATE it_pedv_ele \r\n                                   SET QtdeAtendida = 0,\r\n\t                               QtdeAtendidaUnidPed = 0,\r\n\t                               EstoqueZerado = 1\r\n                            WHERE  cd_emp_ele = {0}\r\n                              AND  nu_ped_ele = {1}\r\n                              AND  seq_ped = {2} ";
		ExecutarSqlCommand(comando, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO);
	}
}
