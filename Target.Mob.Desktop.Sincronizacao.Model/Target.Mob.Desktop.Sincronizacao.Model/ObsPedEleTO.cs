namespace Target.Mob.Desktop.Sincronizacao.Model;

public class ObsPedEleTO
{
	private int _CdEmpEle;

	private decimal _NuPedEle;

	private decimal _SeqPed;

	private decimal _Seq;

	private string _Setor;

	private int? _CdTexto;

	public int CdEmpEle
	{
		get
		{
			return _CdEmpEle;
		}
		set
		{
			_CdEmpEle = value;
		}
	}

	public decimal NuPedEle
	{
		get
		{
			return _NuPedEle;
		}
		set
		{
			_NuPedEle = value;
		}
	}

	public decimal SeqPed
	{
		get
		{
			return _SeqPed;
		}
		set
		{
			_SeqPed = value;
		}
	}

	public decimal Seq
	{
		get
		{
			return _Seq;
		}
		set
		{
			_Seq = value;
		}
	}

	public string Setor
	{
		get
		{
			return _Setor;
		}
		set
		{
			_Setor = value;
		}
	}

	public int? CdTexto
	{
		get
		{
			return _CdTexto;
		}
		set
		{
			_CdTexto = value;
		}
	}
}
