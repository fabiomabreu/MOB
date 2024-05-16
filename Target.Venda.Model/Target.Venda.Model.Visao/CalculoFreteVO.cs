namespace Target.Venda.Model.Visao;

public class CalculoFreteVO
{
	public decimal VALOR_TOTAL_ITENS { get; set; }

	public decimal VALOR_FRETE_CUBAGEM { get; set; }

	public decimal VALOR_FRETE_PESAGEM { get; set; }

	public decimal VALOR_FRETE_PERCENTUAL { get; set; }

	public decimal VALOR_FRETE_FIXA_VALOR { get; set; }

	public decimal VALOR_FRETE_FIXA_PESO { get; set; }

	public decimal VALOR_TOTAL_PEDIDO { get; set; }
}
