using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class ProdutoComissaoDAL : EntidadeBaseDAL<ProdutoComissaoMO>
{
	protected override Expression<Func<ProdutoComissaoMO, bool>> GetWhere(Expression<Func<ProdutoComissaoMO, bool>> whereClause, ProdutoComissaoMO exemplo)
	{
		throw new NotImplementedException();
	}

	private string ObterGrupoComissaoSeqKitProm(int? seqKitProm, byte flexivel, int cdProd)
	{
		string select = ((flexivel != 1) ? "SELECT \r\n                                    cd_grp_comis\r\n                                FROM\r\n\t                                kit_prom_prd\r\n                                WHERE \r\n\t                                seq_kit = {0}\r\n                                AND cd_prod = {1}  " : "SELECT \r\n                                    cd_grp_comis\r\n                                FROM\r\n\t                                kit_prom_req\r\n                                WHERE \r\n\t                                seq_kit = {0}\r\n                                AND cd_prod = {1}  ");
		return ExecutarScalarSQL<string>(select, new object[2] { seqKitProm, cdProd });
	}

	public decimal ObterRedutorComissao(PedidoVendaMO pedidoVenda, ItemPedidoMO itemPedido, decimal percentualDesconto, VendedorMO vendedor)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		decimal? num = null;
		if (itemPedido.SEQ_KIT_PROMOCAO.HasValue)
		{
			empty = " SELECT\r\n                                ISNULL(k.flexivel,0)\r\n                            FROM\r\n                                kit_prom k\r\n                            WHERE   \r\n                                k.seq_kit = {0}    ";
			byte b = ExecutarScalarSQL<byte>(empty, new object[1] { itemPedido.SEQ_KIT_PROMOCAO });
			empty2 = ObterGrupoComissaoSeqKitProm(itemPedido.SEQ_KIT_PROMOCAO, b, itemPedido.CODIGO_PRODUTO);
			empty = ((b != 1) ? "SELECT    \r\n\t\t                            ISNULL( gcr.red_comissao, 0 ) + ISNULL(\r\n          \t                            (\r\n                                                SELECT prm.red_comis_prom\r\n                                                FROM   grp_comis_redut_prom prm,\r\n                                                    grp_comis_frm_pgto pgt\r\n                                                WHERE  prm.cd_grp_comis = gc.cd_grp_comis\r\n                                                AND    prm.cd_grp_comis = pgt.cd_grp_comis\r\n                                                AND    prm.seq_prom = {0}\r\n                                                AND    pgt.formpgto = {1} ), 0)\r\n\t                            FROM      grp_comis gc\r\n\t                            LEFT JOIN grp_comis_redut gcr\r\n\t                            ON        gc.cd_grp_comis = gcr.cd_grp_comis\r\n\t                            AND       gcr.desc_preco =\r\n          \t                            (\r\n                                                SELECT max( desc_preco )\r\n                                                FROM   grp_comis_redut\r\n                                                WHERE  cd_grp_comis = gcr.cd_grp_comis\r\n                                                AND    desc_preco <= {2} )\r\n\t                            LEFT JOIN kit_prom_prd kpp\r\n\t                            ON\t  kpp.cd_grp_comis = gc.cd_grp_comis\r\n\t                            WHERE\r\n\t\t                                kpp.seq_kit = {3}\r\n\t                            AND     kpp.cd_prod = {4} " : "SELECT    \r\n\t\t                            ISNULL( gcr.red_comissao, 0 ) + ISNULL(\r\n          \t                            (\r\n                                                SELECT prm.red_comis_prom\r\n                                                FROM   grp_comis_redut_prom prm,\r\n                                                    grp_comis_frm_pgto pgt\r\n                                                WHERE  prm.cd_grp_comis = gc.cd_grp_comis\r\n                                                AND    prm.cd_grp_comis = pgt.cd_grp_comis\r\n                                                AND    prm.seq_prom = {0}\r\n                                                AND    pgt.formpgto = {1} ), 0)\r\n\t                            FROM      grp_comis gc\r\n\t                            LEFT JOIN grp_comis_redut gcr\r\n\t                            ON        gc.cd_grp_comis = gcr.cd_grp_comis\r\n\t                            AND       gcr.desc_preco =\r\n          \t                            (\r\n                                                SELECT max( desc_preco )\r\n                                                FROM   grp_comis_redut\r\n                                                WHERE  cd_grp_comis = gcr.cd_grp_comis\r\n                                                AND    desc_preco <= {2} )\r\n\t                            LEFT JOIN kit_prom_req kpr\r\n\t                            ON\t  kpr.cd_grp_comis = gc.cd_grp_comis\r\n\t                            WHERE\r\n\t\t                                kpr.seq_kit = {3}\r\n\t                            AND     kpr.cd_prod = {4} ");
			if (!string.IsNullOrEmpty(empty2) && !string.IsNullOrWhiteSpace(empty2))
			{
				num = ExecutarScalarSQL<decimal>(empty, new object[5] { pedidoVenda.SEQ_PROMOCAO, pedidoVenda.FORMA_PAGAMENTO, percentualDesconto, itemPedido.SEQ_KIT_PROMOCAO, itemPedido.CODIGO_PRODUTO });
			}
		}
		if (!num.HasValue)
		{
			empty = " SELECT  ISNULL( gcr.red_comissao, 0 ) + ISNULL(( SELECT prm.red_comis_prom\r\n                                                FROM grp_comis_redut_prom prm,\r\n                                                grp_comis_frm_pgto pgt\r\n                                                WHERE prm.cd_grp_comis = gc.cd_grp_comis\r\n                                                AND prm.cd_grp_comis = pgt.cd_grp_comis\r\n                                                AND prm.seq_prom = {0}\r\n                                                AND pgt.formpgto = {1} ), 0)\r\n                                        FROM\r\n                                        prod_comis pc\r\n                                        JOIN  grp_comis gc\r\n                                            LEFT JOIN grp_comis_redut gcr\r\n                                            ON gc.cd_grp_comis = gcr.cd_grp_comis\r\n                                            AND gcr.desc_preco = ( SELECT MAX( desc_preco )\r\n                                                FROM grp_comis_redut\r\n                                                WHERE cd_grp_comis = gcr.cd_grp_comis\r\n                                                AND desc_preco <= {2} )\r\n                                        ON pc.cd_grp_comis = gc.cd_grp_comis\r\n                                        WHERE\r\n                                        pc.cd_tabela = {3}\r\n                                        AND pc.cd_grupo = {4}\r\n                                        AND pc.cd_prod = {5} ";
			num = ExecutarScalarSQL<decimal>(empty, new object[6] { pedidoVenda.SEQ_PROMOCAO, pedidoVenda.FORMA_PAGAMENTO, percentualDesconto, pedidoVenda.CODIGO_TABELA, vendedor.CODIGO_GRUPO, itemPedido.CODIGO_PRODUTO });
		}
		return num.Value;
	}

	public List<ItemPedidoComissaoVO> ObterComissaoItemPedido(PedidoVendaMO pedidoVenda, PedidoEletronicoMO pedidoEletronico, VendedorMO vendedor)
	{
		try
		{
			string select = "  SELECT \r\n                                    CAST(it.seq as smallint) SEQ,\r\n\t                                CASE\r\n\t\t                                WHEN ISNULL(it.SeqKitResultante, 0) != 0 THEN ISNULL(ISNULL(gckit.perc_comis, gckit2.perc_comis), gc.perc_comis)\r\n\t\t                                ELSE ISNULL(gc.perc_comis, 0)\r\n\t                                END AS COMISSAO_PADRAO,\r\n                                    CASE\r\n\t\t                                WHEN ISNULL(it.SeqKitResultante, 0) != 0 THEN ISNULL(ISNULL(gckit.perc_comis, gckit2.perc_comis),0)\r\n\t\t                                ELSE 0\r\n\t                                END AS COMISSAO_PROMOCAO\r\n\r\n                                    FROM\tit_pedv_ele it\r\n\t\t                            JOIN produto pr ON pr.cd_prod = it.cd_prod\r\n\t\t                            JOIN preco pre ON pr.cd_prod = pre.cd_prod \r\n                                                   AND pre.cd_tabela = {3}\r\n\t\t                            LEFT JOIN prod_comis pc\r\n\t\t                            LEFT JOIN grp_comis gc ON pc.cd_grp_comis = gc.cd_grp_comis\r\n\t\t\t\t\t\t\t                               ON pre.cd_prod = pc.cd_prod \r\n                                                           AND pre.cd_tabela = pc.cd_tabela \r\n                                                           AND pc.cd_grupo = {4}\r\n\t\t                            JOIN ped_vda_ele pe ON pe.cd_emp_ele = it.cd_emp_ele \r\n                                                        AND it.nu_ped_ele = pe.nu_ped_ele \r\n                                                        AND it.seq_ped = pe.seq_ped\r\n\t\t                            JOIN promocao cp ON cp.seq_prom = pe.seq_prom\r\n\t\t                            LEFT JOIN grade_desc_it gdi ON cp.seq_grade_desc = gdi.seq_grade_desc\r\n\t\t\t\t\t\t\t\t                                AND pre.seq_grade_desc_it = gdi.seq_grade_desc_it\r\n\t\t                            LEFT JOIN grp_comis gcgd ON gdi.cd_grp_comis = gcgd.cd_grp_comis\t\t\t\t \r\n\t\t                            LEFT JOIN kit_prom_prd kpp ON pr.cd_prod = kpp.cd_prod\r\n\t\t\t\t\t\t\t\t                               AND kpp.seq_kit = it.SeqKitResultante\r\n\t\t\t\t\t\t\t\t                               AND ISNULL(kpp.bonificado, 0) = ISNULL(it.bonificado, 0)\t\t\t\t\t\t\r\n\t\t                            LEFT JOIN grp_comis gckit2 ON kpp.cd_grp_comis = gckit2.cd_grp_comis\t\t\t\t\t   \r\n\t\t                            LEFT JOIN kit_prom_req kpr ON pr.cd_prod = kpr.cd_prod\r\n\t\t\t\t\t\t\t\t                               AND kpr.seq_kit = it.SeqKitResultante\r\n\t\t                            LEFT JOIN grp_comis gckit  ON kpr.cd_grp_comis = gckit.cd_grp_comis\r\n\t\t\t\t\t\t\t\t   \r\n                                    WHERE it.cd_emp_ele = {0} \r\n                                    AND it.nu_ped_ele = {1} \r\n                                    AND it.seq_ped = {2} \r\n\r\n                                    ORDER BY it.seq ";
			return ExecutarSelectSQL<ItemPedidoComissaoVO>(select, new object[5] { pedidoEletronico.CODIGO_EMPRESA_ELETRONICO, pedidoEletronico.NUMERO_PEDIDO_ELETRONICO, pedidoEletronico.SEQ_PEDIDO_ELETRONICO, pedidoVenda.CODIGO_TABELA, vendedor.CODIGO_GRUPO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}
}
