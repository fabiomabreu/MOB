using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class RamAtivDAL
{
	private const string SELECT = "uspRamAtivSelect";

	public static List<RamAtivTO> Select(DbConnection connection, RamAtivTO model)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo", model.Codigo);
		connection.AddParameters("@Descricao", model.Descricao);
		connection.AddParameters("@Ativo", model.Ativo);
		connection.AddParameters("@RamAtivId", model.RamAtivId);
		connection.AddParameters("@QtdeCheckOut", model.QtdeCheckOut);
		connection.AddParameters("@RowId", model.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspRamAtivSelect"));
	}

	private static List<RamAtivTO> CreateInstances(BasicRS rs)
	{
		List<RamAtivTO> list = new List<RamAtivTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				RamAtivTO ramAtivTO = new RamAtivTO();
				ramAtivTO.Codigo = rs.GetString("Codigo");
				ramAtivTO.Descricao = rs.GetString("Descricao");
				ramAtivTO.Ativo = rs.GetNullableBoolean("Ativo");
				ramAtivTO.QtdeCheckOut = rs.GetNullableShort("QtdeCheckOut");
				ramAtivTO.RamAtivId = rs.GetNullableInteger("RamAtivId");
				ramAtivTO.RowId = rs.GetArrayByte("RowId");
				list.Add(ramAtivTO);
			}
			return list;
		}
	}
}
