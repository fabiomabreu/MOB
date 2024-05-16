namespace Target.Venda.Model.Visao;

public class ObterDescontoParamVO
{
	public bool DESC_COND_PAGTO_UTILIZAR_DESCONTO_AUTOMATICO { get; set; }

	public int CODIGO_PRODUTO { get; set; }

	public string CODIGO_TABELA { get; set; }

	public int? SEQ_PROMOCAO { get; set; }

	public decimal QUANTIDADE { get; set; }
}
