using System;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AcaVisitasForaRotaDAL
{
	private const string INSERT = "uspAcaVisitasForaRotaInsert";

	private const string EXISTS = "uspAcaVisitasForaRotaExists";

	public static void Insert(DbConnection connection, AcaVisitasForaRotaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@dt_visita", instance.DtVisita);
		connection.AddParameters("@hr_visita", instance.HrVisita);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaVisitasForaRotaInsert");
		instance.SeqVisita = int.Parse(obj.ToString());
	}

	public static bool Exists(DbConnection connection, int? SeqVisita, string CdVend, int? CdClien, DateTime? DtVisita, string HrVisita)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_visita", SeqVisita);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@dt_visita", DtVisita);
		connection.AddParameters("@hr_visita", HrVisita);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaVisitasForaRotaExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}
}
