namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CategoriaAnotacaoTO
{
	public int? IdCategoriaAnotacao { get; set; }

	public string Descricao { get; set; }

	public bool? Ativo { get; set; }

	public byte[] RowId { get; set; }
}
