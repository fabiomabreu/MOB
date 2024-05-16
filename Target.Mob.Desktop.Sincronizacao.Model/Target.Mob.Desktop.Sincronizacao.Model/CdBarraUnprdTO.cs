namespace Target.Mob.Desktop.Sincronizacao.Model;

public class CdBarraUnprdTO
{
	private int? cdProd;

	private string unidVda;

	private int? seq;

	private string tpCdBarra;

	private string cdBarra;

	private bool? imprime;

	private bool? ativo;

	private byte[] rowId;

	public int? CdProd
	{
		get
		{
			return cdProd;
		}
		set
		{
			cdProd = value;
		}
	}

	public string UnidVda
	{
		get
		{
			return unidVda;
		}
		set
		{
			unidVda = value;
		}
	}

	public int? Seq
	{
		get
		{
			return seq;
		}
		set
		{
			seq = value;
		}
	}

	public string TpCdBarra
	{
		get
		{
			return tpCdBarra;
		}
		set
		{
			tpCdBarra = value;
		}
	}

	public string CdBarra
	{
		get
		{
			return cdBarra;
		}
		set
		{
			cdBarra = value;
		}
	}

	public bool? Imprime
	{
		get
		{
			return imprime;
		}
		set
		{
			imprime = value;
		}
	}

	public bool? Ativo
	{
		get
		{
			return ativo;
		}
		set
		{
			ativo = value;
		}
	}

	public byte[] RowId
	{
		get
		{
			return rowId;
		}
		set
		{
			rowId = value;
		}
	}
}
