using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class FormPgtoBLL
{
	public static FormPgtoTO[] Select(DbConnection connection, string FormPgto, string Descricao, bool? Ativo)
	{
		FormPgtoTO[] array = FormPgtoDAL.Select(connection, FormPgto, Descricao, Ativo);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static FormPgtoTO[] Select(DbConnection connection, string FormPgto, string Descricao, bool? Ativo, byte[] RowId)
	{
		FormPgtoTO[] array = FormPgtoDAL.Select(connection, FormPgto, Descricao, Ativo, RowId);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
