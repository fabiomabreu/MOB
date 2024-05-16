using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ReplicacaoTabelaBLL
{
	public static ReplicacaoTabelaTO[] Select(DbConnection connection, string tabela, int? qtdeRegistrosPacote, bool? ativo, bool? replicar, byte[] rowId)
	{
		return ReplicacaoTabelaDAL.Select(connection, tabela, qtdeRegistrosPacote, ativo, replicar, rowId);
	}
}
