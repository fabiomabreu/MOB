using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class GerenciaPromotorDAL
{
	private const string SELECT_BY_ROWID = "uspGerenciaPromotorSelectRowId";

	public static List<GerenciaPromotorTO> SelectRowId(DbConnection connection, GerenciaPromotorTO model)
	{
		connection.ClearParameters();
		connection.AddParameters("@RowId", model.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspGerenciaPromotorSelectRowId"));
	}

	private static List<GerenciaPromotorTO> CreateInstances(BasicRS rs)
	{
		List<GerenciaPromotorTO> list = new List<GerenciaPromotorTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				GerenciaPromotorTO gerenciaPromotorTO = new GerenciaPromotorTO();
				gerenciaPromotorTO.GerenciaPromotorId = rs.GetNullableInteger("GerenciaPromotorId");
				gerenciaPromotorTO.CdEmp = rs.GetNullableInteger("CdEmp");
				gerenciaPromotorTO.CdGerencia = rs.GetString("CdGerencia");
				gerenciaPromotorTO.Descricao = rs.GetString("Descricao");
				gerenciaPromotorTO.CdPromotorGerente = rs.GetString("CdPromotorGerente");
				gerenciaPromotorTO.Ativo = rs.GetNullableBoolean("Ativo");
				gerenciaPromotorTO.RowId = rs.GetArrayByte("RowId");
				list.Add(gerenciaPromotorTO);
			}
			return list;
		}
	}
}
