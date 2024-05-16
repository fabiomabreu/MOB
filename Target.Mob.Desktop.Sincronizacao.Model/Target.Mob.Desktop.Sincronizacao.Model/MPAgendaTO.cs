using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class MPAgendaTO
{
	public int SeqVisita { get; set; }

	public int PromotorId { get; set; }

	public int CodigoCliente { get; set; }

	public DateTime DtVisita { get; set; }

	public string HrVisita { get; set; }

	public DateTime? DtUltVisita { get; set; }

	public byte[] RowId { get; set; }

	public bool? VisitaExcluida { get; set; }

	public int? FrequenciaVisitaId { get; set; }

	public string OpcoesRota { get; set; }

	public bool? VisitaTelefonica { get; set; }
}
