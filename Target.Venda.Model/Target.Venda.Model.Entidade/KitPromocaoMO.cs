using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;

namespace Target.Venda.Model.Entidade;

[Table("kit_prom")]
public class KitPromocaoMO : EntidadeBaseMO
{
	[Column("seq_kit")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_KIT { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("validade_de")]
	public DateTime? VALIDADE_DE { get; set; }

	[Column("validade_ate")]
	public DateTime? VALIDADE_ATE { get; set; }

	[Column("ativo")]
	public short? ATIVO { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("flexivel")]
	public bool? FLEXIVEL { get; set; }

	[Column("flex_tp_requisito")]
	public string FLEX_TP_REQUISITO { get; set; }

	[Column("flex_vl_requisito")]
	public decimal? FLEX_VL_REQUISITO { get; set; }

	[Column("flex_tp_benef_bonif")]
	public bool? FLEX_TP_BENEF_BONIF { get; set; }

	[Column("flex_tp_bonif")]
	public string FLEX_TP_BONIF { get; set; }

	[Column("flex_tp_vl_bonif")]
	public string FLEX_TP_VL_BONIF { get; set; }

	[Column("flex_vl_bonif")]
	public decimal? FLEX_VL_BONIF { get; set; }

	[Column("envio_palm_top")]
	public bool? ENVIO_PALM_TOP { get; set; }

	[Column("flex_requisito_minimo_item")]
	public bool? FLEX_REQUISITO_MINIMO_ITEM { get; set; }

	[Column("flex_tp_benef_prazo")]
	public bool? FLEX_TP_BENEF_PRAZO { get; set; }

	[Column("flex_tp_prazo")]
	public string FLEX_TP_PRAZO { get; set; }

	[Column("flex_qtde_prazo")]
	public int? FLEX_QTDE_PRAZO { get; set; }

	[Column("envia_ped_dir")]
	public bool? ENVIA_PED_DIR { get; set; }

	[Column("qtde_limite_venda")]
	public int? QTDE_LIMITE_VENDA { get; set; }

	[Column("flex_vl_limite_venda")]
	public decimal? FLEX_VL_LIMITE_VENDA { get; set; }

	[Column("vl_limite_cli")]
	public decimal? VL_LIMITE_CLI { get; set; }

	[Column("qtde_limite_cli")]
	public int? QTDE_LIMITE_CLI { get; set; }

	[Column("FlexVerbaVend")]
	public bool FLEXVERBAVEND { get; set; }

	[Column("CondPagamentoPorItem")]
	public bool? CONDPAGAMENTOPORITEM { get; set; }

	[Column("PrecoFixo")]
	public bool? PRECOFIXO { get; set; }
}
