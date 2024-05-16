using System;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class UsuarioDAL
{
	private const string ISVALID = "tgtmob_uspUsuario_IsValid";

	internal static bool IsValid(string stringConnTargetErp, string cnpj, string userName, string role, string tipo)
	{
		bool flag = false;
		using DbConnection dbConnection = new DbConnection(stringConnTargetErp);
		dbConnection.Open();
		dbConnection.ClearParameters();
		dbConnection.AddParameters("@Cnpj", cnpj);
		dbConnection.AddParameters("@UserName", userName);
		dbConnection.AddParameters("@Role", role);
		dbConnection.AddParameters("@Tipo", tipo);
		flag = Convert.ToBoolean(int.Parse(dbConnection.ExecuteScalar(CommandType.StoredProcedure, "tgtmob_uspUsuario_IsValid").ToString()));
		dbConnection.Close();
		return flag;
	}
}
