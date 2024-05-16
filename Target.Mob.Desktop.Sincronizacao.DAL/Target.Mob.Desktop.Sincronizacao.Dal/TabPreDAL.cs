using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class TabPreDAL
{
	private const string SELECT = "uspTabPreSelect";

	public static TabPreTO[] Select(DbConnection connection, string CdTabela, string Descricao, bool? Ativo)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", null);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTabPreSelect"));
	}

	public static TabPreTO[] Select(DbConnection connection, string CdTabela, string Descricao, bool? Ativo, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@cd_tabela", CdTabela);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspTabPreSelect"));
	}

	private static TabPreTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				TabPreTO tabPreTO = new TabPreTO();
				tabPreTO.CdTabela = rs.GetString("cd_tabela");
				tabPreTO.Descricao = rs.GetString("descricao");
				tabPreTO.Ativo = rs.GetBoolean("ativo");
				tabPreTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(tabPreTO);
			}
		}
		return (TabPreTO[])arrayList.ToArray(typeof(TabPreTO));
	}
}
