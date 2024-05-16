using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class LogLibAutoTimeOutBLL
{
	public static void Insert(DbConnection connection, LogLibAutoTimeOutTO logLibAutoTimeOut)
	{
		LogLibAutoTimeOutDAL.Insert(connection, logLibAutoTimeOut);
	}

	public static void Update(DbConnection connection, LogLibAutoTimeOutTO logLibAutoTimeOut)
	{
		LogLibAutoTimeOutDAL.Update(connection, logLibAutoTimeOut);
	}

	public static LogLibAutoTimeOutTO Select(DbConnection connection, int? CdEmpEle, int? NuPedEle)
	{
		LogLibAutoTimeOutTO[] array = LogLibAutoTimeOutDAL.Select(connection, CdEmpEle, NuPedEle);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array[0];
	}
}
