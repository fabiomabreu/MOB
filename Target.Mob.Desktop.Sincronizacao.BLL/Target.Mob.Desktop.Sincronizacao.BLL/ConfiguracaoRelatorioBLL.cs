using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class ConfiguracaoRelatorioBLL
{
	public static ConfiguracaoRelatorioTO[] Select(DbConnection connection, ConfiguracaoRelatorioTO ConfiguracaoRelatorio)
	{
		ConfiguracaoRelatorioTO[] array = ConfiguracaoRelatorioDAL.Select(connection, ConfiguracaoRelatorio);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, ConfiguracaoRelatorioTO ConfiguracaoRelatorio)
	{
		ConfiguracaoRelatorioDAL.Insert(connection, ConfiguracaoRelatorio);
	}

	internal static void Update(DbConnection connection, ConfiguracaoRelatorioTO ConfiguracaoRelatorio)
	{
		ConfiguracaoRelatorioDAL.Update(connection, ConfiguracaoRelatorio);
	}
}
