using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("promocao")]
public class PromocaoMO : EntidadeBaseMO
{
	[Column("seq_prom")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int SEQ_PROMOCAO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("cd_prom")]
	public string CODIGO_PROMOCAO { get; set; }

	[Column("vl_min_pedv")]
	public decimal VALOR_MINIMO_PEDIDO_VENDA { get; set; }

	[Column("tp_prazo")]
	public string TIPO_PRAZO { get; set; }

	[Column("tot_parc")]
	public short TOTAL_PARCELAS { get; set; }

	[Column("prz_medio")]
	public decimal? PRAZO_MEDIO { get; set; }

	[Column("cust_fin")]
	public decimal CUSTO_FINANCEIRO { get; set; }

	[Column("dt_inicio")]
	public DateTime? DATA_INICIO { get; set; }

	[Column("dt_fim")]
	public DateTime? DATA_FIM { get; set; }

	[Column("flexivel")]
	public byte? FLEXIVEL { get; set; }

	[Column("ativo")]
	public bool? ATIVO { get; set; }

	[Column("dt_base")]
	public string DATA_BASE { get; set; }

	[Column("ini_prazo")]
	public string INICIO_PRAZO { get; set; }

	[Column("envio_palm_top")]
	public BoolEnum? ENVIO_PALM_TOP { get; set; }

	[Column("tp_cust_fin")]
	public string TIPO_CUSTO_FINANCEIRO { get; set; }

	[Column("validade_de")]
	public DateTime? VALIDADE_DE { get; set; }

	[Column("validade_ate")]
	public DateTime? VALIDADE_ATE { get; set; }

	[Column("seq_grade_desc")]
	public int? SEQ_GRADE_DESCONTO { get; set; }

	[Column("venc_fixo")]
	public BoolEnum? VENCIMENTO_FIXO { get; set; }

	[Column("perc_desc_fin_auto")]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO_AUTO { get; set; }

	[Column("envia_ped_dir")]
	public BoolEnum? ENVIA_PEDIDO_DIRETO { get; set; }

	[Column("CondMultipla")]
	public bool? CONDICAO_MULTIPLA { get; set; }

	[Column("CartaoCredito")]
	public bool? CC_CARTAO_CREDITO { get; set; }

	[Column("ContratoOperadoraCartaoCreditoID")]
	public int? CC_CONTRATO_OPERADORA_ID { get; set; }

	[Column("CartaoCreditoQtdeMaxParc")]
	public int? CC_QTDE_MAX_PARCELAS { get; set; }

	[Column("CartaoCreditoTaxaJurosParc")]
	public decimal? CC_TAXA_JUROS_PARCELAS { get; set; }

	[Column("CartaoCreditoParcSemJuros")]
	public int? CC_NUMERO_PARCELAS_SEM_JUROS { get; set; }

	public List<PromocaoParcelasMO> PARCELAS { get; set; }

	public List<KitPromocaoPagamentoMO> KIT_PROMOCAO_PAGAMENTO { get; set; }

	public List<FormaPagamentoPromocaoMO> FORMAS_PAGAMENTO { get; set; }

	public List<PromocaoEmpresaMO> PROMOCAO_EMPRESA { get; set; }

	public bool? CONSIDERA_PRAZO_FIXO_PRODUTO { get; set; }

	[NotMapped]
	public ContratoOperadoraCartaoCreditoMO CONTRATO { get; set; }
}
