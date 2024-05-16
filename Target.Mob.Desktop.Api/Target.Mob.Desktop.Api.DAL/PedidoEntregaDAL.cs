using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Geracao.Common;

namespace Target.Mob.Desktop.Api.DAL;

public class PedidoEntregaDAL
{
	private const string PEDIDO_ENTREGA_SELECT = "tgtmob_uspPedidoEntregaSelect";

	public static List<PedidoEntregaTO> GetPedidoEntrega(string stringConnTargetErp, string codigoPromotor, int? codigo)
	{
		List<PedidoEntregaTO> list = new List<PedidoEntregaTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspPedidoEntregaSelect", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.CommandTimeout = 300;
			sqlCommand.Parameters.AddWithValue("@CodigoPromotor", codigoPromotor);
			sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				list.Add(CreateInstance(sqlDataReader));
			}
		}
		sqlConnection.Close();
		return list;
	}

	private static PedidoEntregaTO CreateInstance(SqlDataReader dr)
	{
		return new PedidoEntregaTO
		{
			Codigo = GetDataReader.GetInt32(dr, "Codigo"),
			CodigoEmpresa = GetDataReader.GetInt32(dr, "CodigoEmpresa"),
			NumeroPedVda = GetDataReader.GetInt32(dr, "NumeroPedVda"),
			CodigoCliente = GetDataReader.GetInt32(dr, "CodigoCliente"),
			DtEntrega = GetDataReader.GetDateTime(dr, "DtEntrega")
		};
	}
}
