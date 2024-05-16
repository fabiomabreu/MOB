namespace Target.Venda.Model.Visao;

public class ItemReservaLoteEstoqueVO
{
	public int CODIGO_EMPRESA { get; set; }

	public int CODIGO_PRODUTO { get; set; }

	public string CODIGO_LOCAL { get; set; }

	public decimal QUANTIDADE { get; set; }

	public decimal QUANTIDADE_CTB { get; set; }

	public int SEQ_LOTE { get; set; }
}
