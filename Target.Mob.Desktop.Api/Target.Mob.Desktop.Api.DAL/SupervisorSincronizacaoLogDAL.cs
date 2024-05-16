using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Api.DAL;

public class SupervisorSincronizacaoLogDAL
{
	private const string UPDATE = "tgtmob_uspSupervisorSincronizacaoLog_UPDATE";

	internal static void Update(string conn, string codigoSupervisor, long ultimoIdCargaEntidade)
	{
		using SqlConnection sqlConnection = new SqlConnection(conn);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspSupervisorSincronizacaoLog_UPDATE", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@codigoSupervisor", codigoSupervisor);
			sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", ultimoIdCargaEntidade);
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}
}
