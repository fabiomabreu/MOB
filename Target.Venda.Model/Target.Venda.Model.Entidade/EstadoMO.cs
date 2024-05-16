using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("estado")]
public class EstadoMO : EntidadeBaseMO
{
	[Column("estado")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string ESTADO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("perc_frete")]
	public decimal? PERCENTUAL_FRETE { get; set; }

	[Column("margem")]
	public decimal? MARGEM { get; set; }

	[Column("substrib_icms")]
	public BoolEnum? SUBSTITUACAO_TRIBUTARIA_ICMS { get; set; }

	[Column("st_icms_nf_dist")]
	public BoolEnum? ST_ICMS_NF_DISTRITO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("grava_custo_sem_subst")]
	public BoolEnum? GRAVA_CUSTO_SEM_SUBSTITUICAO { get; set; }

	[Column("margem_esp")]
	public decimal? MARGEM_ESP { get; set; }

	[Column("cd_pais")]
	public string CODIGO_PAIS { get; set; }

	[Column("cd_ibge")]
	public string CODIGO_IBGE { get; set; }

	[Column("cred_icms_proprio_margem")]
	public bool? CREDITO_ICMS_PROPRIO_MARGEM { get; set; }

	[Column("TpEmisContingencia")]
	public int? TIPO_EMISSAO_CONTINGENCIA { get; set; }
}
