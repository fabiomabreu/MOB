using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Util.Dal;
using Target.Mob.Desktop.Util.Model;

namespace Target.Mob.Desktop.Util.Bll;

public class UnidadeBLL
{
	public static List<UnidadeTO> Select(SqlConnection conexao, string database, string contextoApp)
	{
		return UnidadeDAL.Select(conexao, database, contextoApp);
	}

	public static List<UnidadeTO> Select(SqlConnection conexaoTargetMob, string servidorLinkedServerERP)
	{
		List<UnidadeTO> list = new List<UnidadeTO>();
		list.AddRange(UnidadeDAL.Select(conexaoTargetMob, (!string.IsNullOrEmpty(servidorLinkedServerERP)) ? "Target Mob" : string.Empty));
		if (!string.IsNullOrEmpty(servidorLinkedServerERP))
		{
			list.AddRange(UnidadeDAL.Select(conexaoTargetMob, servidorLinkedServerERP, "Target ERP"));
		}
		return list;
	}
}
