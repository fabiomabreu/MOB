using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class EquipePromotorDAL
{
	private const string SELECT_BY_ROWID = "uspEquipePromotorSelectRowId";

	public static List<EquipePromotorTO> SelectRowId(DbConnection connection, EquipePromotorTO model)
	{
		connection.ClearParameters();
		connection.AddParameters("@RowId", model.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEquipePromotorSelectRowId"));
	}

	private static List<EquipePromotorTO> CreateInstances(BasicRS rs)
	{
		List<EquipePromotorTO> list = new List<EquipePromotorTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				EquipePromotorTO equipePromotorTO = new EquipePromotorTO();
				equipePromotorTO.EquipePromotorId = rs.GetNullableInteger("EquipePromotorId");
				equipePromotorTO.CdEmp = rs.GetNullableInteger("CdEmp");
				equipePromotorTO.CdEquipe = rs.GetString("CdEquipe");
				equipePromotorTO.Descricao = rs.GetString("Descricao");
				equipePromotorTO.CdPromotorSupervisor = rs.GetString("CdPromotorSupervisor");
				equipePromotorTO.Ativo = rs.GetNullableBoolean("Ativo");
				equipePromotorTO.GerenciaPromotorId = rs.GetNullableInteger("GerenciaPromotorId");
				equipePromotorTO.RowId = rs.GetArrayByte("RowId");
				list.Add(equipePromotorTO);
			}
			return list;
		}
	}
}
