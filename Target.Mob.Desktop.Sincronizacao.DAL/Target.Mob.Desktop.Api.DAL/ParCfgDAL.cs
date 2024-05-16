using System.Data;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class ParCfgDAL
{
	private const string SELECT_BY_CD_EMP = "uspParCfgSelByCdEmp";

	public static ParCfgTO SelectByCdEmp(DbConnection connection, int CdEmp)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdEmp", CdEmp);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspParCfgSelByCdEmp"));
	}

	private static ParCfgTO CreateInstances(BasicRS rs)
	{
		ParCfgTO result = null;
		using (rs)
		{
			if (rs.MoveNext())
			{
				result = new ParCfgTO
				{
					CdEmp = rs.GetInteger("CdEmp"),
					SiglaClien = rs.GetString("SiglaClien"),
					ParCfgID = rs.GetInteger("ParCfgID")
				};
			}
		}
		return result;
	}
}
