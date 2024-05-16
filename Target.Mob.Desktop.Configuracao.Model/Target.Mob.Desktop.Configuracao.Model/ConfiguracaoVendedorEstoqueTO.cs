namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorEstoqueTO
{
	private int? _Id;

	private int? _IdConfiguracaoVendedor;

	private int? _CodigoEmpresaOrigem;

	private string _CodigoLocalEstoqueOrigem;

	private int? _CodigoEmpresaDestino;

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

	public int? CodigoEmpresaOrigem
	{
		get
		{
			return _CodigoEmpresaOrigem;
		}
		set
		{
			_CodigoEmpresaOrigem = value;
		}
	}

	public string CodigoLocalEstoqueOrigem
	{
		get
		{
			return _CodigoLocalEstoqueOrigem;
		}
		set
		{
			_CodigoLocalEstoqueOrigem = value;
		}
	}

	public int? CodigoEmpresaDestino
	{
		get
		{
			return _CodigoEmpresaDestino;
		}
		set
		{
			_CodigoEmpresaDestino = value;
		}
	}
}
