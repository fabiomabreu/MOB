using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;

namespace Target.Mob.Desktop.Geracao.Common;

public class ExportaSQLite
{
	private SqlConnection _ConexaoSQL;

	private SQLiteTransaction _TransacaoSQLite;

	private string _TabelaOrigem;

	private string _TabelaDestino;

	public SqlConnection ConexaoSQL
	{
		get
		{
			return _ConexaoSQL;
		}
		set
		{
			_ConexaoSQL = value;
		}
	}

	public SQLiteTransaction TransacaoSQLite
	{
		get
		{
			return _TransacaoSQLite;
		}
		set
		{
			_TransacaoSQLite = value;
		}
	}

	public string TabelaOrigem
	{
		get
		{
			return _TabelaOrigem;
		}
		set
		{
			_TabelaOrigem = value;
		}
	}

	public string TabelaDestino
	{
		get
		{
			return _TabelaDestino;
		}
		set
		{
			_TabelaDestino = value;
		}
	}

	public ExportaSQLite(SqlConnection conexaoSQL, SQLiteTransaction transacaoSQLite, string tabelaOrigem, string tabelaDestino)
	{
		ConexaoSQL = conexaoSQL;
		TransacaoSQLite = transacaoSQLite;
		TabelaOrigem = tabelaOrigem;
		TabelaDestino = tabelaDestino;
	}

	public void Exporta()
	{
		List<string> colunas = GetColunas(TransacaoSQLite.Connection, TabelaDestino);
		if (colunas.Count <= 0)
		{
			return;
		}
		string comandoSelect = GetComandoSelect(colunas, TabelaOrigem);
		using SQLiteCommand sQLiteCommand = new SQLiteCommand(GetComandoInsert(colunas, TabelaDestino), TransacaoSQLite.Connection, TransacaoSQLite);
		for (int i = 0; i < colunas.Count; i++)
		{
			sQLiteCommand.Parameters.Add(new SQLiteParameter(colunas[i]));
		}
		using SqlCommand sqlCommand = new SqlCommand(comandoSelect, ConexaoSQL);
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		while (sqlDataReader.Read())
		{
			for (int j = 0; j < colunas.Count; j++)
			{
				if (sqlDataReader[j].GetType() == typeof(string))
				{
					sQLiteCommand.Parameters[j].Value = sqlDataReader[j].ToString().TrimEnd();
				}
				else
				{
					sQLiteCommand.Parameters[j].Value = sqlDataReader[j];
				}
			}
			sQLiteCommand.ExecuteNonQuery();
		}
	}

	private string GetComandoSelect(List<string> colunas, string tabelaOrigem)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string result = string.Empty;
		foreach (string coluna in colunas)
		{
			stringBuilder.Append(coluna + ",");
		}
		if (colunas.Count > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			result = $"SELECT {stringBuilder} FROM {tabelaOrigem}";
		}
		return result;
	}

	private string GetComandoInsert(List<string> colunas, string tabelaDestino)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		string result = string.Empty;
		foreach (string coluna in colunas)
		{
			stringBuilder.Append(coluna + ",");
			stringBuilder2.Append("@" + coluna + ",");
		}
		if (colunas.Count > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
			result = $"INSERT INTO {tabelaDestino}({stringBuilder}) VALUES({stringBuilder2})";
		}
		return result;
	}

	private List<string> GetColunas(SQLiteConnection connectionDestination, string tabelaDestino)
	{
		List<string> list = new List<string>();
		using SQLiteCommand sQLiteCommand = new SQLiteCommand($"PRAGMA table_info('{tabelaDestino}')", connectionDestination);
		using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
		while (sQLiteDataReader.Read())
		{
			list.Add(sQLiteDataReader["name"].ToString());
		}
		return list;
	}
}
