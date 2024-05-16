using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class CfopDAL : EntidadeBaseDAL<CfopMO>
{
	protected override Expression<Func<CfopMO, bool>> GetWhere(Expression<Func<CfopMO, bool>> whereClause, CfopMO exemplo)
	{
		throw new NotImplementedException();
	}

	public List<int> ObterCFOPs(CfopVO exemplo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(" SELECT cf.cfop\r\n                            FROM cfop cf\r\n                            JOIN tpedcfop tp ON cf.cfop = tp.cfop\r\n                            WHERE tp.tp_ped = {0}\r\n                            AND cf.cli_dest = {1}\r\n                            AND ISNULL(tp.area_livre_comercio, 0) = {2} ");
		if (exemplo.TIPO_PRODUTO.HasValue)
		{
			stringBuilder.Append(" AND cf.prod_ind = " + (int)exemplo.TIPO_PRODUTO.Value);
		}
		return ExecutarSelectSQL<int>(stringBuilder.ToString(), new object[3] { exemplo.TIPO_PEDIDO, exemplo.TIPO_DESTINO_CLIENTE, exemplo.AREA_LIVRE_COMERCIO });
	}
}
