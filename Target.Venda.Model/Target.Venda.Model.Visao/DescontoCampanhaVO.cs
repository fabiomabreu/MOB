namespace Target.Venda.Model.Visao;

public class DescontoCampanhaVO
{
	public decimal PERC_DESC_CAMPANHA { get; set; }

	public decimal PERC_DESC_CAMPANHA_COMBO { get; set; }

	public bool CALCULAR_VERBA_FABRICANTE { get; set; }

	public bool CONSIDERA_PRODUTOS_PROMOCAO { get; set; }

	public bool CONSIDERA_PRODUTOS_BONIFICADOS { get; set; }

	public bool VERBA_FABR_DEBITA_PIS_COFINS { get; set; }
}
