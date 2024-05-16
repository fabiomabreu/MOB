namespace Target.Mob.Desktop.Configuracao.Model;

public class ConfiguracaoVendedorTipoNotificacaoTO
{
	private int? _IDTipoNotificacao;

	private int? _IDConfiguracaoVendedor;

	public int? IDTipoNotificacao
	{
		get
		{
			return _IDTipoNotificacao;
		}
		set
		{
			_IDTipoNotificacao = value;
		}
	}

	public int? IDConfiguracaoVendedor
	{
		get
		{
			return _IDConfiguracaoVendedor;
		}
		set
		{
			_IDConfiguracaoVendedor = value;
		}
	}
}
