using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class RamAtivBLL
{
	public static List<RamAtivTO> Select(DbConnection connection, RamAtivTO model)
	{
		List<RamAtivTO> list = RamAtivDAL.Select(connection, model);
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
