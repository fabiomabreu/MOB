using System;
using System.Linq.Expressions;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class UnidadeProdutoDAL : EntidadeBaseDAL<UnidadeProdutoMO>
{
	protected override Expression<Func<UnidadeProdutoMO, bool>> GetWhere(Expression<Func<UnidadeProdutoMO, bool>> whereClause, UnidadeProdutoMO exemplo)
	{
		if (exemplo.CODIGO_PRODUTO > 0)
		{
			whereClause = whereClause.And((UnidadeProdutoMO x) => x.CODIGO_PRODUTO == exemplo.CODIGO_PRODUTO);
		}
		if (!string.IsNullOrEmpty(exemplo.UNIDADE_VENDA))
		{
			whereClause = whereClause.And((UnidadeProdutoMO x) => x.UNIDADE_VENDA == exemplo.UNIDADE_VENDA);
		}
		if (exemplo.VENDA == BoolEnum.True)
		{
			whereClause = whereClause.And((UnidadeProdutoMO x) => x.VENDA == BoolEnum.True);
		}
		if (exemplo.ATIVO == BoolEnum.True)
		{
			whereClause = whereClause.And((UnidadeProdutoMO x) => x.ATIVO == BoolEnum.True);
		}
		if (exemplo.PRINCIPAL == BoolEnum.True)
		{
			whereClause = whereClause.And((UnidadeProdutoMO x) => x.PRINCIPAL == BoolEnum.True);
		}
		return whereClause;
	}

	public UnidadeProdutoMO ObterMenorUnidadeElegivel(int codigoProduto, decimal quantidade)
	{
		try
		{
			string select = " SELECT up.unid_vda\r\n                                FROM unid_prod up\r\n                                WHERE up.cd_prod = {0}\r\n                                AND up.pedida = 1\r\n                                AND up.venda = 1\r\n                                AND up.ativo = 1\r\n                                AND up.fator_estoque_direto = ( SELECT MIN( upr.fator_estoque_direto )\r\n                                                                FROM unid_prod upr\r\n                                                                WHERE upr.cd_prod = up.cd_prod\r\n                                                                AND upr.pedida = up.pedida\r\n                                                                AND upr.venda = up.venda\r\n                                                                AND upr.ind_relacao = up.ind_relacao\r\n                                                                AND upr.ativo = up.ativo\r\n                                                                AND upr.fator_estoque_direto <= {1} )";
			string text = ExecutarScalarSQL<string>(select, new object[2] { codigoProduto, quantidade });
			return ObterPeloID(codigoProduto, text);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public UnidadeVariavelVO ObterMaiorUnidadeVariavel(ItemPedidoMO item)
	{
		string select = "SELECT top 1   \r\n                                cd_prod CODIGO_PRODUTO,\r\n                                unid_vda UNIDADE_VENDA,\r\n                                fator_estoque FATOR_ESTOQUE,\r\n                                ind_relacao INDICE_RELACAO\r\n                              FROM unid_prod u\r\n                              WHERE u.cd_prod = {0}\r\n                                AND u.ind_relacao = 'MAIOR'  \r\n                                AND u.fator_estoque NOT IN ( 0, 1 ) \r\n                                AND {3} / fator_estoque >= 1 \r\n                                AND u.venda = 1   \r\n                                AND u.ativo = 1   \r\n                                AND u.unid_vda != {1}\r\n                                AND u.fator_estoque !=  {2}\r\n                                AND {3} % u.fator_estoque = 0\r\n                                AND NOT ({4} = 'MAIOR' AND {5} > u.fator_estoque)\r\n                              ORDER BY\r\n                                    fator_estoque DESC,\r\n                                    unid_vda ";
		return ExecutarScalarSQL<UnidadeVariavelVO>(select, new object[6] { item.CODIGO_PRODUTO, item.UNIDADE_VENDA, item.FATOR_ESTOQUE_VENDA, item.QUANTIDADE, item.INDICE_RELACAO, item.FATOR_ESTOQUE_PEDIDA });
	}
}
