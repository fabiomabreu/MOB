using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("regiao")]
public class RegiaoMO : EntidadeBaseMO
{
	[Column("cd_regiao")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int CODIGO_REGIAO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("dia_sem")]
	public string DIA_SEM { get; set; }

	[Column("tpcobfrete")]
	public string TIPO_COBRANCA_FRETE { get; set; }

	[Column("vl_frete_unid")]
	public decimal? VALOR_FRETE_UNIDADE { get; set; }

	[Column("perc_frete")]
	public decimal? PERCENTUAL_FRETE { get; set; }

	[Column("vl_frete_min")]
	public decimal? VALOR_FRETE_MINIMO { get; set; }

	[Column("vl_taxa_fixa")]
	public decimal? VALOR_TAXA_FIXA { get; set; }

	[Column("vl_vda_min")]
	public decimal? VALOR_VENDA_MINIMA { get; set; }

	[Column("isencao")]
	public bool ISENCAO { get; set; }

	[Column("ativo")]
	public bool ATIVO { get; set; }

	[Column("cd_rot_prdf")]
	public string CODIGO_ROTA_PRDF { get; set; }

	[Column("calc_frete_cif")]
	public BoolEnum? CALCULO_FRETE_CIF { get; set; }

	[Column("calc_frete_fob")]
	public BoolEnum? CALCULO_FRETE_FOB { get; set; }

	[Column("calc_frete_apartir")]
	public decimal? CALCULO_FRETE_APARTIR { get; set; }
}
