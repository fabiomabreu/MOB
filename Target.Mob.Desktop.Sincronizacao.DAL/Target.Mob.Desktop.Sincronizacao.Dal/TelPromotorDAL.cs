using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TelPromotorDAL
{
	public const string SELECT = "uspTelPromotorSelectCdPromotor";

	public static List<TelPromotorTO> Select(DbConnection connection, string CdPromotor)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdPromotor", CdPromotor);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTelPromotorSelectCdPromotor"));
	}

	private static List<TelPromotorTO> CreateInstances(BasicRS rs)
	{
		List<TelPromotorTO> list = new List<TelPromotorTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TelPromotorTO telPromotorTO = new TelPromotorTO();
				telPromotorTO.TelPromotorId = rs.GetInteger("TelPromotorId");
				telPromotorTO.CdPromotor = rs.GetString("CdPromotor");
				telPromotorTO.Ddd = rs.GetNullableInteger("Ddd");
				telPromotorTO.NuTel = rs.GetNullableLong("NuTel");
				telPromotorTO.Ddd = rs.GetNullableInteger("Ddd");
				telPromotorTO.TpTel = rs.GetString("TpTel");
				telPromotorTO.RowId = rs.GetArrayByte("RowId");
				list.Add(telPromotorTO);
			}
			return list;
		}
	}
}
