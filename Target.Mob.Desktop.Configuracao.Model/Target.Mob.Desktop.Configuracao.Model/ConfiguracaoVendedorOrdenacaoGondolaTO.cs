namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorOrdenacaoGondolaTO
{
	private int _IdConfiguracaoVendedorOrdenacaoGondola;

	private int? _Seq;

	private int? _IdConfiguracaoVendedor;

	private string _ColunaOrdenacao;

	private string _TipoOrdenacao;

	public int? Seq
	{
		get
		{
			return _Seq;
		}
		set
		{
			_Seq = value;
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

	public string ColunaOrdenacao
	{
		get
		{
			return _ColunaOrdenacao;
		}
		set
		{
			_ColunaOrdenacao = value;
		}
	}

	public string TipoOrdenacao
	{
		get
		{
			return _TipoOrdenacao;
		}
		set
		{
			_TipoOrdenacao = value;
		}
	}

	public int IdConfiguracaoVendedorOrdenacaoGondola
	{
		get
		{
			return _IdConfiguracaoVendedorOrdenacaoGondola;
		}
		set
		{
			_IdConfiguracaoVendedorOrdenacaoGondola = value;
		}
	}
}
