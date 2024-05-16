using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Target.Mob.Desktop.Geracao.Dal;

public class CargaEntidadeDAL
{
	private const string SELECT_DADOS_VENDEDOR = "tgtmob_uspCargaDadosVendedor";

	public static string[] SelectDadosVendedor(string stringConnTargetErp, string codigoVendedor, string idCargaEntidade)
	{
		string text = "#+";
		int num = 5000;
		List<string> list = new List<string>();
		using (SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp))
		{
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaDadosVendedor", sqlConnection))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Clear();
				sqlCommand.CommandTimeout = 300;
				sqlCommand.Parameters.AddWithValue("@codigoVendedor", codigoVendedor);
				sqlCommand.Parameters.AddWithValue("@qtdeRegistrosTop", num);
				if (idCargaEntidade == null)
				{
					sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", DBNull.Value);
				}
				else
				{
					sqlCommand.Parameters.AddWithValue("@ultimoIdCargaEntidade", idCargaEntidade);
				}
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append($"{sqlDataReader[0]}" + text);
					stringBuilder.Append($"{sqlDataReader[1]}" + text);
					stringBuilder.Append($"{sqlDataReader[2]}" + text);
					stringBuilder.Append($"{sqlDataReader[4]}" + text);
					stringBuilder.Append($"{sqlDataReader[6]}" + text);
					stringBuilder.Append(string.Format("{0}", sqlDataReader[7].ToString().Equals("True") ? 1 : 0));
					list.Add(stringBuilder.ToString());
				}
			}
			sqlConnection.Close();
		}
		return list.ToArray();
	}
}
