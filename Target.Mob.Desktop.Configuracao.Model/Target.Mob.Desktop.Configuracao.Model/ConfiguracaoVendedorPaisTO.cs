namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorPaisTO
{
	private string _CodigoPais;

	private int? _IDConfiguracaoVendedor;

	public string CodigoPais
	{
		get
		{
			return _CodigoPais;
		}
		set
		{
			_CodigoPais = value;
		}
	}

	public int? IDConfiguracaoVendedor
	{
		get
		{
			return _IDConfiguracaoVendedor;
		}
		set
		{
			_IDConfiguracaoVendedor = value;
		}
	}
}
