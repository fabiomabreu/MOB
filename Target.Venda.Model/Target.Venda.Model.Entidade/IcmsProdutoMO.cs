using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("icm_prod")]
public class IcmsProdutoMO : EntidadeBaseMO
{
	[Column("cd_prod", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("est_de", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string ESTADO_DE { get; set; }

	[Column("est_para", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string ESTADO_PARA { get; set; }

	[Column("seq_cl_sintegra")]
	public short? SEQ_CL_SINTEGRA { get; set; }

	[Column("aliq_icm")]
	public double ALIQUOTA_ICMS { get; set; }

	[Column("perc_red_baseicm")]
	public decimal? PERCENTUAL_REDUCAO_ICMS { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("aliq_rest_subst_trib")]
	public decimal? ALIQUOTA_RESTANTE_SUBST_TRIB { get; set; }

	[Column("aliq_desc_isencao_icm")]
	public decimal? ALIQUOTA_DECONTO_ISENCAO_ICMS { get; set; }

	[Column("aliq_repasse")]
	public decimal? ALIQUOTA_REPASSE { get; set; }

	[Column("subst_trib_prc_max")]
	public BoolEnum? SUBST_TRIB_PERCENTUAL_MAXIMO { get; set; }

	[Column("aliq_calc_icm_subst")]
	public decimal? ALIQUOTA_CALCULO_ICMS_SUBST { get; set; }

	[Column("cred_icm_presumido")]
	public decimal? CREDITO_ICMS_PRESUMIDO { get; set; }

	[Column("cd_sit_trib")]
	public string CODIGO_SITUACAO_TRIBUTARIA { get; set; }

	[Column("cd_sit_trib_compra")]
	public string CODIGO_SITUACAO_TRIBUTARIA_COMPRA { get; set; }

	[Column("cd_sit_trib_excecao")]
	public string CODIGO_SITUACAO_EXCECAO { get; set; }

	[Column("cd_sit_trib_esp")]
	public string CODIGO_SITUACAO_TRIBUTARIA_ESP { get; set; }

	[Column("cd_sit_trib_red_esp")]
	public string CODIGO_SITUACAO_TRIBUTARIA_RED_ESP { get; set; }
}
