using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class PedidoDAL
{
	private const string LIBERAR_PEDIDO = "tgtsup_uspLiberarPedido";

	public static int LiberarPedidoSupervisor(string stringConnTargetErp, string codigoSupervisor, int cdEmp, int nuPed)
	{
		using DbConnection dbConnection = new DbConnection(stringConnTargetErp);
		dbConnection.Open();
		SqlCommand sqlCommand = new SqlCommand("tgtsup_uspLiberarPedido", dbConnection.GetConnection());
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@CodigoEmpresa", cdEmp);
		sqlCommand.Parameters.AddWithValue("@NumeroPedido", nuPed);
		sqlCommand.Parameters.AddWithValue("@CodigoSupervisor", codigoSupervisor);
		sqlCommand.Parameters.Add("@Retorno", SqlDbType.Int, 20).Direction = ParameterDirection.Output;
		sqlCommand.ExecuteNonQuery();
		return (int)sqlCommand.Parameters["@Retorno"].Value;
	}
}
