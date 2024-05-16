using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class CliEmpBLL
{
	public static CliEmpTO[] Select(DbConnection connection, int? CdClien)
	{
		CliEmpTO[] array = CliEmpDAL.Select(connection, CdClien);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static CliEmpTO[] SelectNewCustomer(DbConnection connection)
	{
		CliEmpTO[] array = CliEmpDAL.SelectNewCustomer(connection);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, CliEmpTO CliEmp)
	{
		CliEmpDAL.Insert(connection, CliEmp);
	}
}
