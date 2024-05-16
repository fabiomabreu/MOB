using System.Data;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class LogApiDAL
{
	private const string INSERT = "tgtmob_uspLogApi_INSERT";

	public static int Insert(string stringConnTargetErp, LogApiTO log)
	{
		using DbConnection dbConnection = new DbConnection(stringConnTargetErp);
		dbConnection.Open();
		dbConnection.ClearParameters();
		dbConnection.AddParameters("@Acao", log.Acao);
		dbConnection.AddParameters("@Data", log.Data);
		dbConnection.AddParameters("@Rota", log.Rota);
		dbConnection.AddParameters("@Ip", log.Ip);
		dbConnection.AddParameters("@Usuario", log.Usuario);
		dbConnection.AddParameters("@RequestHeader", log.RequestHeader);
		dbConnection.AddParameters("@RequestBody", log.RequestBody);
		dbConnection.AddParameters("@Response", log.Response);
		dbConnection.AddParameters("@StatusCode", log.StatusCode);
		int result = int.Parse(dbConnection.ExecuteScalar(CommandType.StoredProcedure, "tgtmob_uspLogApi_INSERT").ToString());
		dbConnection.Close();
		return result;
	}
}
