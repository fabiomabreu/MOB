using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class TipoGrupoBLL
{
	public static bool Exists(DbConnection connection, int? id)
	{
		return TipoGrupoDAL.Exists(connection, id);
	}

	public static TipoGrupoTO[] Select(DbConnection connection, int? IdTipoGrupo)
	{
		TipoGrupoTO[] array = TipoGrupoDAL.Select(connection, IdTipoGrupo);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	public static TipoGrupoTO[] Select(DbConnection connection, int? IdTipoGrupo, string Descricao, bool? Ativo)
	{
		TipoGrupoTO[] array = TipoGrupoDAL.Select(connection, IdTipoGrupo, Descricao, Ativo);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}

	internal static void Insert(DbConnection connection, TipoGrupoTO IdTipoGrupo)
	{
		TipoGrupoDAL.Insert(connection, IdTipoGrupo);
	}

	internal static void Update(DbConnection connection, TipoGrupoTO IdTipoGrupo)
	{
		TipoGrupoDAL.Update(connection, IdTipoGrupo);
	}

	internal static void Delete(DbConnection connection, TipoGrupoTO IdTipoGrupo)
	{
		TipoGrupoDAL.Delete(connection, IdTipoGrupo);
	}
}
