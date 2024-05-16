using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class CliEmpFormPgtoDAL
{
	private const string EXISTS = "uspCliEmpFormPgtoExists";

	public static bool Exists(DbConnection connection, int? CdEmpEle, int? CdClien, string Formpgto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmpEle);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@formpgto", Formpgto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliEmpFormPgtoExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}
}
