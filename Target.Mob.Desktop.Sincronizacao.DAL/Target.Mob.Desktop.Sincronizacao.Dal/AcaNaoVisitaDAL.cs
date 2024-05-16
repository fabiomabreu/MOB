using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AcaNaoVisitaDAL
{
	private const string INSERT = "uspAcaNaoVisitaInsert";

	private const string UPDATE = "uspAcaNaoVisitaUpdate";

	private const string DELETE = "uspAcaNaoVisitaDelete";

	private const string SELECT = "uspAcaNaoVisitaSelect";

	private const string EXISTS = "uspAcaNaoVisitaExists";

	private const string COUNT = "uspAcaNaoVisitaCount";

	public static void Insert(DbConnection connection, AcaNaoVisitaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_motivo", instance.CdMotivo);
		connection.AddParameters("@desc_motivo", instance.DescMotivo);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVisitaInsert");
		instance.Seq = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, AcaNaoVisitaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_motivo", instance.CdMotivo);
		connection.AddParameters("@desc_motivo", instance.DescMotivo);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaNaoVisitaUpdate");
	}

	public static void Delete(DbConnection connection, AcaNaoVisitaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaNaoVisitaDelete");
	}

	public static AcaNaoVisitaTO[] Select(DbConnection connection, int? Seq)
	{
		return Select(connection, Seq, null, null, null, null, null, null);
	}

	public static AcaNaoVisitaTO[] Select(DbConnection connection, int? Seq, int? CdClien, string CdMotivo, string DescMotivo, DateTime? Data, string CdVend, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@desc_motivo", DescMotivo);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_texto", CdTexto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAcaNaoVisitaSelect"));
	}

	public static bool Exists(DbConnection connection, int? Seq, int? CdClien, string CdMotivo, string DescMotivo, DateTime? Data, string CdVend, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@desc_motivo", DescMotivo);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_texto", CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVisitaExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, string CdMotivo, DateTime Data)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@data", Data);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVisitaCount"));
	}

	private static AcaNaoVisitaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AcaNaoVisitaTO acaNaoVisitaTO = new AcaNaoVisitaTO();
				acaNaoVisitaTO.Seq = rs.GetInteger("seq");
				acaNaoVisitaTO.CdClien = rs.GetNullableInteger("cd_clien");
				acaNaoVisitaTO.CdMotivo = rs.GetString("cd_motivo");
				acaNaoVisitaTO.DescMotivo = rs.GetString("desc_motivo");
				acaNaoVisitaTO.Data = rs.GetNullableDateTime("data");
				acaNaoVisitaTO.CdVend = rs.GetString("cd_vend");
				acaNaoVisitaTO.CdTexto = rs.GetNullableInteger("cd_texto");
				arrayList.Add(acaNaoVisitaTO);
			}
		}
		return (AcaNaoVisitaTO[])arrayList.ToArray(typeof(AcaNaoVisitaTO));
	}
}
