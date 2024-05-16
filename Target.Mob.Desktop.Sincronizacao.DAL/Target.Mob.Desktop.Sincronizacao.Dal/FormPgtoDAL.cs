using System.Collections;
using System.Data;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.DAL;

public class FormPgtoDAL
{
	private const string SELECT = "uspFormPgtoSelect";

	public static FormPgtoTO[] Select(DbConnection connection, string FormPgto, string Descricao, bool? Ativo)
	{
		connection.ClearParameters();
		connection.AddParameters("@formpgto", FormPgto);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", null);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspFormPgtoSelect"));
	}

	public static FormPgtoTO[] Select(DbConnection connection, string FormPgto, string Descricao, bool? Ativo, byte[] RowId)
	{
		connection.ClearParameters();
		connection.AddParameters("@formpgto", FormPgto);
		connection.AddParameters("@descricao", Descricao);
		connection.AddParameters("@ativo", Ativo);
		connection.AddParameters("@rowid", RowId);
		return CreateInstances(connection.ExecuteReaderRS(CommandType.StoredProcedure, "uspFormPgtoSelect"));
	}

	private static FormPgtoTO[] CreateInstances(BasicRS rs)
	{
		ArrayList arrayList = new ArrayList();
		using (rs)
		{
			while (rs.MoveNext())
			{
				FormPgtoTO formPgtoTO = new FormPgtoTO();
				formPgtoTO.FormPgto = rs.GetString("formpgto");
				formPgtoTO.Descricao = rs.GetString("descricao");
				formPgtoTO.Ativo = rs.GetBoolean("ativo");
				formPgtoTO.RowId = rs.GetArrayByte("rowid");
				arrayList.Add(formPgtoTO);
			}
		}
		return (FormPgtoTO[])arrayList.ToArray(typeof(FormPgtoTO));
	}
}
