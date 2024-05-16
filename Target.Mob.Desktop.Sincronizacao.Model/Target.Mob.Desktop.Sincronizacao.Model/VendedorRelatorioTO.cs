namespace Target.Mob.Desktop.Sincronizacao.Model;

public class VendedorRelatorioTO
{
	private int? _IdVendedor;

	private string _CodigoVendedor;

	private string _Nome;

	private int? _IdConfiguracaoVendedor;

	private int? _Major;

	private int? _Minor;

	private int? _Build;

	private int? _Revision;

	private bool? _ForcaCargaCompleta;

	private bool? _Ativo;

	private int? _IDTipoGrupo;

	public int? IdVendedor
	{
		get
		{
			return _IdVendedor;
		}
		set
		{
			_IdVendedor = value;
		}
	}

	public string CodigoVendedor
	{
		get
		{
			return _CodigoVendedor;
		}
		set
		{
			_CodigoVendedor = value;
		}
	}

	public string Nome
	{
		get
		{
			return _Nome;
		}
		set
		{
			_Nome = value;
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

	public int? Major
	{
		get
		{
			return _Major;
		}
		set
		{
			_Major = value;
		}
	}

	public int? Minor
	{
		get
		{
			return _Minor;
		}
		set
		{
			_Minor = value;
		}
	}

	public int? Build
	{
		get
		{
			return _Build;
		}
		set
		{
			_Build = value;
		}
	}

	public int? Revision
	{
		get
		{
			return _Revision;
		}
		set
		{
			_Revision = value;
		}
	}

	public bool? ForcaCargaCompleta
	{
		get
		{
			return _ForcaCargaCompleta;
		}
		set
		{
			_ForcaCargaCompleta = value;
		}
	}

	public bool? Ativo
	{
		get
		{
			return _Ativo;
		}
		set
		{
			_Ativo = value;
		}
	}

	public int? IDTipoGrupo
	{
		get
		{
			return _IDTipoGrupo;
		}
		set
		{
			_IDTipoGrupo = value;
		}
	}
}
