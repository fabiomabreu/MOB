namespace Target.Mob.Desktop.Geracao.Model;

public class ConfiguracaoReplicacaoTO
{
	private int? _Id;

	private string _Entidade;

	private int? _Prioridade;

	private string _CondicaoSelecao;

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

	public string Entidade
	{
		get
		{
			return _Entidade;
		}
		set
		{
			_Entidade = value;
		}
	}

	public int? Prioridade
	{
		get
		{
			return _Prioridade;
		}
		set
		{
			_Prioridade = value;
		}
	}

	public string CondicaoSelecao
	{
		get
		{
			return _CondicaoSelecao;
		}
		set
		{
			_CondicaoSelecao = value;
		}
	}
}
