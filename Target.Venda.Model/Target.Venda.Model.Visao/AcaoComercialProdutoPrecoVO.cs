namespace Target.Venda.Model.Visao;

public class AcaoComercialProdutoPrecoVO
{
	public int SEQ_ACAO_COMERCIAL { get; set; }

	public string CODIGO_TABELA { get; set; }

	public int CODIGO_PRODUTO { get; set; }

	public decimal VALOR_PRECO_ACAO_COMERCIAL { get; set; }

	public decimal VALOR_PRECO_POS_ACAO_COMERCIAL { get; set; }

	public decimal VALOR_PRECO_TABELA { get; set; }

	public decimal VALOR_PRECO_ATUALIZADO { get; set; }
}
