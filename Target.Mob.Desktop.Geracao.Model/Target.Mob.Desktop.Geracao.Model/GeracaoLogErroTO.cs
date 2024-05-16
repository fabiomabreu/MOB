namespace Target.Mob.Desktop.Geracao.Model;

public class GeracaoLogErroTO
{
	private int? _Id;

	private int? _IdGeracaoItem;

	private string _Classe;

	private string _Metodo;

	private string _Erro;

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

	public int? IdGeracaoItem
	{
		get
		{
			return _IdGeracaoItem;
		}
		set
		{
			_IdGeracaoItem = value;
		}
	}

	public string Classe
	{
		get
		{
			return _Classe;
		}
		set
		{
			_Classe = value;
		}
	}

	public string Metodo
	{
		get
		{
			return _Metodo;
		}
		set
		{
			_Metodo = value;
		}
	}

	public string Erro
	{
		get
		{
			return _Erro;
		}
		set
		{
			_Erro = value;
		}
	}
}
