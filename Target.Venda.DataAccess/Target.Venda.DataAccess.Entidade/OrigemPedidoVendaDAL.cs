using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class OrigemPedidoVendaDAL : EntidadeBaseDAL<OrigemPedidoVendaMO>
{
	protected override Expression<Func<OrigemPedidoVendaMO, bool>> GetWhere(Expression<Func<OrigemPedidoVendaMO, bool>> whereClause, OrigemPedidoVendaMO exemplo)
	{
		if (string.IsNullOrEmpty(exemplo.ORIGEM_PEDIDO))
		{
			whereClause = whereClause.And((OrigemPedidoVendaMO x) => x.ORIGEM_PEDIDO == exemplo.ORIGEM_PEDIDO);
		}
		return whereClause;
	}

	public List<OrigemPedidoVendaVO> ObterOrigemPedidoVendaLista()
	{
		try
		{
			string select = "\r\n                        SELECT\r\n                            OrigemPedidoVenda                               AS ORIGEM_PEDIDO,\r\n                            Descricao                                       AS DESCRICAO,\r\n                            CAST( ISNULL( Ativo, 0 ) AS BIT )               AS ATIVO,\r\n                            CAST( ISNULL( DetalhePedVdaEle, 0 ) AS BIT )    AS DETALHE_PEDVDAELE,\r\n                            CAST( ISNULL( ListaPedidoPendente, 0 ) AS BIT ) AS LISTA_PEDIDO_PENDENTE\r\n                        FROM\r\n                            OrigemPedidoVenda\r\n                        WHERE\r\n                            Ativo = 1 ";
			return ExecutarSelectSQL<OrigemPedidoVendaVO>(select, Array.Empty<object>()).ToList();
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
