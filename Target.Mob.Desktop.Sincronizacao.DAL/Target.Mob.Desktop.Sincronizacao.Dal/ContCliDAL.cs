using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ContCliDAL
{
	private const string INSERT = "uspContCliInsert";

	private const string UPDATE = "uspContCliUpdate";

	private const string DELETE = "uspContCliDelete";

	private const string DELETE_CLIENTE = "uspContCliDeleteCliente";

	private const string SELECT = "uspContCliSelect";

	public static void Insert(DbConnection connection, ContCliTO instance)
	{
		connection.ClearParameters();
		setParameters(connection, instance);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspContCliInsert");
		instance.Seq = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, ContCliTO instance)
	{
		connection.ClearParameters();
		setParameters(connection, instance);
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspContCliUpdate");
	}

	public static void Delete(DbConnection connection, ContCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@seq", instance.Seq);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspContCliDelete");
	}

	public static void Delete(DbConnection connection, int cdClien)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", cdClien);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspContCliDeleteCliente");
	}

	public static ContCliTO[] Select(DbConnection connection, int? CdClien)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspContCliSelect"));
	}

	private static ContCliTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ContCliTO contCliTO = new ContCliTO();
				contCliTO.CdClien = rs.GetInteger("cd_clien");
				contCliTO.Seq = rs.GetInteger("seq");
				contCliTO.Nome = rs.GetString("nome");
				contCliTO.Cargo = rs.GetString("cargo");
				contCliTO.UltCont = rs.GetNullableInteger("ult_cont");
				contCliTO.Email = rs.GetString("email");
				contCliTO.Ddd = rs.GetNullableShort("ddd");
				contCliTO.TpTel = rs.GetString("tp_tel");
				contCliTO.Fone = rs.GetNullableLong("fone");
				contCliTO.Time = rs.GetString("time");
				contCliTO.Hobby = rs.GetString("hobby");
				contCliTO.Aniversario = rs.GetNullableDateTime("aniversario");
				contCliTO.EmailComercial = rs.GetNullableBoolean("EmailComercial");
				contCliTO.EmailNFe = rs.GetNullableBoolean("EmailNFe");
				contCliTO.EmailFinanceiro = rs.GetNullableBoolean("EmailFinanceiro");
				contCliTO.CargoID = rs.GetNullableInteger("CargoID");
				contCliTO.EnviaWhatsAppEcommerce = rs.GetNullableBoolean("EnviaWhatsAppEcommerce");
				arrayList.Add(contCliTO);
			}
		}
		return (ContCliTO[])arrayList.ToArray(typeof(ContCliTO));
	}

	private static void setParameters(DbConnection connection, ContCliTO instance)
	{
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@nome", instance.Nome);
		connection.AddParameters("@cargo", instance.Cargo);
		connection.AddParameters("@ult_cont", instance.UltCont);
		connection.AddParameters("@email", instance.Email);
		connection.AddParameters("@ddd", instance.Ddd);
		connection.AddParameters("@tp_tel", instance.TpTel);
		connection.AddParameters("@fone", instance.Fone);
		connection.AddParameters("@time", instance.Time);
		connection.AddParameters("@hobby", instance.Hobby);
		connection.AddParameters("@aniversario", instance.Aniversario);
		connection.AddParameters("@EmailComercial", instance.EmailComercial);
		connection.AddParameters("@EmailNFe", instance.EmailNFe);
		connection.AddParameters("@EmailFinanceiro", instance.EmailFinanceiro);
		connection.AddParameters("@CargoID", instance.CargoID);
		connection.AddParameters("@EnviaWhatsAppEcommerce", instance.EnviaWhatsAppEcommerce);
	}
}
