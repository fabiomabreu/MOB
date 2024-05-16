using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class PromotorBLL
{
	public static List<PromotorTO> Select(DbConnection connection, PromotorTO promotor)
	{
		List<PromotorTO> list = PromotorDAL.Select(connection, promotor);
		foreach (PromotorTO item in list)
		{
			item.ListTelPromotor = TelPromotorBLL.Select(connection, item.CdPromotor);
			item.ListContPromotor = ContPromotorBLL.Select(connection, item.CdPromotor);
		}
		if (list == null || list.Count <= 0)
		{
			return new List<PromotorTO>();
		}
		return list;
	}

	public static PromotorTO SelectById(DbConnection connection, int promotorId)
	{
		PromotorTO promotorTO = PromotorDAL.SelectById(connection, promotorId);
		if (promotorTO != null)
		{
			promotorTO.ListTelPromotor = TelPromotorBLL.Select(connection, promotorTO.CdPromotor);
			promotorTO.ListContPromotor = ContPromotorBLL.Select(connection, promotorTO.CdPromotor);
		}
		return promotorTO;
	}

	public static void setCoordenadaResidencia(DbConnection connTargetErp, CoordenadaResidenciaTO cr)
	{
		PromotorDAL.setCoordenadaResidencia(connTargetErp, cr);
	}
}
