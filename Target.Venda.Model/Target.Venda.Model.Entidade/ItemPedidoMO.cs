using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("it_pedv")]
public class ItemPedidoMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("nu_ped", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO { get; set; }

	[Column("seq", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public short SEQ { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("qtde")]
	[DecimalPrecision(13, 4)]
	public decimal QUANTIDADE { get; set; }

	[Column("unidade")]
	public string UNIDADE { get; set; }

	[Column("preco_tabela")]
	[DecimalPrecision(15, 4)]
	public decimal PRECO_TABELA { get; set; }

	[Column("desc_apl")]
	[DecimalPrecision(6, 4)]
	public decimal? DESCONTO_APLICADO { get; set; }

	[Column("desc_apl_real")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_APLICADO_REAL { get; set; }

	[Column("preco_unit")]
	[DecimalPrecision(15, 4)]
	public decimal? PRECO_UNITARIO { get; set; }

	[Column("preco_nf")]
	[DecimalPrecision(15, 4)]
	public decimal? PRECO_NOTA_FISCAL { get; set; }

	[Column("preco_nf_serv")]
	[DecimalPrecision(13, 2)]
	public decimal? PRECO_NOTA_FISCAL_SERVICO { get; set; }

	[Column("preco_basico")]
	[DecimalPrecision(15, 4)]
	public decimal? PRECO_BASICO { get; set; }

	[Column("vl_base_comissao")]
	[DecimalPrecision(15, 4)]
	public decimal? VALOR_BASE_COMISSAO { get; set; }

	[Column("perc_desc_ger")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_DESCONTO_GERAL { get; set; }

	[Column("perc_desc_fin")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO { get; set; }

	[Column("descperm_prodqtde")]
	[DecimalPrecision(6, 4)]
	public decimal? DESCONTO_PERMITIDO_PRODUTO_QUANTIDADE { get; set; }

	[Column("est_insuf")]
	public bool? ESTOQUE_INSUFICIENTE { get; set; }

	[Column("aliq_ipi")]
	[DecimalPrecision(6, 4)]
	public decimal? ALIQUOTA_IPI { get; set; }

	[Column("aliq_icm")]
	[DecimalPrecision(6, 4)]
	public decimal? ALIQUOTA_ICMS { get; set; }

	[Column("vl_ipi")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_IPI { get; set; }

	[Column("vl_comis")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_COMISSAO { get; set; }

	[Column("vda_av")]
	[DecimalPrecision(13, 2)]
	public decimal? VENDA_AV { get; set; }

	[Column("custo_av")]
	[DecimalPrecision(13, 2)]
	public decimal? CUSTO_AV { get; set; }

	[Column("vda_liq")]
	[DecimalPrecision(13, 2)]
	public decimal? VENDA_LIQUIDA { get; set; }

	[Column("red_comissao")]
	[DecimalPrecision(6, 4)]
	public decimal? REDUCAO_COMISSAO { get; set; }

	[Column("comissao_padrao")]
	[DecimalPrecision(6, 4)]
	public decimal? COMISSAO_PADRAO { get; set; }

	[Column("perc_com")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_COMISSAO { get; set; }

	[Column("nu_nf")]
	public int? NUMERO_NOTA_FISCAL { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("unid_vda")]
	public string UNIDADE_VENDA { get; set; }

	[Column("qtde_unid_vda")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_UNIDADE_VENDA { get; set; }

	[Column("ind_relacao_vda")]
	public string INDICE_RELACAO_VENDA { get; set; }

	[DecimalPrecision(13, 4)]
	[Column("fator_est_vda")]
	public decimal? FATOR_ESTOQUE_VENDA { get; set; }

	[Column("vl_unit_vda")]
	[DecimalPrecision(15, 4)]
	public decimal? VALOR_UNITARIO_VENDA { get; set; }

	[Column("perc_acres_dif_icm")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_ACRESCIMO_DIF_ICMS { get; set; }

	[Column("perc_acres_frete")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_ACRESCIMO_FRETE { get; set; }

	[Column("qtde_volumes")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_VOLUMES { get; set; }

	[Column("papel_cortado")]
	public bool? PAPEL_CORTADO { get; set; }

	[Column("consig_concluida")]
	public bool? CONSIGNACAO_CONCLUIDA { get; set; }

	[Column("qtde_consig_vend")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_CONSIGNADO_VENDIDA { get; set; }

	[Column("qtde_consig_dev")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_CONSIGNADO_DEVOLVIDA { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("fator_est_ped")]
	public double? FATOR_ESTOQUE_PEDIDA { get; set; }

	[Column("unid_ped")]
	public string UNIDADE_PEDIDA { get; set; }

	[Column("qtde_unid_ped")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_UNIDADE_PEDIDA { get; set; }

	[Column("ind_relacao")]
	public string INDICE_RELACAO { get; set; }

	[Column("cust_cmp")]
	[DecimalPrecision(13, 2)]
	public decimal? CUSTO_CMP { get; set; }

	[Column("cust_cue")]
	[DecimalPrecision(13, 2)]
	public decimal? CUSTO_CUE { get; set; }

	[Column("vl_unit_ped")]
	[DecimalPrecision(15, 4)]
	public decimal? VALOR_UNITARIO_PEDIDA { get; set; }

	[Column("vl_comis_vend")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_COMISSAO_VENDEDOR { get; set; }

	[Column("vl_comis_lanc")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_COMISSAO_LANCADOR { get; set; }

	[Column("vl_desc_geral")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESCONTO_GERAL { get; set; }

	[Column("seq_origem")]
	public int? SEQ_ORIGEM { get; set; }

	[Column("descprom_lancprod")]
	public BoolEnum? DESCONTO_PROMOCAO_LANC_PRODUTO { get; set; }

	[Column("descprom_redcomis")]
	public BoolEnum? DESCONTO_PROMOCAO_REDUZ_COMISSAO { get; set; }

	[Column("desc01")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_01 { get; set; }

	[Column("desc02")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_02 { get; set; }

	[Column("estoque_zerado")]
	public BoolEnum? ESTOQUE_ZERADO { get; set; }

	[Column("vl_verba")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA { get; set; }

	[Column("restr_vda")]
	public BoolEnum? RESTRICAO_VENDA { get; set; }

	[Column("bonificado")]
	public BoolEnum? BONIFICADO { get; set; }

	[Column("fator_preco")]
	[DecimalPrecision(7, 4)]
	public decimal? FATOR_PRECO { get; set; }

	[Column("seq_kit")]
	public int? SEQ_KIT_PROMOCAO { get; set; }

	[Column("desc_prom")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_PROMOCAO { get; set; }

	[Column("desc_por_qtde")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_POR_QUANTIDADE { get; set; }

	[Column("seq_custo_crp")]
	public int? SEQ_CUSTO_CRP { get; set; }

	[Column("seq_custo_cue")]
	public int? SEQ_CUSTO_CUE { get; set; }

	[Column("seq_custo_cmp")]
	public int? SEQ_CUSTO_CMP { get; set; }

	[Column("custo_av_capado")]
	[DecimalPrecision(15, 4)]
	public decimal? CUSTO_AV_CAPADO { get; set; }

	[Column("cust_cmp_capado")]
	[DecimalPrecision(15, 4)]
	public decimal? CUSTO_CMP_CAPADO { get; set; }

	[Column("cust_cue_capado")]
	[DecimalPrecision(15, 4)]
	public decimal? CUSTO_CUE_CAPADO { get; set; }

	[Column("vl_verba_emp")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA_EMPRESA { get; set; }

	[Column("vl_verba_equip")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA_EQUIPE { get; set; }

	[Column("vl_icm_subst")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_ICMS_SUBST { get; set; }

	[Column("desc_grd_bon")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_GRADE_BONIFICADO { get; set; }

	[Column("desc_grd_com")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_GRADE_COMERCIAL { get; set; }

	[Column("desc_grd_fin")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_GRADE_FINANCEIRO { get; set; }

	[Column("vl_desc_fin")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESCONTO_FINANCEIRO { get; set; }

	[Column("nf_preco_cheio_desc_bol")]
	public BoolEnum? NF_PRECO_CHEIO_DESC_BOL { get; set; }

	[Column("vl_cred_icm_crp")]
	[DecimalPrecision(13, 4)]
	public decimal? VALOR_CREDITO_ICMS_CRP { get; set; }

	[Column("vl_cred_icm_cmp")]
	[DecimalPrecision(13, 4)]
	public decimal? VALOR_CREDITO_ICMS_CMP { get; set; }

	[Column("vl_cred_icm_cue")]
	[DecimalPrecision(13, 4)]
	public decimal? VALOR_CREDITO_ICMS_CUE { get; set; }

	[Column("vl_deb_icm")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DEBITO_ICMS { get; set; }

	[Column("vl_deb_pis")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DEBITO_PIS { get; set; }

	[Column("vl_deb_cofins")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DEBITO_COFINS { get; set; }

	[Column("venda_casada")]
	public BoolEnum? VENDA_CASADA { get; set; }

	[Column("venda_casada_ped_comp")]
	public int? VENDA_CASADA_PEDIDO_COMP { get; set; }

	[Column("venda_casada_cd_forn")]
	public int? VENDA_CASADA_CODIGO_FORNECEDOR { get; set; }

	[Column("venda_casada_negociacao")]
	public BoolEnum? VENDA_CASADA_NEGOCIACAO { get; set; }

	[Column("seq_it_pedc")]
	public int? SEQ_ITEM_PEDIDO_COMPRA { get; set; }

	[Column("nu_ped_cli")]
	public string NUMERO_PEDIDO_CLIENTE { get; set; }

	[Column("vl_comis_rt")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_COMISSAO_RT { get; set; }

	[Column("vl_frete_item")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_FRETE_ITEM { get; set; }

	[Column("seq_acao_comercial")]
	public int? SEQ_ACAO_COMERCIAL { get; set; }

	[Column("vl_st_unit_adic_item")]
	[DecimalPrecision(15, 4)]
	public decimal? VALOR_ST_UNITARIO_ADIC_ITEM { get; set; }

	[Column("vl_verba_fabr_adic")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA_FABRICANTE_ADIC { get; set; }

	[Column("par_cfg_mg_bruta_desc_fin")]
	public bool? PARCFG_MARGEM_BRUTA_DESCONTO_FINANCEIRO { get; set; }

	[Column("ItemBonifContrato")]
	public bool? ITEM_BONIFICADO_CONTRATO { get; set; }

	[Column("SeqProm")]
	public int? SEQ_PROMOCAO { get; set; }

	[Column("import_seq_doc_import")]
	public long? IMPORT_SEQ_DOC_IMPORT { get; set; }

	[Column("import_seq_adicao_import")]
	public long? IMPORT_SEQ_ADICAO_IMPORT { get; set; }

	[Column("import_vl_siscomex")]
	[DecimalPrecision(13, 2)]
	public decimal? IMPORT_VALOR_SISCOMEX { get; set; }

	[Column("import_aliq_ii")]
	[DecimalPrecision(6, 4)]
	public decimal? IMPORT_ALIQUOTA_II { get; set; }

	[Column("import_vl_ii")]
	[DecimalPrecision(13, 2)]
	public decimal? IMPORT_VALOR_II { get; set; }

	[Column("nf_refer_cd_forn_compra")]
	public int? NF_REF_CODIGO_FORNECEDOR_COMPRA { get; set; }

	[Column("nf_refer_nu_nf_compra")]
	public int? NF_REF_NUMERO_NOTA_FISCAL_COMPRA { get; set; }

	[Column("nf_refer_avulsa_nfe")]
	public bool? NF_REF_AVULSA_NFE { get; set; }

	[Column("nf_refer_avulsa_nu_nf")]
	public int? NF_REF_AVULSA_NUMERO_NOTA_FISCAL { get; set; }

	[Column("nf_refer_avulsa_serie")]
	public string NF_REF_AVULSA_SERIE { get; set; }

	[Column("nf_refer_avulsa_dt_emis", TypeName = "smalldatetime")]
	public DateTime? NF_REF_AVULSA_DATA_EMISSAO { get; set; }

	[Column("NfReferAvulsaChaveAcesso")]
	public string NF_REF_AVULSA_CHAVE_ACESSO { get; set; }

	[Column("vl_acres_dif_icm")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_ACRESCIMO_DIF_ICMS { get; set; }

	[Column("dt_fatur", TypeName = "smalldatetime")]
	public DateTime? DATA_FATURAMENTO { get; set; }

	[Column("pesagem")]
	public short? PESAGEM { get; set; }

	[Column("vl_acres_frete")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_ACRESCIMO_FRETE { get; set; }

	[Column("qtde_pe_vend_ve")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_PEDIDA_VENDA_VE { get; set; }

	[Column("qtde_pe_vend_vs")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_PEDIDA_VENDA_VS { get; set; }

	[Column("qtde_pe_devolvida")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_PEDIDA_DEVOLVIDA { get; set; }

	[Column("pe_concluida")]
	public BoolEnum? PEDIDA_CONCLUIDA { get; set; }

	[Column("vl_tot_vda")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_TOTAL_VENDA { get; set; }

	[Column("peso_tot_brt")]
	[DecimalPrecision(7, 3)]
	public decimal? PESO_TOTAL_BRUTO { get; set; }

	[Column("peso_tot_liq")]
	[DecimalPrecision(7, 3)]
	public decimal? PESO_TOTAL_LIQUIDO { get; set; }

	[Column("pesagem_nf")]
	public BoolEnum? PESAGEM_NF { get; set; }

	[Column("seq_evento_dev")]
	public int? SEQ_EVENTO_DEVOLUCAO { get; set; }

	[Column("situacao_2_nf")]
	public string SITUACAO_2_NF { get; set; }

	[Column("nu_nf_2_nf")]
	public int? NUMERO_NOTA_FISCAL_2_NF { get; set; }

	[Column("direcionado")]
	public BoolEnum? DIRECIONADO { get; set; }

	[Column("trans_efet")]
	public BoolEnum? TRANSFERENCIA_EFETIVA { get; set; }

	[Column("vl_verba_fabr")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA_FABRICANTE { get; set; }

	[Column("vl_venda")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VENDA { get; set; }

	[Column("vl_venda_av")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VENDA_AV { get; set; }

	[Column("vl_mg_brt_cmp")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DecimalPrecision(28, 4)]
	public decimal? VALOR_MARGEM_BRUTA_CMP { get; set; }

	[Column("vl_mg_brt_crp")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DecimalPrecision(28, 4)]
	public decimal? VALOR_MARGEM_BRUTA_CRP { get; set; }

	[Column("vl_mg_brt_cue")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DecimalPrecision(28, 4)]
	public decimal? VALOR_MARGEM_BRUTA_CUE { get; set; }

	[Column("nuRecopi")]
	public string NUMERO_RECOPI { get; set; }

	[Column("QtdePecas")]
	public decimal? QUANTIDADE_PECAS { get; set; }

	[Column("VlVendaAvMargem")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VENDA_AV_MARGEM { get; set; }

	public List<ItemPedidoLocalMO> ITENS_LOCAIS { get; set; }

	[Column("PercDescCampanha")]
	public decimal? PERCDESCCAMPANHA { get; set; }

	[Column("PercDescCampanhaCombo")]
	public decimal? PERC_DESC_CAMPANHA_COMBO { get; set; }

	[Column("VlJurosItem")]
	public decimal? VALOR_JUROS_ITEM { get; set; }

	[Column("VlTaxaContrato")]
	public decimal? VALOR_TAXA_CONTRATO { get; set; }

	[Column("CoeficienteCustoFinanceiro")]
	public decimal? COEFICIENTE_CUSTO_FINANCEIRO { get; set; }

	[Column("TpPedBonificacaoValorZero")]
	public bool TP_PED_BONIFICACAO_VALOR_ZERO { get; set; }

	[Column("ValorICMSDesonerado")]
	public decimal? VALOR_ICMS_DESONERADO { get; set; }

	[ForeignKey("CODIGO_EMPRESA, NUMERO_PEDIDO")]
	public PedidoVendaMO PEDIDO { get; set; }

	[NotMapped]
	public string DESCRICAO { get; set; }

	[NotMapped]
	public decimal TOTAL { get; set; }

	[NotMapped]
	public bool INFO_VOLUMES { get; set; }

	[NotMapped]
	public string CODIGO_LINHA { get; set; }

	[NotMapped]
	public decimal? QUANTIDADE_MULTIPLA { get; set; }

	[NotMapped]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO_AUTO { get; set; }

	[NotMapped]
	public decimal? CUSTO_CUE_SEM_IMPOSTO { get; set; }

	[NotMapped]
	public string REQUISITO_BONIFICADO { get; set; }

	[NotMapped]
	public bool LIBERACAO_FISCAL { get; set; }

	[NotMapped]
	public string CD_SIT_TRIB { get; set; }

	[NotMapped]
	public bool? INCIDE_ICMS_SUBST { get; set; }

	[NotMapped]
	public bool? SUBSTRIB_ICMS_COMPRA { get; set; }

	[NotMapped]
	public string CODIGO_GRUPO_PRODUTO { get; set; }

	[NotMapped]
	public bool ST_ADICIONAL_ITEM { get; set; }

	[NotMapped]
	public bool PRODUTO_CONTROLADO { get; set; }

	[NotMapped]
	public decimal PERCENTUAL_DESCONTO_AUX { get; set; }

	[NotMapped]
	public decimal VALOR_TOTAL_COM_IMPOSTOS { get; set; }

	[NotMapped]
	public decimal TOTAL_COM_IMPOSTOS { get; set; }

	[NotMapped]
	public decimal VALOR_COM_DESCONTO_PERMITIDO { get; set; }

	[NotMapped]
	public bool PRODUZIDO { get; set; }

	[NotMapped]
	public decimal PERCENTUAL_ACRESCIDO_DIF_ICMS { get; set; }

	[NotMapped]
	public decimal VALOR_ACRESCIDO_DIF_ICMS { get; set; }

	[NotMapped]
	public bool CALCULA_REDUCAO_COMISSAO { get; set; }

	[NotMapped]
	public decimal PERCENTUAL_MAX_PRODUTO { get; set; }

	[NotMapped]
	public short? PRAZO_MEDIO_MAXIMO { get; set; }

	[NotMapped]
	public bool VERBA_VENDEDOR { get; set; }

	[NotMapped]
	public bool VERBA_VENDEDOR_BONIF { get; set; }

	[NotMapped]
	public decimal VALOR_ITEM_TABELA { get; set; }

	[NotMapped]
	public decimal TOTAL_ORIGINAL { get; set; }

	[NotMapped]
	public decimal VALOR_DOS_DESCONTOS { get; set; }

	[NotMapped]
	public decimal TOTAL_PEDIDA { get; set; }

	[NotMapped]
	public decimal VALOR_IMPOSTOS { get; set; }

	[NotMapped]
	public decimal VALOR_TOTAL_ORIGINAL_COM_IMPOSTOS { get; set; }

	[NotMapped]
	public decimal? LIMITE_ACRESCIMO { get; set; }

	[NotMapped]
	public decimal? PESO_LIQUIDO { get; set; }

	[NotMapped]
	public decimal? PESO_BRUTO { get; set; }

	[NotMapped]
	public decimal? VOLUME { get; set; }

	[NotMapped]
	public bool CONSIDERA_PRECO_PROMOCAO { get; set; }

	[NotMapped]
	public bool PROMOCAO_CONSIDERA_REDUCAO_COMISSAO { get; set; }

	[NotMapped]
	public decimal? COMISSAO_PROMOCAO { get; set; }

	[NotMapped]
	public DateTime? DT_INI_VALIDADE_LOTE { get; set; }

	[NotMapped]
	public DateTime? DT_FIM_VALIDADE_LOTE { get; set; }

	[NotMapped]
	public bool CAMPANHA_CALCULAR_VERBA_FABRICANTE { get; set; }

	[NotMapped]
	public bool CAMPANHA_CONSIDERA_PRODUTOS_PROMOCAO { get; set; }

	[NotMapped]
	public bool CAMPANHA_CONSIDERA_PRODUTOS_BONIFICADOS { get; set; }

	[NotMapped]
	public bool CAMPANHA_VERBA_FABR_DEBITA_PIS_COFINS { get; set; }
}
