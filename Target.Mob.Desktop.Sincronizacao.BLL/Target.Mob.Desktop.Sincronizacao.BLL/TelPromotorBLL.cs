using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TelPromotorBLL
{
	public static List<TelPromotorTO> Select(DbConnection connection, string CdPromotor)
	{
		return TelPromotorDAL.Select(connection, CdPromotor);
	}
}
