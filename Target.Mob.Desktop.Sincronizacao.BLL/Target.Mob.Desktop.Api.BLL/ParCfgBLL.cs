using Target.Mob.Desktop.Api.DAL;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.BLL;

public class ParCfgBLL
{
	public ParCfgTO SelectByCdEmp(DbConnection connection, int CdEmp)
	{
		return ParCfgDAL.SelectByCdEmp(connection, CdEmp);
	}
}
