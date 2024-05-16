using System.Data.SqlClient;
using Target.Mob.Desktop.Database.Script.Dal;
using Target.Mob.Desktop.Database.Script.Model;

namespace Target.Mob.Desktop.Database.Script.Bll;

public class ControleAtualizacaoErpBLL
{
	public static void Insert(SqlConnection connection, SqlTransaction sqlTransaction, ControleAtualizacaoTO instance)
	{
		ControleAtualizacaoErpDAL.Insert(connection, sqlTransaction, instance);
	}

	public static string SelectMax(SqlConnection connection, string versionPrefix)
	{
		return ControleAtualizacaoErpDAL.SelectMax(connection, versionPrefix);
	}
}
