using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class EventoPedidoEletronicoDAL : EntidadeBaseDAL<EventoPedidoEletronicoMO>
{
	public override void Delete(EventoPedidoEletronicoMO objeto)
	{
		base.Delete(objeto);
	}

	protected override Expression<Func<EventoPedidoEletronicoMO, bool>> GetWhere(Expression<Func<EventoPedidoEletronicoMO, bool>> whereClause, EventoPedidoEletronicoMO exemplo)
	{
		if (exemplo.CODIGO_EMPRESA_ELETRONICO > 0)
		{
			whereClause = whereClause.And((EventoPedidoEletronicoMO x) => x.CODIGO_EMPRESA_ELETRONICO == exemplo.CODIGO_EMPRESA_ELETRONICO);
		}
		if (exemplo.NUMERO_PEDIDO_ELETRONICO > 0)
		{
			whereClause = whereClause.And((EventoPedidoEletronicoMO x) => x.NUMERO_PEDIDO_ELETRONICO == exemplo.NUMERO_PEDIDO_ELETRONICO);
		}
		return whereClause;
	}

	public EventoPedidoEletronicoVO ForcaLockRetornaSeqEvento(PedidoEletronicoMO pedidoEletronico)
	{
		string comando = " UPDATE evento_pdel\r\n                            SET cd_usr_ger = cd_usr_ger \r\n                            WHERE cd_emp_ele = {0} \r\n                              AND nu_ped_ele = {1} \r\n                              AND seq_ped = {2}  ";
		ExecutarSqlCommand(comando, pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO);
		string select = " SELECT    \r\n                               ev.seq_evento SEQ_EVENTO,   \r\n                             CASE WHEN EXISTS(  SELECT  1\r\n                                                FROM evento_pdel_ab eva\r\n                                                WHERE ev.seq_evento = eva.seq_evento )\r\n                             THEN 'AB' \r\n                             ELSE 'FE'\r\n                             END SITUACAO\r\n                             FROM evento_pdel ev  \r\n                             WHERE ev.cd_emp_ele = {0}\r\n                               AND ev.nu_ped_ele = {1}\r\n                               AND ev.seq_ped = {2}";
		return ExecutarScalarSQL<EventoPedidoEletronicoVO>(select, new object[3] { pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO });
	}
}
