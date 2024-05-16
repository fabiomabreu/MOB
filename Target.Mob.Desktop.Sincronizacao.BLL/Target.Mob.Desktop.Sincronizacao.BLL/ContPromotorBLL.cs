using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class ContPromotorBLL
{
	public static List<ContPromotorTO> Select(DbConnection connection, string CdPromotor)
	{
		return ContPromotorDAL.Select(connection, CdPromotor);
	}
}
