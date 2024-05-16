namespace Target.Mob.Desktop.Sincronizacao.Model;

public class FrequenciaVisitaTO
{
	public int? FrequenciaVisitaID { get; set; }

	public string Descricao { get; set; }

	public string TipoFrequencia { get; set; }

	public int? Quantidade { get; set; }

	public bool? Ativo { get; set; }

	public byte[] RowID { get; set; }
}
