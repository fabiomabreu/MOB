namespace Target.Mob.Desktop.Geracao.Model;

public class ConfiguracaoPreCargaTO
{
	private int? _Id;

	private string _NomeProcedure;

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

	public string NomeProcedure
	{
		get
		{
			return _NomeProcedure;
		}
		set
		{
			_NomeProcedure = value;
		}
	}
}
