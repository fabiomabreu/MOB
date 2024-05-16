namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AtualizacaoMovimentoTO
{
	private int _ID;

	private string _Tabela;

	public int ID
	{
		get
		{
			return _ID;
		}
		set
		{
			_ID = value;
		}
	}

	public string Tabela
	{
		get
		{
			return _Tabela;
		}
		set
		{
			_Tabela = value;
		}
	}
}
