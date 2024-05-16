namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorVisitaDiasSemanaTO
{
	private int? _Id;

	private int? _IdConfiguracaoVendedor;

	private string _CodigoDiaSemanaVisita;

	public int? Id
	{
		get
		{
			return _Id;
		}
		set
		{
			_Id = value;
		}
	}

	public int? IdConfiguracaoVendedor
	{
		get
		{
			return _IdConfiguracaoVendedor;
		}
		set
		{
			_IdConfiguracaoVendedor = value;
		}
	}

	public string CodigoDiaSemanaVisita
	{
		get
		{
			return _CodigoDiaSemanaVisita;
		}
		set
		{
			_CodigoDiaSemanaVisita = value;
		}
	}
}
