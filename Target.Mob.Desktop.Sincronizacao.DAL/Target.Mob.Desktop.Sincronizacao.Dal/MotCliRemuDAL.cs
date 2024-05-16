using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class MotCliRemuDAL
{
	private const string INSERT = "uspMotCliRemuInsert";

	private const string UPDATE = "uspMotCliRemuUpdate";

	private const string DELETE = "uspMotCliRemuDelete";

	private const string SELECT = "uspMotCliRemuSelect";

	private const string SELECTNewCustomer = "uspMotCliRemuSelectNewCustomer";

	private const string EXISTS = "uspMotCliRemuExists";

	public static void Insert(DbConnection connection, MotCliRemuTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_motor", instance.CdMotor);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@perc_remu", instance.PercRemu);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspMotCliRemuInsert");
	}

	public static void Update(DbConnection connection, MotCliRemuTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_motor", instance.CdMotor);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.AddParameters("@perc_remu", instance.PercRemu);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspMotCliRemuUpdate");
	}

	public static void Delete(DbConnection connection, MotCliRemuTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_motor", instance.CdMotor);
		connection.AddParameters("@cd_clien", instance.CdClien);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspMotCliRemuDelete");
	}

	public static MotCliRemuTO[] Select(DbConnection connection, string CdMotor, int? CdClien, decimal? PercRemu)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_motor", CdMotor);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@perc_remu", PercRemu);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspMotCliRemuSelect"));
	}

	public static MotCliRemuTO[] SelectNewCustomer(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspMotCliRemuSelectNewCustomer"));
	}

	public static bool Exists(DbConnection connection, string CdMotor, int? CdClien, decimal? PercRemu)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_motor", CdMotor);
		connection.AddParameters("@cd_clien", CdClien);
		connection.AddParameters("@perc_remu", PercRemu);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspMotCliRemuExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static MotCliRemuTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				MotCliRemuTO motCliRemuTO = new MotCliRemuTO();
				motCliRemuTO.CdMotor = rs.GetString("cd_motor");
				motCliRemuTO.CdClien = rs.GetInteger("cd_clien");
				motCliRemuTO.PercRemu = rs.GetDecimal("perc_remu");
				arrayList.Add(motCliRemuTO);
			}
		}
		return (MotCliRemuTO[])arrayList.ToArray(typeof(MotCliRemuTO));
	}
}
