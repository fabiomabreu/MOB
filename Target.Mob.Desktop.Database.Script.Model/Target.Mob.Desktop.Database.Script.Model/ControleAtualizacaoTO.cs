namespace Target.Mob.Desktop.Database.Script.Model;

public class ControleAtualizacaoTO
{
	private string _Arquivo;

	private string _Diretorio;

	public string Arquivo
	{
		get
		{
			return _Arquivo;
		}
		set
		{
			_Arquivo = value;
		}
	}

	public string Diretorio
	{
		get
		{
			return _Diretorio;
		}
		set
		{
			_Diretorio = value;
		}
	}
}
