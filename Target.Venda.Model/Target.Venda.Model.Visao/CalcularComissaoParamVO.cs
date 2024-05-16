using Target.Venda.Model.Entidade;

namespace Target.Venda.Model.Visao;

public class CalcularComissaoParamVO
{
	public ItemPedidoMO ITEM_PEDIDO { get; set; }

	public int QTDE_CASAS_DECIMAIS { get; set; }

	public ConfiguracaoVO PARCFG { get; set; }

	public PedidoVendaMO PEDIDO_VENDA { get; set; }

	public ClienteMO CLIENTE { get; set; }
}
