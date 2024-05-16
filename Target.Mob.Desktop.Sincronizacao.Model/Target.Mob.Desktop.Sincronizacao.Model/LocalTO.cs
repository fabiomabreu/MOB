namespace Target.Mob.Desktop.Sincronizacao.Model;

public class LocalTO
{
	private int _CdEmp;

	private string _CdLocal;

	private bool? _Ativo;

	private byte[] _RowId;

	public int CdEmp
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

	public string CdLocal
	{
		get
		{
			return _CdLocal;
		}
		set
		{
			_CdLocal = value;
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

	public byte[] RowID
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
