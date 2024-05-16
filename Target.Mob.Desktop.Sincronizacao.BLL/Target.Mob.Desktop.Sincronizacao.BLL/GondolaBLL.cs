using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class GondolaBLL
{
	public static void InsertOrReplace(DbConnection connection, GondolaTO gondola)
	{
		GondolaDAL.InsertOrReplace(connection, gondola);
	}
}
