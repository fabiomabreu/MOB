using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Api.Model;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class VerbaDAL
{
	private const string TRANSFERIR_VERBA = "tgtsup_uspTransferirVerba";

	private const string SALDO_VERBA = "tgtsup_uspSaldoVerba";

	public static int TransferirVerba(string stringConnTargetErp, string cdSupervisor, decimal valorVerbaSupervisor, string cdVendedor, decimal valorVerbaVendedor, string tipoOperacao, decimal valorTransferencia)
	{
		using DbConnection dbConnection = new DbConnection(stringConnTargetErp);
		dbConnection.Open();
		dbConnection.ClearParameters();
		dbConnection.AddParameters("@CodigoSupervisor", cdSupervisor);
		dbConnection.AddParameters("@ValorVerbaSupervisor", valorVerbaSupervisor);
		dbConnection.AddParameters("@CodigoVendedor", cdVendedor);
		dbConnection.AddParameters("@ValorVerbaVendedor", valorVerbaVendedor);
		dbConnection.AddParameters("@TipoOperacao", tipoOperacao);
		dbConnection.AddParameters("@ValorTransferencia", valorTransferencia);
		return int.Parse(dbConnection.ExecuteScalar(CommandType.StoredProcedure, "tgtsup_uspTransferirVerba").ToString());
	}

	public static IEnumerable<VerbaSaldoTO> GetSaldo(string stringConnTargetErp, string cdSupervisor)
	{
		List<VerbaSaldoTO> list = new List<VerbaSaldoTO>();
		using SqlConnection sqlConnection = new SqlConnection(stringConnTargetErp);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand("tgtsup_uspSaldoVerba", sqlConnection);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.CommandTimeout = 300;
		sqlCommand.Parameters.AddWithValue("@CodigoSupervisor", cdSupervisor);
		using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
		{
			while (sqlDataReader.Read())
			{
				list.Add(CreateInstance(sqlDataReader));
			}
		}
		sqlConnection.Close();
		return list;
	}

	private static VerbaSaldoTO CreateInstance(SqlDataReader dr)
	{
		return new VerbaSaldoTO
		{
			CodigoVendedor = GetDataReader.GetString(dr, "CodigoVendedor"),
			DtSaldoVerba = GetDataReader.GetDateTime(dr, "DtSaldoVerba"),
			SaldoVerba = GetDataReader.GetDecimal(dr, "SaldoVerba")
		};
	}
}
