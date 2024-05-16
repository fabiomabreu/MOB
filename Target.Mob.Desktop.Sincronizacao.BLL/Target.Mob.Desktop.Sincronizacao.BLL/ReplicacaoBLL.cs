using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ReplicacaoBLL
{
	public static DataTable EstruturaTabela(DbConnection connection, string tabela)
	{
		return ReplicacaoDAL.EstruturaTabela(connection, tabela);
	}

	public static DataTable InfoTabela(DbConnection connection, string tabela)
	{
		return ReplicacaoDAL.InfoTabela(connection, tabela);
	}

	public static DataTable Dados(DbConnection connection, string tabela)
	{
		return ReplicacaoDAL.Dados(connection, tabela);
	}

	public static DataTable DadosReplicar(DbConnection connection, string tabela, int totalRegistros)
	{
		return ReplicacaoDAL.DadosReplicar(connection, tabela, totalRegistros);
	}

	public static int TotalRegistros(DbConnection connection, string tabela)
	{
		return ReplicacaoDAL.TotalRegistros(connection, tabela);
	}

	public static bool ExecutarScript(DbConnection connection, string script)
	{
		return ReplicacaoDAL.ExecutarScript(connection, script);
	}

	public static bool SalvarTabela(DbConnection connection, DataTable dt)
	{
		return ReplicacaoDAL.SalvarTabela(connection, dt);
	}

	public static void ReplicarDadosTabela(DbConnection connection, string tabela, int idControleTabelaLog)
	{
		ReplicacaoDAL.ReplicarDadosTabela(connection, tabela, idControleTabelaLog);
	}

	public static void ReplicarDadosTabelaLog(DbConnection connection, string servidorOrigem, string bancoOrigem, string tabelaOrigem, string tabelaDestino, string condicaoSelecao)
	{
		ReplicacaoDAL.ReplicarDadosTabelaLog(connection, servidorOrigem, bancoOrigem, tabelaOrigem, tabelaDestino, condicaoSelecao);
	}

	public static byte[] SelectRowId(DbConnection connection, string tabela)
	{
		return ReplicacaoDAL.SelectRowId(connection, tabela);
	}
}
