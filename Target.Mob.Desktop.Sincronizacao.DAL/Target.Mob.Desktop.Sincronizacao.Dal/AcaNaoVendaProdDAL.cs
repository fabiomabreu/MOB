using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class AcaNaoVendaProdDAL
{
	private const string INSERT = "uspAcaNaoVendaProdInsert";

	private const string UPDATE = "uspAcaNaoVendaProdUpdate";

	private const string DELETE = "uspAcaNaoVendaProdDelete";

	private const string SELECT = "uspAcaNaoVendaProdSelect";

	private const string EXISTS = "uspAcaNaoVendaProdExists";

	private const string COUNT = "uspAcaNaoVendaProdCount";

	public static void Insert(DbConnection connection, AcaNaoVendaProdTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_prod", instance.CdProd);
		connection.AddParameters("@cd_motivo", instance.CdMotivo);
		connection.AddParameters("@desc_motivo", instance.DescMotivo);
		connection.AddParameters("@data", instance.Data);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVendaProdInsert");
		instance.Seq = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, AcaNaoVendaProdTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_prod", instance.CdProd);
		connection.AddParameters("@cd_motivo", instance.CdMotivo);
		connection.AddParameters("@desc_motivo", instance.DescMotivo);
		connection.AddParameters("@data", instance.Data);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaNaoVendaProdUpdate");
	}

	public static void Delete(DbConnection connection, AcaNaoVendaProdTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspAcaNaoVendaProdDelete");
	}

	public static AcaNaoVendaProdTO[] Select(DbConnection connection, int? Seq)
	{
		return Select(connection, Seq, null, null, null, null, null, null);
	}

	public static AcaNaoVendaProdTO[] Select(DbConnection connection, int? Seq, string CdVend, int? CdClien, int? CdProd, string CdMotivo, string DescMotivo, DateTime? Data)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@desc_motivo", DescMotivo);
		connection.AddParameters("@data", Data);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspAcaNaoVendaProdSelect"));
	}

	public static bool Exists(DbConnection connection, int? Seq, string CdVend, int? CdClien, int? CdProd, string CdMotivo, string DescMotivo, DateTime? Data)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@desc_motivo", DescMotivo);
		connection.AddParameters("@data", Data);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVendaProdExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	public static int Count(DbConnection connection, string CdVend, int CdClien, int CdProd, string CdMotivo, DateTime Data)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_prod", CdProd);
		connection.AddParameters("@cd_motivo", CdMotivo);
		connection.AddParameters("@data", Data);
		return Convert.ToInt32(connection.ExecuteScalar(CommandType.StoredProcedure, "uspAcaNaoVendaProdCount"));
	}

	private static AcaNaoVendaProdTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				AcaNaoVendaProdTO acaNaoVendaProdTO = new AcaNaoVendaProdTO();
				acaNaoVendaProdTO.Seq = rs.GetInteger("seq");
				acaNaoVendaProdTO.CdVend = rs.GetString("cd_vend");
				acaNaoVendaProdTO.CdClien = rs.GetInteger("cd_clien");
				acaNaoVendaProdTO.CdProd = rs.GetInteger("cd_prod");
				acaNaoVendaProdTO.CdMotivo = rs.GetString("cd_motivo");
				acaNaoVendaProdTO.DescMotivo = rs.GetString("desc_motivo");
				acaNaoVendaProdTO.Data = rs.GetDateTime("data");
				arrayList.Add(acaNaoVendaProdTO);
			}
		}
		return (AcaNaoVendaProdTO[])arrayList.ToArray(typeof(AcaNaoVendaProdTO));
	}
}
