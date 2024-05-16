namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TipoGrupoTO
{
	private int? _IdTipoGrupo;

	private string _Descricao;

	private bool? _Ativo;

	public int? IdTipoGrupo
	{
		get
		{
			return _IdTipoGrupo;
		}
		set
		{
			_IdTipoGrupo = value;
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

	public TipoGrupoTO()
	{
	}

	public TipoGrupoTO(int? idTipoGrupo, string descricao, bool? ativo)
	{
		_IdTipoGrupo = idTipoGrupo;
		_Descricao = descricao;
		_Ativo = Ativo;
	}
}
