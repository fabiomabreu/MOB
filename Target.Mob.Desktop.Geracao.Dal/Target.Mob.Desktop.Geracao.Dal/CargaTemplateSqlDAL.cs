using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Target.Mob.Desktop.Geracao.Common;
using Target.Mob.Desktop.Geracao.Model;

namespace Target.Mob.Desktop.Geracao.Dal;

public class CargaTemplateSqlDAL
{
	private const string SELECT = "tgtmob_uspCargaTemplateSql_Select";

	public static List<CargaTemplateSqlTO> Select(string connStringTargetERP)
	{
		using SqlConnection sqlConnection = new SqlConnection(connStringTargetERP);
		List<CargaTemplateSqlTO> result = new List<CargaTemplateSqlTO>();
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand("tgtmob_uspCargaTemplateSql_Select", sqlConnection))
		{
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Clear();
			result = CreateInstance(sqlCommand.ExecuteReader());
		}
		sqlConnection.Close();
		return result;
	}

	private static List<CargaTemplateSqlTO> CreateInstance(SqlDataReader dr)
	{
		List<CargaTemplateSqlTO> list = new List<CargaTemplateSqlTO>();
		while (dr.Read())
		{
			CargaTemplateSqlTO cargaTemplateSqlTO = new CargaTemplateSqlTO();
			cargaTemplateSqlTO.idCargaTemplateSql = GetDataReader.GetInt32(dr, "idCargaTemplateSql");
			cargaTemplateSqlTO.nomeTemplateSql = GetDataReader.GetString(dr, "nomeTemplateSql");
			cargaTemplateSqlTO.scriptTemplateSql = GetDataReader.GetString(dr, "scriptTemplateSql");
			cargaTemplateSqlTO.data = GetDataReader.GetDateTime(dr, "data");
			cargaTemplateSqlTO.rowid = GetDataReader.GetByteArray(dr, "rowid");
			list.Add(cargaTemplateSqlTO);
		}
		return list;
	}
}
