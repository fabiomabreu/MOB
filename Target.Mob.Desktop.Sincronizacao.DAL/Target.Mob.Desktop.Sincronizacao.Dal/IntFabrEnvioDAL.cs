using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class IntFabrEnvioDAL
{
	private const string INSERT = "uspIntFabrEnvioInsert";

	private const string UPDATE = "uspIntFabrEnvioUpdate";

	private const string DELETE = "uspIntFabrEnvioDelete";

	private const string SELECT = "uspIntFabrEnvioSelect";

	private const string SELECTNewCustomer = "uspIntFabrEnvioSelectNewCustomer";

	private const string EXISTS = "uspIntFabrEnvioExists";

	public static void Insert(DbConnection connection, IntFabrEnvioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_sistema", instance.CdSistema);
		connection.AddParameters("@tp_cfg", instance.TpCfg);
		connection.AddParameters("@codigo", instance.Codigo);
		connection.AddParameters("@cd_Fabric", instance.CdFabric);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspIntFabrEnvioInsert");
	}

	public static void Update(DbConnection connection, IntFabrEnvioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_sistema", instance.CdSistema);
		connection.AddParameters("@tp_cfg", instance.TpCfg);
		connection.AddParameters("@codigo", instance.Codigo);
		connection.AddParameters("@cd_Fabric", instance.CdFabric);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspIntFabrEnvioUpdate");
	}

	public static void Delete(DbConnection connection, IntFabrEnvioTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_sistema", instance.CdSistema);
		connection.AddParameters("@tp_cfg", instance.TpCfg);
		connection.AddParameters("@codigo", instance.Codigo);
		connection.AddParameters("@cd_Fabric", instance.CdFabric);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspIntFabrEnvioDelete");
	}

	public static IntFabrEnvioTO[] Select(DbConnection connection, string CdSistema, string TpCfg, string Codigo, string CdFabric)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_sistema", CdSistema);
		connection.AddParameters("@tp_cfg", TpCfg);
		connection.AddParameters("@codigo", Codigo);
		connection.AddParameters("@cd_Fabric", CdFabric);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspIntFabrEnvioSelect"));
	}

	public static IntFabrEnvioTO[] SelectNewCustomer(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspIntFabrEnvioSelectNewCustomer"));
	}

	public static bool Exists(DbConnection connection, string CdSistema, string TpCfg, string Codigo, string CdFabric)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_sistema", CdSistema);
		connection.AddParameters("@tp_cfg", TpCfg);
		connection.AddParameters("@codigo", Codigo);
		connection.AddParameters("@cd_Fabric", CdFabric);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspIntFabrEnvioExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static IntFabrEnvioTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				IntFabrEnvioTO intFabrEnvioTO = new IntFabrEnvioTO();
				intFabrEnvioTO.CdSistema = rs.GetString("cd_sistema");
				intFabrEnvioTO.TpCfg = rs.GetString("tp_cfg");
				intFabrEnvioTO.Codigo = rs.GetString("codigo");
				intFabrEnvioTO.CdFabric = rs.GetString("cd_Fabric");
				arrayList.Add(intFabrEnvioTO);
			}
		}
		return (IntFabrEnvioTO[])arrayList.ToArray(typeof(IntFabrEnvioTO));
	}
}
