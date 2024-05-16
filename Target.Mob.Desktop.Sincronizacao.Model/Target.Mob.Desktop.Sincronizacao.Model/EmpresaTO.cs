namespace Target.Mob.Desktop.Sincronizacao.Model;

public class EmpresaTO
{
	private int? _CdEmp;

	private string _RazSoc;

	private string _NomeFant;

	private string _Cgc;

	private bool? _Ativo;

	private byte[] _RowId;

	private string _Endereco;

	private string _Numero;

	private string _Complemento;

	private string _Bairro;

	private string _Municipio;

	private int? _Cep;

	private string _Estado;

	public int? CdEmp
	{
		get
		{
			return _CdEmp;
		}
		set
		{
			_CdEmp = value;
		}
	}

	public string RazSoc
	{
		get
		{
			return _RazSoc;
		}
		set
		{
			_RazSoc = value;
		}
	}

	public string NomeFant
	{
		get
		{
			return _NomeFant;
		}
		set
		{
			_NomeFant = value;
		}
	}

	public string Cgc
	{
		get
		{
			return _Cgc;
		}
		set
		{
			_Cgc = value;
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

	public byte[] RowId
	{
		get
		{
			return _RowId;
		}
		set
		{
			_RowId = value;
		}
	}

	public string Endereco
	{
		get
		{
			return _Endereco;
		}
		set
		{
			_Endereco = value;
		}
	}

	public string Numero
	{
		get
		{
			return _Numero;
		}
		set
		{
			_Numero = value;
		}
	}

	public string Complemento
	{
		get
		{
			return _Complemento;
		}
		set
		{
			_Complemento = value;
		}
	}

	public string Bairro
	{
		get
		{
			return _Bairro;
		}
		set
		{
			_Bairro = value;
		}
	}

	public string Municipio
	{
		get
		{
			return _Municipio;
		}
		set
		{
			_Municipio = value;
		}
	}

	public int? Cep
	{
		get
		{
			return _Cep;
		}
		set
		{
			_Cep = value;
		}
	}

	public string Estado
	{
		get
		{
			return _Estado;
		}
		set
		{
			_Estado = value;
		}
	}
}
