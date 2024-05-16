using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Visao;

public class ItemPedidoFiscalVO
{
	public short SEQ { get; set; }

	public decimal? VALOR_IPI { get; set; }

	public decimal? ALIQUOTA_IPI { get; set; }

	public bool LIBERACAO_FISCAL { get; set; }

	public BoolEnum? VENDA_CASADA { get; set; }

	public BoolEnum? RESTRICAO_VENDA { get; set; }

	public string SITUACAO { get; set; }

	public bool? ST_ADICIONAL_ITEM { get; set; }

	public string CD_SIT_TRIB { get; set; }

	public bool? INCIDE_ICMS_SUBST { get; set; }

	public bool? SUBSTRIB_ICMS_COMPRA { get; set; }
}
