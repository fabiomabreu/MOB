using System.Collections.Generic;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class GrupoCliDAL
{
	private const string SELECT = "uspGrupoCliSelect";

	public static List<GrupoCliTO> Select(DbConnection connection, GrupoCliTO model)
	{
		connection.ClearParameters();
		connection.AddParameters("@Codigo", model.Codigo);
		connection.AddParameters("@Descricao", model.Descricao);
		connection.AddParameters("@Ativo", model.Ativo);
		connection.AddParameters("@GrupoCliId", model.GrupoCliId);
		connection.AddParameters("@RowId", model.RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspGrupoCliSelect"));
	}

	private static List<GrupoCliTO> CreateInstances(BasicRS rs)
	{
		List<GrupoCliTO> list = new List<GrupoCliTO>();
		using (rs)
		{
			while (rs.MoveNext())
			{
				GrupoCliTO grupoCliTO = new GrupoCliTO();
				grupoCliTO.Codigo = rs.GetString("Codigo");
				grupoCliTO.Descricao = rs.GetString("Descricao");
				grupoCliTO.GrupoCliId = rs.GetNullableInteger("GrupoCliId");
				grupoCliTO.RowId = rs.GetArrayByte("RowId");
				grupoCliTO.Ativo = rs.GetNullableBoolean("Ativo");
				list.Add(grupoCliTO);
			}
			return list;
		}
	}
}
