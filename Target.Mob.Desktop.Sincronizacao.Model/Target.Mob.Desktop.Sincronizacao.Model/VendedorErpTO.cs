namespace Target.Mob.Desktop.Sincronizacao.Model;

public class VendedorErpTO
{
	private string _CdVend;

	private string _Nome;

	private bool? _Ativo;

	private bool? _UtilizaPalmTop;

	private byte[] _RowId;

	private string _CdEquipe;

	private string _MunicRes;

	private string _EstRes;

	private int? _CepRes;

	private string _Pais;

	private string _Logradouro;

	private string _Numero;

	private string _Complemento;

	private byte _MontagemRotVisitaID;

	private int? _CodigoEmpresa;

	private decimal? _Latitude;

	private decimal? _Longitude;

	public string CGC { get; set; }

	public string MunicRes
	{
		get
		{
			return _MunicRes;
		}
		set
		{
			_MunicRes = value;
		}
	}

	public string EstRes
	{
		get
		{
			return _EstRes;
		}
		set
		{
			_EstRes = value;
		}
	}

	public int? CepRes
	{
		get
		{
			return _CepRes;
		}
		set
		{
			_CepRes = value;
		}
	}

	public string Pais
	{
		get
		{
			return _Pais;
		}
		set
		{
			_Pais = value;
		}
	}

	public string Logradouro
	{
		get
		{
			return _Logradouro;
		}
		set
		{
			_Logradouro = value;
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

	public byte MontagemRotVisitaID
	{
		get
		{
			return _MontagemRotVisitaID;
		}
		set
		{
			_MontagemRotVisitaID = value;
		}
	}

	public string CdVend
	{
		get
		{
			return _CdVend;
		}
		set
		{
			_CdVend = value;
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

	public bool? UtilizaPalmTop
	{
		get
		{
			return _UtilizaPalmTop;
		}
		set
		{
			_UtilizaPalmTop = value;
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

	public string CdEquipe
	{
		get
		{
			return _CdEquipe;
		}
		set
		{
			_CdEquipe = value;
		}
	}

	public int? CodigoEmpresa
	{
		get
		{
			return _CodigoEmpresa;
		}
		set
		{
			_CodigoEmpresa = value;
		}
	}

	public decimal? Latitude
	{
		get
		{
			return _Latitude;
		}
		set
		{
			_Latitude = value;
		}
	}

	public decimal? Longitude
	{
		get
		{
			return _Longitude;
		}
		set
		{
			_Longitude = value;
		}
	}
}
