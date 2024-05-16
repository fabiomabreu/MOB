using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class CliEmpDAL
{
	private const string INSERT = "uspCliEmpInsert";

	private const string UPDATE = "uspCliEmpUpdate";

	private const string DELETE = "uspCliEmpDelete";

	private const string SELECT = "uspCliEmpSelect";

	private const string SELECTNewCustomer = "uspCliEmpSelectNewCustomer";

	private const string EXISTS = "uspCliEmpExists";

	public static void Insert(DbConnection connection, CliEmpTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_tabela", instance.CdTabela);
		connection.AddParameters("@seq_prom", instance.SeqProm);
		connection.AddParameters("@nu_banco_ve", instance.NuBancoVe);
		connection.AddParameters("@nu_agencia_ve", instance.NuAgenciaVe);
		connection.AddParameters("@nu_conta_ve", instance.NuContaVe);
		connection.AddParameters("@nu_banco_vs", instance.NuBancoVs);
		connection.AddParameters("@nu_agencia_vs", instance.NuAgenciaVs);
		connection.AddParameters("@nu_conta_vs", instance.NuContaVs);
		connection.AddParameters("@vl_lim_ped_pf", instance.VlLimPedPf);
		connection.AddParameters("@prz_medio_max", instance.PrzMedioMax);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliEmpInsert");
	}

	public static void Update(DbConnection connection, CliEmpTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.AddParameters("@cd_tabela", instance.CdTabela);
		connection.AddParameters("@seq_prom", instance.SeqProm);
		connection.AddParameters("@nu_banco_ve", instance.NuBancoVe);
		connection.AddParameters("@nu_agencia_ve", instance.NuAgenciaVe);
		connection.AddParameters("@nu_conta_ve", instance.NuContaVe);
		connection.AddParameters("@nu_banco_vs", instance.NuBancoVs);
		connection.AddParameters("@nu_agencia_vs", instance.NuAgenciaVs);
		connection.AddParameters("@nu_conta_vs", instance.NuContaVs);
		connection.AddParameters("@vl_lim_ped_pf", instance.VlLimPedPf);
		connection.AddParameters("@prz_medio_max", instance.PrzMedioMax);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCliEmpUpdate");
	}

	public static void Delete(DbConnection connection, CliEmpTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_emp", instance.CdEmp);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspCliEmpDelete");
	}

	public static CliEmpTO[] Select(DbConnection connection, int? CdClien)
	{
		return Select(connection, CdClien, null, null, null, null, null, null, null, null, null, null, null);
	}

	public static CliEmpTO[] Select(DbConnection connection, int? CdClien, int? CdEmp)
	{
		return Select(connection, CdClien, CdEmp, null, null, null, null, null, null, null, null, null, null);
	}

	public static CliEmpTO[] Select(DbConnection connection, int? CdClien, int? CdEmp, string CdTabela, int? SeqProm, int? NuBancoVe, string NuAgenciaVe, string NuContaVe, int? NuBancoVs, string NuAgenciaVs, string NuContaVs, decimal? VlLimPedPf, int? PrzMedioMax)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@seq_prom", SeqProm);
		connection.AddParameters("@nu_banco_ve", NuBancoVe);
		connection.AddParameters("@nu_agencia_ve", NuAgenciaVe);
		connection.AddParameters("@nu_conta_ve", NuContaVe);
		connection.AddParameters("@nu_banco_vs", NuBancoVs);
		connection.AddParameters("@nu_agencia_vs", NuAgenciaVs);
		connection.AddParameters("@nu_conta_vs", NuContaVs);
		connection.AddParameters("@vl_lim_ped_pf", VlLimPedPf);
		connection.AddParameters("@prz_medio_max", PrzMedioMax);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCliEmpSelect"));
	}

	public static CliEmpTO[] SelectNewCustomer(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspCliEmpSelectNewCustomer"));
	}

	public static bool Exists(DbConnection connection, int? CdClien, int? CdEmp, string CdTabela, int? SeqProm, int? NuBancoVe, string NuAgenciaVe, string NuContaVe, int? NuBancoVs, string NuAgenciaVs, string NuContaVs, decimal? VlLimPedPf, int? PrzMedioMax)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@seq_prom", SeqProm);
		connection.AddParameters("@nu_banco_ve", NuBancoVe);
		connection.AddParameters("@nu_agencia_ve", NuAgenciaVe);
		connection.AddParameters("@nu_conta_ve", NuContaVe);
		connection.AddParameters("@nu_banco_vs", NuBancoVs);
		connection.AddParameters("@nu_agencia_vs", NuAgenciaVs);
		connection.AddParameters("@nu_conta_vs", NuContaVs);
		connection.AddParameters("@vl_lim_ped_pf", VlLimPedPf);
		connection.AddParameters("@prz_medio_max", PrzMedioMax);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspCliEmpExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static CliEmpTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				CliEmpTO cliEmpTO = new CliEmpTO();
				cliEmpTO.CdClien = rs.GetInteger("cd_clien");
				cliEmpTO.CdEmp = rs.GetInteger("cd_emp");
				cliEmpTO.CdTabela = rs.GetString("cd_tabela");
				cliEmpTO.SeqProm = rs.GetNullableInteger("seq_prom");
				cliEmpTO.NuBancoVe = rs.GetNullableInteger("nu_banco_ve");
				cliEmpTO.NuAgenciaVe = rs.GetString("nu_agencia_ve");
				cliEmpTO.NuContaVe = rs.GetString("nu_conta_ve");
				cliEmpTO.NuBancoVs = rs.GetNullableInteger("nu_banco_vs");
				cliEmpTO.NuAgenciaVs = rs.GetString("nu_agencia_vs");
				cliEmpTO.NuContaVs = rs.GetString("nu_conta_vs");
				cliEmpTO.VlLimPedPf = rs.GetNullableDecimal("vl_lim_ped_pf");
				cliEmpTO.PrzMedioMax = rs.GetNullableInteger("prz_medio_max");
				arrayList.Add(cliEmpTO);
			}
		}
		return (CliEmpTO[])arrayList.ToArray(typeof(CliEmpTO));
	}
}
