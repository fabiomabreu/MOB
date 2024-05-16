using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CliLogAltTO
{
	private int _SeqLog;

	private int _CdClien;

	private int _CdEmp;

	private string _CdUsuario;

	private DateTime _Data;

	private string _TpLog;

	private int _CdTexto;

	public int SeqLog
	{
		get
		{
			return _SeqLog;
		}
		set
		{
			_SeqLog = value;
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

	public string TpLog
	{
		get
		{
			return _TpLog;
		}
		set
		{
			_TpLog = value;
		}
	}

	public int CdTexto
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
