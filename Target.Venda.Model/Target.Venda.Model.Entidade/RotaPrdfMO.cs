using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("rot_prdf")]
public class RotaPrdfMO : EntidadeBaseMO
{
	[Column("cd_rot_prdf")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string CODIGO_ROTA_PRDF { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("qtde_pedagios")]
	public short? QUANTIDADE_PEDAGIOS { get; set; }

	[Column("vl_saida")]
	public decimal? VALOR_SAIDA { get; set; }

	[Column("remunera_adic")]
	public decimal? REMUNERACAO_ADICIONAL { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("dias_prorr_venc")]
	public short? DIAS_PRORROGACAO_VENCIMENTO { get; set; }

	[Column("dist_percorrida")]
	public short? DIST_PERCORRIDA { get; set; }

	[Column("seq_entrega")]
	public int? SEQ_ENTREGA { get; set; }

	[Column("wms_alcis_fracionado")]
	public bool? WMS_ALCIS_FRACIONADO { get; set; }

	[Column("PercIdealCustoSobreVenda")]
	public decimal? PERCENTUAL_IDEAL_CUSTO_SOBRE_VENDA { get; set; }
}
