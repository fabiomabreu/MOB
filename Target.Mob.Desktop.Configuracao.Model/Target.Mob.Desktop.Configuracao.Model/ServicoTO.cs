using System.Collections.Generic;

namespace Target.Mob.Desktop.Configuracao.Model;

public class ServicoTO
{
	private int? _Id;

	private int? _CodigoServico;

	private bool? _Status;

	private string _Nome;

	private bool? _Principal;

	private List<ConfiguracaoServicoTO> _ConfiguracaoServico = new List<ConfiguracaoServicoTO>();

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

	public int? CodigoServico
	{
		get
		{
			return _CodigoServico;
		}
		set
		{
			_CodigoServico = value;
		}
	}

	public bool? Status
	{
		get
		{
			return _Status;
		}
		set
		{
			_Status = value;
		}
	}

	public string Nome
	{
		get
		{
			return _Nome;
		}
		set
		{
			_Nome = value;
		}
	}

	public bool? Principal
	{
		get
		{
			return _Principal;
		}
		set
		{
			_Principal = value;
		}
	}

	public List<ConfiguracaoServicoTO> ConfiguracaoServico
	{
		get
		{
			return _ConfiguracaoServico;
		}
		set
		{
			_ConfiguracaoServico = value;
		}
	}
}
