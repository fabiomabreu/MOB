namespace Target.Mob.Desktop.Configuracao.Model;

public class TipoNotificacaoTO
{
	private int? _IDTipoNotificacao;

	private string _Descricao;

	private bool? _Ativo;

	public int? IDTipoNotificacao
	{
		get
		{
			return _IDTipoNotificacao;
		}
		set
		{
			_IDTipoNotificacao = value;
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

	public string Descricao
	{
		get
		{
			return _Descricao;
		}
		set
		{
			_Descricao = value;
		}
	}
}
