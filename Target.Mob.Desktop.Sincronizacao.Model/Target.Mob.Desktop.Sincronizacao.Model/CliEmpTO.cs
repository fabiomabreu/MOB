namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CliEmpTO
{
	private int _CdClien;

	private int _CdEmp;

	private string _CdTabela;

	private int? _SeqProm;

	private int? _NuBancoVe;

	private string _NuAgenciaVe;

	private string _NuContaVe;

	private int? _NuBancoVs;

	private string _NuAgenciaVs;

	private string _NuContaVs;

	private decimal? _VlLimPedPf;

	private int? _PrzMedioMax;

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

	public int CdEmp
	{
		get
		{
			return _CdEmp;
		}
		set
		{
			_CdEmp = value;
		}
	}

	public string CdTabela
	{
		get
		{
			return _CdTabela;
		}
		set
		{
			_CdTabela = value;
		}
	}

	public int? SeqProm
	{
		get
		{
			return _SeqProm;
		}
		set
		{
			_SeqProm = value;
		}
	}

	public int? NuBancoVe
	{
		get
		{
			return _NuBancoVe;
		}
		set
		{
			_NuBancoVe = value;
		}
	}

	public string NuAgenciaVe
	{
		get
		{
			return _NuAgenciaVe;
		}
		set
		{
			_NuAgenciaVe = value;
		}
	}

	public string NuContaVe
	{
		get
		{
			return _NuContaVe;
		}
		set
		{
			_NuContaVe = value;
		}
	}

	public int? NuBancoVs
	{
		get
		{
			return _NuBancoVs;
		}
		set
		{
			_NuBancoVs = value;
		}
	}

	public string NuAgenciaVs
	{
		get
		{
			return _NuAgenciaVs;
		}
		set
		{
			_NuAgenciaVs = value;
		}
	}

	public string NuContaVs
	{
		get
		{
			return _NuContaVs;
		}
		set
		{
			_NuContaVs = value;
		}
	}

	public decimal? VlLimPedPf
	{
		get
		{
			return _VlLimPedPf;
		}
		set
		{
			_VlLimPedPf = value;
		}
	}

	public int? PrzMedioMax
	{
		get
		{
			return _PrzMedioMax;
		}
		set
		{
			_PrzMedioMax = value;
		}
	}

	public CliEmpTO()
	{
	}

	public CliEmpTO(int CdEmp)
	{
		this.CdEmp = CdEmp;
	}
}
