using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class EventoPdelAbBLL
{
	public static EventoPdelAbTO[] Select(DbConnection connection, int? SeqEvento, string CdVend, int? QtdePedidos)
	{
		EventoPdelAbTO[] array = EventoPdelAbDAL.Select(connection, SeqEvento, CdVend, QtdePedidos);
		if (array != null)
		{
			EventoPdelAbTO[] array2 = array;
			foreach (EventoPdelAbTO eventoPdelAbTO in array2)
			{
				eventoPdelAbTO.oEventoPdel = EventoPdelBLL.Select(connection, eventoPdelAbTO.SeqEvento);
				eventoPdelAbTO.oPedVdaEle = PedVdaEleBLL.Select(connection, ApenasCabecalho: true, eventoPdelAbTO.oEventoPdel.CdEmpEle, eventoPdelAbTO.oEventoPdel.NuPedEle, eventoPdelAbTO.oEventoPdel.SeqPed);
			}
		}
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, EventoPdelAbTO EventoPdelAb)
	{
		PedVdaEleBLL.Insert(connection, EventoPdelAb.oPedVdaEle);
		EventoPdelAb.oEventoPdel.CdEmpEle = EventoPdelAb.oPedVdaEle.CdEmpEle;
		EventoPdelAb.oEventoPdel.NuPedEle = EventoPdelAb.oPedVdaEle.NuPedEle;
		EventoPdelAb.oEventoPdel.SeqPed = EventoPdelAb.oPedVdaEle.SeqPed;
		EventoPdelBLL.Insert(connection, EventoPdelAb.oEventoPdel);
		EventoPdelAb.SeqEvento = EventoPdelAb.oEventoPdel.SeqEvento;
		EventoPdelAbDAL.Insert(connection, EventoPdelAb);
	}
}
