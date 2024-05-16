namespace Target.Venda.Model.Visao;

public class DescontosPedidoVO
{
	public decimal DESCONTO_PERMITIDO_PRODUTO { get; set; }

	public decimal DESCONTO_VENDEDOR { get; set; }

	public decimal DESCONTO_CLIENTE { get; set; }

	public decimal TOTAL_DESCONTO_PERMITIDO { get; set; }

	public decimal PERCENTUAL_DESCONTO { get; set; }

	public decimal PERCENTUAL_DESCONTO_SEM_CAMPANHA { get; set; }

	public decimal DESCONTO_PERMITIDO_CLIENTE { get; set; }
}
