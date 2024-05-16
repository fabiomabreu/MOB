using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("it_pedv_ele")]
public class ItemPedidoEletronicoMO : EntidadeBaseMO
{
	[Column("cd_emp_ele", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	[Column("nu_ped_ele", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	[Column("seq_ped", Order = 3)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal SEQ_PEDIDO { get; set; }

	[Column("seq", Order = 4)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public decimal SEQ { get; set; }

	[Column("cd_prod")]
	public int CODIGO_PRODUTO { get; set; }

	[Column("qtde")]
	[DecimalPrecision(13, 4)]
	public decimal QUANTIDADE { get; set; }

	[Column("fator_est_ped")]
	public double? FATOR_ESTOQUE_PEDIDA { get; set; }

	[Column("qtde_unid_ped")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_UNIDADE_PEDIDA { get; set; }

	[Column("ind_relacao")]
	public string INDICE_RELACAO { get; set; }

	[Column("vl_unit_ped")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_UNITARIO_PEDIDA { get; set; }

	[Column("preco_unit")]
	[DecimalPrecision(13, 2)]
	public decimal PRECO_UNITARIO { get; set; }

	[Column("aliq_ipi")]
	[DecimalPrecision(6, 4)]
	public decimal? ALIQUOTA_IPI { get; set; }

	[Column("vl_ipi")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_IPI { get; set; }

	[Column("desc_apl")]
	[DecimalPrecision(6, 4)]
	public decimal? DESCONTO_APLICADO { get; set; }

	[Column("vl_verba")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA { get; set; }

	[Column("seq_kit")]
	public int? SEQ_KIT { get; set; }

	[Column("bonificado")]
	public BoolEnum? BONIFICADO { get; set; }

	[Column("unid_ped")]
	public string UNIDADE_PEDIDA { get; set; }

	[Column("cd_sit_trib")]
	public string CODIGO_SITUACAO_TRIBUTARIA { get; set; }

	[Column("desc_cfop")]
	public string DESCONTO_CFOP { get; set; }

	[Column("incide_icm")]
	public BoolEnum? INCIDE_ICMS { get; set; }

	[Column("aliq_icm")]
	[DecimalPrecision(7, 4)]
	public decimal? ALIQUOTA_ICMS { get; set; }

	[Column("perc_red_baseicm")]
	[DecimalPrecision(7, 4)]
	public decimal? PERCENTUAL_REDUCAO_BASE_ICMS { get; set; }

	[Column("vl_base_icm")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_BASE_ICMS { get; set; }

	[Column("vl_icm")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_ICMS { get; set; }

	[Column("vl_base_icm_subst")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_BASE_ICMS_SUBST { get; set; }

	[Column("vl_icm_subst")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_ICMS_SUBST { get; set; }

	[Column("desc01")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_01 { get; set; }

	[Column("desc02")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_02 { get; set; }

	[Column("seq_grade_desc")]
	public int? SEQ_GRADE_DESC { get; set; }

	[Column("seq_grade_desc_it")]
	public short? SEQ_GRADE_DESCONTO_ITEM { get; set; }

	[Column("desc_grd_bon")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_GRADE_BONIFICADO { get; set; }

	[Column("desc_grd_com")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_GRADE_COMERCIAL { get; set; }

	[Column("desc_grd_fin")]
	[DecimalPrecision(7, 4)]
	public decimal? DESCONTO_GRADE_FINANCEIRO { get; set; }

	[Column("VlVerbaFabr")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_VERBA_FABRICANTE { get; set; }

	[Column("SeqProm")]
	public int? SEQ_PROMOCAO { get; set; }

	[Column("QtdeAtendida")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_ATENDIDA { get; set; }

	[Column("QtdeAtendidaUnidPed")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_ATENDIDA_UNIDADE_PEDIDA { get; set; }

	[Column("SeqKitResultante")]
	public int? SEQ_KIT_RESULTANTE { get; set; }

	[Column("QtdeFalta")]
	[DecimalPrecision(13, 4)]
	public decimal? QUANTIDADE_FALTA { get; set; }

	[Column("EstoqueZerado")]
	public bool? ESTOQUE_ZERADO { get; set; }

	[ForeignKey("CODIGO_EMPRESA_ELETRONICO, NUMERO_PEDIDO_ELETRONICO, SEQ_PEDIDO")]
	public PedidoEletronicoMO PEDVDAELETO { get; set; }

	[NotMapped]
	public decimal TOTAL { get; set; }

	[NotMapped]
	public decimal COMISSAO_PADRAO { get; set; }

	[NotMapped]
	public bool? ENFARDAVEL { get; set; }

	[NotMapped]
	public decimal PRECO_PEDIDA { get; set; }

	[NotMapped]
	public string UNIDADE_VENDA { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_CRP { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_CMP { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_CUE { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_ULTIMA_ENTRADA_SEM_IMPOSTO { get; set; }

	[NotMapped]
	public int SEQ_CUSTO_CRP { get; set; }

	[NotMapped]
	public int SEQ_CUSTO_CUE { get; set; }

	[NotMapped]
	public int SEQ_CUSTO_CMP { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_CAPADO { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_CMP_CAPADO { get; set; }

	[NotMapped]
	public decimal? VALOR_CUSTO_CUE_CAPADO { get; set; }

	[NotMapped]
	public bool PAPEL_CORTADO { get; set; }

	[NotMapped]
	public decimal? PRECO_BASICO { get; set; }

	[NotMapped]
	public decimal? VALOR_PRECO { get; set; }

	[NotMapped]
	public decimal? VALOR_ORIGINAL { get; set; }

	[NotMapped]
	public bool? INCIDE_ICMS_SUBST { get; set; }

	[NotMapped]
	public string REQUISITO_BONIFICADO { get; set; }

	[NotMapped]
	public decimal? KIT_FLEX_QUANTIDADE_MINIMA { get; set; }

	[NotMapped]
	public decimal? KIT_FLEX_VALOR_MINIMO { get; set; }

	[NotMapped]
	public string FLEX_TIPO_REQUISITO { get; set; }

	[NotMapped]
	public decimal? FLEX_VALOR_REQUISITO { get; set; }

	[NotMapped]
	public bool? FLEXIVEL { get; set; }

	[NotMapped]
	public bool? ESTOQUE_INSUFICIENTE { get; set; }

	[NotMapped]
	public bool? VERBA_VENDA { get; set; }

	[NotMapped]
	public decimal? VERBA_VENDA_DESCONTO_MAXIMO { get; set; }

	[NotMapped]
	public bool? VERBA_VENDA_BONIFICADO { get; set; }

	[NotMapped]
	public bool? RESTRICAO_VENDA { get; set; }

	[NotMapped]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO { get; set; }

	[NotMapped]
	public bool? SOMENTE_ITENS { get; set; }

	[Column("DtIniValidadeLote")]
	public DateTime? DT_INI_VALIDADE_LOTE { get; set; }

	[Column("DtFimValidadeLote")]
	public DateTime? DT_FIM_VALIDADE_LOTE { get; set; }
}
