using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ReplicacaoTabelaDAL
{
	private const string SELECT = "uspReplicacaoTabelaSel";

	public static ReplicacaoTabelaTO[] Select(DbConnection connection, string tabela, int? qtdeRegistrosPacote, bool? ativo, bool? replicar, byte[] rowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@Tabela", tabela);
		connection.AddParameters("@QtdeRegistrosPacote", qtdeRegistrosPacote);
		connection.AddParameters("@Ativo", ativo);
		connection.AddParameters("@Replicar", replicar);
		connection.AddParameters("@CondicaoSelecao", null);
		connection.AddParameters("@RowId", rowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspReplicacaoTabelaSel"));
	}

	private static ReplicacaoTabelaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ReplicacaoTabelaTO replicacaoTabelaTO = new ReplicacaoTabelaTO();
				replicacaoTabelaTO.IdReplicacaoTabela = rs.GetInteger("IdReplicacaoTabela");
				replicacaoTabelaTO.Tabela = rs.GetString("Tabela");
				replicacaoTabelaTO.QtdeRegistrosPacote = rs.GetInteger("QtdeRegistrosPacote");
				replicacaoTabelaTO.Ativo = rs.GetBoolean("Ativo");
				replicacaoTabelaTO.Replicar = rs.GetBoolean("Replicar");
				replicacaoTabelaTO.CondicaoSelecao = rs.GetString("CondicaoSelecao");
				replicacaoTabelaTO.RowId = rs.GetArrayByte("RowId");
				arrayList.Add(replicacaoTabelaTO);
			}
		}
		return (ReplicacaoTabelaTO[])arrayList.ToArray(typeof(ReplicacaoTabelaTO));
	}
}
