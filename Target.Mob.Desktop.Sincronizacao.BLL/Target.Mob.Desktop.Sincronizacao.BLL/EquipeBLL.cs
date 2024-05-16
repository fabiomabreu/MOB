using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public class EquipeBLL
{
	public static EquipeTO[] Select(DbConnection connection, string CdEquipe, string Descricao, string CdVendSup, bool? Ativo, string CdGerencia, byte[] RowId, int? CodigoEmpresa)
	{
		EquipeTO[] array = EquipeDAL.Select(connection, CdEquipe, Descricao, CdVendSup, Ativo, CdGerencia, RowId, CodigoEmpresa);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return array;
	}
}
