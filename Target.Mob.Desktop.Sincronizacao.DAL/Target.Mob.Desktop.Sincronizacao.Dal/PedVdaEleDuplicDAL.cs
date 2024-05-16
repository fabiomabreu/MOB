using System;
using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class PedVdaEleDuplicDAL
{
	private const string INSERT = "uspPedVdaEleDuplicInsert";

	private const string UPDATE = "uspPedVdaEleDuplicUpdate";

	private const string DELETE = "uspPedVdaEleDuplicDelete";

	private const string SELECT = "uspPedVdaEleDuplicSelect";

	private const string EXISTS = "uspPedVdaEleDuplicExists";

	public static void Insert(DbConnection connection, PedVdaEleDuplicTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@dt_ped", instance.DtPed);
		connection.AddParameters("@valor_tot", instance.ValorTot);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspPedVdaEleDuplicInsert");
	}

	public static void Update(DbConnection connection, PedVdaEleDuplicTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@dt_ped", instance.DtPed);
		connection.AddParameters("@valor_tot", instance.ValorTot);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaEleDuplicUpdate");
	}

	public static void Delete(DbConnection connection, PedVdaEleDuplicTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", instance.CdEmpEle);
		connection.AddParameters("@nu_ped_ele", instance.NuPedEle);
		connection.AddParameters("@seq_ped", instance.SeqPed);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPedVdaEleDuplicDelete");
	}

	public static PedVdaEleDuplicTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed)
	{
		return Select(connection, CdEmpEle, NuPedEle, SeqPed, null, null, null, null);
	}

	public static PedVdaEleDuplicTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, int? CdClien, string CdVend, DateTime? DtPed, decimal? ValorTot)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@dt_ped", DtPed);
		connection.AddParameters("@valor_tot", ValorTot);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPedVdaEleDuplicSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdEmpEle, int? NuPedEle, decimal? SeqPed, int? CdClien, string CdVend, DateTime? DtPed, decimal? ValorTot)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp_ele", CdEmpEle);
		connection.AddParameters("@nu_ped_ele", NuPedEle);
		connection.AddParameters("@seq_ped", SeqPed);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@dt_ped", DtPed);
		connection.AddParameters("@valor_tot", ValorTot);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspPedVdaEleDuplicExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static PedVdaEleDuplicTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PedVdaEleDuplicTO pedVdaEleDuplicTO = new PedVdaEleDuplicTO();
				pedVdaEleDuplicTO.CdEmpEle = rs.GetInteger("cd_emp_ele");
				pedVdaEleDuplicTO.NuPedEle = rs.GetDecimal("nu_ped_ele");
				pedVdaEleDuplicTO.SeqPed = rs.GetDecimal("seq_ped");
				pedVdaEleDuplicTO.CdClien = rs.GetInteger("cd_clien");
				pedVdaEleDuplicTO.CdVend = rs.GetString("cd_vend");
				pedVdaEleDuplicTO.DtPed = rs.GetNullableDateTime("dt_ped");
				pedVdaEleDuplicTO.ValorTot = rs.GetDecimal("valor_tot");
				arrayList.Add(pedVdaEleDuplicTO);
			}
		}
		return (PedVdaEleDuplicTO[])arrayList.ToArray(typeof(PedVdaEleDuplicTO));
	}
}
