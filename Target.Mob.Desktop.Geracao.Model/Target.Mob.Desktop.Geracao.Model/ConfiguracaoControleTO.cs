using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Model;

public class ConfiguracaoControleTO
{
	private int? _Id;

	private int? _IdVersaoCarga;

	private string _Entidade;

	private TipoControleTR? _TipoControle;

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

	public int? IdVersaoCarga
	{
		get
		{
			return _IdVersaoCarga;
		}
		set
		{
			_IdVersaoCarga = value;
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

	public TipoControleTR? TipoControle
	{
		get
		{
			return _TipoControle;
		}
		set
		{
			_TipoControle = value;
		}
	}
}
