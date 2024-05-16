namespace Target.Mob.Desktop.Sincronizacao.Model;

public class VendCliTO
{
	private int? _CdClien;

	private string _CdVend;

	private bool? _Prioritario;

	private decimal? _VlLimiteVerba;

	public int? CdClien
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

	public string CdVend
	{
		get
		{
			return _CdVend;
		}
		set
		{
			_CdVend = value;
		}
	}

	public bool? Prioritario
	{
		get
		{
			return _Prioritario;
		}
		set
		{
			_Prioritario = value;
		}
	}

	public decimal? VlLimiteVerba
	{
		get
		{
			return _VlLimiteVerba;
		}
		set
		{
			_VlLimiteVerba = value;
		}
	}
}
