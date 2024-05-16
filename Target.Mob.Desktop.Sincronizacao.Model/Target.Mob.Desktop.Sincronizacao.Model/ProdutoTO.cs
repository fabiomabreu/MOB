namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ProdutoTO
{
	private int? _CdProd;

	private string _CdProdFabric;

	private int? _CdEmp;

	private string _CdGrupoPrd;

	private string _Descricao;

	private string _DescResum;

	private bool? _Ativo;

	private bool? _BloqEnvioPalmTop;

	private byte[] _RowId;

	private string _CdFabric;

	private string _CdLinha;

	private string _TpCdBarra;

	private string _CdBarra;

	private string _TpCdBarraCompra;

	private string _CdBarraCompra;

	public int? CdProd
	{
		get
		{
			return _CdProd;
		}
		set
		{
			_CdProd = value;
		}
	}

	public string CdProdFabric
	{
		get
		{
			return _CdProdFabric;
		}
		set
		{
			_CdProdFabric = value;
		}
	}

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

	public string CdGrupoPrd
	{
		get
		{
			return _CdGrupoPrd;
		}
		set
		{
			_CdGrupoPrd = value;
		}
	}

	public string Descricao
	{
		get
		{
			return _Descricao;
		}
		set
		{
			_Descricao = value;
		}
	}

	public string DescResum
	{
		get
		{
			return _DescResum;
		}
		set
		{
			_DescResum = value;
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

	public bool? BloqEnvioPalmTop
	{
		get
		{
			return _BloqEnvioPalmTop;
		}
		set
		{
			_BloqEnvioPalmTop = value;
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

	public string CdFabric
	{
		get
		{
			return _CdFabric;
		}
		set
		{
			_CdFabric = value;
		}
	}

	public string CdLinha
	{
		get
		{
			return _CdLinha;
		}
		set
		{
			_CdLinha = value;
		}
	}

	public string TpCdBarra
	{
		get
		{
			return _TpCdBarra;
		}
		set
		{
			_TpCdBarra = value;
		}
	}

	public string CdBarra
	{
		get
		{
			return _CdBarra;
		}
		set
		{
			_CdBarra = value;
		}
	}

	public string TpCdBarraCompra
	{
		get
		{
			return _TpCdBarraCompra;
		}
		set
		{
			_TpCdBarraCompra = value;
		}
	}

	public string CdBarraCompra
	{
		get
		{
			return _CdBarraCompra;
		}
		set
		{
			_CdBarraCompra = value;
		}
	}
}
