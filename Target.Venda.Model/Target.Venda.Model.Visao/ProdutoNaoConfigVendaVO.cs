namespace Target.Venda.Model.Visao;

public class ProdutoNaoConfigVendaVO
{
	public int CODIGO_PRODUTO { get; set; }

	public string DESCRICAO_PRODUTO { get; set; }

	public string DESCRICAO_TIPO_PEDIDO { get; set; }

	public int? EXISTE_PROMOCAO_EMPRESA { get; set; }

	public int? EXISTE_TABELA_PRECO_EMPRESA { get; set; }

	public string DESCRICAO_TABELA_PRECO { get; set; }

	public decimal? VALOR_PRECO { get; set; }

	public decimal? VALOR_PARCELA { get; set; }

	public bool? EXISTE_ICM_PROD { get; set; }

	public string CODIGO_SITUACAO_TRIB { get; set; }

	public string TIPO_SITUACAO_TRIB { get; set; }

	public string UNIDADE_ESTOQUE { get; set; }

	public string DESCRICAO_LOCAL_ESTOQUE { get; set; }

	public string DESCRICAO_GRUPO_COMISSAO { get; set; }
}
