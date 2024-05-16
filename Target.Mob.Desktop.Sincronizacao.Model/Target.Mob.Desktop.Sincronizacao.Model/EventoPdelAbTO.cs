namespace Target.Mob.Desktop.Sincronizacao.Model;

public class EventoPdelAbTO
{
	private int _SeqEvento;

	private EventoPdelTO _oEventoPdel;

	private PedVdaEleTO _oPedVdaEle;

	public int SeqEvento
	{
		get
		{
			return _SeqEvento;
		}
		set
		{
			_SeqEvento = value;
		}
	}

	public EventoPdelTO oEventoPdel
	{
		get
		{
			return _oEventoPdel;
		}
		set
		{
			_oEventoPdel = value;
		}
	}

	public PedVdaEleTO oPedVdaEle
	{
		get
		{
			return _oPedVdaEle;
		}
		set
		{
			_oPedVdaEle = value;
		}
	}
}
