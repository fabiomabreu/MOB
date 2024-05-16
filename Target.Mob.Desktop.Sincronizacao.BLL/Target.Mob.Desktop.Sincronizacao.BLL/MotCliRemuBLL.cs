using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

internal class MotCliRemuBLL
{
	public static MotCliRemuTO[] Select(DbConnection connection, string CdMotor, int? CdClien, decimal? PercRemu)
	{
		MotCliRemuTO[] array = MotCliRemuDAL.Select(connection, CdMotor, CdClien, PercRemu);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static MotCliRemuTO[] SelectNewCustomer(DbConnection connection)
	{
		MotCliRemuTO[] array = MotCliRemuDAL.SelectNewCustomer(connection);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, MotCliRemuTO MotCliRemu)
	{
		MotCliRemuDAL.Insert(connection, MotCliRemu);
	}
}
