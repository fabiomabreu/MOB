using System;

namespace Target.Mob.Desktop.Api.Model;

public class VerbaSaldoTO
{
	public string CodigoVendedor { get; set; }

	public DateTime DtSaldoVerba { get; set; }

	public decimal SaldoVerba { get; set; }
}
