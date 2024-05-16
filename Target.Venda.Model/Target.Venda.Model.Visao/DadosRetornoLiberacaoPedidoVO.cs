namespace Target.Venda.Model.Visao;

public class DadosRetornoLiberacaoPedidoVO
{
	public string CODIGO_FILA_LIBERADO { get; set; }

	public string CODIGO_FILA { get; set; }

	public string PEDIDO_TIPO_ENTREGA { get; set; }

	public string NOME_TABELA_TEMP { get; set; }

	public int? CODIGO_CLIENTE { get; set; }

	public string MENSAGEM_ERRO { get; set; }
}
