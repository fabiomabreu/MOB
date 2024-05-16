namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ReplicacaoTabelaColunaTO
{
	public int IdReplicacaoTabelaColuna { get; set; }

	public ReplicacaoTabelaTO ReplicacaoTabela { get; set; }

	public string Coluna { get; set; }

	public bool Replicar { get; set; }

	public byte[] RowId { get; set; }
}
