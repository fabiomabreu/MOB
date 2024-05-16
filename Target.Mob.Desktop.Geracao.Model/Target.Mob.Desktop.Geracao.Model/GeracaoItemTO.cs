using System;
using System.Collections.Generic;
using Target.Mob.Desktop.Geracao.Enum;

namespace Target.Mob.Desktop.Geracao.Model;

public class GeracaoItemTO
{
	private int? _Id;

	private int? _IdGeracao;

	private DateTime? _DataInicio;

	private EtapaGeracaoItemTR? _EtapaGeracaoItem;

	private string _TabelaBancoDados;

	private int? _IdVendedor;

	private DateTime? _DataFim;

	private int? _QtdeRegistros;

	private StatusGeracaoItemTR? _StatusGeracaoItem;

	private List<GeracaoLogErroTO> _GeracaoLogErro;

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

	public int? IdGeracao
	{
		get
		{
			return _IdGeracao;
		}
		set
		{
			_IdGeracao = value;
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

	public EtapaGeracaoItemTR? EtapaGeracaoItem
	{
		get
		{
			return _EtapaGeracaoItem;
		}
		set
		{
			_EtapaGeracaoItem = value;
		}
	}

	public string TabelaBancoDados
	{
		get
		{
			return _TabelaBancoDados;
		}
		set
		{
			_TabelaBancoDados = value;
		}
	}

	public int? IdVendedor
	{
		get
		{
			return _IdVendedor;
		}
		set
		{
			_IdVendedor = value;
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

	public int? QtdeRegistros
	{
		get
		{
			return _QtdeRegistros;
		}
		set
		{
			_QtdeRegistros = value;
		}
	}

	public StatusGeracaoItemTR? StatusGeracaoItem
	{
		get
		{
			return _StatusGeracaoItem;
		}
		set
		{
			_StatusGeracaoItem = value;
		}
	}

	public List<GeracaoLogErroTO> GeracaoLogErro
	{
		get
		{
			return _GeracaoLogErro;
		}
		set
		{
			_GeracaoLogErro = value;
		}
	}
}
