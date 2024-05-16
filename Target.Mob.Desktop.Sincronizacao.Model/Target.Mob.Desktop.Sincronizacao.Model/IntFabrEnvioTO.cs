namespace Target.Mob.Desktop.Sincronizacao.Model;

public class IntFabrEnvioTO
{
	private string _CdSistema;

	private string _TpCfg;

	private string _Codigo;

	private string _CdFabric;

	public string CdSistema
	{
		get
		{
			return _CdSistema;
		}
		set
		{
			_CdSistema = value;
		}
	}

	public string TpCfg
	{
		get
		{
			return _TpCfg;
		}
		set
		{
			_TpCfg = value;
		}
	}

	public string Codigo
	{
		get
		{
			return _Codigo;
		}
		set
		{
			_Codigo = value;
		}
	}

	public string CdFabric
	{
		get
		{
			return _CdFabric;
		}
		set
		{
			_CdFabric = value;
		}
	}
}
