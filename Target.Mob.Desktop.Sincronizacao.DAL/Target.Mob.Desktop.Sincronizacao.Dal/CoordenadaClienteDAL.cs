using System;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class CoordenadaClienteDAL
{
	private const string INSERT_APROVA_COORDENADA = "uspGeraAprovacaoCoordenada";

	public static void InsereCoordenadaCliente(DbConnection connTargetErp, int? CodigoCliente, decimal? latitude, decimal? longitude, string codigoVendedor, DateTime? dtCoordenada)
	{
		connTargetErp.ClearParameters();
		connTargetErp.AddParameters("@CdClien", CodigoCliente);
		connTargetErp.AddParameters("@pLatitude", latitude);
		connTargetErp.AddParameters("@pLongitude", longitude);
		connTargetErp.AddParameters("@CdUsuarioColeta", codigoVendedor);
		connTargetErp.AddParameters("@DataColeta", dtCoordenada);
		connTargetErp.ExecuteScalar(CommandType.StoredProcedure, "uspGeraAprovacaoCoordenada");
	}
}
