using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Visao;

public class ItemPedidoKitPromocaoVO
{
	public short SEQ { get; set; }

	public int? SEQ_KIT_PROMOCAO { get; set; }

	public BoolEnum? BONIFICADO { get; set; }

	public string REQUISITO_BONIFICADO { get; set; }

	public decimal? VALOR_VERBA { get; set; }

	public decimal? VALOR_VERBA_FABRICANTE_ADIC { get; set; }

	public decimal PERCENTUAL_DESCONTO_AUX { get; set; }

	public bool VERBA_VENDEDOR { get; set; }

	public bool VERBA_VENDEDOR_BONIF { get; set; }

	public bool CONSIDERA_PRECO_PROMOCAO { get; set; }

	public bool PROMOCAO_CONSIDERA_REDUCAO_COMISSAO { get; set; }
}
