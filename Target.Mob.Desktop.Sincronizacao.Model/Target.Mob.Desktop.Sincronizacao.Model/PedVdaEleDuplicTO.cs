using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class PedVdaEleDuplicTO
{
	private int _CdEmpEle;

	private decimal _NuPedEle;

	private decimal _SeqPed;

	private int _CdClien;

	private string _CdVend;

	private DateTime? _DtPed;

	private decimal _ValorTot;

	public int CdEmpEle
	{
		get
		{
			return _CdEmpEle;
		}
		set
		{
			_CdEmpEle = value;
		}
	}

	public decimal NuPedEle
	{
		get
		{
			return _NuPedEle;
		}
		set
		{
			_NuPedEle = value;
		}
	}

	public decimal SeqPed
	{
		get
		{
			return _SeqPed;
		}
		set
		{
			_SeqPed = value;
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

	public DateTime? DtPed
	{
		get
		{
			return _DtPed;
		}
		set
		{
			_DtPed = value;
		}
	}

	public decimal ValorTot
	{
		get
		{
			return _ValorTot;
		}
		set
		{
			_ValorTot = value;
		}
	}
}
