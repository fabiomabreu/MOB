using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Entidade;

[Table("tp_ped")]
public class TipoPedidoMO : EntidadeBaseMO
{
	[Column("tp_ped")]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public string TIPO_PEDIDO { get; set; }

	[Column("descricao")]
	public string DESCRICAO { get; set; }

	[Column("atualiza_estoque")]
	public bool? ATUALIZA_ESTOQUE { get; set; }

	[Column("gera_titrec")]
	public bool? GERA_TITULO_RECEBER { get; set; }

	[Column("imprime_nf")]
	public bool? IMPRIME_NOTA_FISCAL { get; set; }

	[Column("calcula_icm")]
	public bool? CALCULA_ICMS { get; set; }

	[Column("calcula_ipi")]
	public bool? CALCULA_IPI { get; set; }

	[Column("estat_com")]
	public bool? ESTATISTICA_COMERCIAL { get; set; }

	[Column("principal")]
	public BoolEnum? PRINCIPAL { get; set; }

	[Column("transf_estoque")]
	public BoolEnum? TRANSFERENCIA_ESTOQUE { get; set; }

	[Column("cd_emp_transf")]
	public int? CODIGO_EMPRESA_TRANSFERENCIA { get; set; }

	[Column("cd_local_transf")]
	public string CODIGO_LOCAL_TRANSFERENCIA { get; set; }

	[Column("calcula_icm_ipi")]
	public BoolEnum? CALCULA_ICMS_IPI { get; set; }

	[Column("automat_3_casa")]
	public BoolEnum? AUTOMATICO_3_CASA { get; set; }

	[Column("ipi_base_calc_icm")]
	public BoolEnum? IPI_BASE_CALCULO_ICMS { get; set; }

	[Column("consignacao")]
	public BoolEnum? CONSIGNACAO { get; set; }

	[Column("vda_posconsig")]
	public BoolEnum? VENDA_POS_CONSIGUINACAO { get; set; }

	[Column("dev_fornecedor")]
	public BoolEnum? DEVOLUCAO_FORNECEDOR { get; set; }

	[Column("vda_especial")]
	public BoolEnum? VENDA_ESPECIAL { get; set; }

	[Column("ativo")]
	public int ATIVO { get; set; }

	[Column("icms_diferido")]
	public BoolEnum? ICMS_DIFERIDO { get; set; }

	[Column("comissao")]
	public BoolEnum? COMISSAO { get; set; }

	[Column("tp_ped_sr")]
	public string TIPO_PEDIDO_SR { get; set; }

	[Column("vs_principal")]
	public BoolEnum? VS_PRINCIPAL { get; set; }

	[Column("curva_abc")]
	public BoolEnum? CURVA_ABC { get; set; }

	[Column("automatico")]
	public BoolEnum AUTOMATICO { get; set; }

	[Column("tp_ped_edi")]
	public string TIPO_PEDIDO_EDI { get; set; }

	[Column("armazenagem")]
	public BoolEnum? ARMAZENAGEM { get; set; }

	[Column("mail_cliente")]
	public BoolEnum? MAIL_CLIENTE { get; set; }

	[Column("mail_vendedor")]
	public BoolEnum? MAIL_VENDEDOR { get; set; }

	[Column("tp_ped_palm")]
	public BoolEnum? TIPO_PEDIDO_PALM { get; set; }

	[Column("bonificacao")]
	public BoolEnum? BONIFICACAO { get; set; }

	[Column("gera_meia_nota")]
	public BoolEnum GERA_MEIA_NOTA { get; set; }

	[Column("tp_ped_meia_nota")]
	public string TIPO_PEDIDO_MEIA_NOTA { get; set; }

	[Column("perc_nota")]
	public decimal? PERCENTUAL_NOTA { get; set; }

	[Column("formpgto_meia_nota")]
	public string FORMA_PAGAMENTO_MEIA_NOTA { get; set; }

	[Column("utiliza_preco_custo")]
	public BoolEnum? UTILIZA_PRECO_CUSTO { get; set; }

	[Column("utiliza_preco_tp_custo")]
	public string UTILIZA_PRECO_TIPO_CUSTO { get; set; }

	[Column("destaque_pedido")]
	public string DESTAQUE_PEDIDO { get; set; }

	[Column("lote_manual")]
	public BoolEnum LOTE_MANUAL { get; set; }

	[Column("prod_controlado")]
	public BoolEnum PRODUTO_CONTROLADO { get; set; }

	[Column("baixa_lote")]
	public string BAIXA_LOTE { get; set; }

