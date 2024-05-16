using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AcaNaoVendaDAL
{
	private const string INSERT = "uspAcaNaoVendaInsert";

	private const string UPDATE = "uspAcaNaoVendaUpdate";

	private const string DELETE = "uspAcaNaoVendaDelete";

	private const string SELECT = "uspAcaNaoVendaSelect";

	private const string EXISTS = "uspAcaNaoVendaExists";

	private const string COUNT = "uspAcaNaoVendaCount";

	public static void Insert(DbConnection connection, AcaNaoVendaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_motivo", instance.CdMotivo);
		connection.AddParameters("@desc_motivo", instance.DescMotivo);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVendaInsert");
		instance.Seq = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, AcaNaoVendaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_motivo", instance.CdMotivo);
		connection.AddParameters("@desc_motivo", instance.DescMotivo);
		connection.AddParameters("@data", instance.Data);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaNaoVendaUpdate");
	}

	public static void Delete(DbConnection connection, AcaNaoVendaTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaNaoVendaDelete");
	}

	public static AcaNaoVendaTO[] Select(DbConnection connection, int? Seq)
	{
		return Select(connection, Seq, null, null, null, null, null, null);
	}

	public static AcaNaoVendaTO[] Select(DbConnection connection, int? Seq, int? CdClien, string CdMotivo, string DescMotivo, DateTime? Data, string CdVend, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@desc_motivo", DescMotivo);
		connection.AddParameters("@data", Data);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_texto", CdTexto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAcaNaoVendaSelect"));
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
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVendaExists");
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
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVendaCount"));
	}

	private static AcaNaoVendaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AcaNaoVendaTO acaNaoVendaTO = new AcaNaoVendaTO();
				acaNaoVendaTO.Seq = rs.GetInteger("seq");
				acaNaoVendaTO.CdClien = rs.GetNullableInteger("cd_clien");
				acaNaoVendaTO.CdMotivo = rs.GetString("cd_motivo");
				acaNaoVendaTO.DescMotivo = rs.GetString("desc_motivo");
				acaNaoVendaTO.Data = rs.GetNullableDateTime("data");
				acaNaoVendaTO.CdVend = rs.GetString("cd_vend");
				acaNaoVendaTO.CdTexto = rs.GetNullableInteger("cd_texto");
				arrayList.Add(acaNaoVendaTO);
			}
		}
		return (AcaNaoVendaTO[])arrayList.ToArray(typeof(AcaNaoVendaTO));
	}
}
