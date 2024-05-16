namespace Target.Venda.Model.Visao;

public class TipoPedidoVO
{
	public string CODIGO_TIPO_PEDIDO { get; set; }

	public string DESCRICAO { get; set; }

	public bool ATUALIZA_ESTOQUE { get; set; }

	public bool GERA_TITULO_RECEBER { get; set; }

	public bool IMPRIME_NOTA_FISCAL { get; set; }

	public bool CALCULA_ICMS { get; set; }

	public bool CALCULA_IPI { get; set; }

	public bool ESTATISTICA_COMERCIAL { get; set; }

	public bool PRINCIPAL { get; set; }

	public bool TRANSFERENCIA_ESTOQUE { get; set; }

	public int? CODIGO_EMPRESA_TRANSFERENCIA { get; set; }

	public string CODIGO_LOCAL_TRANSFERENCIA { get; set; }

	public bool CALCULA_ICMS_IPI { get; set; }

	public bool AUTOMATICO_3_CASA { get; set; }

	public bool IPI_BASE_CALCULO_ICMS { get; set; }

	public bool CONSIGNACAO { get; set; }

	public bool VENDA_POS_CONSIGNACAO { get; set; }

	public bool DEVOLUCAO_FORNECEDOR { get; set; }

	public bool VENDA_ESPECIAL { get; set; }

	public bool ATIVO { get; set; }

	public bool ICMS_DIFERIDO { get; set; }

	public bool COMISSAO { get; set; }

	public string TIPO_PEDIDO_SR { get; set; }

	public bool VS_PRINCIPAL { get; set; }

	public bool CURVA_ABC { get; set; }

	public bool AUTOMATICO { get; set; }

	public string TIPO_PEDIDO_EDI { get; set; }

	public bool ARMAZENAGEM { get; set; }

	public bool MAIL_CLIENTE { get; set; }

	public bool MAIL_VENDEDOR { get; set; }

	public bool TIPO_PEDIDO_PALM { get; set; }

	public bool BONIFICACAO { get; set; }

	public bool GERA_MEIA_NOTA { get; set; }

	public string TIPO_PEDIDO_MEIA_NOTA { get; set; }

	public decimal? PERCENTUAL_NOTA { get; set; }

	public string FORMA_PAGAMENTO_MEIA_NOTA { get; set; }

	public bool UTILIZA_PRECO_CUSTO { get; set; }

	public string UTILIZA_PRECO_TIPO_CUSTO { get; set; }

	public string DESTAQUE_PEDIDO { get; set; }

	public bool LOTE_MANUAL { get; set; }

	public bool PRODUTO_CONTROLADO { get; set; }

	public string BAIXA_LOTE { get; set; }

	public bool VENDA_MEDIA_DIA { get; set; }

	public bool BUSCA_CFOP_EXCECAO { get; set; }

	public bool GERA_VERBA { get; set; }

	public bool RESTRICAO_VENDA { get; set; }

	public bool FRETE_BASE_CALCULO_ICMS { get; set; }

	public bool QUEBRA_ITEM_BONIFICADO { get; set; }

	public string TIPO_PEDIDO_BONIFICACAO { get; set; }

	public bool NOTA_FISCAL_ITEM_PRECO_CHEIO { get; set; }

	public bool IMPRIME_ORCAMENTO { get; set; }

	public bool CALCULA_ICMS_SUBSTITUTO { get; set; }

	public bool IMP_ALIQUOTA_ICMS_ITENS { get; set; }

	public bool CALCULA_ICMS_RESSARCIMENTO { get; set; }

	public bool ATUALIZA_ESTOQUE_CTB { get; set; }

	public bool IMP_ALIQUOTA_ICMS_ISENTOS { get; set; }

	public bool NAO_CALCULA_SUBSTITUICAO_TITULO_RECEBER { get; set; }

	public string TIPO_QUEBRA_MEIA_NOTA_FISCAL { get; set; }

	public bool UTILIZA_PRECO_TIPO_CUSTO_SEM_ICMS { get; set; }

	public int? MAIL_CLIENTE_CODIGO_MOD { get; set; }

	public bool CALCULA_ICMS_RESSARCIMENTO_BONIFICACAO { get; set; }

	public bool ICMS_RESSARCIMENTO_SOMA_NOTA_FISCAL { get; set; }

