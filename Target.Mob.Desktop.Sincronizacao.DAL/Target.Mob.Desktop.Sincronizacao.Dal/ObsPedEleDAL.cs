using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ObsPedEleDAL
{
	private const string INSERT = "uspObsPedEleInsert";

	private const string UPDATE = "uspObsPedEleUpdate";

	private const string DELETE = "uspObsPedEleDelete";

	private const string SELECT = "uspObsPedEleSelect";

	private const string EXISTS = "uspObsPedEleExists";

	public static void Insert(DbConnection connection, ObsPedEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@setor", instance.Setor);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspObsPedEleInsert");
	}

	public static void Update(DbConnection connection, ObsPedEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@seq", instance.Seq);
		connection.AddParameters("@setor", instance.Setor);
		connection.AddParameters("@cd_texto", instance.CdTexto);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspObsPedEleUpdate");
	}

	public static void Delete(DbConnection connection, ObsPedEleTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspObsPedEleDelete");
	}

	public static ObsPedEleTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		return Select(connection, CdEmpEle, NuPedEle, SeqPed, null, null, null);
	}

	public static ObsPedEleTO[] Select(DbConnection connection, int? CdEmpEle, decimal? NuPedEle, decimal? SeqPed, decimal? Seq)
	{
		return Select(connection, CdEmpEle, NuPedEle, SeqPed, Seq, null, null);
	}

	public static ObsPedEleTO[] Select(DbConnection connection, int? CdEmpEle, decimal? NuPedEle, decimal? SeqPed, decimal? Seq, string Setor, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@setor", Setor);
		connection.AddParameters("@cd_texto", CdTexto);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspObsPedEleSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdEmpEle, decimal? NuPedEle, decimal? SeqPed, decimal? Seq, string Setor, int? CdTexto)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@seq", Seq);
		connection.AddParameters("@setor", Setor);
		connection.AddParameters("@cd_texto", CdTexto);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspObsPedEleExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static ObsPedEleTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ObsPedEleTO obsPedEleTO = new ObsPedEleTO();
				obsPedEleTO.CdEmpEle = rs.GetInteger("cd_emp_ele");
				obsPedEleTO.NuPedEle = rs.GetDecimal("nu_ped_ele");
				obsPedEleTO.SeqPed = rs.GetDecimal("seq_ped");
				obsPedEleTO.Seq = rs.GetDecimal("seq");
				obsPedEleTO.Setor = rs.GetString("setor");
				obsPedEleTO.CdTexto = rs.GetNullableInteger("cd_texto");
				arrayList.Add(obsPedEleTO);
			}
		}
		return (ObsPedEleTO[])arrayList.ToArray(typeof(ObsPedEleTO));
	}
}
