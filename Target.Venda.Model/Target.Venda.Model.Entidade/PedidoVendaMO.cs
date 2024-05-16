using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Target.Venda.Model.Base;
using Target.Venda.Model.TipoDado;
using Target.Venda.Model.Visao;

namespace Target.Venda.Model.Entidade;

[Table("ped_vda")]
public class PedidoVendaMO : EntidadeBaseMO
{
	[Column("cd_emp", Order = 1)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CODIGO_EMPRESA { get; set; }

	[NotMapped]
	public EmpresaMO EMPRESA { get; set; }

	[Column("nu_ped", Order = 2)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int NUMERO_PEDIDO { get; set; }

	[Column("cd_emp_orc")]
	public int? CODIGO_EMPRESA_ORCAMENTO { get; set; }

	[Column("nu_ped_orc")]
	public int? NUMERO_PEDIDO_ORCAMENTO { get; set; }

	[Column("cd_vend")]
	public string CODIGO_VENDEDOR { get; set; }

	[NotMapped]
	public VendedorMO VENDEDOR { get; set; }

	[Column("cd_clien")]
	public int CODIGO_CLIENTE { get; set; }

	[NotMapped]
	public ClienteMO CLIENTE { get; set; }

	[Column("distribuidor")]
	public bool? DISTRIBUIDOR { get; set; }

	[Column("cd_clien_dist")]
	public int? CODIGO_CLIENTE_DISTRIBUIDOR { get; set; }

	[Column("seq_prom")]
	public int? SEQ_PROMOCAO { get; set; }

	[NotMapped]
	public PromocaoMO PROMOCAO { get; set; }

	[Column("perc_desc_geral")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_DESCONTO_GERAL { get; set; }

	[Column("vl_desc_geral")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESCONTO_GERAL { get; set; }

	[Column("perc_desc_fin")]
	[DecimalPrecision(6, 4)]
	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO { get; set; }

	[Column("vl_desc_fin")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESCONTO_FINANCEIRO { get; set; }

	[Column("nu_dias_desc_fin")]
	public short? NUMERO_DIAS_DESCONTO_FINANCEIRO { get; set; }

	[Column("tp_estab")]
	public string TIPO_ESTABELECIMENTO { get; set; }

	[Column("tp_ped")]
	public string CODIGO_TIPO_PEDIDO { get; set; }

	[NotMapped]
	public TipoPedidoVO TIPO_PEDIDO { get; set; }

	[NotMapped]
	public TipoPedidoVO TIPO_PEDIDO_SR { get; set; }

	[Column("dt_ped", TypeName = "smalldatetime")]
	public DateTime? DATA_PEDIDO { get; set; }

	[Column("dt_cad")]
	public DateTime DATA_CADASTRO { get; set; }

	[Column("dt_prev_fatu", TypeName = "smalldatetime")]
	public DateTime? DATA_PREVISAO_FATURAMENTO { get; set; }

	[Column("dt_entrega", TypeName = "smalldatetime")]
	public DateTime? DATA_ENTREGA { get; set; }

	[Column("cd_tabela")]
	public string CODIGO_TABELA { get; set; }

	[Column("vl_frete")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_FRETE { get; set; }

	[Column("valor_tot")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_TOTAL { get; set; }

	[Column("peso_tot")]
	[DecimalPrecision(13, 2)]
	public decimal? PESO_TOTAL { get; set; }

	[Column("qtde_volumes")]
	[DecimalPrecision(11, 4)]
	public decimal? QUANTIDADE_VOLUMES { get; set; }

	[Column("qtde_fardos")]
	[DecimalPrecision(11, 4)]
	public decimal? QUANTIDADE_FARDOS { get; set; }

	[Column("qtde_nao_fardos")]
	[DecimalPrecision(11, 4)]
	public decimal? QUANTIDADE_NAO_FARDOS { get; set; }

	[Column("tp_midia")]
	public string TIPO_MIDIA { get; set; }

	[Column("cd_veic")]
	public string CODIGO_VEICULO { get; set; }

	[Column("dt_inicio", TypeName = "smalldatetime")]
	public DateTime? DATA_INICIO { get; set; }

	[NotMapped]
	public DateTime DATA_ABERTURA_PEDIDO { get; set; }

	[NotMapped]
	public DateTime DATA_FECHAMENTO_PEDIDO { get; set; }

	[Column("tp_entrega")]
	public string TIPO_ENTREGA { get; set; }

	[Column("cd_forn")]
	public int? CODIGO_FORNECEDOR { get; set; }

	[NotMapped]
	public FornecedorMO FORNECEDOR { get; set; }

	[Column("ent_outcli")]
	public bool? ENTREGA_OUTRO_CLIENTE { get; set; }

	[Column("cd_clien_outcli")]
	public int? CODIGO_CLIENTE_OUTRO_CLIENTE { get; set; }

	[NotMapped]
	public ClienteMO CLIENTE_ENTREGA { get; set; }

	[Column("nu_ped_cli")]
	public string NUMERO_PEDIDO_CLIENTE { get; set; }

	[Column("verificacao_cred")]
	public bool? VERIFICACAO_CREDITO { get; set; }

	[Column("nu_nf_inic_talao")]
	public int? NUMERO_NOTA_INICIO_TALAO { get; set; }

	[Column("nu_nf_fim_talao")]
	public int? NUMERO_NOTA_FIM_TALAO { get; set; }

	[Column("placa_veiculo")]
	public string PLACA_VEICULO { get; set; }

	[Column("tp_frete")]
	public string TIPO_FRETE { get; set; }

	[Column("tp_prod_ped")]
	public string TIPO_PRODUTO_PEDIDO { get; set; }

	[Column("consig_concluida")]
	public bool? CONSIGNACAO_CONCLUIDA { get; set; }

	[Column("formpgto")]
	public string FORMA_PAGAMENTO { get; set; }

	[Column("cd_rot_prdf")]
	public string CODIGO_ROTA { get; set; }

	[Column("cfop")]
	public int? CFOP { get; set; }

	[Column("icms_diferido")]
	public BoolEnum? ICMS_DIFERIDO { get; set; }

	[Column("situacao")]
	public string SITUACAO { get; set; }

	[Column("cd_texto")]
	public int? CODIGO_TEXTO { get; set; }

	[Column("cfop_sr")]
	public int? CFOP_SR { get; set; }

	[Column("qtde_imp_sepa")]
	public int? QUANTIDADE_IMP_SEPARACAO { get; set; }

	[Column("qtde_imp_orca")]
	public byte? QUANTIDADE_IMP_ORCAMENTO { get; set; }

	[Column("cliente_novo")]
	public BoolEnum? CLIENTE_NOVO { get; set; }

	[Column("nu_nf_prt_entg")]
	public int? NUMERO_NOTA_PRONTA_ENTREGA { get; set; }

	[Column("dt_emis_prt_entg", TypeName = "smalldatetime")]
	public DateTime? DATA_EMISSAO_PRONTA_ENTREGA { get; set; }

	[Column("dt_entrega_final", TypeName = "smalldatetime")]
	public DateTime? DATA_ENTREGA_FINAL { get; set; }

	[Column("nu_ped_orig_bon")]
	public int? NUMERO_PEDIDO_ORIGEM_BONIFICADO { get; set; }

	[Column("cd_vend_lc")]
	public string CODIGO_VENDEDOR_LANCADOR { get; set; }

	[Column("perc_comis_vend")]
	[DecimalPrecision(7, 4)]
	public decimal PERCENTUAL_COMISSAO_VENDEDOR { get; set; }

	[Column("perc_comis_lanc")]
	[DecimalPrecision(7, 4)]
	public decimal PERCENTUAL_COMISSAO_LANCADOR { get; set; }

	[Column("cd_vend_comis")]
	public string CODIGO_VENDEDOR_COMISSAO { get; set; }

	[Column("peso_tot_liq")]
	[DecimalPrecision(13, 2)]
	public decimal? PESO_TOTAL_LIQUIDO { get; set; }

	[Column("origem_pedido")]
	public string ORIGEM_PEDIDO { get; set; }

	[Column("suframa")]
	public BoolEnum SUFRAMA { get; set; }

	[Column("cd_usr_separador")]
	public string CODIGO_USUARIO_SEPARADOR { get; set; }

	[Column("dt_inic_sepa", TypeName = "smalldatetime")]
	public DateTime? DATA_INICIAL_SEPARACAO { get; set; }

	[Column("dt_fim_sepa", TypeName = "smalldatetime")]
	public DateTime? DATA_FINAL_SEPARACAO { get; set; }

	[Column("lanc_cred_verba")]
	public string LANCAMENTO_CREDITO_VERBA { get; set; }

	[Column("qtde_vol_ab")]
	public int? QUANTIDADE_VOLUME_ABERTO { get; set; }

	[Column("urgente")]
	public BoolEnum? URGENTE { get; set; }

	[Column("cd_vend_verba")]
	public string CODIGO_VENDEDOR_VERBA { get; set; }

	[Column("qtde_vol_fe")]
	public int? QUANTIDADE_VOLUME_FECHADO { get; set; }

	[Column("seq_cont_cli")]
	public short? SEQ_CONTATO_CLIENTE { get; set; }

	[Column("cd_emp_quebra_nf")]
	public int? CODIGO_EMPRESA_QUEBRA_NOTA_FISCAL { get; set; }

	[Column("nu_ped_quebra_nf")]
	public int? NUMERO_PEDIDO_QUEBRA_NOTA_FISCAL { get; set; }

	[Column("desm_quebra_nf")]
	public BoolEnum? DESMENBRAR_QUEBRA_NOTA_FISCAL { get; set; }

	[Column("prz_medio")]
	[DecimalPrecision(5, 2)]
	public decimal? PRAZO_MEDIO { get; set; }

	[Column("prev_vda_flx_caixa")]
	public BoolEnum? PREVISAO_VENDA_FLUXO_CAIXA { get; set; }

	[Column("cd_grupo_prd")]
	public string CODIGO_GRUPO_PRODUTO { get; set; }

	[Column("tp_vl_base_comissao")]
	public string TIPO_VALOR_BASE_COMISSAO { get; set; }

	[Column("cd_vend_rt")]
	public string CODIGO_VENDEDOR_RT { get; set; }

	[Column("vl_comis_rt")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_COMISSAO_RT { get; set; }

	[Column("seq_lc_fatu")]
	public int? SEQ_LOCAL_FATURAMENTO { get; set; }

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

	[Column("cd_vend_serv_interno")]
	public string CODIGO_VENDEDOR_SERVICO_INTERNO { get; set; }

	[Column("cd_vend_serv_tecnico")]
	public string CODIGO_VENDEDOR_SERVICO_TECNICO { get; set; }

	[Column("vl_cust_frete")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_CUSTO_FRETE { get; set; }

	[Column("st_remu_inst")]
	public string ST_REMUNERADO_INST { get; set; }

	[Column("cd_forn_inst")]
	public int? CODIGO_FORNECEDOR_INST { get; set; }

	[Column("dt_inst", TypeName = "smalldatetime")]
	public DateTime? DATA_INST { get; set; }

	[Column("vl_custo_inst")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_CUSTO_INST { get; set; }

	[Column("vl_remu_inst")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_REMUNERACAO_INST { get; set; }

	[Column("dt_pgto_inst", TypeName = "smalldatetime")]
	public DateTime? DATA_PAGAMENTO_INST { get; set; }

	[Column("vl_frete_nao_soma_ped")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_FRETE_NAO_SOMA_PEDIDO { get; set; }

	[Column("cd_emp_original")]
	public int? CODIGO_EMPRESA_ORIGINAL { get; set; }

	[Column("nu_ped_original")]
	public int? NUMERO_PEDIDO_ORIGINAL { get; set; }

	[Column("qtde_imp_lmer")]
	public int? QUANTIDADE_IMPRESSAO_LISTA_MERCADORIAS { get; set; }

	[Column("seq_trib_cli")]
	public int? SEQ_TRIBUTACAO_CLIENTE { get; set; }

	[Column("sigla_separacao")]
	public string SIGLA_SEPARACAO { get; set; }

	[Column("vl_desp_aces")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_DESPESAS_ACESSORIAS { get; set; }

	[Column("export_uf_embarque")]
	public string EXPORT_UF_EMBARQUE { get; set; }

	[Column("export_local_embarque")]
	public string EXPORT_LOCAL_EMBARQUE { get; set; }

	[Column("import_vl_siscomex")]
	[DecimalPrecision(13, 2)]
	public decimal? IMPORT_VALOR_SISCOMEX { get; set; }

	[Column("import_aliq_ii")]
	[DecimalPrecision(6, 4)]
	public decimal? IMPORT_ALIQUOTA_II { get; set; }

	[Column("situacao_it_pedv")]
	[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	public int? SITUACAO_ITENS_PEDIDO { get; set; }

	[Column("VlTotNf")]
	[DecimalPrecision(13, 2)]
	public decimal? VALOR_TOTAL_NOTA_FISCAL { get; set; }

	[Column("PercDescGerAuto")]
	[DecimalPrecision(13, 4)]
	public decimal? PERCENTUAL_DESCONTO_GERACAO_AUTOMATICA { get; set; }

	[Column("wms_transf_end_final")]
	public BoolEnum? WMS_TRANFERENCIA_ENDERECO_FINAL { get; set; }

	[Column("lote_reservado")]
	public BoolEnum? LOTE_RESERVADO { get; set; }

	[Column("sepa_hibrida_pedido")]
	public bool? SEPARACAO_HIBRIDA_PEDIDO { get; set; }

	[Column("RotPrdfDiaDiarioID")]
	public int? ROTA_PRDF_DIA_DIARIO_ID { get; set; }

	[Column("CdDoca")]
	public string CODIGO_DOCA { get; set; }

	[Column("VlFreteAlteradoManual")]
	public bool? VALOR_FRETE_ALTERADO_MANUAL { get; set; }

	[Column("InicioProcessoFatura")]
	public bool? INICIO_PROCESSO_FATURA { get; set; }

	[Column("VlJuros")]
	public decimal? VALOR_JUROS { get; set; }

	[Column("VlTaxaContrato")]
	public decimal? VALOR_TAXA_CONTRATO { get; set; }

	[Column("IntermediadorID")]
	public int? INTERMEDIADOR_ID { get; set; }

	[Column("ValorCupom")]
	public decimal? VALOR_CUPOM { get; set; }

	public byte? SEQ_TRIB_REG_EMP { get; set; }

	public string DESCRICAO_VAN { get; set; }

	public List<ItemPedidoMO> ITENS { get; set; }

	public List<ObservacaoPedidoMO> OBSERVACOES { get; set; }

	public List<FaltaProdutoMO> FALTAS_PRODUTOS { get; set; }

	public List<ParcelaPedidoMO> PARCELAS { get; set; }

	public List<EnderecoPedidoMO> ENDERECOS { get; set; }

	[NotMapped]
	public string TIPO_DESCONTO_GERAL { get; set; }

	[NotMapped]
	public bool BUSCA_RED_COMISSAO_VENDEDOR { get; set; }

	[NotMapped]
	public List<AcaoComercialVO> ACOES_COMERCIAIS { get; set; }

	[NotMapped]
	public TrocaMO TROCA { get; set; }

	[NotMapped]
	public PedidoEletronicoMO PEDIDO_ELETRONICO { get; set; }

	[NotMapped]
	public InscricaoEstadualVO IE_VALIDA { get; set; }

	[NotMapped]
	public int? CAMPANHAID { get; set; }

	[NotMapped]
	public CampanhaMO CAMPANHA { get; set; }

	[NotMapped]
	public int? QTDE_PARCELAS_CARTAO_CREDITO { get; set; }
}
