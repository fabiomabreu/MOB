using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class GondolaTO
{
	public int CodigoEmpresa { get; set; }

	public int NumeroPedido { get; set; }

	public int Codigo { get; set; }

	public int CodigoCliente { get; set; }

	public int CodigoProduto { get; set; }

	public DateTime Data { get; set; }

	public int? QtdeEstoqueCliente { get; set; }

	public decimal? PrecoGondola { get; set; }

	public int? QtdeGiro { get; set; }

	public decimal? QtdeVendaMedia { get; set; }

	public int? QtdeSugerida { get; set; }

	public int? QtdeSeguranca { get; set; }

	public int? QtdeVendida { get; set; }

	public int? QtdeSaldo { get; set; }

	public decimal? Markup { get; set; }

	public int? IdVendedor { get; set; }
}
