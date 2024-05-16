using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class AreaBLL
{
	public static List<AreaTO> Select(DbConnection connection, AreaTO model)
	{
		List<AreaTO> list = AreaDAL.Select(connection, model);
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
