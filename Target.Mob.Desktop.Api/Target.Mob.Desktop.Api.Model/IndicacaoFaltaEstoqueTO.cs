using System;

namespace Target.Mob.Desktop.Api.Model;

public class IndicacaoFaltaEstoqueTO
{
	public int? IDIndicacaoFaltaEstoque { get; set; }

	public string CdPromotor { get; set; }

	public int? CdClien { get; set; }

	public int? CdProd { get; set; }

	public DateTime? DataReporte { get; set; }
}
