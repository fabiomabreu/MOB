using Target.Venda.Model.Entidade;

namespace Target.Venda.Model.Visao;

public class CalculoVerbaParamVO
{
	public ItemPedidoMO ITEM_PEDIDO { get; set; }

	public PrecoMO PRECO { get; set; }

	public DescontosPedidoVO DESCONTOS { get; set; }

	public TipoPedidoVO TIPO_PEDIDO { get; set; }

	public ConfiguracaoVO PAR_CFG { get; set; }

	public ConfiguracaoTelaVendaVO PARAMETRO_TELA_VENDA { get; set; }

	public ClienteMO CLIENTE { get; set; }
}
