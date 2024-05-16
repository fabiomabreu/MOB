using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class GrupoCliBLL
{
	public static List<GrupoCliTO> Select(DbConnection connection, GrupoCliTO model)
	{
		List<GrupoCliTO> list = GrupoCliDAL.Select(connection, model);
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
