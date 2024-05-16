namespace Target.Mob.Desktop.Sincronizacao.Model;

public class RamAtivTO
{
	public string Codigo { get; set; }

	public string Descricao { get; set; }

	public bool? Ativo { get; set; }

	public short? QtdeCheckOut { get; set; }

	public int? RamAtivId { get; set; }

	public byte[] RowId { get; set; }
}
