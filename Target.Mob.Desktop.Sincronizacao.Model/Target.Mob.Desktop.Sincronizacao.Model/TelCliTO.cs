namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TelCliTO
{
	private int _CdClien;

	private int _Seq;

	private string _TpTel;

	private string _Ddd;

	private long _Numero;

	private int? _Compl;

	private string _TipoOperacao;

	public int CdClien
	{
		get
		{
			return _CdClien;
		}
		set
		{
			_CdClien = value;
		}
	}

	public int Seq
	{
		get
		{
			return _Seq;
		}
		set
		{
			_Seq = value;
		}
	}

	public string TpTel
	{
		get
		{
			return _TpTel;
		}
		set
		{
			_TpTel = value;
		}
	}

	public string Ddd
	{
		get
		{
			return _Ddd;
		}
		set
		{
			_Ddd = value;
		}
	}

	public long Numero
	{
		get
		{
			return _Numero;
		}
		set
		{
			_Numero = value;
		}
	}

	public int? Compl
	{
		get
		{
			return _Compl;
		}
		set
		{
			_Compl = value;
		}
	}

	public string TipoOperacao
	{
		get
		{
			return _TipoOperacao;
		}
		set
		{
			_TipoOperacao = value;
		}
	}
}
