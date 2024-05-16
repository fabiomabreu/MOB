using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Api.DAL;

public class CampanhaDAL
{
	private const string EXISTS = "tgtmob_uspClienteCampanhaExists";

	public static bool Exists(string stringConnTargetErp, string codigoVendedor, int codigoCliente, int codigoEmpresa, string tpPed)
	{
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand("tgtmob_uspClienteCampanhaExists", sqlConnection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.CommandTimeout = 300;
		sqlCommand.Parameters.AddWithValue("@CdVend", codigoVendedor);
		sqlCommand.Parameters.AddWithValue("@CdClien", codigoCliente);
		sqlCommand.Parameters.AddWithValue("@CdEmp", codigoEmpresa);
		sqlCommand.Parameters.AddWithValue("@TpPed", tpPed);
		return (int)sqlCommand.ExecuteScalar() == 1;
	}
}
