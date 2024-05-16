using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class LocalDAL
{
	private const string SELECT = "uspLocalSelect";

	public static LocalTO[] Select(DbConnection connection, int? CdEmp, string CdLocal, bool? Ativo)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_local", CdLocal);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", null);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspLocalSelect"));
	}

	public static LocalTO[] Select(DbConnection connection, int? CdEmp, string CdLocal, bool? Ativo, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_emp", CdEmp);
		connection.AddParameters("@cd_local", CdLocal);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspLocalSelect"));
	}

	private static LocalTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				LocalTO localTO = new LocalTO();
				localTO.CdEmp = rs.GetInteger("cd_emp");
				localTO.CdLocal = rs.GetString("cd_local");
				localTO.Ativo = rs.GetNullableBoolean("ativo");
				localTO.RowID = rs.GetArrayByte("rowid");
				arrayList.Add(localTO);
			}
		}
		return (LocalTO[])arrayList.ToArray(typeof(LocalTO));
	}
}
