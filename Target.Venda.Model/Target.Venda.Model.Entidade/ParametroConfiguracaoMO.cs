using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Entidade;

[Table("par_cfg")]
public class ParametroConfiguracaoMO : EntidadeBaseMO
{
	[Key]
	[Column("cd_emp")]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("perm_ped_vda_end_desatu")]
	public byte? PERM_PED_VDA_END_DESATU { get; set; }

	[Column("formpgto_banco_tped_vs")]
	public byte? FORMPGTO_BANCO_TPED_VS { get; set; }

	[Column("forma_pagto_assoc_clien")]
	public bool? FORMA_PAGTO_ASSOC_CLIEN { get; set; }

	[Column("utiliza_nfe")]
	public string UTILIZA_NFE { get; set; }

	[NotMapped]
	public string UTILIZA_NFE_DESCRIPTOGRAFADO { get; set; }

	[Column("utiliza_sit_trib_esp_tp_ped")]
	public byte? UTILIZA_SIT_TRIB_ESP_TP_PED { get; set; }

	[Column("volpedvdatipoid")]
	public byte VOL_PEDVDA_TIPO_ID { get; set; }

	[NotMapped]
	public OrigemVolumePedidoEnum VOL_PEDVDA_TIPO
	{
		get
		{
			return (OrigemVolumePedidoEnum)VOL_PEDVDA_TIPO_ID;
		}
		set
		{
			VOL_PEDVDA_TIPO_ID = (byte)value;
		}
	}

	[Column("volpedvdaorigemid")]
	public byte VOL_PEDVDA_ORIGEM_ID { get; set; }

	[NotMapped]
	public TipoVolumePedidoEnum VOL_PEDVDA_ORIGEM
	{
		get
		{
			return (TipoVolumePedidoEnum)VOL_PEDVDA_ORIGEM_ID;
		}
		set
		{
			VOL_PEDVDA_ORIGEM_ID = (byte)value;
		}
	}

	[Column("volpedvdaobrigarinformacao")]
	public bool? VOLPEDVDAOBRIGARINFORMACAO { get; set; }

	[Column("fila_separacao")]
	public bool? FILA_SEPARACAO { get; set; }

	[Column("tp_desc_fin_auto")]
	public string TP_DESC_FIN_AUTO { get; set; }

	[Column("desc_fin_tot_nf")]
	public byte? DESC_FIN_TOT_NF { get; set; }

	[Column("nu_dias_desc_fin_auto")]
	public short? NU_DIAS_DESC_FIN_AUTO { get; set; }

	[Column("unid_pedida")]
	public bool? UNID_PEDIDA { get; set; }

	[Column("unid_vda_var")]
	public bool? UNID_VDA_VAR { get; set; }

	[Column("desconto_por_quantidade")]
	public bool? DESCONTO_POR_QUANTIDADE { get; set; }

	[Column("acrescimo_dif_icm")]
	public bool? ACRESCIMO_DIF_ICM { get; set; }

	[Column("titrec_prox_dia_util")]
	public bool? TITREC_PROX_DIA_UTIL { get; set; }

	[Column("utiliza_frete_estado")]
	public bool? UTILIZA_FRETE_ESTADO { get; set; }

	[Column("acrescimo_frete")]
	public bool? ACRESCIMO_FRETE { get; set; }

	[Column("frete_utiliza_regtrans")]
	public bool? FRETE_UTILIZA_REGTRANS { get; set; }

	[Column("qtde_def_regiao")]
	public short? QTDE_DEF_REGIAO { get; set; }

	[Column("tp_vl_base_comissao")]
	public string TP_VL_BASE_COMISSAO { get; set; }

	[Column("comis_clien")]
	public byte? COMIS_CLIEN { get; set; }

	[Column("verba_perc_cred")]
	public decimal? VERBA_PERC_CRED { get; set; }

	[Column("verba_perc_cred_emp")]
	public decimal? VERBA_PERC_CRED_EMP { get; set; }

	[Column("verba_perc_cred_equip")]
	public decimal? VERBA_PERC_CRED_EQUIP { get; set; }

	[Column("verba_tp_lanc")]
	public string VERBA_TP_LANC { get; set; }

	[Column("desc_geral_red_comis")]
	public byte? DESC_GERAL_RED_COMIS { get; set; }

	[Column("tp_redutor_comissao")]
	public string TP_REDUTOR_COMISSAO { get; set; }

	[Column("tp_custo_comis_mg")]
	public string TP_CUSTO_COMIS_MG { get; set; }

	[Column("utiliza_comis_rt")]
	public byte? UTILIZA_COMIS_RT { get; set; }

	[Column("descitem_blq_pedvda")]
	public bool? DESCITEM_BLQ_PEDVDA { get; set; }

	[Column("bloq_nf_pf")]
	public byte? BLOQ_NF_PF { get; set; }

	[Column("pedido_pf_x_pj")]
	public byte? PEDIDO_PF_X_PJ { get; set; }

	[Column("util_controle_grupo_produto")]
	public byte? UTIL_CONTROLE_GRUPO_PRODUTO { get; set; }

	[Column("utiliza_grade_desc")]
	public byte? UTILIZA_GRADE_DESC { get; set; }

	[Column("nf_item_bonif_valor_vda")]
	public bool? NF_ITEM_BONIF_VALOR_VDA { get; set; }

	[Column("lanc_cred_verba")]
	public string LANC_CRED_VERBA { get; set; }

	[Column("mg_bruta_desc_fin")]
	public bool? MG_BRUTA_DESC_FIN { get; set; }

	[Column("cred_verba_fabr_neg_ind")]
	public string CRED_VERBA_FABR_NEG_IND { get; set; }

	[Column("ind_prodpapel")]
	public bool? IND_PRODPAPEL { get; set; }

	[Column("verba_fabr_enc_item_estoque")]
	public bool? VERBA_FABR_ENC_ITEM_ESTOQUE { get; set; }

	[Column("DescGeralProd")]
	public bool? DESCGERALPROD { get; set; }

	[Column("DescGeralNaoRecalculaCorte")]
	public bool? DESCGERALNAORECALCULACORTE { get; set; }
}
