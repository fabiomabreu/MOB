namespace Target.Mob.Desktop.Sincronizacao.Model;

public class EquipePromotorTO
{
	public int? EquipePromotorId { get; set; }

	public int? CdEmp { get; set; }

	public string CdEquipe { get; set; }

	public string Descricao { get; set; }

	public string CdPromotorSupervisor { get; set; }

	public bool? Ativo { get; set; }

	public int? GerenciaPromotorId { get; set; }

	public byte[] RowId { get; set; }
}
