using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class EventoPdelTO
{
	private int _SeqEvento;

	private int _CdEmpEle;

	private int _NuPedEle;

	private decimal _SeqPed;

	private string _CdUsrGer;

	private DateTime _DtCriacao;

	private string _CdUsrEnc;

	private DateTime? _DtEncer;

	private int? _CdTexto;

	public int SeqEvento
	{
		get
		{
			return _SeqEvento;
		}
		set
		{
			_SeqEvento = value;
		}
	}

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

	public int NuPedEle
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

	public string CdUsrGer
	{
		get
		{
			return _CdUsrGer;
		}
		set
		{
			_CdUsrGer = value;
		}
	}

	public DateTime DtCriacao
	{
		get
		{
			return _DtCriacao;
		}
		set
		{
			_DtCriacao = value;
		}
	}

	public string CdUsrEnc
	{
		get
		{
			return _CdUsrEnc;
		}
		set
		{
			_CdUsrEnc = value;
		}
	}

	public DateTime? DtEncer
	{
		get
		{
			return _DtEncer;
		}
		set
		{
			_DtEncer = value;
		}
	}

	public int? CdTexto
	{
		get
		{
			return _CdTexto;
		}
		set
		{
			_CdTexto = value;
		}
	}
}
