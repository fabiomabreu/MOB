using System;

namespace Target.Mob.Desktop.Api.Model;

public class NotaFiscalTO
{
	public int NumNotaFiscal { get; set; }

	public int NumNotaFiscalFat { get; set; }

	public int NumPedido { get; set; }

	public DateTime DataEmissaoNF { get; set; }

	public int CodEmpresa { get; set; }

	public string NomeEmpresa { get; set; }

	public int ItNotaId { get; set; }

	public int? ItNotaLoteId { get; set; }

	public string Lote { get; set; }

	public int CodProduto { get; set; }

	public DateTime? DataValidProd { get; set; }

	public decimal QtdeVendida { get; set; }

	public decimal PrecoUnit { get; set; }

	public decimal ValorTotal { get; set; }

	public string UnidEstoque { get; set; }

	public string UnidVendida { get; set; }

	public decimal FatorUnidVenda { get; set; }

	public string IndiceRelacaoUnidVda { get; set; }

	public decimal QtdeRestante { get; set; }
}
