using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class VendCliDAL
{
	private const string INSERT = "uspVendCliInsert";

	private const string UPDATE = "uspVendCliUpdate";

	private const string DELETE = "uspVendCliDelete";

	private const string SELECT = "uspVendCliSelect";

	private const string EXISTS = "uspVendCliExists";

	public static void Insert(DbConnection connection, VendCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@prioritario", instance.Prioritario);
		connection.AddParameters("@vl_limite_verba", instance.VlLimiteVerba);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspVendCliInsert");
	}

	public static void Update(DbConnection connection, VendCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.AddParameters("@prioritario", instance.Prioritario);
		connection.AddParameters("@vl_limite_verba", instance.VlLimiteVerba);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspVendCliUpdate");
	}

	public static void Delete(DbConnection connection, VendCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@cd_vend", instance.CdVend);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspVendCliDelete");
	}

	public static VendCliTO[] Select(DbConnection connection, int? CdClien, string CdVend, bool? Prioritario, float? VlLimiteVerba)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@prioritario", Prioritario);
		connection.AddParameters("@vl_limite_verba", VlLimiteVerba);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspVendCliSelect"));
	}

	public static bool Exists(DbConnection connection, int? CdClien, string CdVend, bool? Prioritario, float? VlLimiteVerba)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@prioritario", Prioritario);
		connection.AddParameters("@vl_limite_verba", VlLimiteVerba);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspVendCliExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static VendCliTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				VendCliTO vendCliTO = new VendCliTO();
				vendCliTO.CdClien = rs.GetInteger("cd_clien");
				vendCliTO.CdVend = rs.GetString("cd_vend");
				vendCliTO.Prioritario = rs.GetBoolean("prioritario");
				vendCliTO.VlLimiteVerba = rs.GetDecimal("vl_limite_verba");
				arrayList.Add(vendCliTO);
			}
		}
		return (VendCliTO[])arrayList.ToArray(typeof(VendCliTO));
	}
}
