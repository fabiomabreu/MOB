namespace Target.Venda.Model.Visao;

public class FiltroItemPedidoVO
{
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	public decimal SEQ_PEDIDO_ELETRONICO { get; set; }

	public string CODIGO_TABELA { get; set; }

	public string CODIGO_GRUPO_COMISSAO { get; set; }

	public string ESTADO_ORIGEM { get; set; }

	public string ESTADO_DESTINO { get; set; }

	public bool MANTER_DESCONTO_APLICADO_PEDIDO_ELETRONICO { get; set; }

	public string CODIGO_TRIBUTACAO_TIPO_SIT_TRIB { get; set; }

	public bool DEVOLUCAO_FORNECEDOR { get; set; }

	public bool UTILIZA_SIT_TRIB_ESP_TP_PED { get; set; }

	public bool UTILIZA_SITUACAO_TRIBUTACAO_ESP { get; set; }

	public bool IMPRIME_NOTA_FISCAL { get; set; }

	public bool UTILIZA_PRECO_CUSTO { get; set; }
}
