namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ImportacaoLogErroTO
{
	private int _Id;

	private int _IdImportacaoItem;

	private string _Classe;

	private string _Metodo;

	private string _Erro;

	public int Id
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

	public int IdImportacaoItem
	{
		get
		{
			return _IdImportacaoItem;
		}
		set
		{
			_IdImportacaoItem = value;
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
