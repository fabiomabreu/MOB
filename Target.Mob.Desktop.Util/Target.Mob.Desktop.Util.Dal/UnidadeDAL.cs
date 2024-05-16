using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Util.Model;

namespace Target.Mob.Desktop.Util.Dal;

public class UnidadeDAL
{
	public static List<UnidadeTO> Select(SqlConnection conexao, string contextoApp)
	{
		using SqlDataReader dr = SelectDR(conexao, null);
		return CreateInstance(dr, contextoApp);
	}

	public static List<UnidadeTO> Select(SqlConnection conexao, string servidorLinkedServer, string contextoApp)
	{
		using SqlDataReader dr = SelectDR(conexao, servidorLinkedServer);
		return CreateInstance(dr, contextoApp);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, string servidorLinkedServer)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspXpFixedDrives", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@ServidorOrigem", servidorLinkedServer);
		return sqlCommand.ExecuteReader();
	}

	private static List<UnidadeTO> CreateInstance(SqlDataReader dr, string contextoApp)
	{
		List<UnidadeTO> list = new List<UnidadeTO>();
		while (dr.Read())
		{
			UnidadeTO unidadeTO = new UnidadeTO();
			unidadeTO.Nome = GetDataReader.GetString(dr, 0);
			unidadeTO.EspacoLivre = GetDataReader.GetInt32(dr, 1);
			unidadeTO.ContextoAppServer = contextoApp;
			list.Add(unidadeTO);
		}
		return list;
	}
}
