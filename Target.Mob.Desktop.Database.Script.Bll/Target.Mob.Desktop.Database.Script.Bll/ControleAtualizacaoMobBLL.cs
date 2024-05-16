using System.Data.SqlClient;
using Target.Mob.Desktop.Database.Script.Dal;
using Target.Mob.Desktop.Database.Script.Model;

namespace Target.Mob.Desktop.Database.Script.Bll;

public class ControleAtualizacaoMobBLL
{
	public static void Insert(SqlConnection connection, SqlTransaction transaction, ControleAtualizacaoTO instance)
	{
		ControleAtualizacaoMobDAL.Insert(connection, transaction, instance);
	}

	public static string SelectMax(SqlConnection connection, string versionPrefix)
	{
		return ControleAtualizacaoMobDAL.SelectMax(connection, versionPrefix);
	}

	public static int SelectCount(SqlConnection connection)
	{
		return ControleAtualizacaoMobDAL.SelectCount(connection);
	}
}
