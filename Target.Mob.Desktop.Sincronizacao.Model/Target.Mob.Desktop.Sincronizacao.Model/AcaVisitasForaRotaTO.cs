using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AcaVisitasForaRotaTO
{
	private int _SeqVisita;

	private string _CdVend;

	private int _CdClien;

	private DateTime _DtVisita;

	private string _HrVisita;

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

	public DateTime DtVisita
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
}
