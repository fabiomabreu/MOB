using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Geracao.Dal;

public class TriggerDAL
{
	private string _connStringTargetERP;

	public TriggerDAL(string connStringTargetERP)
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
