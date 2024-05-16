using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class SeqTxtLogDAL
{
	private const string UPDATE = "uspSeqTxtLogUpdate";

	private const string SELECT = "uspSeqTxtLogSelect";

	public static void Update(DbConnection connection, SeqTxtLogTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@numero", instance.Numero);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspSeqTxtLogUpdate");
	}

	public static SeqTxtLogTO[] Select(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspSeqTxtLogSelect"));
	}

	private static SeqTxtLogTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				SeqTxtLogTO seqTxtLogTO = new SeqTxtLogTO();
				seqTxtLogTO.Numero = rs.GetInteger("numero");
				arrayList.Add(seqTxtLogTO);
			}
		}
		return (SeqTxtLogTO[])arrayList.ToArray(typeof(SeqTxtLogTO));
	}
}
