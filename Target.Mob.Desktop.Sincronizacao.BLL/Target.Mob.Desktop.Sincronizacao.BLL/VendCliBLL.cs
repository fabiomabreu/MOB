using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class VendCliBLL
{
	public static VendCliTO[] Select(DbConnection connection, int? CdClien, string CdVend, bool? Prioritario, float? VlLimiteVerba)
	{
		VendCliTO[] array = VendCliDAL.Select(connection, CdClien, CdVend, Prioritario, VlLimiteVerba);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, VendCliTO VendCli)
	{
		VendCliDAL.Insert(connection, VendCli);
	}
}