	public bool ICMS_RESSARCIMENTO_SOMA_TITULO_RECEBIMENTO { get; set; }

	public bool PEDIDO_PF_X_PJ { get; set; }

	public bool VENDA_BALCAO { get; set; }

	public bool SOMENTE_ETAPA_FATURAMENTO { get; set; }

	public bool OUTROS_LOCAIS_ESTOQUE { get; set; }

	public bool SELECIONA_LOTE_TODOS_ITENS { get; set; }

	public bool UTILIZA_PRECO_CUSTO_BONIFICADO { get; set; }

	public string UTILIZA_PRECO_TP_CUSTO_BONIF { get; set; }

	public string TIPO_PEDIDO_IT_BONIFICADO { get; set; }

	public bool SUFRAMA { get; set; }

	public bool UTILIZA_SITUACAO_TRIBUTACAO_ESP { get; set; }

	public bool SERVICO { get; set; }

	public bool INVENTARIO { get; set; }

	public string INVENTARIO_TIPO_MOVIMENTACAO { get; set; }

	public bool SERVICO_TECNICO_VENDA_PRINCIPAL { get; set; }

	public bool TRANSFERENCIA_OUTROS_LOCAIS_ESTOQUE { get; set; }

	public bool ELIMINA_FILAS_GERENCIAIS { get; set; }

	public bool CALCULO_IPI_FRETE { get; set; }

	public bool SOMENTE_ETAPA_FATURAMENTO_GERA_EXPEDICAO { get; set; }

	public bool DESTAQUE_ST_TOTAIS_NF { get; set; }

	public bool DESTAQUE_ST_DADOS_ADICIONAIS { get; set; }

	public bool DESTAQUE_IPI_TOTAIS_NF { get; set; }

	public bool DESTAQUE_IPI_DADOS_ADIC { get; set; }

	public bool UTILIZA_PRECO_CUSTO_SEM_ST { get; set; }

	public bool GERA_NF_COMPRA_AUTOMATICA { get; set; }

	public bool PEDIDO_NF_ENTRADA { get; set; }

	public bool DESTAQUE_ICMS_ITEM_ST_TOTAIS_NF { get; set; }

	public bool DESTAQUE_ICMS_ITEM_ST_DADOS_ADICIONAIS { get; set; }

	public bool RESSARCIMENTO_INDUSTRIA { get; set; }

	public int? OUTROS_LOCAIS_ESTOQUE_FALTA_CD_EMP { get; set; }

	public string OUTROS_LOCAIS_ESTOQUE_FALTA_CD_LOCAL { get; set; }

	public bool VERIFICA_LIMITE_VENDA { get; set; }

	public string TIPO_VALOR_CUSTO_TRANSFERENCIA_AUTO { get; set; }

	public bool PRODUTO_BONIFICADO_VALOR_ZERADO { get; set; }

	public bool PRODUTO_BONIFICADO_CST_ESPEC { get; set; }

	public bool TRANSFERENCIA_ATUALIZA_CUSTO { get; set; }

	public bool ST_ALIQUOTA_DIF { get; set; }

	public bool ISENTA_PIS_COFINS { get; set; }

	public short? CST_ESPECIFICA_PIS_COFINS { get; set; }

	public int? TIPO_ENTRADA_TRANSFERENCIA_AUTO { get; set; }

	public bool UTILIZA_TRIBUTACAO_ESTOQUE_DESTINO { get; set; }

	public bool UTILIZA_RECOPI { get; set; }

	public bool DESC_GERAL_AUTOMATICO_CLIENTE { get; set; }

	public bool IPI_BASE_CALCULO_PIS_COFINS { get; set; }

	public bool ENVIO_PDV { get; set; }

	public bool PERMITE_ALTERACAO_LOGISTICA { get; set; }

	public bool PEDIDO_NF_ENTRADA_DEVOLUCAO_CLIENTE { get; set; }

	public bool CONSUMIDOR_FINAL { get; set; }

	public bool ESCOLHA_LOTE_AUTOMATICO { get; set; }

	public bool IGNORAR_VALIDACAO_VALOR_MIN_PEDIDO { get; set; }

	public bool NFCE_SEM_IDENTIFICACAO_DESTINATARIO { get; set; }
}
