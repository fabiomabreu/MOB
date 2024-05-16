using System.Collections.Generic;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class CoordenadaRoteiroVendedorPermanenciaBLL
{
	public static byte[] selectMaxRowId(DbConnection connTargetErp)
	{
		return CoordenadaRoteiroVendedorPermanenciaDAL.selectMaxRowId(connTargetErp);
	}

	public static void Merge(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO crvp)
	{
		CoordenadaRoteiroVendedorPermanenciaTO coordenadaRoteiroVendedorPermanenciaTO = new CoordenadaRoteiroVendedorPermanenciaTO();
		coordenadaRoteiroVendedorPermanenciaTO.IdVendedor = crvp.IdVendedor;
		coordenadaRoteiroVendedorPermanenciaTO.Data = crvp.Data;
		CoordenadaRoteiroVendedorPermanenciaTO[] array = CoordenadaRoteiroVendedorPermanenciaDAL.Select(connTargetErp, coordenadaRoteiroVendedorPermanenciaTO);
		if (array != null && array.Count() > 0)
		{
			CoordenadaRoteiroVendedorPermanenciaTO[] array2 = array;
			foreach (CoordenadaRoteiroVendedorPermanenciaTO rtv in array2)
			{
				CoordenadaRoteiroVendedorPermanenciaDAL.Delete(connTargetErp, rtv);
			}
		}
		CoordenadaRoteiroVendedorPermanenciaDAL.Insert(connTargetErp, crvp);
	}

	public static void DeleteByIdVendedorEData(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO crvp)
	{
		CoordenadaRoteiroVendedorPermanenciaDAL.DeleteByIdVendedorEData(connTargetErp, crvp);
	}

	public static void Insert(DbConnection connTargetErp, CoordenadaRoteiroVendedorPermanenciaTO crvp)
	{
		CoordenadaRoteiroVendedorPermanenciaDAL.Insert(connTargetErp, crvp);
	}

	public static void CRVPMerge(DbConnection connTargetErp, List<CoordenadaRoteiroVendedorPermanenciaTO> listaCRVP, List<CoordenadaRoteiroVendedorPermanenciaTO> listaCRVPDelete)
	{
		foreach (CoordenadaRoteiroVendedorPermanenciaTO item in listaCRVPDelete)
		{
			DeleteByIdVendedorEData(connTargetErp, item);
		}
		foreach (CoordenadaRoteiroVendedorPermanenciaTO item2 in listaCRVP)
		{
			Insert(connTargetErp, item2);
		}
	}
}
