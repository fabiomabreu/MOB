namespace Target.Venda.Business.Helpers;

public class ImpostosPedidoVendaResponse
{
	public decimal BASE_CALCULO_ICMS { get; set; }

	public decimal VALOR_ICMS { get; set; }

	public decimal BASE_CALCULO_IPI { get; set; }

	public decimal VALOR_IPI { get; set; }

	public decimal BASE_CALCULO_SUBST_TRIB { get; set; }

	public decimal VALOR_SUBST_TRIB { get; set; }

	public decimal VALOR_PIS { get; set; }

	public decimal VALOR_COFINS { get; set; }

	public decimal BASE_CALCULO_RESSARCIMENTO_ICMS { get; set; }

	public decimal VALOR_RESSARCIMENTO_ICMS { get; set; }

	public decimal BASE_CALCULO_REPASSE_SUBST_TRIB { get; set; }

	public decimal VALOR_REPASSE_SUBST_TRIB { get; set; }

	public decimal BASE_CALCULO_RESTRICAO_SUBST_TRIB { get; set; }

	public decimal VALOR_RESTITUICAO_SUBST_TRIB { get; set; }

	public decimal ALIQUOTA_ICMS { get; set; }

	public decimal ALIQUOTA_IPI { get; set; }

	public decimal MARGEM_SUBST_TRIB { get; set; }

	public decimal PERCENTUAL_REDUCAO_BASE_SUBST_TRIB { get; set; }

	public decimal MODALIDADE_ICMS { get; set; }

	public decimal MODALIDADE_ICMS_SUBST_TRIB { get; set; }

	public decimal VALOR_ADICIONAL_NF { get; set; }

	public decimal ALIQUOTA_CREDITO_ICMS_SIMPLES_NACIONAL { get; set; }

	public decimal PERCENTUAL_REDUCAO_BASE_CALCULO { get; set; }

	public decimal ALIQUOTA_ICMS_CALCULO_ST_ICMS_PROPRIO { get; set; }

	public decimal VALOR_IMPOSTO_IMPORTACAO { get; set; }

	public decimal VALOR_SISCOMEX { get; set; }

	public decimal CODIGO_TRIBUTACAO_CLIENTE { get; set; }

	public decimal ALIQUOTA_ICMS_ST { get; set; }

	public decimal VALOR_ICMS_DESONERADO { get; set; }
}
