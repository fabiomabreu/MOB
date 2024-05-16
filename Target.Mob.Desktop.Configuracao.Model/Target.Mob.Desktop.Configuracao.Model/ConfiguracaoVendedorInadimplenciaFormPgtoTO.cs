namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorInadimplenciaFormPgtoTO
{
	private int? _IdConfiguracaoVendedor;

	private string _CodigoFormPgto;

	private bool? _Padrao;

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

	public string CodigoFormPgto
	{
		get
		{
			return _CodigoFormPgto;
		}
		set
		{
			_CodigoFormPgto = value;
		}
	}

	public bool? Padrao
	{
		get
		{
			return _Padrao;
		}
		set
		{
			_Padrao = value;
		}
	}
}
