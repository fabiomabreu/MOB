using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Api.DAL;

public class VendedorSincronizacaoLogDAL
{
	private const string UPDATE = "tgtmob_uspVendedorSincronizacaoLog_UPDATE";

	internal static void Update(string conn, string codigoVendedor, long ultimoIdCargaEntidade)
	{
		using SqlConnection sqlConnection = new SqlConnection(conn);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspVendedorSincronizacaoLog_UPDATE", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@codigoVendedor", codigoVendedor);
			sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", ultimoIdCargaEntidade);
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}
}
