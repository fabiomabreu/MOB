using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class AreaDAL
{
	private const string SELECT = "uspAreaSelect";

	public static List<AreaTO> Select(DbConnection connection, AreaTO model)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo", model.Codigo);
		connection.AddParameters("@Descricao", model.Descricao);
		connection.AddParameters("@Ativo", model.Ativo);
		connection.AddParameters("@AreaId", model.AreaId);
		connection.AddParameters("@RowId", model.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAreaSelect"));
	}

	private static List<AreaTO> CreateInstances(BasicRS rs)
	{
		List<AreaTO> list = new List<AreaTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AreaTO areaTO = new AreaTO();
				areaTO.Codigo = rs.GetString("Codigo");
				areaTO.Descricao = rs.GetString("Descricao");
				areaTO.AreaId = rs.GetNullableInteger("AreaId");
				areaTO.RowId = rs.GetArrayByte("RowId");
				areaTO.Ativo = rs.GetNullableBoolean("Ativo");
				list.Add(areaTO);
			}
			return list;
		}
	}
}
