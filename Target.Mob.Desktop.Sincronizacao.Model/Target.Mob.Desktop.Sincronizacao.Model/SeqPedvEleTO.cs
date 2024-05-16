namespace Target.Mob.Desktop.Sincronizacao.Model;

public class SeqPedvEleTO
{
	private int _CdEmp;

	private decimal? _Numero;

	public int CdEmp
	{
		get
		{
			return _CdEmp;
		}
		set
		{
			_CdEmp = value;
		}
	}

	public decimal? Numero
	{
		get
		{
			return _Numero;
		}
		set
		{
			_Numero = value;
		}
	}
}
