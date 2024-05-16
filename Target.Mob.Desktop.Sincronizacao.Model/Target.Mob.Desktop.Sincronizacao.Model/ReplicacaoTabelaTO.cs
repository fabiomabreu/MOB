namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ReplicacaoTabelaTO
{
	public int? IdReplicacaoTabela { get; set; }

	public string Tabela { get; set; }

	public int? QtdeRegistrosPacote { get; set; }

	public bool? Ativo { get; set; }

	public bool? Replicar { get; set; }

	public string CondicaoSelecao { get; set; }

	public byte[] RowId { get; set; }
}
