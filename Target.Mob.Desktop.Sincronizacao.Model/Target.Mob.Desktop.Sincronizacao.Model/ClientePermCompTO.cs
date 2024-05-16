using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ClientePermCompTO
{
	private int _ClientePermCompID;

	private int _CdClien;

	private int _CdDoc;

	private string _NumeroDoc;

	private DateTime? _DtVencimento;

	private string _SitRegular;

	public int ClientePermCompID
	{
		get
		{
			return _ClientePermCompID;
		}
		set
		{
			_ClientePermCompID = value;
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

	public int CdDoc
	{
		get
		{
			return _CdDoc;
		}
		set
		{
			_CdDoc = value;
		}
	}

	public string NumeroDoc
	{
		get
		{
			return _NumeroDoc;
		}
		set
		{
			_NumeroDoc = value;
		}
	}

	public DateTime? DtVencimento
	{
		get
		{
			return _DtVencimento;
		}
		set
		{
			_DtVencimento = value;
		}
	}

	public string SitRegular
	{
		get
		{
			return _SitRegular;
		}
		set
		{
			_SitRegular = value;
		}
	}
}
