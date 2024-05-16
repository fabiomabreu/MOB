using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class VendedorRelatoBLL
{
	public static VendedorRelatorioTO[] Select(DbConnection connection, VendedorRelatorioTO value)
	{
		VendedorRelatorioTO[] array = VendedorRelatorioDAL.Select(connection, value);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static VendedorRelatorioTO[] SelectTipoGrupo(DbConnection connection, VendedorRelatorioTO value)
	{
		VendedorRelatorioTO[] array = VendedorRelatorioDAL.SelectTipoGrupo(connection, value);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Update(DbConnection connection, VendedorRelatorioTO vendedorRelatorioTo)
	{
		VendedorRelatorioDAL.Update(connection, vendedorRelatorioTo);
	}

	public static bool Exists(DbConnection connection, VendedorRelatorioTO vendedorRelatorioTo)
	{
		return VendedorRelatorioDAL.Exists(connection, vendedorRelatorioTo);
	}
}
