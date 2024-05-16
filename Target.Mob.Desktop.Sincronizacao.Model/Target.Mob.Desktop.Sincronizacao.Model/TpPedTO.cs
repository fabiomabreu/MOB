namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TpPedTO
{
	private string _TpPed;

	private string _Descricao;

	private bool? _Bonificacao;

	private int? _Ativo;

	private bool? _EstatCom;

	private byte[] _RowId;

	public string TpPed
	{
		get
		{
			return _TpPed;
		}
		set
		{
			_TpPed = value;
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

	public bool? Bonificacao
	{
		get
		{
			return _Bonificacao;
		}
		set
		{
			_Bonificacao = value;
		}
	}

	public int? Ativo
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

	public bool? EstatCom
	{
		get
		{
			return _EstatCom;
		}
		set
		{
			_EstatCom = value;
		}
	}

	public byte[] RowId
	{
		get
		{
			return _RowId;
		}
		set
		{
			_RowId = value;
		}
	}
}
