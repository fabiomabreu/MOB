using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Util.Model;

namespace Target.Mob.Desktop.Util.Dal;

public class InfoDBDAL
{
	public static List<InfoDBTO> Select(SqlConnection conexao, string dataBase, string contextoApp)
	{
		using SqlDataReader dr = SelectDR(conexao, dataBase, null);
		return CreateInstance(dr, contextoApp, dataBase);
	}

	public static List<InfoDBTO> Select(SqlConnection conexao, string dataBase, string servidorLinkedServer, string contextoApp)
	{
		using SqlDataReader dr = SelectDR(conexao, dataBase, servidorLinkedServer);
		return CreateInstance(dr, contextoApp, dataBase);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, string dataBase, string servidorLinkedServer)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspInfoDBSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@DB", dataBase);
		sqlCommand.Parameters.AddWithValue("@ServidorOrigem", servidorLinkedServer);
		return sqlCommand.ExecuteReader();
	}

	private static List<InfoDBTO> CreateInstance(SqlDataReader dr, string contextoApp, string dataBase)
	{
		List<InfoDBTO> list = new List<InfoDBTO>();
		while (dr.Read())
		{
			InfoDBTO infoDBTO = new InfoDBTO();
			infoDBTO.DataBase = dataBase;
			infoDBTO.FileName = GetDataReader.GetString(dr, "Filename");
			infoDBTO.CurrentlyAllocatedSpace = GetDataReader.GetNullableDecimal(dr, "Currently Allocated Space (MB)");
			infoDBTO.SpaceUsed = GetDataReader.GetNullableDecimal(dr, "Space Used (MB)");
			infoDBTO.AvailableSpace = GetDataReader.GetNullableDecimal(dr, "Available Space (MB)");
			infoDBTO.ContextoAppServer = contextoApp;
			list.Add(infoDBTO);
		}
		return list;
	}
}
