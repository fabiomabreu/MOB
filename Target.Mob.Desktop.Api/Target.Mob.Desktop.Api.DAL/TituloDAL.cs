using System;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Api.DAL;

public class TituloDAL
{
	private const string BOLETO = "tgtmob_uspBoletoLinhaDigitavelSelect";

	public static string GetBoletoTitulo(string stringConnTargetErp, int numeroTitulo, char serieTitulo)
	{
		string result = "";
		using DbConnection dbConnection = new DbConnection(stringConnTargetErp);
		dbConnection.Open();
		dbConnection.ClearParameters();
		dbConnection.AddParameters("@NumeroTitulo", numeroTitulo);
		dbConnection.AddParameters("@SerieTitulo", serieTitulo);
		object obj = dbConnection.ExecuteScalar(CommandType.StoredProcedure, "tgtmob_uspBoletoLinhaDigitavelSelect");
		if (obj != null)
		{
			result = Convert.ToString(obj.ToString());
		}
		dbConnection.Close();
		return result;
	}
}
