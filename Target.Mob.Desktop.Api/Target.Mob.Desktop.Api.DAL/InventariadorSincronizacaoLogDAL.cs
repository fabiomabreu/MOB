using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Api.DAL;

public class InventariadorSincronizacaoLogDAL
{
	private const string UPDATE = "tgtmob_uspInventariadorSincronizacaoLog_UPDATE";

	internal static void Update(string conn, string codigoUsuario, long ultimoIdCargaEntidade)
	{
		using SqlConnection sqlConnection = new SqlConnection(conn);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspInventariadorSincronizacaoLog_UPDATE", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);
			sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", ultimoIdCargaEntidade);
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}
}
