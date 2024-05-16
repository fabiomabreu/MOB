namespace Target.Venda.Model.Visao;

public class FreteVO
{
	public decimal SEQ_REG { get; set; }

	public decimal VALOR_FRETE_UNIDADE { get; set; }

	public decimal VALOR_FRETE_MINIMO { get; set; }

	public bool CALCULAR_FRETE_CIF { get; set; }

	public bool CALCULAR_FRETE_FOB { get; set; }

	public bool TIPO_COBRANCA_CUBAGEM { get; set; }

	public decimal? TIPO_COBRANCA_CUBAGEM_VALOR { get; set; }

	public bool TIPO_COBRANCA_PESAGEM { get; set; }

	public decimal? TIPO_COBRANCA_PESAGEM_VALOR { get; set; }

	public bool TIPO_COBRANCA_PERCENTUAL { get; set; }

	public decimal? TIPO_COBRANCA_PERCENTUAL_VALOR { get; set; }

	public bool MELHOR_CALCULO { get; set; }

	public bool TIPO_COBRANCA_FIXO_PESO { get; set; }

	public bool TIPO_COBRANCA_FIXO_VALOR { get; set; }

	public int SEQ_FRETE { get; set; }

	public bool TIPO_COBRANCA_PRECO { get; set; }

	public bool ISENCAO { get; set; }

	public decimal? ISENCAO_VALOR_MINIMO_PEDIDO { get; set; }

	public string TIPO_COBRANCA_FRETE { get; set; }

	public decimal PERCENTUAL_FRETE { get; set; }

	public decimal VALOR_TAXA_FIXA { get; set; }

	public decimal CALCULO_FRETE_APARTIR { get; set; }
}
