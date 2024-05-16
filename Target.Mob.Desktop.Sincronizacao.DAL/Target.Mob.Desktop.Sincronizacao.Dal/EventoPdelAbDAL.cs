using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class EventoPdelAbDAL
{
	private const string INSERT = "uspEventoPdelAbInsert";

	private const string UPDATE = "uspEventoPdelAbUpdate";

	private const string DELETE = "uspEventoPdelAbDelete";

	private const string SELECT = "uspEventoPdelAbSelect";

	private const string EXISTS = "uspEventoPdelAbExists";

	public static void Insert(DbConnection connection, EventoPdelAbTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", instance.SeqEvento);
		connection.ExecuteScalar(CommandType.StoredProcedure, "uspEventoPdelAbInsert");
	}

	public static void Update(DbConnection connection, EventoPdelAbTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", instance.SeqEvento);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoPdelAbUpdate");
	}

	public static void Delete(DbConnection connection, EventoPdelAbTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", instance.SeqEvento);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoPdelAbDelete");
	}

	public static EventoPdelAbTO[] Select(DbConnection connection, int? SeqEvento, string CdVend, int? QtdePedidos)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", SeqEvento);
		connection.AddParameters("@cd_vend", CdVend);
		connection.AddParameters("@qtde_pedidos", QtdePedidos);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspEventoPdelAbSelect"));
	}

	public static bool Exists(DbConnection connection, int? SeqEvento)
	{
		connection.ClearParameters();
		connection.AddParameters("@seq_evento", SeqEvento);
		object obj = connection.ExecuteScalar(CommandType.StoredProcedure, "uspEventoPdelAbExists");
		if (obj != null)
		{
			return int.Parse(obj.ToString()) == 1;
		}
		return false;
	}

	private static EventoPdelAbTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				EventoPdelAbTO eventoPdelAbTO = new EventoPdelAbTO();
				eventoPdelAbTO.SeqEvento = rs.GetInteger("seq_evento");
				arrayList.Add(eventoPdelAbTO);
			}
		}
		return (EventoPdelAbTO[])arrayList.ToArray(typeof(EventoPdelAbTO));
	}
}
