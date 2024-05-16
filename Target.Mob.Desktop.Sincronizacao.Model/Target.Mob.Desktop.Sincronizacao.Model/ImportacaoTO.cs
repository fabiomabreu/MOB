using System;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;

namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ImportacaoTO
{
	private int _Id;

	private DateTime _DataInicio;

	private DateTime? _DataFim;

	private StatusImportacaoTR _IdStatusImportacaoTR;

	private ImportacaoItemTO[] _oImportacaoItem;

	public int Id
	{
		get
		{
			return _Id;
		}
		set
		{
			_Id = value;
		}
	}

	public DateTime DataInicio
	{
		get
		{
			return _DataInicio;
		}
		set
		{
			_DataInicio = value;
		}
	}

	public DateTime? DataFim
	{
		get
		{
			return _DataFim;
		}
		set
		{
			_DataFim = value;
		}
	}

	public StatusImportacaoTR IdStatusImportacaoTR
	{
		get
		{
			return _IdStatusImportacaoTR;
		}
		set
		{
			_IdStatusImportacaoTR = value;
		}
	}

	public ImportacaoItemTO[] oImportacaoItem
	{
		get
		{
			return _oImportacaoItem;
		}
		set
		{
			_oImportacaoItem = value;
		}
	}
}
