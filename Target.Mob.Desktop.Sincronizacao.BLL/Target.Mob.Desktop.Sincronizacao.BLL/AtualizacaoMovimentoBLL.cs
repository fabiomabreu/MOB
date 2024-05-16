using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class AtualizacaoMovimentoBLL
{
	public static AtualizacaoMovimentoTO[] Select(DbConnection connection, int ID, string Tabela)
	{
		AtualizacaoMovimentoTO[] array = AtualizacaoMovimentoDAL.Select(connection, ID, Tabela);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static void Insert(DbConnection connection, AtualizacaoMovimentoTO atualizacaoMovimento)
	{
		AtualizacaoMovimentoDAL.Insert(connection, atualizacaoMovimento);
	}

	public static bool Exists(DbConnection connection, AtualizacaoMovimentoTO atualizacaoMovimento)
	{
		return AtualizacaoMovimentoDAL.Exists(connection, atualizacaoMovimento.Tabela);
	}

	public static void Update(DbConnection connection, AtualizacaoMovimentoTO atualizacaoMovimento)
	{
		AtualizacaoMovimentoDAL.Update(connection, atualizacaoMovimento);
	}
}
