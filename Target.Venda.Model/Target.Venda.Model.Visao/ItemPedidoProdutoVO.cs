using System;
using Target.Venda.Model.TipoDado;

namespace Target.Venda.Model.Visao;

public class ItemPedidoProdutoVO
{
	public short SEQ { get; set; }

	public int CODIGO_PRODUTO { get; set; }

	public string CODIGO_LINHA { get; set; }

	public string CODIGO_GRUPO_PRODUTO { get; set; }

	public short? PRAZO_MEDIO_MAXIMO { get; set; }

	public bool PRODUTO_CONTROLADO { get; set; }

	public DateTime? DT_INI_VALIDADE_LOTE { get; set; }

	public DateTime? DT_FIM_VALIDADE_LOTE { get; set; }

	public string DESCRICAO { get; set; }

	public string UNIDADE_VENDA { get; set; }

	public string UNIDADE_PEDIDA { get; set; }

	public string UNIDADE { get; set; }

	public bool? INFO_VOLUMES { get; set; }

	public decimal? VOLUME { get; set; }

	public string INDICE_RELACAO { get; set; }

	public string INDICE_RELACAO_VENDA { get; set; }

	public decimal? FATOR_PRECO { get; set; }

	public double? FATOR_ESTOQUE_PEDIDA { get; set; }

	public decimal? FATOR_ESTOQUE_VENDA { get; set; }

	public BoolEnum? ESTOQUE_ZERADO { get; set; }

	public bool ESTOQUE_INSUFICIENTE { get; set; }

	public decimal PESO_BRUTO { get; set; }

	public decimal PESO_LIQUIDO { get; set; }

	public decimal? QUANTIDADE_MULTIPLA { get; set; }

	public decimal? QUANTIDADE_UNIDADE_VENDA { get; set; }

	public decimal? QUANTIDADE_UNIDADE_PEDIDA { get; set; }

	public decimal QUANTIDADE { get; set; }

	public decimal? ALIQUOTA_IPI { get; set; }
}
