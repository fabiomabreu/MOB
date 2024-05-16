using System;
using System.Collections.Generic;
using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Model;

public class GeracaoTO
{
	private int? _Id;

	private DateTime? _DataInicio;

	private DateTime? _DataFim;

	private StatusGeracaoTR? _StatusGeracao;

	private List<GeracaoItemTO> _GeracaoItem;

	private int? _QtdeVendedores;

	private byte[] _rowId;

	public int? Id
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

	public DateTime? DataInicio
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

	public StatusGeracaoTR? StatusGeracao
	{
		get
		{
			return _StatusGeracao;
		}
		set
		{
			_StatusGeracao = value;
		}
	}

	public List<GeracaoItemTO> ProcessoGeracaoItem
	{
		get
		{
			return _GeracaoItem;
		}
		set
		{
			_GeracaoItem = value;
		}
	}

	public byte[] RowId
	{
		get
		{
			return _rowId;
		}
		set
		{
			_rowId = value;
		}
	}

	public int? QtdeVendedores
	{
		get
		{
			return _QtdeVendedores;
		}
		set
		{
			_QtdeVendedores = value;
		}
	}
}