	[Column("vda_med_dia")]
	public BoolEnum VENDA_MEDIA_DIA { get; set; }

	[Column("busca_cfop_excecao")]
	public BoolEnum? BUSCA_CFOP_EXCECAO { get; set; }

	[Column("gera_verba")]
	public BoolEnum? GERA_VERBA { get; set; }

	[Column("restr_vda")]
	public BoolEnum? RESTRICAO_VENDA { get; set; }

	[Column("frete_base_calc_icm")]
	public BoolEnum? FRETE_BASE_CALCULO_ICMS { get; set; }

	[Column("quebra_it_bonif")]
	public BoolEnum? QUEBRA_ITEM_BONIFICADO { get; set; }

	[Column("tp_ped_bonif")]
	public string TIPO_PEDIDO_BONIFICACAO { get; set; }

	[Column("nf_item_preco_cheio")]
	public BoolEnum? NOTA_FISCAL_ITEM_PRECO_CHEIO { get; set; }

	[Column("imprime_orcamento")]
	public BoolEnum? IMPRIME_ORCAMENTO { get; set; }

	[Column("calcula_icm_subst")]
	public BoolEnum? CALCULA_ICMS_SUBSTITUTO { get; set; }

	[Column("imp_aliq_icm_itens")]
	public BoolEnum? IMP_ALIQUOTA_ICMS_ITENS { get; set; }

	[Column("calcula_icm_ressarc")]
	public BoolEnum? CALCULA_ICMS_RESSARCIMENTO { get; set; }

	[Column("atualiza_estoque_ctb")]
	public BoolEnum? ATUALIZA_ESTOQUE_CTB { get; set; }

	[Column("imp_aliq_icm_isentos")]
	public BoolEnum? IMP_ALIQUOTA_ICMS_ISENTOS { get; set; }

	[Column("nao_calc_subst_titrec")]
	public BoolEnum? NAO_CALCULA_SUBSTITUICAO_TITULO_RECEBER { get; set; }

	[Column("tp_quebra_meia_nf")]
	public string TIPO_QUEBRA_MEIA_NOTA_FISCAL { get; set; }

	[Column("utiliza_preco_tp_custo_sem_icm")]
	public BoolEnum? UTILIZA_PRECO_TIPO_CUSTO_SEM_ICMS { get; set; }

	[Column("mail_cliente_cod_mod")]
	public int? MAIL_CLIENTE_CODIGO_MOD { get; set; }

	[Column("calcula_icm_ressarc_bonif")]
	public BoolEnum? CALCULA_ICMS_RESSARCIMENTO_BONIFICACAO { get; set; }

	[Column("icm_ressarc_soma_nf")]
	public BoolEnum? ICMS_RESSARCIMENTO_SOMA_NOTA_FISCAL { get; set; }

	[Column("icm_ressarc_soma_titrec")]
	public BoolEnum? ICMS_RESSARCIMENTO_SOMA_TITULO_RECEBIMENTO { get; set; }

	[Column("pedido_pf_x_pj")]
	public BoolEnum? PEDIDO_PF_X_PJ { get; set; }

	[Column("venda_balcao")]
	public BoolEnum? VENDA_BALCAO { get; set; }

	[Column("somente_etapa_fatu")]
	public BoolEnum? SOMENTE_ETAPA_FATURAMENTO { get; set; }

	[Column("outros_locais_est")]
	public BoolEnum? OUTROS_LOCAIS_ESTOQUE { get; set; }

	[Column("selec_lote_todos_itens")]
	public BoolEnum? SELECIONA_LOTE_TODOS_ITENS { get; set; }

	[Column("utiliza_preco_custo_bonif")]
	public BoolEnum? UTILIZA_PRECO_CUSTO_BONIFICADO { get; set; }

	[Column("utiliza_preco_tp_custo_bonif")]
	public string UTILIZA_PRECO_TP_CUSTO_BONIF { get; set; }

	[Column("tp_ped_it_bonif")]
	public string TIPO_PEDIDO_IT_BONIFICADO { get; set; }

	[Column("suframa")]
	public BoolEnum? SUFRAMA { get; set; }

	[Column("utiliza_sit_trib_esp")]
	public BoolEnum? UTILIZA_SITUACAO_TRIBUTACAO_ESP { get; set; }

	[Column("servico")]
	public bool? SERVICO { get; set; }

	[Column("inventario")]
	public BoolEnum? INVENTARIO { get; set; }

	[Column("invent_tp_mov")]
	public string INVENTARIO_TIPO_MOVIMENTACAO { get; set; }

