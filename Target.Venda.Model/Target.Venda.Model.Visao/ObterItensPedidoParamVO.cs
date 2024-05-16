namespace Target.Venda.Model.Visao;

public class ObterItensPedidoParamVO
{
	public bool IMPRIME_NOTA_FISCAL { get; set; }

	public bool MANTER_DESCONTO_APLICADO_PEDIDO_ELETRONICO { get; set; }

	public bool DEVOLUCAO_FORNECEDOR { get; set; }

	public bool UTILIZA_SIT_TRIB_ESP_TP_PED { get; set; }

	public bool UTILIZA_SITUACAO_TRIBUTACAO_ESP { get; set; }

	public string CODIGO_TRIBUTACAO_TIPO_SIT_TRIB { get; set; }

	public string CODIGO_GRUPO { get; set; }

	public int SEQ_PROMOCAO { get; set; }

	public string CODIGO_TABELA { get; set; }

	public int CODIGO_EMPRESA { get; set; }

	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	public string ESTADO_DE { get; set; }

	public string ESTADO_PARA { get; set; }
}
