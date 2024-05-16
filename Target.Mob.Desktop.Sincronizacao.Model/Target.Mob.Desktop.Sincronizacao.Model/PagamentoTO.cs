using System;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class PagamentoTO
{
	private int? _TgtMobPagamentoID;

	private string _CdVend;

	private DateTime? _DataPgto;

	private int? _CdClien;

	private string _TpPgto;

	private double? _ValorPgto;

	private DateTime? _DataImportacao;

	public int? TgtMobPagamentoID
	{
		get
		{
			return _TgtMobPagamentoID;
		}
		set
		{
			_TgtMobPagamentoID = value;
		}
	}

	public DateTime? DataPgto
	{
		get
		{
			return _DataPgto;
		}
		set
		{
			_DataPgto = value;
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

	public string TpPgto
	{
		get
		{
			return _TpPgto;
		}
		set
		{
			_TpPgto = value;
		}
	}

	public double? ValorPgto
	{
		get
		{
			return _ValorPgto;
		}
		set
		{
			_ValorPgto = value;
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

	public DateTime? DataImportacao
	{
		get
		{
			return _DataImportacao;
		}
		set
		{
			_DataImportacao = value;
		}
	}
}
