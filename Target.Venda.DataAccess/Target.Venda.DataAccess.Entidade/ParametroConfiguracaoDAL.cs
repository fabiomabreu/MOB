using System;
using System.Linq.Expressions;
using System.Text;
using LinqKit;
using Target.Venda.DataAccess.Base;
using Target.Venda.Model.Entidade;
using Target.Venda.Model.Visao;

namespace Target.Venda.DataAccess.Entidade;

public class ParametroConfiguracaoDAL : EntidadeBaseDAL<ParametroConfiguracaoMO>
{
	protected override Expression<Func<ParametroConfiguracaoMO, bool>> GetWhere(Expression<Func<ParametroConfiguracaoMO, bool>> whereClause, ParametroConfiguracaoMO exemplo)
	{
		if (exemplo.CODIGO_EMPRESA > 0)
		{
			whereClause = whereClause.And((ParametroConfiguracaoMO x) => x.CODIGO_EMPRESA == exemplo.CODIGO_EMPRESA);
		}
		return whereClause;
	}

	public ConfiguracaoVO ObterParametroConfiguracao(int codigoEmpresa)
	{
		StringBuilder stringBuilder = new StringBuilder();
		VersaoERPVO versaoERPVO = new VersaoERPVO();
		versaoERPVO = VersaoDAL.VERSAO_ERP_ATUAL;
		stringBuilder.Append("SELECT  cd_emp CODIGO_EMPRESA  ,\r\n\t                            cast(isnull(perm_ped_vda_end_desatu,0) as BIT) PERM_PED_VDA_END_DESATU ,\r\n\t                            cast(isnull(formpgto_banco_tped_vs,0) as BIT) FORMPGTO_BANCO_TPED_VS ,\r\n\t                            cast(isnull(forma_pagto_assoc_clien,0) as BIT) FORMA_PAGTO_ASSOC_CLIEN  ,\r\n\t                            cast(case when dbo.Crip(utiliza_nfe) = 'SIM' then 1 else 0 end as BIT)  UTILIZA_NFE  ,\r\n\t                            cast(isnull(utiliza_sit_trib_esp_tp_ped,0) as BIT) UTILIZA_SIT_TRIB_ESP_TP_PED  ,\r\n\t                            cast(isnull(volpedvdatipoid,0) as INT) VOL_PEDVDA_TIPO  ,\r\n\t                            cast(isnull(volpedvdaorigemid,0) as INT) VOL_PEDVDA_ORIGEM ,\r\n\t                            cast(isnull(volpedvdaobrigarinformacao,0) as BIT) VOLPEDVDAOBRIGARINFORMACAO ,\r\n\t                            cast(isnull(fila_separacao,0) as BIT) FILA_SEPARACAO ,\r\n\t                            isnull(tp_desc_fin_auto,0) TP_DESC_FIN_AUTO  ,\r\n\t                            cast(isnull(desc_fin_tot_nf,0) as BIT) DESC_FIN_TOT_NF ,\r\n\t                            isnull(nu_dias_desc_fin_auto,0) NU_DIAS_DESC_FIN_AUTO ,\r\n\t                            cast(isnull(unid_pedida,0) as BIT) UNID_PEDIDA ,\r\n\t                            cast(isnull(unid_vda_var,0) as BIT) UNID_VDA_VAR ,\r\n\t                            cast(isnull(desconto_por_quantidade,0) as BIT) DESCONTO_POR_QUANTIDADE ,\r\n\t                            cast(isnull(acrescimo_dif_icm,0) as BIT) ACRESCIMO_DIF_ICM  ,\r\n\t                            cast(isnull(titrec_prox_dia_util,0) as BIT) TITREC_PROX_DIA_UTIL ,\r\n\t                            cast(isnull(utiliza_frete_estado,0) as BIT) UTILIZA_FRETE_ESTADO ,\r\n\t                            cast(isnull(acrescimo_frete,0) as BIT) ACRESCIMO_FRETE  ,\r\n\t                            cast(isnull(frete_utiliza_regtrans,0) as BIT) FRETE_UTILIZA_REGTRANS ,\r\n                                TpRateioFrete TIPO_RATEIO_FRETE,\r\n\t                            isnull(qtde_def_regiao,0) QTDE_DEF_REGIAO  ,\r\n\t                            tp_vl_base_comissao TP_VL_BASE_COMISSAO  ,\r\n\t                            cast(isnull(comis_clien,0) as BIT) COMIS_CLIEN  ,\r\n\t                            isnull(verba_perc_cred,0) VERBA_PERC_CRED  ,\r\n\t                            isnull(verba_perc_cred_emp,0) VERBA_PERC_CRED_EMP ,\r\n\t                            isnull(verba_perc_cred_equip,0) VERBA_PERC_CRED_EQUIP ,\r\n\t                            verba_tp_lanc VERBA_TP_LANC ,\r\n\t                            cast(isnull(desc_geral_red_comis,0) as BIT) DESC_GERAL_RED_COMIS ,\r\n\t                            tp_redutor_comissao TP_REDUTOR_COMISSAO  ,\r\n\t                            tp_custo_comis_mg TP_CUSTO_COMIS_MG ,\r\n\t                            cast(isnull(utiliza_comis_rt,0) as BIT) UTILIZA_COMIS_RT  ,\r\n\t                            cast(isnull(descitem_blq_pedvda,0) as BIT) DESCITEM_BLQ_PEDVDA ,\r\n\t                            cast(isnull(bloq_nf_pf,0) as BIT) BLOQ_NF_PF ,\r\n\t                            cast(isnull(pedido_pf_x_pj,0) as BIT) PEDIDO_PF_X_PJ ,\r\n                                isnull(perc_pedido_pf_x_pj,0) PERC_PEDIDO_PF_X_PJ ,\r\n\t                            cast(isnull(util_controle_grupo_produto,0) as BIT) UTIL_CONTROLE_GRUPO_PRODUTO ,\r\n\t                            cast(isnull(utiliza_grade_desc,0) as BIT) UTILIZA_GRADE_DESC ,\r\n\t                            cast(isnull(nf_item_bonif_valor_vda,0) as BIT) NF_ITEM_BONIF_VALOR_VDA ,\r\n\t                            lanc_cred_verba LANC_CRED_VERBA  ,\r\n\t                            cast(isnull(mg_bruta_desc_fin,0) as BIT) MG_BRUTA_DESC_FIN  ,\r\n\t                            cred_verba_fabr_neg_ind CRED_VERBA_FABR_NEG_IND ,\r\n\t                            cast(isnull(ind_prodpapel,0) as BIT) IND_PRODPAPEL ,\r\n\t                            cast(isnull(verba_fabr_enc_item_estoque,0) as BIT) VERBA_FABR_ENC_ITEM_ESTOQUE,\r\n                                sigla_clien AS SIGLA_CLIENTE,\r\n                                PrecoVenda4Dec as PRECO_VENDA_4_DEC,\r\n                                PrecoVenda4DecCliente AS PRECO_VENDA_4_DEC_CLIENTE,\r\n                                cast( PrecoVendaDecQtde as INT)      AS PRECO_VENDA_4_DEC_QTDE,\r\n                                verba_fabr_tp_custo_bonif AS VERBA_FABR_TP_CUSTO_BONIF,\r\n                                cast(isnull(utiliza_wms,0) as BIT)  UTILIZA_WMS,\r\n\t\t\t\t\t\t\t\tcast(ISNULL(subst_trib_maior_valor,0) AS BIT) SUBST_TRIB_MAIOR_VALOR,\r\n\t\t\t\t\t\t\t\tcast(ISNULL(vda_pf_fe_redicm,0) AS BIT) VDA_PF_FE_REDICM");
		stringBuilder.Append("       ,cast(isnull(ConsideraPrazoMedioProm,0) as BIT) CONSIDERA_PRAZO_MEDIO_PROM,\r\n                                cast(isnull(DescGeralProd,0) as BIT) DESCGERALPROD,\r\n                                cast(isnull(DescGeralNaoRecalculaCorte,0) as BIT) DESCGERALNAORECALCULACORTE,\r\n                                CAST( ISNULL( UtilizaCampanha, 0 ) AS BIT ) UTILIZA_CAMPANHA,\r\n                                CAST( ISNULL( CampanhaUtilizaFilaApur, 0 ) AS BIT ) CAMPANHA_UTILIZA_FILA_APUR,\r\n\t\t\t\t\t\t\t\tCAST(ISNULL(TpPedBonificacaoValorZero, 0) AS BIT) TPPEDBONIFICACAOVALORZERO");
		if (versaoERPVO.MAJOR > 11 || versaoERPVO.MINOR > 2 || versaoERPVO.BUILD > 24 || (versaoERPVO.BUILD >= 24 && versaoERPVO.REVISION >= 1))
		{
			stringBuilder.Append("\t,CAST( ISNULL( CancPedVlMinOrigPed, 0) AS BIT) CANCPEDVLMINORIGPED");
		}
		stringBuilder.AppendLine(" FROM par_cfg\r\n                                WHERE cd_emp = {0}");
		return ExecutarScalarSQL<ConfiguracaoVO>(stringBuilder.ToString(), new object[1] { codigoEmpresa });
	}

	public bool VerificaExistenciaObjeto(string nomeObjeto)
	{
		string select = "SELECT \r\n                            CONVERT(BIT, 1) \r\n                        FROM\r\n                            sys.objects \r\n                        WHERE \r\n                            name = {0}";
		return ExecutarScalarSQL<bool>(select, new object[1] { nomeObjeto });
	}
}
