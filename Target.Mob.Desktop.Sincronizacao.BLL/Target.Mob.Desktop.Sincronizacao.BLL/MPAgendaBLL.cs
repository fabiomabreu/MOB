using System.Collections.Generic;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class MPAgendaBLL
{
	public static List<MPAgendaTO> SelectExport(DbConnection connection, byte[] RowId)
	{
		List<MPAgendaTO> list = MPAgendaDAL.SelectExport(connection, RowId);
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		return list;
	}
}
