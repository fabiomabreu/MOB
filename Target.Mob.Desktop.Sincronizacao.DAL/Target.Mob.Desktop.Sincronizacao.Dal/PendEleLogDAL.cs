using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class PendEleLogDAL
{
	private const string INSERT = "uspPendEleLogInsert";

	private const string UPDATE = "uspPendEleLogUpdate";

	private const string DELETE = "uspPendEleLogDelete";

	private const string SELECT = "uspPendEleLogSelect";

	private const string EXISTS = "uspPendEleLogExists";

	public static void Insert(DbConnection connection, PendEleLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@CdEmpEle", instance.CdEmpEle);
		connection.AddParameters("@NuPedEle", instance.NuPedEle);
		connection.AddParameters("@SeqPed", instance.SeqPed);
		connection.AddParameters("@NuTentativasLib", instance.NuTentativasLib);
		connection.AddParameters("@Processando", instance.Processando);
		connection.AddParameters("@IdProc", instance.IdProc);
		connection.AddParameters("@Falha", instance.Falha);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspPendEleLogInsert");
		instance.SeqPendEleLog = int.Parse(obj.ToString());
	}

	public static void Update(DbConnection connection, PendEleLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@SeqPendEleLog", instance.SeqPendEleLog);
		connection.AddParameters("@CdEmpEle", instance.CdEmpEle);
		connection.AddParameters("@NuPedEle", instance.NuPedEle);
		connection.AddParameters("@SeqPed", instance.SeqPed);
		connection.AddParameters("@NuTentativasLib", instance.NuTentativasLib);
		connection.AddParameters("@Processando", instance.Processando);
		connection.AddParameters("@IdProc", instance.IdProc);
		connection.AddParameters("@Falha", instance.Falha);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPendEleLogUpdate");
	}

	public static void Delete(DbConnection connection, PendEleLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@SeqPendEleLog", instance.SeqPendEleLog);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspPendEleLogDelete");
	}

	public static PendEleLogTO[] Select(DbConnection connection, int? CdEmpEle, int? NuPedEle, int? SeqPed)
	{
		return Select(connection, null, CdEmpEle, NuPedEle, SeqPed, null, null, null, null);
	}

	public static PendEleLogTO[] Select(DbConnection connection, int? SeqPendEleLog)
	{
		return Select(connection, SeqPendEleLog, null, null, null, null, null, null, null);
	}

	public static PendEleLogTO[] Select(DbConnection connection, bool Processando, bool Falha)
	{
		return Select(connection, null, null, null, null, null, Processando, null, Falha);
	}

	public static PendEleLogTO[] Select(DbConnection connection, int? SeqPendEleLog, int? CdEmpEle, int? NuPedEle, int? SeqPed, int? NuTentativasLib, bool? Processando, int? IdProc, bool? Falha)
	{
		connection.ClearParameters();
		connection.AddParameters("@SeqPendEleLog", SeqPendEleLog);
		connection.AddParameters("@CdEmpEle", CdEmpEle);
		connection.AddParameters("@NuPedEle", NuPedEle);
		connection.AddParameters("@SeqPed", SeqPed);
		connection.AddParameters("@NuTentativasLib", NuTentativasLib);
		connection.AddParameters("@Processando", Processando);
		connection.AddParameters("@IdProc", IdProc);
		connection.AddParameters("@Falha", Falha);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspPendEleLogSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqPendEleLog, int? CdEmpEle, int? NuPedEle, int? SeqPed, int? NuTentativasLib, bool? Processando, int? IdProc, bool? Falha)
	{
		connection.ClearParameters();
		connection.AddParameters("@SeqPendEleLog", SeqPendEleLog);
		connection.AddParameters("@CdEmpEle", CdEmpEle);
		connection.AddParameters("@NuPedEle", NuPedEle);
		connection.AddParameters("@SeqPed", SeqPed);
		connection.AddParameters("@NuTentativasLib", NuTentativasLib);
		connection.AddParameters("@Processando", Processando);
		connection.AddParameters("@IdProc", IdProc);
		connection.AddParameters("@Falha", Falha);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspPendEleLogExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static PendEleLogTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				PendEleLogTO pendEleLogTO = new PendEleLogTO();
				pendEleLogTO.SeqPendEleLog = rs.GetInteger("SeqPendEleLog");
				pendEleLogTO.CdEmpEle = rs.GetInteger("CdEmpEle");
				pendEleLogTO.NuPedEle = rs.GetInteger("NuPedEle");
				pendEleLogTO.SeqPed = rs.GetInteger("SeqPed");
				pendEleLogTO.NuTentativasLib = rs.GetNullableInteger("NuTentativasLib");
				pendEleLogTO.Processando = rs.GetBoolean("Processando");
				pendEleLogTO.IdProc = rs.GetNullableInteger("IdProc");
				pendEleLogTO.Falha = rs.GetBoolean("Falha");
				arrayList.Add(pendEleLogTO);
			}
		}
		return (PendEleLogTO[])arrayList.ToArray(typeof(PendEleLogTO));
	}
}
