using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class SeqTxtDAL
{
	private const string UPDATE = "uspSeqTxtUpdate";

	private const string SELECT = "uspSeqTxtSelect";

	public static void Update(DbConnection connection, SeqTxtTO instance)
	{
		connection.ClearParameters();
		connection.AddParameters("@numero", instance.Numero);
		connection.ExecuteNonQuery(CommandType.StoredProcedure, "uspSeqTxtUpdate");
	}

	public static SeqTxtTO[] Select(DbConnection connection)
	{
		connection.ClearParameters();
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspSeqTxtSelect"));
	}

	private static SeqTxtTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				SeqTxtTO seqTxtTO = new SeqTxtTO();
				seqTxtTO.Numero = rs.GetInteger("numero");
				arrayList.Add(seqTxtTO);
			}
		}
		return (SeqTxtTO[])arrayList.ToArray(typeof(SeqTxtTO));
	}
}
