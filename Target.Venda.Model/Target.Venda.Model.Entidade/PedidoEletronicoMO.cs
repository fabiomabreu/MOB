using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("ped_vda_ele")]
public class PedidoEletronicoMO : EntidadeBaseMO
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
	public decimal SEQ_PEDIDO_ELETRONICO { get; set; }

	[Column("nu_ped_cli")]
	public string NUMERO_PEDIDO_CLIENTE { get; set; }

	[Column("cd_emp")]
	public int? CODIGO_EMPRESA { get; set; }

	[Column("nu_ped")]
	public int? NUMERO_PEDIDO { get; set; }

	[Column("cd_vend")]
	public string CODIGO_VENDEDOR { get; set; }

	[Column("cd_clien")]
	public int? CODIGO_CLIENTE { get; set; }

	[Column("per_desc_fin")]
	[DecimalPrecision(6, 3)]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO { get; set; }

	[Column("vl_desc_fin")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESCONTO_FINANCEIRO { get; set; }

	[Column("nu_dias_desc_fin")]
	public decimal? NUMERO_DIAS_DESCONTO_FINANCIERO { get; set; }

	[Column("tp_estab")]
	public string TIPO_ESTABELECIMENTO { get; set; }

	[Column("tp_ped")]
	public string CODIGO_TIPO_PEDIDO { get; set; }

	[Column("dt_ped")]
	public DateTime? DATA_PEDIDO { get; set; }

	[Column("cd_tabela")]
	public string CODIGO_TABELA { get; set; }

	[Column("seq_prom")]
	public int? SEQ_PROMOCAO { get; set; }

	[Column("formpgto")]
	public string FORMA_PAGAMENTO { get; set; }

	[Column("vl_frete")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_FRETE { get; set; }

	[Column("valor_tot")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_TOTAL { get; set; }

	[Column("tp_midia")]
	public string TIPO_MIDIA { get; set; }

	[Column("tp_entrega")]
	public string TIPO_ENTREGA { get; set; }

	[Column("cd_forn")]
	public int? CODIGO_FORNECEDOR { get; set; }

	[Column("tp_frete")]
	public string TIPO_FRETE { get; set; }

	[Column("dt_entrega")]
	public DateTime? DATA_ENTREGA { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("prom_padr_cli")]
	public BoolEnum? PROMOCAO_PADRAO_CLIENTE { get; set; }

	[Column("dt_prev_fatu")]
	public DateTime? DATA_PREVISAO_FATURAMENTO { get; set; }

	[Column("perc_desc_geral")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_DESCONTO_GERAL { get; set; }

	[Column("vl_desc_geral")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESCONTO_GERAL { get; set; }

	[Column("origem_pedido")]
	public string ORIGEM_PEDIDO { get; set; }

	[Column("nu_ped_palm")]
	public string NUMERO_PEDIDO_PALM { get; set; }

	[Column("sem_estoque")]
	public BoolEnum? SEM_ESTOQUE { get; set; }

	[Column("nu_nf")]
	public int? NUMERO_NOTA_FISCAL { get; set; }

	[Column("nu_nf_emp_fat")]
	public int? NUMERO_NOTA_FISCAL_EMPRESA_FATURADA { get; set; }

	[Column("desc_cfop")]
	public string DESCRICAO_CFOP { get; set; }

	[Column("desc_nat_oper")]
	public string DESCRICAO_NATUREZA_OPERACAO { get; set; }

	[Column("imp_via_sp")]
	public BoolEnum? IMP_VIA_SP { get; set; }

	[Column("tp_imp_sp")]
	public string TP_IMP_SP { get; set; }

	[Column("nf_canc")]
	public BoolEnum? NOTA_FISCAL_CANCELADA { get; set; }

	[Column("card_cred_numero")]
	public string CARTAO_CREDITO_NUMERO { get; set; }

	[Column("card_cred_proprietario")]
	public string CARTAO_CREDITO_PROPRIETARIO { get; set; }

	[Column("card_cred_tipo")]
	public string CARTAO_CREDITO_TIPO { get; set; }

	[Column("card_cred_complemento")]
	public string CARTAO_CREDITO_COMPLEMENTO { get; set; }

	[Column("card_cred_dt_expiracao_mes")]
	public string CARTAO_CREDITO_DATA_EXPIRACAO_MES { get; set; }

	[Column("card_cred_dt_expiracao_ano")]
	public string CARTAO_CREDITO_DATA_EXPIRACAO_ANO { get; set; }

	[Column("card_cred_cpf_proprietario")]
	public string CARTAO_CREDITO_CPF_PROPRIETARIO { get; set; }

	[Column("pedido_direto")]
	public BoolEnum? PEDIDO_DIRETO { get; set; }

	[Column("cd_intpededi")]
	public string CODIGO_INTPEDEDI { get; set; }

	[Column("idOrder_Vertis")]
	public int? IDORDER_VERTIS { get; set; }

	[Column("vertis_ped_finalizado")]
	public BoolEnum? VERTIS_PEDIDO_FINALIZADO { get; set; }

	[Column("mantem_vl_frete_pedv_ele")]
	public BoolEnum? MANTEM_VALOR_FRETE_PEDIDO_ELETRONICO { get; set; }

	[Column("mantem_vl_desc_ger_pedv_ele")]
	public BoolEnum? MANTEM_VALOR_DESCONTO_GERAL_PEDIDO_ELETRONICO { get; set; }

	[Column("cd_int_ped_ele")]
	public string CODICO_INT_PEDIDO_ELETRONICO { get; set; }

	[Column("proposta_vda")]
	public bool? PROPOSTA_VENDA { get; set; }

	[Column("pend_ele_libera_auto")]
	public bool? PEDIDO_ELETRONICO_LIBERA_AUTO { get; set; }

	[Column("nome_entrega")]
	public string NOME_ENTREGA { get; set; }

	[Column("liberacao_automatica")]
	public bool? LIBERACAO_AUTOMATICA { get; set; }

	[NotMapped]
	public bool? ATENDIMENTO_ENVIADO { get; set; }

	[Column("cd_ped_ele_sist")]
	public string CODIGO_PEDIDO_ELETRONICO_SISTEMA { get; set; }

	[Column("SeqTroca")]
	public int? SEQ_TROCA { get; set; }

	[Column("EntOutCli")]
	public bool? ENTREGA_OUTRO_CLIENTE { get; set; }

	[Column("CdClienOutCli")]
	public int? CODIGO_CLIENTE_OUTRO_CLIENTE { get; set; }

	[Column("CancelamentoManual")]
	public bool? CANCELAMENTO_MANUAL { get; set; }

	[Column("CdFornCompraTransf")]
	public int? CODIGO_FORNECEDOR_COMPRA_TRANSFERENCIA { get; set; }

	[Column("NuNfCompraTransf")]
	public int? NUMERO_NOTA_FISCAL_COMPRA_TRANSFERENCIA { get; set; }

	[Column("QtdeParcelasCartaoCredito")]
	public int? QTDE_PARCELAS_CARTAO_CREDITO { get; set; }

	[Column("IntermediadorPedido")]
	public bool? INTERMEDIADOR_PEDIDO { get; set; }

	[Column("CnpjIntermediador")]
	public string CNPJ_INTERMEDIADOR { get; set; }

	[Column("ValorCupom")]
	public decimal? VALOR_CUPOM { get; set; }

	public string DESCRICAO_VAN { get; set; }

	public List<string> ORIGEM_PEDIDO_VENDA_LISTA { get; set; }

	public List<ItemPedidoEletronicoMO> ITENS { get; set; }

	public List<EventoPedidoEletronicoMO> EVENTOS_PEDIDO_ELETRONICO { get; set; }

	public List<ObservacaoPedidoEletronicoMO> OBSERVACOES { get; set; }

	public List<EnderecoPedidoEletronicoMO> ENDERECOS { get; set; }

	public string OrigemPedidoVendaIn()
	{
		string text = "";
		foreach (string oRIGEM_PEDIDO_VENDA_LISTum in ORIGEM_PEDIDO_VENDA_LISTA)
		{
			text = ((!(text == "")) ? (text + ", '" + oRIGEM_PEDIDO_VENDA_LISTum + "'") : ("'" + oRIGEM_PEDIDO_VENDA_LISTum + "'"));
		}
		return text;
	}
}
