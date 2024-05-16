using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class EquipePromotorBLL
{
	public static List<EquipePromotorTO> SelectRowId(DbConnection connection, EquipePromotorTO equipePromotor)
	{
		List<EquipePromotorTO> list = EquipePromotorDAL.SelectRowId(connection, equipePromotor);
		if (list == null || list.Count <= 0)
		{
			return new List<EquipePromotorTO>();
		}
		return list;
	}
}
