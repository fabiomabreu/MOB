namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CadastroSPTO
{
	private int? _IDCadastroSP;

	private string _Descricao;

	private string _Texto;

	private bool? _Ativo;

	private bool? _Automatica;

	public int? IDCadastroSP
	{
		get
		{
			return _IDCadastroSP;
		}
		set
		{
			_IDCadastroSP = value;
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

	public string Texto
	{
		get
		{
			return _Texto;
		}
		set
		{
			_Texto = value;
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

	public bool? Automatica
	{
		get
		{
			return _Automatica;
		}
		set
		{
			_Automatica = value;
		}
	}

	public CadastroSPTO()
	{
	}

	public CadastroSPTO(int? iDCadastroSP, string descricao, string texto, bool? ativo, bool? automatica)
	{
		_IDCadastroSP = iDCadastroSP;
		_Descricao = descricao;
		_Texto = texto;
		Automatica = automatica;
	}
}
