using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class GerenciaPromotorBLL
{
	public static List<GerenciaPromotorTO> SelectRowId(DbConnection connection, GerenciaPromotorTO gerenciaPromotor)
	{
		List<GerenciaPromotorTO> list = GerenciaPromotorDAL.SelectRowId(connection, gerenciaPromotor);
		if (list == null || list.Count <= 0)
		{
			return new List<GerenciaPromotorTO>();
		}
		return list;
	}
}
