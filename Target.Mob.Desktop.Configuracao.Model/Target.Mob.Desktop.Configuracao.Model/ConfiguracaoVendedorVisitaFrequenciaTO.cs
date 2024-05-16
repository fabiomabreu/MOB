namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorVisitaFrequenciaTO
{
	private int? _Id;

	private int? _IdConfiguracaoVendedor;

	private string _CodigoTipoFrequenciaVisita;

	private int? _FrequenciaVisitaId;

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

	public string CodigoTipoFrequenciaVisita
	{
		get
		{
			return _CodigoTipoFrequenciaVisita;
		}
		set
		{
			_CodigoTipoFrequenciaVisita = value;
		}
	}

	public int? FrequenciaVisitaId
	{
		get
		{
			return _FrequenciaVisitaId;
		}
		set
		{
			_FrequenciaVisitaId = value;
		}
	}
}
