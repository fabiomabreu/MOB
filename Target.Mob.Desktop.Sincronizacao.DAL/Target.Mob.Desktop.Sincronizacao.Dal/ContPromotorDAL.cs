using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class ContPromotorDAL
{
	public const string SELECT = "uspContPromotorSelectCdPromotor";

	public static List<ContPromotorTO> Select(DbConnection connection, string CdPromotor)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdPromotor", CdPromotor);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspContPromotorSelectCdPromotor"));
	}

	private static List<ContPromotorTO> CreateInstances(BasicRS rs)
	{
		List<ContPromotorTO> list = new List<ContPromotorTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ContPromotorTO contPromotorTO = new ContPromotorTO();
				contPromotorTO.ContPromotorId = rs.GetInteger("ContPromotorId");
				contPromotorTO.CdPromotor = rs.GetString("CdPromotor");
				contPromotorTO.Nome = rs.GetString("Nome");
				contPromotorTO.Cargo = rs.GetString("Cargo");
				contPromotorTO.RowId = rs.GetArrayByte("RowId");
				list.Add(contPromotorTO);
			}
			return list;
		}
	}
}
