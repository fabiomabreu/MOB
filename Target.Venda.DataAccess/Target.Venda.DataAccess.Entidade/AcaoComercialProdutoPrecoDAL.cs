using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class AcaoComercialProdutoPrecoDAL : EntidadeBaseDAL<AcaoComercialProdutoPrecoMO>
{
	protected override Expression<Func<AcaoComercialProdutoPrecoMO, bool>> GetWhere(Expression<Func<AcaoComercialProdutoPrecoMO, bool>> whereClause, AcaoComercialProdutoPrecoMO exemplo)
	{
		throw new NotImplementedException();
	}

	public List<string> ObterTabelasAcaoComercialProduto(AcaoComercialEncerradaVO acaoComercial)
	{
		try
		{
			string select = "SELECT DISTINCT \r\n                                         cd_tabela\r\n                                    FROM acao_comercial_prod_preco \r\n                                   WHERE seq_acao_comercial = {0}\r\n                                     AND cd_prod = {1} ";
			return ExecutarSelectSQL<string>(select, new object[2] { acaoComercial.SEQ_ACAO_COMERCIAL, acaoComercial.CODIGO_PRODUTO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public AcaoComercialProdutoPrecoVO ObterAcaoComercialProdutoPrecoPelaTabela(AcaoComercialEncerradaVO acaoComercial, string codigoTabela)
	{
		try
		{
			string select = " SELECT ac.seq_acao_comercial AS SEQ_ACAO_COMERCIAL,\r\n                                          ac.cd_tabela AS CODIGO_TABELA,\r\n                                          ac.cd_prod AS CODIGO_PRODUTO,\r\n                                          ac.vl_preco_acao_com AS VALOR_PRECO_ACAO_COMERCIAL,\r\n                                          ac.vl_preco_pos_acao_com AS VALOR_PRECO_POS_ACAO_COMERCIAL,\r\n                                          pr.vl_preco AS VALOR_PRECO_TABELA\r\n                                     FROM acao_comercial_prod_preco ac\r\n                                     JOIN preco pr ON ac.cd_tabela = pr.cd_tabela\r\n                                                  AND ac.cd_prod = pr.cd_prod\r\n                                    WHERE ac.seq_acao_comercial = {0}\r\n                                      AND ac.cd_prod = {1}\r\n                                      AND ac.cd_tabela = {2} ";
			return ExecutarScalarSQL<AcaoComercialProdutoPrecoVO>(select, new object[3] { acaoComercial.SEQ_ACAO_COMERCIAL, acaoComercial.CODIGO_PRODUTO, codigoTabela });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
