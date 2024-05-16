using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public static class ReplicacaoTabelaColunaDAL
{
	private const string SELECT = "uspReplicacaoTabelaColunaSel";

	public static ReplicacaoTabelaColunaTO[] Select(DbConnection connection, int? idReplicacaoTabela, string coluna, bool replicar, byte[] rowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@IdReplicacaoTabela", idReplicacaoTabela);
		connection.AddParameters("@Coluna", coluna);
		connection.AddParameters("@Replicar", replicar);
		connection.AddParameters("@RowId", rowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspReplicacaoTabelaColunaSel"));
	}

	private static ReplicacaoTabelaColunaTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				ReplicacaoTabelaColunaTO replicacaoTabelaColunaTO = new ReplicacaoTabelaColunaTO();
				replicacaoTabelaColunaTO.IdReplicacaoTabelaColuna = rs.GetInteger("IdReplicacaoTabelaColuna");
				replicacaoTabelaColunaTO.ReplicacaoTabela = new ReplicacaoTabelaTO();
				replicacaoTabelaColunaTO.ReplicacaoTabela.IdReplicacaoTabela = rs.GetInteger("IdReplicacaoTabela");
				replicacaoTabelaColunaTO.ReplicacaoTabela.Tabela = rs.GetString("Tabela");
				replicacaoTabelaColunaTO.Coluna = rs.GetString("Coluna");
				replicacaoTabelaColunaTO.Replicar = rs.GetBoolean("Replicar");
				replicacaoTabelaColunaTO.RowId = rs.GetArrayByte("RowId");
				arrayList.Add(replicacaoTabelaColunaTO);
			}
		}
		return (ReplicacaoTabelaColunaTO[])arrayList.ToArray(typeof(ReplicacaoTabelaColunaTO));
	}
}
