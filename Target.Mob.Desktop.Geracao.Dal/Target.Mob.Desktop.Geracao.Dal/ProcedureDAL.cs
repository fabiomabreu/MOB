using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Geracao.Dal;

public class ProcedureDAL
{
	private string _connStringTargetERP;

	public ProcedureDAL(string connStringTargetERP)
	{
		_connStringTargetERP = connStringTargetERP;
	}

	public void Exec(string sqlCmd)
	{
		using SqlConnection sqlConnection = new SqlConnection(_connStringTargetERP);
		using SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection);
		sqlConnection.Open();
		sqlCommand.CommandType = CommandType.Text;
		sqlCommand.Parameters.Clear();
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}
}
