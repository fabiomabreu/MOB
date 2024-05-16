using System;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.DAL.Util;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class CoordenadaClienteBLL
{
	public static bool ExistsProcedure(DbConnection connection, string nomeProcedure)
	{
		return DbUtils.ExistsProcedure(connection, nomeProcedure);
	}

	public static void InsereCoordenadaCliente(DbConnection connTargetERP, int? CodigoCliente, decimal? latitude, decimal? longitude, string CodigoVendedor, DateTime? dtCoordenada)
	{
		CoordenadaClienteDAL.InsereCoordenadaCliente(connTargetERP, CodigoCliente, latitude, longitude, CodigoVendedor, dtCoordenada);
	}
}
