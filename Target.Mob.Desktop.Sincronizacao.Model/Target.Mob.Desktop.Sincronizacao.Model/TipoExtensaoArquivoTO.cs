namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TipoExtensaoArquivoTO
{
	private int _IDTipoExtensaoArquivo;

	private string _Descricao;

	public int IDTipoExtensaoArquivo
	{
		get
		{
			return _IDTipoExtensaoArquivo;
		}
		set
		{
			_IDTipoExtensaoArquivo = value;
		}
	}

	public string Descricao
	{
		get
		{
			return _Descricao;
		}
		set
		{
			_Descricao = value;
		}
	}

	public TipoExtensaoArquivoTO()
	{
	}

	public TipoExtensaoArquivoTO(int iDTipoExtensaoArquivo, string descricao)
	{
		_IDTipoExtensaoArquivo = iDTipoExtensaoArquivo;
		_Descricao = descricao;
	}
}
