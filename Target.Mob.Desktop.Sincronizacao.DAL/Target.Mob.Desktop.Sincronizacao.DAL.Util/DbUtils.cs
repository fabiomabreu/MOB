using System;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Sincronizacao.DAL.Util;

public static class DbUtils
{
	public const string GERASEQPORSEMPRESA = "uspGeraSeqPorEmpresa";

	public const string GERASEQ = "usp_gera_seq";

	public static bool ExistsProcedure(DbConnection connection, string nomeProcedure)
	{
		bool result = false;
		try
		{
			result = int.Parse(connection.ExecuteScalar(CommandType.Text, "   SELECT COUNT(*)    FROM sys.Procedures    WHERE NAME = '" + nomeProcedure + "' ").ToString()) == 1;
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static int GeraSeqPorEmpresa(DbConnection connection, string NomeTabela, int CdEmpEle)
	{
		try
		{
			using SqlCommand sqlCommand = new SqlCommand("uspGeraSeqPorEmpresa", connection.GetConnection());
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.AddWithValue("@pStrTabela", NomeTabela);
			sqlCommand.Parameters.AddWithValue("@pCdEmp", CdEmpEle);
			sqlCommand.Parameters.Add("@Numero", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
			sqlCommand.ExecuteNonQuery();
			object value = sqlCommand.Parameters["@Numero"].Value;
			if (value != null && int.Parse(value.ToString()) > 0)
			{
				return (int)value;
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Não foi possível gerar sequencial para tabela: " + NomeTabela + " e empresa: " + CdEmpEle + ". " + ex.Message);
		}
		return 0;
	}

	public static int GeraSeq(DbConnection connection, string NomeTabela)
	{
		string text = "";
		try
		{
			using SqlCommand sqlCommand = new SqlCommand("usp_gera_seq", connection.GetConnection(), connection.GetTransaction());
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.AddWithValue("@par_str_tabela", NomeTabela);
			sqlCommand.Parameters.Add("@rpar_nu_seq", SqlDbType.Int).Direction = ParameterDirection.Output;
			sqlCommand.Parameters.Add("@rpar_msg", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
			sqlCommand.ExecuteNonQuery();
			object value = sqlCommand.Parameters["@rpar_nu_seq"].Value;
			text = ((sqlCommand.Parameters["@rpar_msg"].Value != DBNull.Value) ? sqlCommand.Parameters["@rpar_msg"].Value.ToString() : "");
			if (value != null && int.Parse(value.ToString()) > 0)
			{
				return int.Parse(value.ToString());
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Não foi possível gerar sequencial para tabela: " + NomeTabela + ". Mensagem: " + text + ". " + ex.Message);
		}
		return 0;
	}
}
