using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class PagamentoBLL
{
	public static void Insert(DbConnection connection, PagamentoTO Pagamento)
	{
		PagamentoDAL.Insert(connection, Pagamento);
	}

	public static bool Exists(DbConnection connection, PagamentoTO Pagamento)
	{
		return PagamentoDAL.Exists(connection, Pagamento.CdClien, Pagamento.DataPgto, Pagamento.TpPgto, Pagamento.ValorPgto, Pagamento.CdVend);
	}
}
