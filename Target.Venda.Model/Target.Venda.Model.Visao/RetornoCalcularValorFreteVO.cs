namespace Target.Venda.Model.Visao;

public class RetornoCalcularValorFreteVO
{
	public string TIPO_COBRANCA_FRETE { get; set; }

	public decimal VALOR_FRETE_UNIDADE { get; set; }

	public decimal PERCENTUAL_FRETE { get; set; }

	public decimal VALOR_TAXA_FIXA { get; set; }

	public decimal VALOR_FRETE_MINIMO { get; set; }

	public bool ISENCAO_FRETE { get; set; }

	public bool CALCULA_FRETE_CIF { get; set; }

	public bool CALCULA_FRETE_FOB { get; set; }

	public decimal ISENCAO_VALOR_MINIMO_PEDIDO { get; set; }

	public decimal VALOR_TOTAL_FRETE { get; set; }
}
