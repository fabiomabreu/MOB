using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class ComoRealizouVendaBLL
{
	public static List<ComoRealizouVendaTO> Select(DbConnection connection, ComoRealizouVendaTO comoRealizouVenda)
	{
		List<ComoRealizouVendaTO> list = ComoRealizouVendaDAL.Select(connection, comoRealizouVenda);
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
