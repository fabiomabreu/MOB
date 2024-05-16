namespace Target.Mob.Desktop.Sincronizacao.Model;

public class FormPgtoTO
{
	private string _FormPgto;

	private string _Descricao;

	private bool _Ativo;

	private byte[] _RowId;

	public string FormPgto
	{
		get
		{
			return _FormPgto;
		}
		set
		{
			_FormPgto = value;
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

	public bool Ativo
	{
		get
		{
			return _Ativo;
		}
		set
		{
			_Ativo = value;
		}
	}

	public byte[] RowId
	{
		get
		{
			return _RowId;
		}
		set
		{
			_RowId = value;
		}
	}
}
