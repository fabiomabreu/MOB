namespace Target.Mob.Desktop.Sincronizacao.Model;

public class PendEleLogTO
{
	private int _SeqPendEleLog;

	private int _CdEmpEle;

	private int _NuPedEle;

	private int _SeqPed;

	private int? _NuTentativasLib;

	private bool _Processando;

	private int? _IdProc;

	private bool _Falha;

	public int SeqPendEleLog
	{
		get
		{
			return _SeqPendEleLog;
		}
		set
		{
			_SeqPendEleLog = value;
		}
	}

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

	public int NuPedEle
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

	public int SeqPed
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

	public int? NuTentativasLib
	{
		get
		{
			return _NuTentativasLib;
		}
		set
		{
			_NuTentativasLib = value;
		}
	}

	public bool Processando
	{
		get
		{
			return _Processando;
		}
		set
		{
			_Processando = value;
		}
	}

	public int? IdProc
	{
		get
		{
			return _IdProc;
		}
		set
		{
			_IdProc = value;
		}
	}

	public bool Falha
	{
		get
		{
			return _Falha;
		}
		set
		{
			_Falha = value;
		}
	}
}
