using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AcaVisitasReagendTO
{
	private int _SeqVisita;

	private string _CdVend;

	private int _CdClien;

	private DateTime? _DtVisita;

	private string _HrVisita;

	private string _CdTpFreqVisita;

	private int? _QtdeDiasFreqVisita;

	private int? _Reagendado;

	public int SeqVisita
	{
		get
		{
			return _SeqVisita;
		}
		set
		{
			_SeqVisita = value;
		}
	}

	public string CdVend
	{
		get
		{
			return _CdVend;
		}
		set
		{
			_CdVend = value;
		}
	}

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

	public DateTime? DtVisita
	{
		get
		{
			return _DtVisita;
		}
		set
		{
			_DtVisita = value;
		}
	}

	public string HrVisita
	{
		get
		{
			return _HrVisita;
		}
		set
		{
			_HrVisita = value;
		}
	}

	public string CdTpFreqVisita
	{
		get
		{
			return _CdTpFreqVisita;
		}
		set
		{
			_CdTpFreqVisita = value;
		}
	}

	public int? QtdeDiasFreqVisita
	{
		get
		{
			return _QtdeDiasFreqVisita;
		}
		set
		{
			_QtdeDiasFreqVisita = value;
		}
	}

	public int? Reagendado
	{
		get
		{
			return _Reagendado;
		}
		set
		{
			_Reagendado = value;
		}
	}
}
