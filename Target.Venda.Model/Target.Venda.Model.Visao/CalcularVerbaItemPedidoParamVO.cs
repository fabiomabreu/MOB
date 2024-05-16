using Target.Venda.Model.Entidade;

namespace Target.Venda.Model.Visao;

public class CalcularVerbaItemPedidoParamVO
{
	public ValorBaseCalculoVerbaVO VALORES_BASE { get; set; }

	public ItemPedidoMO ITEM_PEDIDO { get; set; }

	public PrecoMO PRECO { get; set; }

	public ConfiguracaoVO PARCFG { get; set; }

	public VendedorMO VENDEDOR { get; set; }

	public EquipeMO EQUIPE_VENDEDOR { get; set; }
}
