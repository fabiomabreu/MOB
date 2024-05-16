using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AnotacaoTO
{
	public int? CodigoAnotacao { get; set; }

	public int? CodigoCategoriaAnotacao { get; set; }

	public int? CodigoCliente { get; set; }

	public string CodigoVendedor { get; set; }

	public int? CodigoEmpresa { get; set; }

	public int? NumeroPedVda { get; set; }

	public DateTime? DataHora { get; set; }

	public string Texto { get; set; }

	public DateTime? DtLembrete { get; set; }
}
