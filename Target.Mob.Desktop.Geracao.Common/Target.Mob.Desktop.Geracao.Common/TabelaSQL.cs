using System;
using System.Data;
using System.Data.SqlClient;

namespace Target.Mob.Desktop.Geracao.Common;

public class TabelaSQL
{
	public static void CopiaTabela(SqlConnection conexaoSQL, string tabelaOrigem, string tabelaDestino, bool sobreescreve)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCopiaTabela", conexaoSQL);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.CommandTimeout = 3600;
		sqlCommand.Parameters.AddWithValue("@TabelaOrigem", tabelaOrigem);
		sqlCommand.Parameters.AddWithValue("@TabelaDestino", tabelaDestino);
		sqlCommand.Parameters.AddWithValue("@Sobrescreve", sobreescreve);
		sqlCommand.ExecuteNonQuery();
		if (!Existe(conexaoSQL, tabelaDestino))
		{
			throw new Exception($"A tabela {tabelaDestino} não foi criada corretamente.");
		}
	}

	public static void LimpaTabela(SqlConnection conexaoSQL, string tabela)
	{
		using SqlCommand sqlCommand = new SqlCommand("Truncate Table " + tabela, conexaoSQL);
		sqlCommand.CommandTimeout = 3600;
		sqlCommand.ExecuteNonQuery();
	}

	public static void CriaTabelaRowVersion(SqlConnection conexaoSQL, string tabelaOrigem, string tabelaDestino, bool sobreescreve)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspCriaTabelaControle", conexaoSQL);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.CommandTimeout = 3600;
		sqlCommand.Parameters.AddWithValue("@TabelaOrigem", tabelaOrigem);
		sqlCommand.Parameters.AddWithValue("@TabelaDestino", tabelaDestino);
		sqlCommand.Parameters.AddWithValue("@Sobrescreve", sobreescreve);
		sqlCommand.ExecuteNonQuery();
		if (!Existe(conexaoSQL, tabelaDestino))
		{
			throw new Exception($"A tabela {tabelaDestino} não foi criada corretamente.");
		}
	}

	public static bool Existe(SqlConnection conexaoSQL, string tabela)
	{
		using SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM SYSOBJECTS WHERE ID = OBJECT_ID(@Tabela) AND xtype = 'U'", conexaoSQL);
		sqlCommand.CommandType = CommandType.Text;
		sqlCommand.Parameters.Clear();
		sqlCommand.CommandTimeout = 3600;
		sqlCommand.Parameters.AddWithValue("@Tabela", tabela);
		return (int)sqlCommand.ExecuteScalar() != 0;
	}
}
