using System;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class TrocaDAL : EntidadeBaseDAL<TrocaMO>
{
	protected override Expression<Func<TrocaMO, bool>> GetWhere(Expression<Func<TrocaMO, bool>> whereClause, TrocaMO exemplo)
	{
		if (exemplo.SEQ_TROCA > 0)
		{
			whereClause = whereClause.And((TrocaMO x) => x.SEQ_TROCA == exemplo.SEQ_TROCA);
		}
		return whereClause;
	}

	public TrocaMO ObterMenorTrocaAberta(ObterTrocaParamVO filtro)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("    SELECT MIN( seq_troca ) as SEQ_TROCA\r\n                            FROM troca (nolock)\r\n                            WHERE nu_ped_pedido IS NULL\r\n                            AND situacao = 'AB'\r\n                            AND tp_envio = 'PF' \r\n                            AND NOT ( tp_abatimento = 'NC' AND prod_localiza = 'E' ) ");
		stringBuilder.AppendFormat(" AND cd_clien = {0}", filtro.CODIGO_CLIENTE);
		stringBuilder.AppendFormat(" AND cd_emp = {0}", filtro.CODIGO_EMPRESA);
		if (filtro.ASSOCIA_TROCA_SOMENTE_AO_MESMO_VENDEDOR_E_CLIENTE)
		{
			stringBuilder.AppendFormat(" AND cd_vend = '{0}' ", filtro.CODIGO_VENDEDOR);
		}
		int? num = ExecutarScalarSQL<int?>(stringBuilder.ToString(), Array.Empty<object>());
		return ObterPeloID(num);
	}

	public void AssociarTrocaPedido(PedidoVendaMO pedidoVenda, TrocaMO troca)
	{
		string comando = " UPDATE troca\r\n                                        SET cd_emp_pedido = {0},\r\n                                            nu_ped_pedido = {1},\r\n                                            tp_envio = 'PA',\r\n                                            situacao = 'AB'\r\n                                WHERE seq_troca = {2} ";
		ExecutarSqlCommand(comando, pedidoVenda.CODIGO_EMPRESA, pedidoVenda.NUMERO_PEDIDO, troca.SEQ_TROCA);
	}
}
