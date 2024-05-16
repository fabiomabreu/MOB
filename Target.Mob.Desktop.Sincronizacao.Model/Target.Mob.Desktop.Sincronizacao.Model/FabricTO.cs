namespace Target.Mob.Desktop.Sincronizacao.Model;

public class FabricTO
{
	private string _CdFabric;

	private string _Descricao;

	private bool? _Ativo;

	private bool? _EnvioPalmTop;

	private byte[] _RowId;

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

	public bool? EnvioPalmTop
	{
		get
		{
			return _EnvioPalmTop;
		}
		set
		{
			_EnvioPalmTop = value;
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
}
