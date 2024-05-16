namespace Target.Mob.Desktop.Geracao.Common;

public static class ConfigGeracao
{
	private static string _ConnStringTargetMob;

	private static string _NomeServidorOrigemReplicacao;

	private static string _NomeDbOrigemReplicacao;

	private static string _TargetMobPath;

	private static bool _GeracaoLogaEtapa;

	public static string ConnStringTargetMob
	{
		get
		{
			return _ConnStringTargetMob;
		}
		set
		{
			_ConnStringTargetMob = value;
		}
	}

	public static string NomeServidorOrigemReplicacao
	{
		get
		{
			if (!(_NomeServidorOrigemReplicacao == string.Empty))
			{
				return _NomeServidorOrigemReplicacao;
			}
			return null;
		}
		set
		{
			_NomeServidorOrigemReplicacao = value;
		}
	}

	public static string NomeDbOrigemReplicacao
	{
		get
		{
			return _NomeDbOrigemReplicacao;
		}
		set
		{
			_NomeDbOrigemReplicacao = value;
		}
	}

	public static string TargetMobPath
	{
		get
		{
			return _TargetMobPath;
		}
		set
		{
			_TargetMobPath = value;
		}
	}

	public static bool GeracaoLogaEtapa
	{
		get
		{
			return _GeracaoLogaEtapa;
		}
		set
		{
			_GeracaoLogaEtapa = value;
		}
	}
}
