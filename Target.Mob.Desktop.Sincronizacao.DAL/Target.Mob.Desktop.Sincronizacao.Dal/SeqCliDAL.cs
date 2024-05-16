using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class SeqCliDAL
{
	private const string UPDATE = "uspSeqCliUpdate";

	private const string SELECT = "uspSeqCliSelect";

	public static void Update(DbConnection connection, SeqCliTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@numero", instance.Numero);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspSeqCliUpdate");
	}

	public static SeqCliTO[] Select(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspSeqCliSelect"));
	}

	private static SeqCliTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				SeqCliTO seqCliTO = new SeqCliTO();
				seqCliTO.Numero = rs.GetInteger("numero");
				arrayList.Add(seqCliTO);
			}
		}
		return (SeqCliTO[])arrayList.ToArray(typeof(SeqCliTO));
	}
}
