namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AreaTO
{
	public string Codigo { get; set; }

	public string Descricao { get; set; }

	public bool? Ativo { get; set; }

	public int? AreaId { get; set; }

	public byte[] RowId { get; set; }
}
