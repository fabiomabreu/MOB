namespace Target.Venda.Model.Visao;

public class TotaisPedidoEletronicoVO
{
	public decimal VALOR_TOTAL { get; set; }

	public decimal TOTAL_ORIGINAL { get; set; }

	public decimal TOTAL_PEDIDA { get; set; }

	public decimal VALOR_DESCONTO_GERAL { get; set; }

	public decimal DESCONTO_ITEM { get; set; }

	public decimal VALOR_DESCONTO_ITEM { get; set; }

	public decimal DESCONTO_APENAS_ITEM { get; set; }

	public decimal VALOR_DESCONTO_APENAS_ITEM { get; set; }

	public decimal VALOR_DESCONTO_PERMITIDO { get; set; }
}
