namespace Target.Venda.Model.Visao;

public class ParametrosLiberarPedidoEletronicoVO
{
	public int CODIGO_EMPRESA_ELETRONICO { get; set; }

	public int NUMERO_PEDIDO_ELETRONICO { get; set; }

	public int NUMERO_SEQ_PEDIDO { get; set; }

	public string CODIGO_USUARIO { get; set; }

	public string NOME_PROGRAMA { get; set; }

	public decimal VALOR_MINIMO_INTEGRACAO { get; set; }
}
