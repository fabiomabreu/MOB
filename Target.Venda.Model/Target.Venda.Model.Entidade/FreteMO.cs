using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("frete")]
public class FreteMO : EntidadeBaseMO
{
	[Column("seq_frete")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int SEQ_FRETE { get; set; }

	[Column("cd_forn")]
	public int CODIGO_FORNECEDOR { get; set; }

	[Column("cep_de")]
	public int CEP_DE { get; set; }

	[Column("cep_ate")]
	public int CEP_ATE { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("vl_frete_min")]
	public decimal VALOR_FRETE_MINIMO { get; set; }

	[Column("isencao")]
	public bool ISENCAO { get; set; }

	[Column("isencao_vl_ped_min")]
	public decimal ISENCAO_VALOR_PEDIDO_MINIMO { get; set; }

	[Column("calc_frete_cif")]
	public bool CALCULAR_FRETE_CIF { get; set; }

	[Column("calc_frete_fob")]
	public bool CALCULAR_FRETE_FOB { get; set; }

	[Column("ativo")]
	public bool ATIVO { get; set; }

	[Column("tpcob_melhor_calculo")]
	public bool TIPO_COBRANCA_MELHOR_CALCULO { get; set; }

	[Column("tpcob_cubagem")]
	public bool TIPO_COBRANCA_CUBAGEM { get; set; }

	[Column("tpcob_cubagem_vl_frete")]
	public decimal? TIPO_COBRANCA_CUBABEM_VALOR_FRETE { get; set; }

	[Column("tpcob_pesagem")]
	public bool TIPO_COBRANCA_PESAGEM { get; set; }

	[Column("tpcob_pesagem_vl_frete")]
	public decimal? TIPO_COBRANCA_PESAGEM_VALOR_FRETE { get; set; }

	[Column("tpcob_percentual")]
	public bool TIPO_COBRANCA_PERCENTUAL { get; set; }

	[Column("tpcob_percentual_frete")]
	public decimal? TIPO_COBRANCA_PERCENTUAL_FRETE { get; set; }

	[Column("tpcob_fx_valor")]
	public bool TIPO_COBRANCA_FX_VALOR { get; set; }

	[Column("tpcob_fx_peso")]
	public bool TIPO_COBRANCA_FX_PESO { get; set; }

	[NotMapped]
	public decimal VALOR_FRETE_UNIDADE { get; set; }

	[NotMapped]
	public bool TIPO_COBRANCA_PRECO { get; set; }

	[NotMapped]
	public int SEQ_REG { get; set; }
}
