namespace Target.Mob.Desktop.Sincronizacao.Model;

public class EquipeTO
{
	public string CdEquipe { get; set; }

	public string Descricao { get; set; }

	public string CdVendSup { get; set; }

	public bool? Ativo { get; set; }

	public string CdGerencia { get; set; }

	public byte[] RowId { get; set; }

	public int? CodigoEmpresa { get; set; }
}