	[Column("servico_tecnico_vend_princ")]
	public BoolEnum? SERVICO_TECNICO_VENDA_PRINCIPAL { get; set; }

	[Column("transf_outros_locais_est")]
	public BoolEnum? TRANSFERENCIA_OUTROS_LOCAIS_ESTOQUE { get; set; }

	[Column("elimina_filas_gerenciais")]
	public bool? ELIMINA_FILAS_GERENCIAIS { get; set; }

	[Column("calc_ipi_frete")]
	public bool? CALCULO_IPI_FRETE { get; set; }

	[Column("somente_etapa_fatu_gera_expe")]
	public bool? SOMENTE_ETAPA_FATURAMENTO_GERA_EXPEDICAO { get; set; }

	[Column("destaque_st_totais_nf")]
	public bool? DESTAQUE_ST_TOTAIS_NF { get; set; }

	[Column("destaque_st_dados_adic")]
	public bool? DESTAQUE_ST_DADOS_ADICIONAIS { get; set; }

	[Column("destaque_ipi_totais_nf")]
	public bool? DESTAQUE_IPI_TOTAIS_NF { get; set; }

	[Column("destaque_ipi_dados_adic")]
	public bool? DESTAQUE_IPI_DADOS_ADIC { get; set; }

	[Column("utiliza_preco_custo_sem_st")]
	public bool? UTILIZA_PRECO_CUSTO_SEM_ST { get; set; }

	[Column("gera_nf_compra_autom")]
	public bool? GERA_NF_COMPRA_AUTOMATICA { get; set; }

	[Column("pedido_nf_entrada")]
	public bool? PEDIDO_NF_ENTRADA { get; set; }

	[Column("destaque_icm_item_st_totais_nf")]
	public bool? DESTAQUE_ICMS_ITEM_ST_TOTAIS_NF { get; set; }

	[Column("destaque_icm_item_st_dados_adic")]
	public bool? DESTAQUE_ICMS_ITEM_ST_DADOS_ADICIONAIS { get; set; }

	[Column("ressarc_industria")]
	public bool? RESSARCIMENTO_INDUSTRIA { get; set; }

	[Column("outros_locais_est_falta_cd_emp")]
	public int? OUTROS_LOCAIS_ESTOQUE_FALTA_CD_EMP { get; set; }

	[Column("outros_locais_est_falta_cd_local")]
	public string OUTROS_LOCAIS_ESTOQUE_FALTA_CD_LOCAL { get; set; }

	[Column("verifica_limite_venda")]
	public bool? VERIFICA_LIMITE_VENDA { get; set; }

	[Column("tp_vl_custo_transf_auto")]
	public string TIPO_VALOR_CUSTO_TRANSFERENCIA_AUTO { get; set; }

	[Column("prod_bonif_valor_zerado")]
	public bool? PRODUTO_BONIFICADO_VALOR_ZERADO { get; set; }

	[Column("prod_bonif_cst_espec")]
	public bool? PRODUTO_BONIFICADO_CST_ESPEC { get; set; }

	[Column("st_aliq_dif")]
	public bool? ST_ALIQUOTA_DIF { get; set; }

	[Column("isenta_pis_cofins")]
	public BoolEnum? ISENTA_PIS_COFINS { get; set; }

	[Column("cst_especifica_pis_cofins")]
	public short? CST_ESPECIFICA_PIS_COFINS { get; set; }

	[Column("TpEntradaTransfAuto")]
	public int? TIPO_ENTRADA_TRANSFERENCIA_AUTO { get; set; }

	[Column("UtilizaTribEstDest")]
	public bool? UTILIZA_TRIBUTACAO_ESTOQUE_DESTINO { get; set; }

	[Column("UtilizaRecopi")]
	public bool UTILIZA_RECOPI { get; set; }

	[Column("DescGerAutoCli")]
	public bool? DESC_GERAL_AUTOMATICO_CLIENTE { get; set; }

	[Column("ipi_base_calc_pis_cofins")]
	public bool? IPI_BASE_CALCULO_PIS_COFINS { get; set; }

	[Column("EnvioPdv")]
	public bool ENVIO_PDV { get; set; }

	[Column("PermiteAltLogistica")]
	public bool? PERMITE_ALTERACAO_LOGISTICA { get; set; }

	[Column("PedidoNFEntradaDevCliente")]
	public bool? PEDIDO_NF_ENTRADA_DEVOLUCAO_CLIENTE { get; set; }

	[Column("EscolhaLoteAuto")]
	public bool? ESCOLHA_LOTE_AUTOMATICO { get; set; }
}
