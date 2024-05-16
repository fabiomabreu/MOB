using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Api.DAL;

public class PromotorSincronizacaoLogDAL
{
	private const string UPDATE = "tgtmob_uspPromotorSincronizacaoLog_UPDATE";

	internal static void Update(string conn, string codigoPromotor, long ultimoIdCargaEntidade)
	{
		using SqlConnection sqlConnection = new SqlConnection(conn);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspPromotorSincronizacaoLog_UPDATE", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@codigoPromotor", codigoPromotor);
			sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", ultimoIdCargaEntidade);
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}
}
