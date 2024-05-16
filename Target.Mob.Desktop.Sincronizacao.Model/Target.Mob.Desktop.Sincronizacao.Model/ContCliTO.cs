using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ContCliTO
{
	private int _CdClien;

	private int _Seq;

	private string _Nome;

	private string _Cargo;

	private int? _UltCont;

	private string _Email;

	private long? _Fone;

	private string _Time;

	private string _Hobby;

	private DateTime? _Aniversario;

	private bool? _EmailComercial;

	private short? _Ddd;

	private string _TpTel;

	private string _TipoOperacao;

	private bool? _EmailNFe;

	private bool? _EmailFinanceiro;

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

	public string Nome
	{
		get
		{
			return _Nome;
		}
		set
		{
			_Nome = value;
		}
	}

	public string Cargo
	{
		get
		{
			return _Cargo;
		}
		set
		{
			_Cargo = value;
		}
	}

	public int? UltCont
	{
		get
		{
			return _UltCont;
		}
		set
		{
			_UltCont = value;
		}
	}

	public string Email
	{
		get
		{
			return _Email;
		}
		set
		{
			_Email = value;
		}
	}

	public long? Fone
	{
		get
		{
			return _Fone;
		}
		set
		{
			_Fone = value;
		}
	}

	public string Time
	{
		get
		{
			return _Time;
		}
		set
		{
			_Time = value;
		}
	}

	public string Hobby
	{
		get
		{
			return _Hobby;
		}
		set
		{
			_Hobby = value;
		}
	}

	public DateTime? Aniversario
	{
		get
		{
			return _Aniversario;
		}
		set
		{
			_Aniversario = value;
		}
	}

	public bool? EmailComercial
	{
		get
		{
			return _EmailComercial;
		}
		set
		{
			_EmailComercial = value;
		}
	}

	public short? Ddd
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

	public bool? EmailNFe
	{
		get
		{
			return _EmailNFe;
		}
		set
		{
			_EmailNFe = value;
		}
	}

	public bool? EmailFinanceiro
	{
		get
		{
			return _EmailFinanceiro;
		}
		set
		{
			_EmailFinanceiro = value;
		}
	}

	public int? CargoID { get; set; }

	public bool? EnviaWhatsAppEcommerce { get; set; }
}
