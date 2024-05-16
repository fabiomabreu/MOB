using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Helpers.Log;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class ItemPedidoDAL : EntidadeBaseDAL<ItemPedidoMO>
{
	protected override Expression<Func<ItemPedidoMO, bool>> GetWhere(Expression<Func<ItemPedidoMO, bool>> whereClause, ItemPedidoMO exemplo)
	{
		if (exemplo.NUMERO_PEDIDO > 0)
		{
			whereClause = whereClause.And((ItemPedidoMO x) => x.NUMERO_PEDIDO == exemplo.NUMERO_PEDIDO);
		}
		if (exemplo.CODIGO_EMPRESA > 0)
		{
			whereClause = whereClause.And((ItemPedidoMO x) => x.CODIGO_EMPRESA == exemplo.CODIGO_EMPRESA);
		}
		return whereClause;
	}

	private string ObterColunaSituacaoTributaria(string codigoTipoSituacaoTibutaria, bool devolucaoFornecedor, bool utilizaSitTribEspTpPed, bool utilizaSitTribEspTpPedEsp)
	{
		string empty = string.Empty;
		if (devolucaoFornecedor)
		{
			return "cd_sit_trib_compra";
		}
		if (codigoTipoSituacaoTibutaria == "PDR")
		{
			return "cd_sit_trib";
		}
		if (codigoTipoSituacaoTibutaria == "ESP" && !utilizaSitTribEspTpPed)
		{
			return "cd_sit_trib_esp";
		}
		if (codigoTipoSituacaoTibutaria == "ESP" && utilizaSitTribEspTpPed && utilizaSitTribEspTpPedEsp)
		{
			return "cd_sit_trib_esp";
		}
		if (codigoTipoSituacaoTibutaria == "RES")
		{
			return "cd_sit_trib_red_esp";
		}
		if (codigoTipoSituacaoTibutaria == "EXC")
		{
			return "cd_sit_trib_excecao";
		}
		return "cd_sit_trib";
	}

	public int QuantidadeItensAtendidosPedidoEletronico(PedidoEletronicoMO pedidoEletronicoMO)
	{
		string select = " SELECT COUNT(*)\r\n                         FROM it_pedv_ele it\r\n                         WHERE it.cd_emp_ele = {0}\r\n                         AND it.nu_ped_ele = {1}\r\n                         AND it.seq_ped = {2}\r\n                         AND it.QtdeAtendida > 0 ";
		return ExecutarScalarSQL<int>(select, new object[3] { pedidoEletronicoMO.CODIGO_EMPRESA_ELETRONICO, pedidoEletronicoMO.NUMERO_PEDIDO_ELETRONICO, pedidoEletronicoMO.SEQ_PEDIDO_ELETRONICO });
	}

	public void IncluirPapelCortado(PedidoVendaMO pedidoVenda, ItemPedidoMO item)
	{
		string comando = "INSERT INTO itpvcomp \r\n                                     ( cd_emp,  \r\n                                        nu_ped,  \r\n                                        seq,  \r\n                                        comp_cortado, \r\n                                        larg_cortado, \r\n                                        num_folhas_pctcort, \r\n                                        qtde_milheiro, \r\n                                        preco_unit_cort, \r\n                                        qtde_pct_cort ) \r\n                                     VALUES\r\n                                     (  :par_nu_cd_emp,\r\n                                        :par_nu_ped, \r\n                                        :tab_vendas.tbl_pedido.col_seq,  \r\n                                        :tab_vendas.tbl_pedido.col_nu_comp_cort, \r\n                                        :tab_vendas.tbl_pedido.col_nu_larg_cort, \r\n                                        :tab_vendas.tbl_pedido.col_nu_folhas_pct, \r\n                                        :tab_vendas.tbl_pedido.col_nu_qtde_milheiro, \r\n                                        :tab_vendas.tbl_pedido.col_nu_vl_unit_milheiro, \r\n                                        :tab_vendas.tbl_pedido.col_nu_qtde_pct ) ";
		ExecutarSqlCommand(comando, item.CODIGO_EMPRESA, item.NUMERO_PEDIDO, item.SEQ, 0, 0, 0, 0, 0, 0);
	}

	public List<ItemPedidoBasicoVO> ObterDadosItemPedidoBasico(FiltroItemPedidoVO filtro)
	{
		try
		{
			string select = " SELECT CAST(it.seq as smallint) SEQ\r\n                                          FROM it_pedv_ele it\r\n                                          WHERE it.cd_emp_ele = {0}\r\n                                          AND it.nu_ped_ele = {1}\r\n                                          AND it.seq_ped = {2} \r\n                                          ORDER BY it.seq ";
			return ExecutarSelectSQL<ItemPedidoBasicoVO>(select, new object[3] { filtro.CODIGO_EMPRESA_ELETRONICO, filtro.NUMERO_PEDIDO_ELETRONICO, filtro.SEQ_PEDIDO_ELETRONICO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemPedidoProdutoVO> ObterDadosItemPedidoProduto(FiltroItemPedidoVO filtro)
	{
		try
		{
			string select = "  SELECT \r\n                                    CAST(it.seq as smallint) SEQ,\r\n                                    \r\n                                    --Produto\r\n                                    it.cd_prod CODIGO_PRODUTO,\r\n                                    pr.cd_linha\tAS CODIGO_LINHA,\r\n                                    pr.cd_grupo_prd AS CODIGO_GRUPO_PRODUTO,\r\n                                    pr.prz_medio_max AS PRAZO_MEDIO_MAXIMO,\r\n                                    ISNULL(pr.controlado, 0) AS PRODUTO_CONTROLADO,\r\n\r\n                                    --Descricao\r\n                                    pr.descricao AS DESCRICAO,\r\n\r\n                                    --Unidade \\ Volumes\r\n                                    up.unid_vda AS UNIDADE_VENDA,\r\n                                    it.unid_ped\tAS UNIDADE_PEDIDA,\r\n                                    pr.unid_est AS UNIDADE,\r\n                                    pr.inf_volumes AS INFO_VOLUMES,\r\n                                    pr.volume AS VOLUME,\r\n\r\n                                    --Estoque\r\n                                    it.ind_relacao INDICE_RELACAO,\r\n                                    up.ind_relacao AS INDICE_RELACAO_VENDA,\r\n                                    up.fator_preco AS FATOR_PRECO,\r\n                                    CAST(CONVERT(NUMERIC(15,4),it.fator_est_ped) AS FLOAT) AS FATOR_ESTOQUE_PEDIDA,\r\n                                    up.fator_estoque AS FATOR_ESTOQUE_VENDA,\r\n                                    CAST(it.EstoqueZerado AS tinyint) AS ESTOQUE_ZERADO,\r\n                                    CAST(CASE WHEN it.QtdeFalta > 0 THEN 1\tELSE 0\tEND AS bit) ESTOQUE_INSUFICIENTE,\r\n\r\n                                    --Peso\r\n                                    pr.peso_brt AS PESO_BRUTO,\r\n                                    pr.peso_liq AS PESO_LIQUIDO,\r\n\r\n                                    --Quantidade\r\n                                    pr.qtde_multipla AS QUANTIDADE_MULTIPLA,\r\n                                    ISNULL(it.QtdeAtendida,0)  AS QUANTIDADE_UNIDADE_VENDA,\r\n                                    ISNULL(it.QtdeAtendidaUnidPed,0) AS QUANTIDADE_UNIDADE_PEDIDA,\r\n                                    ISNULL(it.QtdeAtendida,0)  AS QUANTIDADE,\r\n\r\n                                    --Impostos\r\n                                    cast(pr.aliq_ipi as numeric(6,4)) as ALIQUOTA_IPI,\r\n\r\n                                    it.DtIniValidadeLote AS DT_INI_VALIDADE_LOTE,\r\n                                    it.DtFimValidadeLote AS DT_FIM_VALIDADE_LOTE\r\n                                    \r\n                                    FROM it_pedv_ele it\r\n                                    JOIN produto pr ON pr.cd_prod = it.cd_prod\r\n                                    JOIN fabric fa ON fa.cd_fabric = pr.cd_fabric\r\n                                    JOIN unid_prod up ON up.cd_prod = it.cd_prod AND up.principal = 1 AND up.venda = 1 AND up.ativo = 1\r\n                                    JOIN unidade un ON un.unidade = up.unid_vda\r\n                                    \r\n                                    WHERE it.cd_emp_ele = {0}\r\n                                    AND it.nu_ped_ele = {1}\r\n                                    AND it.seq_ped = {2} \r\n                                    \r\n                                    ORDER BY it.seq ";
			return ExecutarSelectSQL<ItemPedidoProdutoVO>(select, new object[3] { filtro.CODIGO_EMPRESA_ELETRONICO, filtro.NUMERO_PEDIDO_ELETRONICO, filtro.SEQ_PEDIDO_ELETRONICO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemPedidoPrecoVO> ObterDadosItemPedidoPreco(FiltroItemPedidoVO filtro)
	{
		try
		{
			string text = "CASE    WHEN    pr.preco_fixo = 1\r\n\t\t\t\t                                THEN    it.preco_unit \r\n\t\t\t\t                                ELSE    it.preco_unit / cp.coef_total\r\n\t\t\t                            END ";
			string text2 = "it.preco_unit";
			string text3 = "it.desc01";
			string text4 = "it.desc02";
			if (!filtro.MANTER_DESCONTO_APLICADO_PEDIDO_ELETRONICO && !filtro.UTILIZA_PRECO_CUSTO)
			{
				text = "pre.vl_preco";
				text2 = "pre.vl_preco";
				text3 = "it.desc_apl";
				text4 = "0.0";
			}
			string empty = string.Empty;
			empty = "  SELECT Cast(it.seq as smallint)                      SEQ, \r\n                                    CASE \r\n\t\t\t\t\t\t\t\t\t\tWHEN ISNULL(kp.PrecoFixo,0) != 0 \r\n\t\t\t\t\t\t\t\t\t\t\tTHEN pre.vl_preco\r\n\t\t\t\t\t\t\t\t\t    ELSE " + text + " END              AS PRECO_BASICO, \r\n                                    Round(( it.QtdeAtendida * it.preco_unit ), 2) AS TOTAL, \r\n                                    it.preco_unit                                 PRECO_UNITARIO, \r\n                                    --(Duplicados) \r\n                                    CASE \r\n                                        WHEN ISNULL(kp.PrecoFixo,0) != 0 \r\n                                        THEN\r\n                                            pre.vl_preco\r\n                                    ELSE\r\n                                    " + text2 + " END                         AS PRECO_TABELA, \r\n                                    --(Duplicados) \r\n                                    CASE \r\n                                        WHEN ISNULL(kp.PrecoFixo,0) != 0 \r\n                                        THEN\r\n                                            pre.vl_preco\r\n                                    ELSE\r\n                                    " + text2 + " END                        AS VALOR_ORIGINAL, \r\n                                    --(Duplicados) \r\n                                    CASE \r\n                                        WHEN ISNULL(kp.PrecoFixo,0) != 0 \r\n                                        THEN\r\n                                            pre.vl_preco\r\n                                    ELSE\r\n                                    " + text2 + " END                       AS PRECO_NOTA_FISCAL,\r\n                                    --(Duplicados) \r\n                                    CASE \r\n                                        WHEN pe.NuNfCompraTransf IS NULL THEN \r\n                                        CASE \r\n                                            WHEN ( pcfg.PrecoVenda4Dec = 1 \r\n                                                AND pcfg.PrecoVenda4DecCliente = 0 ) THEN Round( it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ), pcfg.PrecoVendaDecQtde) \r\n                                            ELSE \r\n                                            CASE \r\n                                                WHEN ( pcfg.PrecoVenda4Dec = 1 \r\n                                                    AND pcfg.PrecoVenda4DecCliente = 1 ) THEN \r\n                                                CASE \r\n                                                    WHEN ( c.PrecoVenda4Dec = 1 ) THEN Round(it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ), pcfg.PrecoVendaDecQtde) \r\n                                                    ELSE Round(it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ), 2) \r\n                                                END \r\n                                                ELSE Round(it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ),2)\r\n                                            END  \r\n                                        END \r\n                                        ELSE it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ) \r\n                                    END                                           VALOR_UNITARIO_VENDA, --(Duplicados) \r\n                                    CASE \r\n                                        WHEN pe.NuNfCompraTransf IS NULL THEN \r\n                                        CASE \r\n                                            WHEN ( pcfg.PrecoVenda4Dec = 1 \r\n                                                AND pcfg.PrecoVenda4DecCliente = 0 ) THEN Round( it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ), pcfg.PrecoVendaDecQtde) \r\n                                            ELSE \r\n                                            CASE \r\n                                                WHEN ( pcfg.PrecoVenda4Dec = 1 \r\n                                                    AND pcfg.PrecoVenda4DecCliente = 1 ) THEN \r\n                                                CASE \r\n                                                    WHEN ( c.PrecoVenda4Dec = 1 ) THEN Round(it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ), pcfg.PrecoVendaDecQtde) \r\n                                                    ELSE Round(it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ), 2) \r\n                                                END \r\n                                                ELSE Round(it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ),2) \r\n                                            END \r\n                                        END \r\n                                        ELSE it.vl_unit_ped * ( 1 - ISNULL(it.desc_apl, 0) ) \r\n                                    END                                           VALOR_UNITARIO_PEDIDA, --(Duplicados) \r\n                                    --Desconto \r\n                                    pe.per_desc_fin                               as \r\n                                    PERCENTUAL_DESCONTO_FINANCEIRO, \r\n                                    CASE WHEN pcfg.tp_desc_fin_auto = 'FACL'                                   \r\n                                        THEN    dfc.PercDescFinAuto\r\n                                        ELSE    pre.perc_desc_fin_auto \r\n                                    END\r\n                                    PERCENTUAL_DESCONTO_FINANCEIRO_AUTO, \r\n                                    CASE \r\n                                        WHEN ISNULL(kp.PrecoFixo,0) != 0  AND ISNULL(it.bonificado,0) = 0\r\n                                        THEN 0\r\n                                        ELSE it.desc_apl                          \r\n\t\t\t\t\t\t\t\t\tEND                                         DESCONTO_APLICADO,\r\n                                    " + text3 + "                AS DESCONTO_01, \r\n                                    " + text4 + "                 AS DESCONTO_02, \r\n                                    it.desc_grd_bon                               DESCONTO_GRADE_BONIFICADO, \r\n                                    it.desc_grd_com                               DESCONTO_GRADE_COMERCIAL, \r\n                                    it.desc_grd_fin                               DESCONTO_GRADE_FINANCEIRO, \r\n                                    --Condicao Pagamento \r\n                                    CASE\r\n\t\t\t\t\t\t\t\t\t\tWHEN COALESCE(pr.preco_fixo, 0) = 0 THEN cp.coef_total\r\n\t\t\t\t\t\t\t\t\t\tELSE 1\r\n\t\t\t\t\t\t\t\t\tEND                                          COEFICIENTE_CUSTO_FINANCEIRO,\r\n                                    it.SeqProm                                    SEQ_PROMOCAO\r\n                                FROM   it_pedv_ele it \r\n                                        JOIN produto pr \r\n                                            ON pr.cd_prod = it.cd_prod \r\n                                        JOIN preco pre \r\n                                            ON it.cd_prod = pre.cd_prod \r\n                                            AND pre.cd_tabela = {3} \r\n                                        JOIN ped_vda_ele pe \r\n                                            ON pe.cd_emp_ele = it.cd_emp_ele \r\n                                            AND pe.nu_ped_ele = it.nu_ped_ele \r\n                                            AND pe.seq_ped = it.seq_ped \r\n                                        JOIN promocao cp \r\n                                            ON cp.seq_prom = pe.seq_prom \r\n                                        JOIN par_cfg pcfg \r\n                                            ON pcfg.cd_emp = pe.cd_emp_ele \r\n                                        JOIN cliente c \r\n                                            ON c.cd_clien = pe.cd_clien  \r\n\t\t\t\t\t\t\t\t\t\tLEFT JOIN kit_prom kp\r\n\t\t\t\t\t\t\t\t\t\t\tON\tit.seq_kit = kp.seq_kit\r\n                                        LEFT JOIN   DescFinFabCli dfc\r\n                                            ON  pr.cd_fabric = dfc.CdFabric\r\n                                            AND pe.cd_clien = dfc.CdClien\r\n                            WHERE  it.cd_emp_ele = {0} \r\n                                    AND it.nu_ped_ele = {1} \r\n                                    AND it.seq_ped = {2} \r\n                            ORDER  BY it.seq  ";
			return ExecutarSelectSQL<ItemPedidoPrecoVO>(empty, new object[4] { filtro.CODIGO_EMPRESA_ELETRONICO, filtro.NUMERO_PEDIDO_ELETRONICO, filtro.SEQ_PEDIDO_ELETRONICO, filtro.CODIGO_TABELA });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemPedidoKitPromocaoVO> ObterDadosItemPedidoKitPromocao(FiltroItemPedidoVO filtro)
	{
		try
		{
			string select = " SELECT\r\n                                   CAST(it.seq as smallint) SEQ,\r\n\r\n                                   --Kit Promocao\r\n                                   it.SeqKitResultante\tSEQ_KIT_PROMOCAO,\r\n\r\n                                    CASE WHEN kprom.flexivel = 1\r\n\t\t\t\t\t                            THEN ISNULL( kpr.perc_desc, 0)\t\r\n\t\t\t\t\t                           ELSE ISNULL( kpp.perc_desc, 0)\t\r\n                                    END\tas PERCENTUAL_DESCONTO_AUX,\r\n\r\n                                   --Bonificado\r\n                                   CAST(it.bonificado as tinyint)\tBONIFICADO,\r\n                                   CASE WHEN it.SeqKitResultante IS NOT NULL AND (it.bonificado = 0 or it.bonificado is null) then 'R'\t\t\r\n                                        WHEN  it.SeqKitResultante IS NOT NULL AND it.bonificado = 1  then 'B'\tELSE ''\r\n                                   END  REQUISITO_BONIFICADO,\r\n                                   \r\n                                   --Verba\r\n                                   it.vl_verba\tVALOR_VERBA,\r\n                                   it.VlVerbaFabr\tVALOR_VERBA_FABRICANTE_ADIC,\r\n\t\t\t\t\t\t\t\t   CASE\tWHEN ISNULL(kprom.flexivel,0) = 0 AND ISNULL(kprom.FlexVerbaVend,0) = 1 THEN CONVERT(BIT,1)\r\n\t\t\t\t\t\t\t\t\t\tWHEN it.SeqKitResultante IS NOT NULL AND it.bonificado = 1 THEN ISNULL(kpb.VerbaVend, 0)\r\n\t\t\t\t\t\t\t\t\t\tELSE ISNULL(kpr.VerbaVend,0)\r\n\t\t\t\t\t\t\t\t\tEND VERBA_VENDEDOR,\r\n\r\n                                   CASE      \r\n                                        WHEN ISNULL(kprom.flexivel,0) = 0 AND ISNULL(kprom.FlexVerbaVend,0) = 1 \r\n                                                                          AND ISNULL(kpp.bonificado, 0) = 1 \r\n                                             THEN CONVERT(BIT,1) \r\n                                        ELSE\r\n                                             ISNULL(kpb.VerbaVend,0)\r\n                                    END  VERBA_VENDEDOR_BONIF,\r\n                                   ISNULL(kprom.PrecoFixo, 0)               CONSIDERA_PRECO_PROMOCAO,\r\n                                   ISNULL(kprom.ConsideraRedComissao,0)     PROMOCAO_CONSIDERA_REDUCAO_COMISSAO\r\n                                   \r\n                                   FROM it_pedv_ele it\r\n                                   LEFT JOIN kit_prom kprom ON it.SeqKitResultante = kprom.seq_kit\r\n                                   LEFT JOIN kit_prom_benef kpb ON kpb.cd_prod = it.cd_prod \r\n                                         AND kpb.seq_kit = it.SeqKitResultante\r\n                                   LEFT JOIN kit_prom_req kpr ON it.cd_prod = kpr.cd_prod \r\n                                         AND kpr.seq_kit = it.SeqKitResultante\r\n                                   LEFT JOIN kit_prom_prd kpp ON it.cd_prod = kpp.cd_prod\r\n\t\t\t\t\t\t\t\t         AND kpp.seq_kit = it.SeqKitResultante\r\n\t\t\t\t\t\t\t\t         AND ISNULL(kpp.bonificado, 0) = ISNULL(it.bonificado, 0)\t\r\n                                   \r\n                                   WHERE it.cd_emp_ele = {0}\r\n                                     AND it.nu_ped_ele = {1}\r\n                                     AND it.seq_ped = {2} \r\n                                   \r\n                                   ORDER BY it.seq";
			return ExecutarSelectSQL<ItemPedidoKitPromocaoVO>(select, new object[3] { filtro.CODIGO_EMPRESA_ELETRONICO, filtro.NUMERO_PEDIDO_ELETRONICO, filtro.SEQ_PEDIDO_ELETRONICO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemPedidoComissaoVO> ObterDadosItemPedidoComissao(FiltroItemPedidoVO filtro)
	{
		try
		{
			string select = "  SELECT \r\n                                    CAST(it.seq as smallint) SEQ,\r\n\t                                CASE\r\n\t\t                                WHEN ISNULL(it.SeqKitResultante, 0) != 0 THEN ISNULL(ISNULL(gckit.perc_comis, gckit2.perc_comis), gc.perc_comis)\r\n\t\t                                ELSE ISNULL(gc.perc_comis, 0)\r\n\t                                END AS COMISSAO_PADRAO,\r\n                                    CASE\r\n\t\t                                WHEN ISNULL(it.SeqKitResultante, 0) != 0 THEN ISNULL(ISNULL(gckit.perc_comis, gckit2.perc_comis),0)\r\n\t\t                                ELSE 0\r\n\t                                END AS COMISSAO_PROMOCAO\r\n\r\n                                    FROM\tit_pedv_ele it\r\n\t\t                            JOIN produto pr ON pr.cd_prod = it.cd_prod\r\n\t\t                            JOIN preco pre ON pr.cd_prod = pre.cd_prod \r\n                                                   AND pre.cd_tabela = {3}\r\n\t\t                            LEFT JOIN prod_comis pc\r\n\t\t                            LEFT JOIN grp_comis gc ON pc.cd_grp_comis = gc.cd_grp_comis\r\n\t\t\t\t\t\t\t                               ON pre.cd_prod = pc.cd_prod \r\n                                                           AND pre.cd_tabela = pc.cd_tabela \r\n                                                           AND pc.cd_grupo = {4}\r\n\t\t                            JOIN ped_vda_ele pe ON pe.cd_emp_ele = it.cd_emp_ele \r\n                                                        AND it.nu_ped_ele = pe.nu_ped_ele \r\n                                                        AND it.seq_ped = pe.seq_ped\r\n\t\t                            JOIN promocao cp ON cp.seq_prom = pe.seq_prom\r\n\t\t                            LEFT JOIN grade_desc_it gdi ON cp.seq_grade_desc = gdi.seq_grade_desc\r\n\t\t\t\t\t\t\t\t                                AND pre.seq_grade_desc_it = gdi.seq_grade_desc_it\r\n\t\t                            LEFT JOIN grp_comis gcgd ON gdi.cd_grp_comis = gcgd.cd_grp_comis\t\t\t\t \r\n\t\t                            LEFT JOIN kit_prom_prd kpp ON pr.cd_prod = kpp.cd_prod\r\n\t\t\t\t\t\t\t\t                               AND kpp.seq_kit = it.SeqKitResultante\r\n\t\t\t\t\t\t\t\t                               AND ISNULL(kpp.bonificado, 0) = ISNULL(it.bonificado, 0)\t\t\t\t\t\t\r\n\t\t                            LEFT JOIN grp_comis gckit2 ON kpp.cd_grp_comis = gckit2.cd_grp_comis\t\t\t\t\t   \r\n\t\t                            LEFT JOIN kit_prom_req kpr ON pr.cd_prod = kpr.cd_prod\r\n\t\t\t\t\t\t\t\t                               AND kpr.seq_kit = it.SeqKitResultante\r\n\t\t                            LEFT JOIN grp_comis gckit  ON kpr.cd_grp_comis = gckit.cd_grp_comis\r\n\t\t\t\t\t\t\t\t   \r\n                                    WHERE it.cd_emp_ele = {0} \r\n                                    AND it.nu_ped_ele = {1} \r\n                                    AND it.seq_ped = {2} \r\n\r\n                                    ORDER BY it.seq ";
			return ExecutarSelectSQL<ItemPedidoComissaoVO>(select, new object[5] { filtro.CODIGO_EMPRESA_ELETRONICO, filtro.NUMERO_PEDIDO_ELETRONICO, filtro.SEQ_PEDIDO_ELETRONICO, filtro.CODIGO_TABELA, filtro.CODIGO_GRUPO_COMISSAO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemPedidoFiscalVO> ObterDadosItemPedidoFiscal(FiltroItemPedidoVO filtro)
	{
		try
		{
			string text = ObterColunaSituacaoTributaria(filtro.CODIGO_TRIBUTACAO_TIPO_SIT_TRIB, filtro.DEVOLUCAO_FORNECEDOR, filtro.UTILIZA_SIT_TRIB_ESP_TP_PED, filtro.UTILIZA_SITUACAO_TRIBUTACAO_ESP);
			string text2 = string.Empty;
			if (!filtro.IMPRIME_NOTA_FISCAL)
			{
				text2 = " AND ISNULL( pr.controlado, 0 ) = 0 ";
			}
			string text3 = ((!(text == "cd_sit_trib_compra")) ? "\t{3}, {4} ) " : "\t{4}, {3} ) ");
			string select = " SELECT \r\n                                CAST(it.seq as smallint) SEQ,\r\n                                CAST(si.st_adic_item as BIT) AS ST_ADICIONAL_ITEM,\r\n                                    \r\n                                'AB' AS SITUACAO,\r\n\r\n                                --Impostos\r\n                                CAST( ( it.QtdeAtendida * it.preco_unit ) * pr.aliq_ipi as decimal(13,2) ) VALOR_IPI,\r\n                                CAST(pr.aliq_ipi as decimal(6,4) )\tALIQUOTA_IPI,\r\n                                   \r\n                                --Restrição\r\n                                CAST(ISNULL(pr.lib_fiscal, 0) AS BIT) AS LIBERACAO_FISCAL,\r\n                                CAST(pr.venda_casada as tinyint) AS VENDA_CASADA,\r\n                                CAST(CASE WHEN (rvd.cd_prod IS NOT NULL) \r\n                                            THEN 1 ELSE 0 \r\n                                        END AS tinyint) AS RESTRICAO_VENDA,\r\n                                ic." + text + " CD_SIT_TRIB,\r\n                                CAST(si.incide_icm_subst as BIT) AS INCIDE_ICMS_SUBST,\r\n                                CAST(si.substrib_icms_compra as BIT) AS SUBSTRIB_ICMS_COMPRA\r\n\r\n\r\n                                FROM \r\n                                it_pedv_ele it\r\n                                    \r\n                                JOIN produto pr \r\n                                ON pr.cd_prod = it.cd_prod\r\n\r\n                                JOIN fabric fa \r\n                                ON fa.cd_fabric = pr.cd_fabric                                   \r\n\r\n                                CROSS APPLY dbo.ufnIcmProd( {0}, it.cd_prod, " + text3 + " ic                                    \r\n\r\n                                JOIN sit_trib si \r\n                                ON ic." + text + " = si.cd_sit_trib\r\n                                   \r\n                                LEFT JOIN ped_vda_ele pe ON pe.cd_emp_ele = it.cd_emp_ele \r\n                                        AND pe.nu_ped_ele = it.nu_ped_ele \r\n                                        AND pe.seq_ped = it.seq_ped\r\n                                LEFT JOIN restr_vda rvd ON rvd.cd_clien = pe.cd_clien \r\n                                        AND rvd.cd_prod = it.cd_prod\r\n                                WHERE \r\n                                    it.cd_emp_ele = {0}\r\n                                    AND it.nu_ped_ele = {1}\r\n                                    AND it.seq_ped = {2} \r\n                                    AND ic.cd_prod = pr.cd_prod \r\n                                    " + text2 + "\r\n                                ORDER BY it.seq ";
			return ExecutarSelectSQL<ItemPedidoFiscalVO>(select, new object[5] { filtro.CODIGO_EMPRESA_ELETRONICO, filtro.NUMERO_PEDIDO_ELETRONICO, filtro.SEQ_PEDIDO_ELETRONICO, filtro.ESTADO_ORIGEM, filtro.ESTADO_DESTINO });
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	public List<ItemPedidoMO> ObterItensPedido(FiltroItemPedidoVO filtro)
	{
		try
		{
			List<ItemPedidoBasicoVO> list = ObterDadosItemPedidoBasico(filtro);
			int count = list.Count;
			List<ItemPedidoProdutoVO> list2 = ObterDadosItemPedidoProduto(filtro);
			if (list2.Count != count)
			{
				throw new Exception("Erro ao obter dados de produtos no carregamento dos itens do pedido");
			}
			List<ItemPedidoPrecoVO> list3 = ObterDadosItemPedidoPreco(filtro);
			if (list3.Count != count)
			{
				throw new Exception("Erro ao obter dados de preços no carregamento dos itens do pedido");
			}
			List<ItemPedidoKitPromocaoVO> list4 = ObterDadosItemPedidoKitPromocao(filtro);
			if (list4.Count != count)
			{
				throw new Exception("Erro ao obter dados de promoções no carregamento dos itens do pedido");
			}
			List<ItemPedidoFiscalVO> list5 = ObterDadosItemPedidoFiscal(filtro);
			if (list5.Count != count)
			{
				throw new Exception("Erro ao obter dados fiscais no carregamento dos itens do pedido");
			}
			List<ItemPedidoMO> list6 = new List<ItemPedidoMO>();
			foreach (ItemPedidoBasicoVO item in list)
			{
				ItemPedidoProdutoVO produto = list2.Find((ItemPedidoProdutoVO x) => x.SEQ == item.SEQ);
				ItemPedidoPrecoVO preco = list3.Find((ItemPedidoPrecoVO x) => x.SEQ == item.SEQ);
				ItemPedidoKitPromocaoVO kitPromocao = list4.Find((ItemPedidoKitPromocaoVO x) => x.SEQ == item.SEQ);
				ItemPedidoFiscalVO fiscal = list5.Find((ItemPedidoFiscalVO x) => x.SEQ == item.SEQ);
				ItemPedidoMO item2 = MontarItemPedidoMO(produto, preco, kitPromocao, new ItemPedidoComissaoVO(), fiscal);
				list6.Add(item2);
			}
			return list6;
		}
		catch (Exception ex)
		{
			LogHelper.ErroLog(ex);
			throw ex;
		}
	}

	private ItemPedidoMO MontarItemPedidoMO(ItemPedidoProdutoVO produto, ItemPedidoPrecoVO preco, ItemPedidoKitPromocaoVO kitPromocao, ItemPedidoComissaoVO comissao, ItemPedidoFiscalVO fiscal)
	{
		try
		{
			ItemPedidoMO itemPedidoMO = new ItemPedidoMO();
			List<PropertyInfo> propsItemPedido = itemPedidoMO.GetType().GetProperties().ToList();
			TransformarObjetoItemPedido(itemPedidoMO, propsItemPedido, produto);
			TransformarObjetoItemPedido(itemPedidoMO, propsItemPedido, preco);
			TransformarObjetoItemPedido(itemPedidoMO, propsItemPedido, kitPromocao);
			TransformarObjetoItemPedido(itemPedidoMO, propsItemPedido, comissao);
			TransformarObjetoItemPedido(itemPedidoMO, propsItemPedido, fiscal);
			return itemPedidoMO;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void TransformarObjetoItemPedido(ItemPedidoMO itemPedido, List<PropertyInfo> propsItemPedido, object partObjeto)
	{
		List<PropertyInfo> list = partObjeto.GetType().GetProperties().ToList();
		foreach (PropertyInfo propObj in list)
		{
			PropertyInfo propertyInfo = propsItemPedido.Find((PropertyInfo x) => x.Name == propObj.Name);
			if (propertyInfo == null)
			{
				throw new Exception($"Não encontrado relação entre a propriedade {propObj.Name} do objeto {partObjeto.GetType().Name} e o objeto ItemPedidoMO");
			}
			object value = propObj.GetValue(partObjeto, null);
			propertyInfo.SetValue(itemPedido, value, null);
		}
	}
}
