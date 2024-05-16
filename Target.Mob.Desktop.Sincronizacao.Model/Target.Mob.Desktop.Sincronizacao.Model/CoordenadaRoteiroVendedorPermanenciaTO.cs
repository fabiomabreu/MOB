using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CoordenadaRoteiroVendedorPermanenciaTO
{
	public int IdCoordenadaRoteiroVendedorPermanencia { get; set; }

	public int IdVendedor { get; set; }

	public string CodigoVendedor { get; set; }

	public DateTime Data { get; set; }

	public int CodigoCliente { get; set; }

	public TimeSpan HoraInicio { get; set; }

	public TimeSpan HoraFim { get; set; }

	public int Roteiro { get; set; }

	public int CodigoAcao { get; set; }

	public byte[] RowId { get; set; }
}
