namespace Target.Mob.Desktop.Geracao.Model;

public class CargaControleEntidadeTO
{
	public int idCargaControleEntidade { get; set; }

	public string entidadeNome { get; set; }

	public bool entidadeTipoRestricao { get; set; }

	public int commandSqlOnda { get; set; }

	public string commandSqlEntidadeRestricaoNomeVendedor { get; set; }

	public string commandSqlEntidadeRestricaoNomePromotor { get; set; }

	public string commandSqlEntidadeRestricaoNomeSupervisor { get; set; }

	public string commandSqlEntidadeRestricaoNomeInventariador { get; set; }

	public string commandSqlEntidadeRestricaoColumn { get; set; }

	public string commandSqlColumnKey { get; set; }

	public string commandSqlQuery { get; set; }

	public string commandSqlTabelasUtilizadas { get; set; }

	public string commandSqlColumnDados { get; set; }

	public bool ativo { get; set; }

	public byte[] rowid { get; set; }

	public int ultimaExecucaoTempoMs { get; set; }

	public string tipoSistema { get; set; }
}
