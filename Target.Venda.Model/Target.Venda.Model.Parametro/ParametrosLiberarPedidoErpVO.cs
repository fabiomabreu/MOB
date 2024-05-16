namespace Target.Venda.Model.Parametro;

public class ParametrosLiberarPedidoErpVO
{
	public int CODIGO_EMPRESA { get; set; }

	public int NUMERO_PEDIDO { get; set; }

	public string CODIGO_USUARIO { get; set; }

	public bool UTILIZA_FRETE { get; set; }

	public string CODIGO_FILA_ATUAL { get; set; }
}
