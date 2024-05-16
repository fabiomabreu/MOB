using System;

namespace Target.Mob.Desktop.Api.Model;

public class PcfgTelaMultiTO
{
	public string CdTela { get; set; }

	public int? Seq { get; set; }

	public string Descricao { get; set; }

	public string Tipo { get; set; }

	public string Texto { get; set; }

	public DateTime? Data { get; set; }

	public decimal? Numero { get; set; }

	public bool? Ativo { get; set; }

	public string Versao { get; set; }

	public byte[] RowId { get; set; }

	public int? PcfgTelaMultiId { get; set; }

	public PcfgTelaMultiTO()
	{
	}

	public PcfgTelaMultiTO(string CdTela, int Seq)
	{
		this.CdTela = CdTela;
		this.Seq = Seq;
	}
}
