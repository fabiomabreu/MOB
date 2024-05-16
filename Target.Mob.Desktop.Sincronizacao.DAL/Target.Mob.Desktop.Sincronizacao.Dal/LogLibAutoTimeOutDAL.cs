using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class LogLibAutoTimeOutDAL
{
	private const string INSERT = "uspLogLibAutoTimeOutInsert";

	private const string UPDATE = "uspLogLibAutoTimeOutUpdate";

	private const string DELETE = "uspLogLibAutoTimeOutDelete";

	private const string SELECT = "uspLogLibAutoTimeOutSelect";

	public static void Insert(DbConnection connection, LogLibAutoTimeOutTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdEmpEle", instance.CdEmpEle);
		connection.AddParameters("@NuPedEle", instance.NuPedEle);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspLogLibAutoTimeOutInsert");
		instance.IdLog = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, LogLibAutoTimeOutTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdLog", instance.IdLog);
		connection.AddParameters("@CdEmpEle", instance.CdEmpEle);
		connection.AddParameters("@NuPedEle", instance.NuPedEle);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLogLibAutoTimeOutUpdate");
	}

	public static void Delete(DbConnection connection, LogLibAutoTimeOutTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdLog", instance.IdLog);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspLogLibAutoTimeOutDelete");
	}

	public static LogLibAutoTimeOutTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle)
	{
		return Select(connection, null, CdEmpEle, NuPedEle);
	}

	public static LogLibAutoTimeOutTO[] Select(DbConnection connection, int? IdLog)
	{
		return Select(connection, IdLog, null, null);
	}

	public static LogLibAutoTimeOutTO[] Select(DbConnection connection, int? IdLog, int? CdEmpEle, int? NuPedEle)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdLog", IdLog);
		connection.AddParameters("@CdEmpEle", CdEmpEle);
		connection.AddParameters("@NuPedEle", NuPedEle);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspLogLibAutoTimeOutSelect"));
	}

	private static LogLibAutoTimeOutTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				LogLibAutoTimeOutTO logLibAutoTimeOutTO = new LogLibAutoTimeOutTO();
				logLibAutoTimeOutTO.IdLog = rs.GetInteger("SeqLogLibAutoTimeOut");
				logLibAutoTimeOutTO.CdEmpEle = rs.GetInteger("CdEmpEle");
				logLibAutoTimeOutTO.NuPedEle = rs.GetInteger("NuPedEle");
				logLibAutoTimeOutTO.DtLogIdLog = rs.GetDateTime("SeqPed");
				arrayList.Add(logLibAutoTimeOutTO);
			}
		}
		return (LogLibAutoTimeOutTO[])arrayList.ToArray(typeof(LogLibAutoTimeOutTO));
	}
}
