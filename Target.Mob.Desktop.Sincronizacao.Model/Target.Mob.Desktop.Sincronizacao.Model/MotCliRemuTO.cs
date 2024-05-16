namespace Target.Mob.Desktop.Sincronizacao.Model;

public class MotCliRemuTO
{
	private string _CdMotor;

	private int _CdClien;

	private decimal _PercRemu;

	public string CdMotor
	{
		get
		{
			return _CdMotor;
		}
		set
		{
			_CdMotor = value;
		}
	}

	public int CdClien
	{
		get
		{
			return _CdClien;
		}
		set
		{
			_CdClien = value;
		}
	}

	public decimal PercRemu
	{
		get
		{
			return _PercRemu;
		}
		set
		{
			_PercRemu = value;
		}
	}
}
