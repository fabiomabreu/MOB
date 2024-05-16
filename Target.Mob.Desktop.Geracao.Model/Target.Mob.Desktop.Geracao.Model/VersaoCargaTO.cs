namespace Target.Mob.Desktop.Geracao.Model;

public class VersaoCargaTO
{
	private int? _Id;

	private int? _Major;

	private int? _Minor;

	private int? _Build;

	private int? _Revision;

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
}
