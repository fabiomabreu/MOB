using System;

namespace Target.Mob.Desktop.Api.Model;

public class PedidoEntregaTO
{
	public int Codigo { get; set; }

	public int CodigoEmpresa { get; set; }

	public int NumeroPedVda { get; set; }

	public int CodigoCliente { get; set; }

	public DateTime DtEntrega { get; set; }
}
