using System;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class PrecoDAL : EntidadeBaseDAL<PrecoMO>
{
	protected override Expression<Func<PrecoMO, bool>> GetWhere(Expression<Func<PrecoMO, bool>> whereClause, PrecoMO exemplo)
	{
		if (exemplo.CODIGO_PRODUTO > 0)
		{
			whereClause = whereClause.And((PrecoMO x) => x.CODIGO_PRODUTO == exemplo.CODIGO_PRODUTO);
		}
		if (!string.IsNullOrEmpty(exemplo.CODIGO_TABELA))
		{
			whereClause = whereClause.And((PrecoMO x) => x.CODIGO_TABELA == exemplo.CODIGO_TABELA);
		}
		return whereClause;
	}

	public VerbaVO ObterVerbaDoCliente(VendedorMO vendedor, ClienteMO cliente)
	{
		string select = $" SELECT  isnull(b.valor,0) as VALOR_ATUAL,\r\n                                                 isnull(a.vl_limite_verba,0) as VALOR_LIMITE_VERBA\r\n                                         FROM vend_cli a\r\n                                         LEFT JOIN vi_verba_ab_clien b\r\n                                         ON a.cd_clien = b.cd_clien AND a.cd_vend = b.cd_vend\r\n                                         WHERE\r\n                                            a.cd_clien = {cliente.CODIGO_CLIENTE}\r\n                                         AND a.cd_vend = '{vendedor.CODIGO_VENDEDOR}' ";
		return ExecutarScalarSQL<VerbaVO>(select, Array.Empty<object>());
	}

	public VerbaVO ObterVerbaVendedor(VendedorMO vendedor)
	{
		string select = $" SELECT \r\n                                            ISNULL(b.valor, 0.0) as VALOR_ATUAL,\r\n                                            ISNULL(a.vl_limite_verba, 0.0) as VALOR_LIMITE_VERBA\r\n                                          FROM VENDEDOR a\r\n                                          LEFT JOIN vi_verba_ab_vend b ON a.cd_vend = b.cd_vend\r\n                                          WHERE a.cd_vend = '{vendedor.CODIGO_VENDEDOR}' ";
		return ExecutarScalarSQL<VerbaVO>(select, Array.Empty<object>());
	}

	public void AtualizarPrecoProdutoPelaTabela(int codigoProduto, decimal valorPrecoAtualizado, string codigoTabela)
	{
		try
		{
			string comando = " UPDATE preco\r\n                                      SET vl_preco = {0}\r\n                                    WHERE cd_prod = {1}\r\n                                      AND cd_tabela = {2} ";
			ExecutarSqlCommand(comando, valorPrecoAtualizado, codigoProduto, codigoTabela);
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public PrecoMO ObterPrecoItemPedido(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, bool utilizaDescontoCondPagto)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" SELECT  pre.cd_tabela CODIGO_TABELA,\r\n                                         pre.cd_prod CODIGO_PRODUTO,\r\n                                         vl_preco VALOR_PRECO, ");
			if (utilizaDescontoCondPagto)
			{
				stringBuilder.Append(" ISNULL(pdp.descprom_lancprod, pre.descprom_lancprod ) as DESCONTO_PROMOCAO_LANCAMENTO_PRODUTO, ");
			}
			else
			{
				stringBuilder.Append(" pre.descprom_lancprod DESCONTO_PROMOCAO_LANCAMENTO_PRODUTO, ");
			}
			stringBuilder.Append("        ISNULL(pdp.desconto, ISNULL(pre.desc_prom,0)) as DESCONTO_PROMOCAO,\r\n                                        descprom_redcomis DESCONTO_PROMOCAO_REDUZ_COMISSAO,\r\n                                        imprime_tab_pre IMPRIME_TABELA_PRECO,\r\n                                        dt_alt_imprime DATA_ALTERACAO_IMPRIME,\r\n                                        gera_verba GERA_VERBA,\r\n                                        desc_max_prd DESCONTO_MAXIMO_PRODUTO,\r\n                                        promocao PROMOCAO,\r\n                                        limite_acrescimo LIMITE_ACRESCIMO,\r\n                                        vl_verba_unit VALOR_VERBA_UNITARIO,\r\n                                        verba_max_deb VERBA_MAX_DEBITO,\r\n                                        desc_grd_bon DESCONTO_GRADE_BONIFICADO,\r\n                                        desc_grd_com DESCONTO_GRADE_COMERCIAL,\r\n                                        desc_grd_fin DESCONTO_GRADE_FINANCEIRO,\r\n                                        seq_grade_desc_it SEQ_GRADE_DESCONTO_ITEM,\r\n                                        desp_extra DESPESA_EXTRA,\r\n                                        desc_flex DESCONTO_FLEX,\r\n                                        perc_desc_fin_auto PERCENTUAL_DESCONTO_FINANCEIRO_AUTOMATICO,\r\n                                        seq_oferta SEQ_OFERTA,\r\n                                        dt_ult_alteracao DATA_ULTIMA_ALTERACAO,\r\n                                        PercMgCt PERCENTUAL_MARGEM_CUSTO,\r\n                                        PercMgBr PERCENTUAL_MARGEM_BRUTA ");
			stringBuilder.AppendFormat("  FROM preco pre\r\n                                        LEFT JOIN prod_desc_prz pdp\r\n                                        ON  pdp.cd_tabela = pre.cd_tabela\r\n                                        AND  pdp.seq_prom = {0}\r\n                                        AND pdp.cd_prod = pre.cd_prod\r\n                                        WHERE pre.cd_tabela = '{1}'\r\n                                        AND  pre.cd_prod = {2} ", pedidoVenda.SEQ_PROMOCAO, pedidoVenda.CODIGO_TABELA, itemPedido.CODIGO_PRODUTO);
			return ExecutarScalarSQL<PrecoMO>(stringBuilder.ToString(), Array.Empty<object>());
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
