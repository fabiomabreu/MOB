using System.Collections.Generic;
using System.Data.SqlClient;
using Target.Mob.Desktop.Util.Dal;
using Target.Mob.Desktop.Util.Model;

namespace Target.Mob.Desktop.Util.Bll;

public class InfoDBBLL
{
	public static List<InfoDBTO> Select(SqlConnection conexao, string database, string contextoApp)
	{
		return InfoDBDAL.Select(conexao, database, contextoApp);
	}

	public static List<InfoDBTO> Select(SqlConnection conexao, string database, string servidorLinkedServer, string contextoApp)
	{
		return InfoDBDAL.Select(conexao, database, servidorLinkedServer, contextoApp);
	}
}
