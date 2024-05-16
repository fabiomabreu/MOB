using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class IntFabrEnvioBLL
{
	public static IntFabrEnvioTO[] Select(DbConnection connection, string CdSistema, string TpCfg, string Codigo, string CdFabric)
	{
		IntFabrEnvioTO[] array = IntFabrEnvioDAL.Select(connection, CdSistema, TpCfg, Codigo, CdFabric);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static IntFabrEnvioTO[] SelectNewCustomer(DbConnection connection)
	{
		IntFabrEnvioTO[] array = IntFabrEnvioDAL.SelectNewCustomer(connection);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, IntFabrEnvioTO IntFabrEnvio)
	{
		IntFabrEnvioDAL.Insert(connection, IntFabrEnvio);
	}
}
