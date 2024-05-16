namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ConfiguracaoRelatorioTO
{
	private int? _IDConfiguracaoRelatorio;

	private string _Diretorio;

	private int? _TamanhoMaximo;

	public int? IDConfiguracaoRelatorio
	{
		get
		{
			return _IDConfiguracaoRelatorio;
		}
		set
		{
			_IDConfiguracaoRelatorio = value;
		}
	}

	public string Diretorio
	{
		get
		{
			return _Diretorio;
		}
		set
		{
			_Diretorio = value;
		}
	}

	public int? TamanhoMaximo
	{
		get
		{
			return _TamanhoMaximo;
		}
		set
		{
			_TamanhoMaximo = value;
		}
	}

	public ConfiguracaoRelatorioTO()
	{
	}

	public ConfiguracaoRelatorioTO(int? iDConfiguracaoRelatorio, string diretorio, int? tamanhoMaximo)
	{
		_IDConfiguracaoRelatorio = iDConfiguracaoRelatorio;
		_Diretorio = diretorio;
		_TamanhoMaximo = tamanhoMaximo;
	}
}
