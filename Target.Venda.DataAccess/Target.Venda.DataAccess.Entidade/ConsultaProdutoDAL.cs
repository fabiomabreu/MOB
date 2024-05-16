using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class ConsultaProdutoDAL : EntidadeBaseDAL<ConsultaProdutoMO>
{
	protected override Expression<Func<ConsultaProdutoMO, bool>> GetWhere(Expression<Func<ConsultaProdutoMO, bool>> whereClause, ConsultaProdutoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public bool VerificarConsultaProduto(PedidoVendaMO pedidoVenda, ItemPedidoMO item)
	{
		string select = " SELECT \r\n                                cast( case when count(1) > 0 then 1 else 0 end as bit)\r\n                            FROM cons_prd  \r\n                            WHERE cd_prod = {0}\r\n                              AND dt_consulta = CAST(getDate() as Date )\r\n                              AND cd_vend = {1}\r\n                              AND cd_clien = {2} ";
		return ExecutarScalarSQL<bool>(select, new object[3] { item.CODIGO_PRODUTO, pedidoVenda.CODIGO_VENDEDOR, pedidoVenda.CODIGO_CLIENTE });
	}

	public void InserirConsultaProduto(ItemPedidoMO item, PedidoVendaMO pedidoVenda)
	{
		string comando = "INSERT INTO cons_prd  \r\n                                      ( cd_prod,  \r\n                                        dt_consulta, \r\n                                        cd_linha,  \r\n                                        cd_vend,  \r\n                                        cd_clien,  \r\n                                        qtde )            \r\n                            SELECT cd_prod,\r\n\t\t\t\t\t\t\t\t   CAST(GETDATE() AS DATE),\r\n\t\t\t\t\t\t\t\t   cd_linha,\r\n\t\t\t\t\t\t\t\t   {0}, \r\n                                   {1}, \r\n                                   {2}\r\n                            from produto  \r\n                            where cd_prod = {3}";
		ExecutarSqlCommand(comando, pedidoVenda.CODIGO_VENDEDOR, pedidoVenda.CODIGO_CLIENTE, 1, item.CODIGO_PRODUTO);
	}

	public void AtualizaConsultaProduto(ItemPedidoMO item, PedidoVendaMO pedidoVenda)
	{
		string comando = " UPDATE cons_prd   \r\n                                  SET qtde = qtde + 1 \r\n                                WHERE cd_prod = {0}\r\n                                  AND dt_consulta = CAST(getdate() AS DATE)\r\n                                  AND cd_vend  =  {1}\r\n                                  AND cd_clien = {2} ";
		ExecutarSqlCommand(comando, item.CODIGO_PRODUTO, pedidoVenda.CODIGO_VENDEDOR, pedidoVenda.CODIGO_CLIENTE);
	}
}
