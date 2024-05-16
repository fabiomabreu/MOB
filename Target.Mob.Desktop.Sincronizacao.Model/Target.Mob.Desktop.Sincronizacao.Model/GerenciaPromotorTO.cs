namespace Target.Mob.Desktop.Sincronizacao.Model;

public class GerenciaPromotorTO
{
	public int? GerenciaPromotorId { get; set; }

	public int? CdEmp { get; set; }

	public string CdGerencia { get; set; }

	public string Descricao { get; set; }

	public string CdPromotorGerente { get; set; }

	public bool? Ativo { get; set; }

	public byte[] RowId { get; set; }
}
