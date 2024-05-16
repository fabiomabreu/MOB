namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoServicoTO
{
	private int? _Id;

	private int? _IdServico;

	private short? _Dia;

	private string _HorarioInicio;

	private string _HorarioTermino;

	private int? _Intervalo;

	private bool? _Alterado;

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

	public int? IdServico
	{
		get
		{
			return _IdServico;
		}
		set
		{
			_IdServico = value;
		}
	}

	public short? Dia
	{
		get
		{
			return _Dia;
		}
		set
		{
			_Dia = value;
		}
	}

	public string HorarioInicio
	{
		get
		{
			return _HorarioInicio;
		}
		set
		{
			_HorarioInicio = value;
		}
	}

	public string HorarioTermino
	{
		get
		{
			return _HorarioTermino;
		}
		set
		{
			_HorarioTermino = value;
		}
	}

	public int? Intervalo
	{
		get
		{
			return _Intervalo;
		}
		set
		{
			_Intervalo = value;
		}
	}

	public bool? Alterado
	{
		get
		{
			return _Alterado;
		}
		set
		{
			_Alterado = value;
		}
	}
}
