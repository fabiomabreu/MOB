using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class LinTxtLogTO
{
	private int _CdTextoLog;

	private int _NumLin;

	private int _CdTextoOrig;

	private string _Texto;

	private DateTime _Data;

	private string _CdUsuario;

	public int CdTextoLog
	{
		get
		{
			return _CdTextoLog;
		}
		set
		{
			_CdTextoLog = value;
		}
	}

	public int NumLin
	{
		get
		{
			return _NumLin;
		}
		set
		{
			_NumLin = value;
		}
	}

	public int CdTextoOrig
	{
		get
		{
			return _CdTextoOrig;
		}
		set
		{
			_CdTextoOrig = value;
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

	public DateTime Data
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

	public string CdUsuario
	{
		get
		{
			return _CdUsuario;
		}
		set
		{
			_CdUsuario = value;
		}
	}
}
