using System;

namespace Target.Mob.Desktop.Api.Model;

public class EstatisticaResumoSincronizacaoVendedorTO
{
	public string CodigoVendedor { get; set; }

	public string NomeVendedor { get; set; }

	public string NomeGuerra { get; set; }

	public DateTime? DataUltimaAtualizacao { get; set; }
}
