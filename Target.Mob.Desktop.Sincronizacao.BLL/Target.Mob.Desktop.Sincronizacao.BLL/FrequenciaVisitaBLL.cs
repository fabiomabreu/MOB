using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class FrequenciaVisitaBLL
{
	public static FrequenciaVisitaTO[] Select(DbConnection connection, FrequenciaVisitaTO instance)
	{
		return FrequenciaVisitaDAL.Select(connection, instance);
	}
}
