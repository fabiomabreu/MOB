using System.Collections.Generic;
using System.Data.SQLite;

namespace Target.Mob.Desktop.Geracao.Common;

public static class SQLiteUtil
{
	public static void ExcluiTabelasVazias(SQLiteConnection conn)
	{
		foreach (string item in ListaTabelas(conn))
		{
			if (ContaLinhas(conn, item) == 0)
			{
				ExcluiTabela(conn, item);
			}
		}
		Vacuum(conn);
	}

	private static void Vacuum(SQLiteConnection conn)
	{
		using SQLiteCommand sQLiteCommand = new SQLiteCommand("VACUUM", conn);
		sQLiteCommand.ExecuteNonQuery();
	}

	private static List<string> ListaTabelas(SQLiteConnection conn)
	{
		List<string> list = new List<string>();
		using SQLiteCommand sQLiteCommand = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table'", conn);
		using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
		while (sQLiteDataReader.Read())
		{
			list.Add(sQLiteDataReader["name"].ToString());
		}
		return list;
	}

	private static int ContaLinhas(SQLiteConnection conn, string nomeTabela)
	{
		int num = 0;
		using SQLiteCommand sQLiteCommand = new SQLiteCommand($"SELECT COUNT(*) FROM {nomeTabela}", conn);
		return int.Parse(sQLiteCommand.ExecuteScalar().ToString());
	}

	private static void ExcluiTabela(SQLiteConnection conn, string nomeTabela)
	{
		using SQLiteCommand sQLiteCommand = new SQLiteCommand($"DROP TABLE {nomeTabela}", conn);
		sQLiteCommand.ExecuteNonQuery();
	}
}
