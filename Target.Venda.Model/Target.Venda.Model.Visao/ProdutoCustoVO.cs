namespace Target.Venda.Model.Visao;

public struct ProdutoCustoVO
{
	public int CODIGO_PRODUTO { get; set; }

	public string TIPO_CUSTO { get; set; }

	public int? SEQ { get; set; }

	public decimal VALOR_CUSTO { get; set; }

	public decimal? VALOR_CUSTO_SEM_IMPOSTOS { get; set; }

	public decimal? VALOR_ICMS_SUBST { get; set; }

	public decimal? VALOR_ICMS_COMPRA { get; set; }

	public decimal? VALOR_PIS { get; set; }

	public decimal? VALOR_CONFINS { get; set; }

	public decimal? CRED_ICMS_PRESUMIDO { get; set; }

	public bool CUSTO_CAPADO_CRED_ICMS { get; set; }
}
