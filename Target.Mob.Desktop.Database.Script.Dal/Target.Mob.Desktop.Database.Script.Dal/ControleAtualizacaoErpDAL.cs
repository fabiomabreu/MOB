using System;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Database.Script.Model;

namespace Target.Mob.Desktop.Database.Script.Dal;

public class ControleAtualizacaoErpDAL
{
	private const string INSERT = "uspTGTMOBControleAtualizacaoInsert";

	private const string SELMAX = "uspTGTMOBControleAtualizacaoSelectMax";

	public static void Insert(SqlConnection connection, SqlTransaction transaction, ControleAtualizacaoTO instance)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspTGTMOBControleAtualizacaoInsert", connection, transaction);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Arquivo", instance.Arquivo);
		sqlCommand.Parameters.AddWithValue("@Diretorio", instance.Diretorio);
		sqlCommand.ExecuteNonQuery();
	}

	public static string SelectMax(SqlConnection connection, string versionPrefix)
	{
		object obj = null;
		if (TableExists(connection))
		{
			using SqlCommand sqlCommand = new SqlCommand("uspTGTMOBControleAtualizacaoSelectMax", connection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@Prefixo", versionPrefix);
			obj = sqlCommand.ExecuteScalar();
		}
		if (obj != DBNull.Value)
		{
			return (string)obj;
		}
		return null;
	}

	public static bool TableExists(SqlConnection connection)
	{
		using SqlCommand sqlCommand = new SqlCommand("SELECT 1 FROM sysobjects WHERE id = OBJECT_ID('TGTMOBControleAtualizacao')", connection);
		sqlCommand.CommandType = CommandType.Text;
		sqlCommand.Parameters.Clear();
		return ((int?)sqlCommand.ExecuteScalar()).HasValue;
	}
}
