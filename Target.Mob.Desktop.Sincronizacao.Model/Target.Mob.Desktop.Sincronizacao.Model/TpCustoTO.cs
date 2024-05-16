namespace Target.Mob.Desktop.Sincronizacao.Model;

public class TpCustoTO
{
	private string _TpCusto;

	private string _Descricao;

	private int? _Contabil;

	private byte[] _RowId;

	public string TpCusto
	{
		get
		{
			return _TpCusto;
		}
		set
		{
			_TpCusto = value;
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

	public int? Contabil
	{
		get
		{
			return _Contabil;
		}
		set
		{
			_Contabil = value;
		}
	}

	public byte[] RowID
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
