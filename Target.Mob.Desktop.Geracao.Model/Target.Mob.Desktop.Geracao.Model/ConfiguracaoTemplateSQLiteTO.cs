namespace Target.Mob.Desktop.Geracao.Model;

public class ConfiguracaoTemplateSQLiteTO
{
	private int? _Id;

	private int? _IdVersaoCarga;

	private byte[] _Template;

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

	public int? IdVersaoCarga
	{
		get
		{
			return _IdVersaoCarga;
		}
		set
		{
			_IdVersaoCarga = value;
		}
	}

	public byte[] Template
	{
		get
		{
			return _Template;
		}
		set
		{
			_Template = value;
		}
	}
}
