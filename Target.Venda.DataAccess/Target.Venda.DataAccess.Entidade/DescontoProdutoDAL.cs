using System;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;

namespace Target.Venda.DataAccess.Entidade;

public class DescontoProdutoDAL : EntidadeBaseDAL<DescontoProdutoMO>
{
	protected override Expression<Func<DescontoProdutoMO, bool>> GetWhere(Expression<Func<DescontoProdutoMO, bool>> whereClause, DescontoProdutoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public DescontoProdutoMO ObterDescontoPorQuantidade(string codigoTabela, int codigoProduto, decimal quantidade)
	{
		string select = " SELECT cd_prod CODIGO_PRODUTO,\r\n                                   seq_descprod SEQ_DESCONTO_PRODUTO,\r\n                                   cd_tabela CODIGO_TABELA,\r\n                                   qtde_de QUANTIDADE_DE,\r\n                                   qtde_ate QUANTIDADE_ATE,\r\n                                   desconto DESCONTO\r\n                             FROM  descprod\r\n                             WHERE cd_prod = {0}\r\n                             AND cd_tabela = {1}\r\n                             AND qtde_de <= {2}\r\n                             AND qtde_ate >= {2} ";
		return ExecutarScalarSQL<DescontoProdutoMO>(select, new object[3] { codigoProduto, codigoTabela, quantidade });
	}
}
