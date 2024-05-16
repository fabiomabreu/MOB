namespace Target.Mob.Desktop.Api.Model;

public class IndenizacaoItemTO
{
	public int? IndenizacaoItemID { get; set; }

	public int? IndenizacaoID { get; set; }

	public int? CdProd { get; set; }

	public int? ItNotaID { get; set; }

	public int? ItNotaLoteID { get; set; }

	public decimal? Qtde { get; set; }

	public decimal? ValorUnitario { get; set; }

	public string UnidVda { get; set; }

	public decimal? QtdeUnidVda { get; set; }

	public string IndiceRelacaoUnidVda { get; set; }

	public decimal? FatorEstoqueUnidVda { get; set; }

	public IndenizacaoItemTO()
	{
	}

	public IndenizacaoItemTO(int indenizacaoID)
	{
		IndenizacaoID = indenizacaoID;
	}
}
