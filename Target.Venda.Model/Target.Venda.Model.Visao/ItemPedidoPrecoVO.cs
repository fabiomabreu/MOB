namespace Target.Venda.Model.Visao;

public class ItemPedidoPrecoVO
{
	public short SEQ { get; set; }

	public decimal PRECO_BASICO { get; set; }

	public decimal TOTAL { get; set; }

	public decimal PRECO_UNITARIO { get; set; }

	public decimal PRECO_TABELA { get; set; }

	public decimal PRECO_NOTA_FISCAL { get; set; }

	public decimal VALOR_UNITARIO_VENDA { get; set; }

	public decimal VALOR_UNITARIO_PEDIDA { get; set; }

	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO { get; set; }

	public decimal? PERCENTUAL_DESCONTO_FINANCEIRO_AUTO { get; set; }

	public decimal? DESCONTO_APLICADO { get; set; }

	public decimal? DESCONTO_01 { get; set; }

	public decimal? DESCONTO_02 { get; set; }

	public decimal? DESCONTO_GRADE_BONIFICADO { get; set; }

	public decimal? DESCONTO_GRADE_FINANCEIRO { get; set; }

	public decimal? COEFICIENTE_CUSTO_FINANCEIRO { get; set; }
}
