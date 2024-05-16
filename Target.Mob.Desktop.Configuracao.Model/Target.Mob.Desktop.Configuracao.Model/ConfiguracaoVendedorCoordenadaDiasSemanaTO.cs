using System;

namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorCoordenadaDiasSemanaTO
{
	private int? _Id;

	private int? _IdConfiguracaoVendedor;

	private string _CodigoCoordenadaDiaSemana;

	private DateTime? _HorarioInicioCoordenada;

	private DateTime? _HorarioFimCoordenada;

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

	public int? IdConfiguracaoVendedor
	{
		get
		{
			return _IdConfiguracaoVendedor;
		}
		set
		{
			_IdConfiguracaoVendedor = value;
		}
	}

	public string CodigoCoordenadaDiaSemana
	{
		get
		{
			return _CodigoCoordenadaDiaSemana;
		}
		set
		{
			_CodigoCoordenadaDiaSemana = value;
		}
	}

	public DateTime? HorarioInicioCoordenada
	{
		get
		{
			return _HorarioInicioCoordenada;
		}
		set
		{
			_HorarioInicioCoordenada = value;
		}
	}

	public DateTime? HorarioFimCoordenada
	{
		get
		{
			return _HorarioFimCoordenada;
		}
		set
		{
			_HorarioFimCoordenada = value;
		}
	}
}
