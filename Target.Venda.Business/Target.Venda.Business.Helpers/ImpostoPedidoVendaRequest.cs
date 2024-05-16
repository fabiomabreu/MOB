namespace Target.Venda.Business.Helpers;

public class ImpostoPedidoVendaRequest
{
	public int CODIGO_EMPRESA { get; set; }

	public string TIPO_PEDIDO { get; set; }

	public int CODIGO_PRODUTO { get; set; }

	public decimal PRECO_TABELA { get; set; }

	public decimal PERCENTUAL_DESCONTO { get; set; }

	public string UF { get; set; }

	public int CODIGO_CLIENTE { get; set; }

	public decimal QUANTIDADE_UNIDADE_PEDIDA { get; set; }

	public decimal QUANTIDADE_UNIDADE_ESTOQUE { get; set; }

	public decimal VALOR_UNITARIO_VENDA { get; set; }

	public decimal VALOR_FRETE_ITEM { get; set; }

	public decimal VALOR_DESCONTO_GERAL { get; set; }

	public bool BONIFICADO { get; set; }
}
