namespace Target.Mob.Desktop.Sincronizacao.Model;

public class LinhaTO
{
	private string _CdLinha;

	private string _Descricao;

	private bool? _Ativo;

	private bool? _EnvioPalmTop;

	private string _CdCategprd;

	private byte[] _RowId;

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

	public string CdCategprd
	{
		get
		{
			return _CdCategprd;
		}
		set
		{
			_CdCategprd = value;
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
