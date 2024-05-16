using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ReplicacaoTabelaColunaBLL
{
	public static ReplicacaoTabelaColunaTO[] Select(DbConnection connection, int? idReplicacaoTabela, string coluna, bool replicar, byte[] rowId)
	{
		return ReplicacaoTabelaColunaDAL.Select(connection, idReplicacaoTabela, coluna, replicar, rowId);
	}
}
