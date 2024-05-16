using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class AcaNaoVisitaTO
{
	private int _Seq;

	private int? _CdClien;

	private string _CdMotivo;

	private string _DescMotivo;

	private DateTime? _Data;

	private string _CdVend;

	private int? _CdTexto;

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

	public int? CdClien
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

	public string CdMotivo
	{
		get
		{
			return _CdMotivo;
		}
		set
		{
			_CdMotivo = value;
		}
	}

	public string DescMotivo
	{
		get
		{
			return _DescMotivo;
		}
		set
		{
			_DescMotivo = value;
		}
	}

	public DateTime? Data
	{
		get
		{
			return _Data;
		}
		set
		{
			_Data = value;
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
