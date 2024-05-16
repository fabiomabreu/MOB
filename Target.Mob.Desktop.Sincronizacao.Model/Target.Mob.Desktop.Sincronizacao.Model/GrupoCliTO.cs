namespace Target.Mob.Desktop.Sincronizacao.Model;

public class GrupoCliTO
{
	public int? GrupoCliId { get; set; }

	public string Codigo { get; set; }

	public string Descricao { get; set; }

	public bool? Ativo { get; set; }

	public byte[] RowId { get; set; }
}
