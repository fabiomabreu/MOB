using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("produto_custo")]
public class ProdutoCustoMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[Column("cd_prod", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("tp_custo", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string TIPO_CUSTO { get; set; }

	[Column("dt_inicio")]
	public DateTime DATA_INICIO { get; set; }

	[Column("desc_apl_1")]
	public decimal? DESCONTO_APLICADO_1 { get; set; }

	[Column("desc_apl_2")]
	public decimal? DESCONTO_APLICADO_2 { get; set; }

	[Column("vl_custo_sem_imposto")]
	public decimal? VALOR_CUSTO_SEM_IMPOSTO { get; set; }

	[Column("vl_ipi")]
	public decimal? VALOR_IPI { get; set; }

	[Column("vl_icm_subst")]
	public decimal? VALOR_ICMS_SUBSTITUTO { get; set; }

	[Column("vl_frete")]
	public decimal? VALOR_FRETE { get; set; }

	[Column("vl_compl")]
	public decimal? VALOR_COMPLEMENTO { get; set; }

	[Column("vl_icm_compra")]
	public decimal? VALOR_ICMS_COMPRA { get; set; }

	[Column("vl_pis")]
	public decimal? VALOR_PIS { get; set; }

	[Column("vl_cofins")]
	public decimal? VALOR_COFINS { get; set; }

	[Column("nu_nf")]
	public int? NUMERO_NOTA_FISCAL { get; set; }

	[Column("cd_forn")]
	public int? CODIGO_FORNECEDOR { get; set; }

	[Column("qtde")]
	public decimal? QUANTIDADE { get; set; }

	[Column("seq_grp_desc")]
	public int? SEQ_GRADE_DESCONTO { get; set; }

	[Column("seq_nf_reci")]
	public int? SEQ_NOTA_FISCAL_RECEBIMENTO { get; set; }

	[Column("seq_cust_ant")]
	public int? SEQ_CUSTO_ANTERIOR { get; set; }

	[Column("par_cfg_custo_capado_subtrai_ipi")]
	public bool? PAR_CFG_CUSTO_CAPADO_SUBTRAI_IPI { get; set; }

	[Column("par_cfg_calc_imp_tare")]
	public bool? PAR_CFG_CALCULO_IMP_TARE { get; set; }

	[Column("nf_recm_aplic_icm_cust_capado")]
	public bool? NF_RECM_APLICADO_ICMS_CUSTO_CAPADO { get; set; }

	[Column("nf_recm_aplic_vl_st_custo_bruto")]
	public bool? NF_RECM_APLICADO_VALOR_ST_CUSTO_BRUTO { get; set; }

	[Column("nf_recm_aplic_vl_st_custo_capado")]
	public bool? NF_RECM_APLICADO_VALOR_ST_CUSTO_CAPADO { get; set; }

	[Column("vl_imp_cmp_adic")]
	public decimal? VALOR_IMP_CMP_ADIC { get; set; }

	[Column("vl_custo")]
	public decimal? VALOR_CUSTO { get; set; }

	[Column("vl_cust_brt")]
	public decimal? VALOR_CUSTO_BRUTO { get; set; }

	[Column("vl_custo_capado")]
	public decimal? VALOR_CUSTO_CAPADO { get; set; }
}
