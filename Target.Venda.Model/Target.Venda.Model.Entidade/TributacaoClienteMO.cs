using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Entidade;

[Table("tributacao_cli")]
public class TributacaoClienteMO : EntidadeBaseMO
{
	[Column("seq_trib_cli")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_TRIBUTACAO_CLIENTE { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("ipi_base_calc_icm")]
	public bool? IPI_BASE_CALCULO_ICMS { get; set; }

	[Column("icms_diferido")]
	public bool? ICMS_DIFERIDO { get; set; }

	[Column("util_aliq_interestadual")]
	public bool UTILIZA_ALIQUOTA_INTERESTADUAL { get; set; }

	[Column("ad_icm_cli_isento")]
	public bool? ADICIONA_ICMS_CLIENTE_ISENTO { get; set; }

	[Column("isento_icm_subst")]
	public bool? ISENTO_ICMS_SUBSTITUTO { get; set; }

	[Column("subst_margem_esp")]
	public bool? SUBSTITUTO_MARGEM_ESP { get; set; }

	[Column("calcula_repasse")]
	public bool? CALCULA_REPASSE { get; set; }

	[Column("suframa_desc_pis_cofins")]
	public bool? SUFRAMA_DESC_PIS_COFINS { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("contribuinte_icms")]
	public bool? CONTRIBUINTE_ICMS { get; set; }

	[Column("st_sem_credito_icm")]
	public bool? ST_SEM_CREDITO_ICMS { get; set; }

	[Column("util_aliq_st_interestadual")]
	public bool? UTIL_ALIQUOTA_ST_INTERESTADUAL { get; set; }

	[Column("seq_tributacao_regime")]
	public RegimeTributacaoEnum? SEQ_TRIBUTACAO_REGIME { get; set; }

	[Column("cd_trib_tp_sit_trib")]
	public string CODIGO_TRIBUTACAO_TIPO_SIT_TRIB { get; set; }

	[Column("cd_trib_tp_red_icms")]
	public string CODIGO_TRIBUTACAO_TIPO_RED_ICMS { get; set; }

	[Column("suframa")]
	public bool? SUFRAMA { get; set; }

	[Column("suframa_desc_icm")]
	public bool? SUFRAMA_DESCONTA_ICMS { get; set; }

	[Column("suframa_tp_desc")]
	public string SUFRAMA_TIPO_DESC { get; set; }

	[Column("suframa_msg_pis_cofins")]
	public int? SUFRAMA_MSG_PIS_COFINS { get; set; }

	[Column("suframa_msg_icm")]
	public int? SUFRAMA_MSG_ICMS { get; set; }

	[Column("subst_aliquota_fixa")]
	public bool? SUBSTITUICAO_ALIQUOTA_FIXA { get; set; }

	[Column("perc_subst_aliq_fixa")]
	public decimal? PERCENTUAL_SUBSTITUICAO_ALIQUOTA_FIXA { get; set; }

	[Column("InformaImpostosNf")]
	public bool? INFORMA_IMPOSTOS_NF { get; set; }

	[Column("UtilizaPMC2")]
	public bool? UTILIZA_PMC_2 { get; set; }
}
