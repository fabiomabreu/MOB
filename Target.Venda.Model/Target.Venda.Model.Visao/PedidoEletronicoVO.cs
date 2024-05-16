using System;

namespace Target.Venda.Model.Visao;

public class PedidoEletronicoVO
{
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	public int SEQ_EVENTO { get; set; }

	public string NRO_PEDIDO_CLIENTE { get; set; }

	public string TIPO_PEDIDO { get; set; }

	public int CODIGO_CLIENTE { get; set; }

	public string CODIGO_VENDEDOR { get; set; }

	public decimal? VALOR_TOTAL { get; set; }

	public decimal? VALOR_TOTAL_COM_DESCONTO { get; set; }

	public string NOME_CLIENTE { get; set; }

	public int TOTAL_ITENS { get; set; }

	public string TIPO_INTEGRACAO { get; set; }

	public DateTime DATA_PEDIDO { get; set; }
}
