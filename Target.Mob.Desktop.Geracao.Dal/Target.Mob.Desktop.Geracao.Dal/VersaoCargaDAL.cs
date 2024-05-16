using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class VersaoCargaDAL
{
	public static VersaoCargaTO Select(SqlConnection conexao, int id)
	{
		VersaoCargaTO versaoCargaTO = new VersaoCargaTO();
		versaoCargaTO.Id = id;
		List<VersaoCargaTO> list = Select(conexao, versaoCargaTO);
		if (list.Count <= 0)
		{
			return null;
		}
		return list[0];
	}

	public static List<VersaoCargaTO> Select(SqlConnection conexao, VersaoCargaTO versaoCarga)
	{
		using SqlDataReader dr = SelectDR(conexao, versaoCarga);
		return CreateInstance(dr);
	}

	public static SqlDataReader SelectDR(SqlConnection conexao, VersaoCargaTO versaoCarga)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVersaoCargaSelect", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Id", versaoCarga.Id);
		sqlCommand.Parameters.AddWithValue("@Major", versaoCarga.Major);
		sqlCommand.Parameters.AddWithValue("@Minor", versaoCarga.Minor);
		sqlCommand.Parameters.AddWithValue("@Build", versaoCarga.Build);
		sqlCommand.Parameters.AddWithValue("@Revision", versaoCarga.Revision);
		return sqlCommand.ExecuteReader();
	}

	public static VersaoCargaTO SelectMax(SqlConnection conexao, int? Major, int? Minor)
	{
		using SqlCommand sqlCommand = new SqlCommand("uspVersaCargaSelectMax", conexao);
		sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.Parameters.Clear();
		sqlCommand.Parameters.AddWithValue("@Major", Major);
		sqlCommand.Parameters.AddWithValue("@Minor", Minor);
		using SqlDataReader dr = sqlCommand.ExecuteReader();
		List<VersaoCargaTO> list = CreateInstance(dr);
		return (list.Count > 0) ? list[0] : null;
	}

	private static List<VersaoCargaTO> CreateInstance(SqlDataReader dr)
	{
		List<VersaoCargaTO> list = new List<VersaoCargaTO>();
		while (dr.Read())
		{
			VersaoCargaTO versaoCargaTO = new VersaoCargaTO();
			versaoCargaTO.Id = GetDataReader.GetNullableInt32(dr, "Id");
			versaoCargaTO.Major = GetDataReader.GetNullableInt32(dr, "Major");
			versaoCargaTO.Minor = GetDataReader.GetNullableInt32(dr, "Minor");
			versaoCargaTO.Build = GetDataReader.GetNullableInt32(dr, "Build");
			versaoCargaTO.Revision = GetDataReader.GetNullableInt32(dr, "Revision");
			list.Add(versaoCargaTO);
		}
		return list;
	}
}
