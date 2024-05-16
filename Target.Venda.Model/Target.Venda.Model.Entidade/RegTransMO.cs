using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("regtrans")]
public class RegTransMO : EntidadeBaseMO
{
	[Column("cd_forn", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_FORNECEDOR { get; set; }

	[Column("seq_reg", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal SEQ_REG { get; set; }

	[Column("cep_de")]
	public decimal CEP_DE { get; set; }

	[Column("cep_ate")]
	public decimal CEP_ATE { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

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
	public decimal? VALOR_VENDA_MINIMO { get; set; }

	[Column("isencao")]
	public bool? ISENCAO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("calc_frete_cif")]
	public BoolEnum? CALCULO_FRETE_CIF { get; set; }

	[Column("calc_frete_fob")]
	public BoolEnum? CALCULO_FRETE_FOB { get; set; }

	[Column("seq_frete")]
	public int SEQ_FRETE { get; set; }
}
