namespace Target.Mob.Desktop.Util.Model;

public class InfoDBTO
{
	private string _DataBase;

	private string _FileName;

	private decimal? _CurrentlyAllocatedSpace;

	private decimal? _SpaceUsed;

	private decimal? _AvailableSpace;

	private string _ContextoAppServer;

	public string DataBase
	{
		get
		{
			return _DataBase;
		}
		set
		{
			_DataBase = value;
		}
	}

	public string FileName
	{
		get
		{
			return _FileName;
		}
		set
		{
			_FileName = value;
		}
	}

	public decimal? CurrentlyAllocatedSpace
	{
		get
		{
			return _CurrentlyAllocatedSpace;
		}
		set
		{
			_CurrentlyAllocatedSpace = value;
		}
	}

	public decimal? SpaceUsed
	{
		get
		{
			return _SpaceUsed;
		}
		set
		{
			_SpaceUsed = value;
		}
	}

	public decimal? AvailableSpace
	{
		get
		{
			return _AvailableSpace;
		}
		set
		{
			_AvailableSpace = value;
		}
	}

	public string ContextoAppServer
	{
		get
		{
			return _ContextoAppServer;
		}
		set
		{
			_ContextoAppServer = value;
		}
	}
}
