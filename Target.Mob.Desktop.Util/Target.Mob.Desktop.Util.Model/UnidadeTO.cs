namespace Target.Mob.Desktop.Util.Model;

public class UnidadeTO
{
	private string _Nome;

	private long _EspacoLivre;

	private string _ContextoAppServer;

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

	public long EspacoLivre
	{
		get
		{
			return _EspacoLivre;
		}
		set
		{
			_EspacoLivre = value;
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
