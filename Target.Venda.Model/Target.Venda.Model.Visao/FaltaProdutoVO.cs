namespace Target.Venda.Model.Visao;

public class FaltaProdutoVO
{
	public decimal SEQ_ITEM { get; set; }

	public int CODIGO_PRODUTO { get; set; }

	public decimal QUANTIDADE_FALTA { get; set; }

	public string UNIDADE_ESTOQUE { get; set; }

	public decimal PRECO_BASICO { get; set; }

	public string UNIDADE_VENDA { get; set; }

	public decimal? PRECO_UNITARIO { get; set; }

	public bool BONIFICADO { get; set; }

	public int? SEQ_KIT { get; set; }
}
