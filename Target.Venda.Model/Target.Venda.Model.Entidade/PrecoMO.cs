using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("preco")]
public class PrecoMO : EntidadeBaseMO
{
	[Column("cd_tabela", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_TABELA { get; set; }

	[Column("cd_prod", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_PRODUTO { get; set; }

	[Column("vl_preco")]
	public decimal? VALOR_PRECO { get; set; }

	[Column("descprom_lancprod")]
	public BoolEnum? DESCONTO_PROMOCAO_LANCAMENTO_PRODUTO { get; set; }

	[Column("desc_prom")]
	public decimal? DESCONTO_PROMOCAO { get; set; }

	[Column("descprom_redcomis")]
	public BoolEnum? DESCONTO_PROMOCAO_REDUZ_COMISSAO { get; set; }

	[Column("imprime_tab_pre")]
	public BoolEnum? IMPRIME_TABELA_PRECO { get; set; }

	[Column("dt_alt_imprime")]
	public DateTime? DATA_ALTERACAO_IMPRIME { get; set; }

	[Column("gera_verba")]
	public BoolEnum? GERA_VERBA { get; set; }

	[Column("desc_max_prd")]
	public decimal? DESCONTO_MAXIMO_PRODUTO { get; set; }

	[Column("promocao")]
	public BoolEnum? PROMOCAO { get; set; }

	[Column("limite_acrescimo")]
	public decimal? LIMITE_ACRESCIMO { get; set; }

	[Column("vl_verba_unit")]
	public decimal? VALOR_VERBA_UNITARIO { get; set; }

	[Column("verba_max_deb")]
	public decimal? VERBA_MAX_DEBITO { get; set; }

	[Column("desc_grd_bon")]
	public decimal? DESCONTO_GRADE_BONIFICADO { get; set; }

	[Column("desc_grd_com")]
	public decimal? DESCONTO_GRADE_COMERCIAL { get; set; }

	[Column("desc_grd_fin")]
	public decimal? DESCONTO_GRADE_FINANCEIRO { get; set; }

	[Column("seq_grade_desc_it")]
	public short? SEQ_GRADE_DESCONTO_ITEM { get; set; }

	[Column("desp_extra")]
	public decimal? DESPESA_EXTRA { get; set; }

	[Column("desc_flex")]
	public decimal? DESCONTO_FLEX { get; set; }

	[Column("perc_desc_fin_auto")]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO_AUTOMATICO { get; set; }

	[Column("seq_oferta")]
	public int? SEQ_OFERTA { get; set; }

	[Column("dt_ult_alteracao")]
	public DateTime DATA_ULTIMA_ALTERACAO { get; set; }

	[Column("PercMgCt")]
	public decimal? PERCENTUAL_MARGEM_CUSTO { get; set; }

	[Column("PercMgBr")]
	public decimal? PERCENTUAL_MARGEM_BRUTA { get; set; }
}
