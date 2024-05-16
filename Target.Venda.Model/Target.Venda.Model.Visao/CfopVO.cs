using Target.Venda.Model.Enum;

namespace Target.Venda.Model.Visao;

public class CfopVO
{
	public string TIPO_PEDIDO { get; set; }

	public string TIPO_DESTINO_CLIENTE { get; set; }

	public bool AREA_LIVRE_COMERCIO { get; set; }

	public TipoProdutoCFOPEnum? TIPO_PRODUTO { get; set; }
}
